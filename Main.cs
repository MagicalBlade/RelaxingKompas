using KompasAPI7;
using Kompas6API5;
using Kompas6Constants;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using RelaxingKompas.Data;
using RelaxingKompas.Properties;
using System.Text.RegularExpressions;
using RelaxingKompas.Classes;
using RelaxingKompas.Windows;
using RelaxingKompas.Utils;
using System.Globalization;
using System.Linq;

namespace RelaxingKompas
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Main
    {
        [DllImport("User32.dll", EntryPoint = "UnhookWindowsHookEx", SetLastError = true)]
        private static extern byte UnhookWindowsHookEx(IntPtr hHook);

        private KompasObject _kompas;
        public KompasObject kompas { get => _kompas; set => _kompas = value; }

        public IApplication Application { get => _application; set => _application = value; }

        private IApplication _application;



        private ksDocument2D _activedocument2D;
        public ksDocument2D activedocument2D { get => _activedocument2D; set => _activedocument2D = value; }

        #region Данные формы
        private FormWeightAndSize _windowWeightAndSize = new FormWeightAndSize();
        public FormWeightAndSize WindowWeightAndSize { get => _windowWeightAndSize; set => _windowWeightAndSize = value; }

        public FormLibrarySettings WindowLibrarySettings { get => _windowLibrarySettings; set => _windowLibrarySettings = value; }

        private FormLibrarySettings _windowLibrarySettings = new FormLibrarySettings();

        public System.Windows.Forms.IWin32Window Win32 { get => _win32; set => _win32 = value; }

        private System.Windows.Forms.IWin32Window _win32;
        #endregion

        public List<string> setToleranceHistory = new List<string>();

        // Имя библиотеки
        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetLibraryName()
        {
            return "Работать весело";
        }

        [return: MarshalAs(UnmanagedType.BStr)]

        #region Формируем меню команд
        public string ExternalMenuItem(short number, ref short itemType, ref short command)
        {
            string result = string.Empty;
            itemType = 1; // "MENUITEM"
            switch (number)
            {
                case 1:
                    result = "Сохранить контур";
                    command = 1;
                    break;
                case 2:
                    result = "Скопировать таблицу";
                    command = 2;
                    break;
                case 3:
                    result = "Вставить таблицу";
                    command = 3;
                    break;
                case 4:
                    result = "Посчитать массу";
                    command = 4;
                    break;
                case 5:
                    result = "Скопировать текст из элемента";
                    command = 5;
                    break;
                case 6:
                    result = "Скрыть/показать разрыв вида";
                    command = 6;
                    break;
                case 7:
                    result = "";
                    command = 7;
                    break;
                case 8:
                    result = "Вставить точки по координатам из файла";
                    command = 8;
                    break;
                case 9:
                    result = "Шероховатость";
                    command = 9;
                    break;
                case 10:
                    result = "Настройки";
                    command = 10;
                    break;
                case 11:
                    result = "Копирование данных из штампа";
                    command = 11;
                    break;
                case 12:
                    result = "Простановка допусков/припусков";
                    command = 12;
                    break;
                case 13:
                    result = "Замена макроэлемента";
                    command = 12;
                    break;
                case 14:
                    result = "Запись шага отверстий и т.п.";
                    command = 12;
                    break;
                case 15:
                    command = -1;
                    itemType = 13; // "ENDMENU"
                    break;
            }
            return result;
        }

        #endregion

        #region Команды

        #region Копирование геометрии со стилем линии "основная" в новый документ типа "фрагмент" и сохранение его в формате "dxf"

        private void SaveContour()
        {
            activedocument2D = (ksDocument2D)kompas.ActiveDocument2D();
            IKompasDocument2D1 activekompasDocument2D1 = (IKompasDocument2D1)Application.ActiveDocument;
            ksDocumentParam activedocumentParam = (ksDocumentParam)kompas.GetParamStruct(35);
            activedocument2D.ksGetObjParam(activedocument2D.reference, activedocumentParam, -1); //Получаем параметры активного окна
            string namefile = activedocumentParam.fileName;
            if (namefile == "")
            {
                kompas.ksMessage("Изначальный чертеж не сохранен. Нет возможности получить имя.");
                return;
            }
            string namedxf = namefile.Substring(0, namefile.Length - 3);


            //Создаем временную группу
            int copygroup = activedocument2D.ksNewGroup(1);
            activedocument2D.ksEndGroup();


            ksIterator iterator = kompas.GetIterator();
            int itemobject;
            int[] itemobjects = new int[] //Перечисляем элементы которые нужно перенести в новый документ
			{
                1, //линия
                2, //окружность
                3, //дуга окруж­ности
                8, //кривая Безье
                26, //контур
                31, //лома­ная ли­ния
                32, //эллипс
                33, //кривая NURBS
                34, //дуга эл­липса
                35, //прямо­уголь­ник
                36, //пра­виль­ный многоу­гольник
                37, //эквиди­станта
                55, //объект волни­стая ли­ния
                72, //муль­тили­ния
            };
            foreach (var item in itemobjects)
            {
                iterator.ksCreateIterator(item, 0);
                while ((itemobject = iterator.ksMoveIterator("N")) != 0)
                {
                    if (activedocument2D.ksGetObjectStyle(itemobject) == 1) //Проверяем стиль линии. Если основная то добавляем в группу
                    {
                        activedocument2D.ksAddObjGroup(copygroup, itemobject);
                    }

                }
            }
            activedocument2D.ksWriteGroupToClip(copygroup, true); //Копируем группу в буфер обмена

            #region Создаем новый документ типа "фрагмент"
            ksDocument2D document2D = (ksDocument2D)kompas.Document2D();
            ksDocumentParam documentParam = (ksDocumentParam)kompas.GetParamStruct(35);
            documentParam.type = 3;
            document2D.ksCreateDocument(documentParam);
            #endregion

            ksDocument2D newactivedocument2D = (ksDocument2D)kompas.ActiveDocument2D();
            int pastegroup = newactivedocument2D.ksReadGroupFromClip(); //Считываем буфер обмена во временную группу
            if (pastegroup == 0)
            {
                kompas.ksMessage("Не получилось вставить элементы");
                newactivedocument2D.ksCloseDocument();
                return;
            }

            #region Получаем координаты нижней левой точки "габаритного прямоугольника" группы элементов
            ksRectParam rectParam = kompas.GetParamStruct((short)StructType2DEnum.ko_RectParam);
            document2D.ksGetObjGabaritRect(pastegroup, rectParam);
            ksMathPointParam mathPointParam = rectParam.GetpBot();
            #endregion

            newactivedocument2D.ksMoveObj(pastegroup, -mathPointParam.x, -mathPointParam.y); //Перемещаем группу в начало координат
            newactivedocument2D.ksStoreTmpGroup(pastegroup); //Вставляем временную группу в новый чертеж
            
            //Сохраняем файл в форматах
            if (WindowLibrarySettings.cb_SaveDxf.Checked)
            {
                CheckFile("dxf");
                newactivedocument2D.ksSaveToDXF($"{namedxf}dxf");
            }
            if (WindowLibrarySettings.cb_SaveFragment.Checked)
            {
                CheckFile("frw");
                #region Переносим переменную толщина во фрагмент
                IVariable7 variable = activekompasDocument2D1.Variable[false, "t"];
                IKompasDocument2D1 newactivedocument2D1 = (IKompasDocument2D1)Application.ActiveDocument;
                if (variable != null)
                {
                    IVariable7 variable7 = newactivedocument2D1.AddVariable("t", Convert.ToDouble(variable.Expression), "Толщина");
                    variable7.External = true;
                }
                newactivedocument2D.ksSaveDocument($"{namedxf}frw"); 
                #endregion
            }


            if (WindowLibrarySettings.cb_CloseFragment.Checked) newactivedocument2D.ksCloseDocument();
            if (WindowLibrarySettings.cb_CloseDrawing.Checked) activedocument2D.ksCloseDocument();
            
            
            ///<summary> Проверка на возможность пересохранения файла ///</summary>
            void CheckFile(string TypeFile)
            {
                if (File.Exists($"{namedxf}{TypeFile}"))
                {
                    try
                    {
                        using (FileStream stream = File.Open($"{namedxf}{TypeFile}", FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            stream.Close();
                        }
                    }
                    catch (IOException)
                    {

                        kompas.ksMessage($"Не получается сохранить {TypeFile}. Проверьте доступ к файлу. Возможно он открыт в другой программе.");
                        return;
                    }
                }
            }
        }
        #endregion


        /// <summary>
        /// Копирование данных из таблицы в буфер обмена, в формате эксель.
        /// </summary>
        private void CopyTable()
        {
            IApplication application = kompas.ksGetApplication7();
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)application.ActiveDocument;
            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            object selecobjects =  selectionManager.SelectedObjects;
            if (selecobjects == null)
            {
                application.MessageBoxEx("Не выбрана таблица", "Ошибка", 0);
                return;
            }
            if (selecobjects.GetType().Name == "Object[]")
            {
                application.MessageBoxEx("Выбрано элементов. Выберите одну таблицу.", "Ошибка", 0);
                return;
            }
            IKompasAPIObject kompasAPIObject = (IKompasAPIObject)selecobjects;
            if (kompasAPIObject.Type != KompasAPIObjectTypeEnum.ksObjectDrawingTable)
            {
                application.MessageBoxEx("Выбрана не таблица.", "Ошибка", 0);
                return;
            }
            ITable table = (ITable)selecobjects;
            #region Оформляем таблицу для буфера обмена
            string plainText = ""; //Таблица для текстового формата
            string copytable = "<table>"; //Таблица для html формата
            for (int rows = 0; rows < table.RowsCount; rows++)
            {
                copytable += "<tr>\n";
                for (int colum = 0; colum < table.ColumnsCount; colum++)
                {
                    ITableCell tableCell = table.Cell[rows, colum];
                    IText text = (IText)tableCell.Text;
                    copytable += $"<td>{text.Str}</td>";
                    plainText += text.Str + "\t";
                }
                copytable += "</tr>\n";
                plainText += "\n";
            }
            copytable += "</table>";
            #endregion

            Excel.CopyToExcel(plainText, copytable);
        }

        /// <summary>
        /// Вставка в таблицу данных из эксель.
        /// </summary>
        private void InsertTable()
        {
            IApplication application = kompas.ksGetApplication7();
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)application.ActiveDocument;
            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            IKompasAPIObject selecobjects = selectionManager.SelectedObjects;

            if (selecobjects == null)
            {
                application.MessageBoxEx("Не выбрана таблица", "Ошибка", 0);
                return;
            }
            if (selecobjects.Type != KompasAPIObjectTypeEnum.ksObjectDrawingTable)
            {
                application.MessageBoxEx("Выбрана не таблица, либо несколько таблиц", "Ошибка", 0);
                return;
            }
            ITable table = (ITable)selecobjects;
            IDrawingTable drawingTable = (IDrawingTable)table;

            string clipboardString = Clipboard.GetText().Trim();
            int rowsnumber = table.RowsCount - 1;
            foreach (string rows in clipboardString.Split('\n'))
            {
                int columnumber = 0;
                if (rowsnumber == table.RowsCount)
                {
                    table.AddRow(table.RowsCount - 1, true);
                }
                foreach (string colum in rows.Split('\t'))
                {
                    if (columnumber == table.ColumnsCount) //Проверка на количество колонок, если не хватает - добавляем
                    {
                        table.AddColumn(columnumber - 1, true);
                    }
                    ITableCell tableCell = table.Cell[table.RowsCount - 1, columnumber];
                    IText text = (IText)tableCell.Text;
                    text.Str = colum.Trim();
                    columnumber++;
                }
                rowsnumber++;
            }
            drawingTable.Update(); //Применяем изменения
        }

        /// <summary>
        /// Получение габаритов детали. Расчет массы детали и запись ее в штамп. Копирование данных в эксель.
        /// </summary>
        private void WeightAndSize()
        {
            IApplication application = kompas.ksGetApplication7();
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)application.ActiveDocument;
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)application.ActiveDocument;
            IKompasDocument kompasDocument = (IKompasDocument)application.ActiveDocument;
            DataWeightAndSize.Application = application;
            DataWeightAndSize.KompasDocument = kompasDocument;
            DataWeightAndSize.FormWeightAndSize = WindowWeightAndSize;
            DataWeightAndSize.WindowLibrarySettings = WindowLibrarySettings;
            WindowWeightAndSize.tb_thickness.Text = "";
            DataWeightAndSize.Thickness = 0;
            WindowWeightAndSize.tb_steel.Text = "";
            WindowWeightAndSize.tb_weight.Text = "";


            #region Получаем данные из штампа
            const string pattern = "[^\\d\\.,-]";
            string postext = DataWeightAndSize.GetCellStamp(2); //Ячейка позиции
            postext = Regex.Replace(postext, pattern, "");
            postext = postext.Trim('.');
            WindowWeightAndSize.tb_pos.Text = postext;
            WindowWeightAndSize.tb_sheet.Text = DataWeightAndSize.GetCellStamp(16001); //Ячейки номера листа

            string stampid3 = DataWeightAndSize.GetCellStamp(3);//Ячейка с толщиной, материалом и т.д.
            if (stampid3 != "")
            {
                string[] profile = stampid3.Split("$dsm; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (profile.Length > 4)
                {
                    WindowWeightAndSize.tb_thickness.Text = profile[1];
                    WindowWeightAndSize.tb_steel.Text = profile[4];
                }
            }
            #endregion

            ksDocument2D ksdocument2D = kompas.ActiveDocument2D();

            kompas.ksSetCriticalProcess();

            ksInertiaParam ksinertiaParam = kompas.GetParamStruct(83); //Параметры МЦХ
            int group = ksdocument2D.ksViewGetObjectArea(); //Контур площади
            if (group == 0)
            {
                return;
            }
            ksMathematic2D mathematic2D = kompas.GetMathematic2D();
            mathematic2D.ksCalcInertiaProperties(group, ksinertiaParam, 0x1);

            #region Получение габаритного прямоугольника
            ksRectParam rectParam = kompas.GetParamStruct(15); //Параметры прямоугольника
            ksdocument2D.ksGetObjGabaritRect(group, rectParam); //Получение габаритного прямоугольника фигуры, полученной через площадь

            ksMathPointParam LeftMathPointParam = rectParam.GetpBot(); //Левая нижняя точка прямоугольника
            ksMathPointParam RightMathPointParam = rectParam.GetpTop(); //Правая верхняя точка прямоугольника
            double LeftX; double LeftY;
            double RightX; double RightY;
            //Пересчет координат точек из системы координат(СК) листа в СК вида.
            ksdocument2D.ksSheetToView(LeftMathPointParam.x, LeftMathPointParam.y, out LeftX, out LeftY);
            ksdocument2D.ksSheetToView(RightMathPointParam.x, RightMathPointParam.y, out RightX, out RightY);
            double width = Math.Abs(Math.Round(RightY - LeftY, MidpointRounding.AwayFromZero));
            double length = Math.Abs(Math.Round(RightX - LeftX, MidpointRounding.AwayFromZero));
            #endregion

            #region Поиск обозначения маркировки в области контура и запись значения в ячейку позиции
            dynamic insideContur = kompasDocument2D1.SelectObjects(ksRegionTypeEnum.ksRTCutFrame, LeftX, LeftY, RightX, RightY);
            if (insideContur is object[] selected)
            {
                List<IMarkLeader> insideConturMarkLeader = new List<IMarkLeader>();
                foreach (var item in insideContur)
                {
                    if (item is IMarkLeader)
                    {
                        insideConturMarkLeader.Add(item);
                    }
                }
                if (insideConturMarkLeader.Count == 1)
                {
                    WindowWeightAndSize.tb_pos.Text = insideConturMarkLeader[0].Designation.Str;
                }
            }
            else if (insideContur is IMarkLeader insideConturMarkLeader)
            {
                WindowWeightAndSize.tb_pos.Text = insideConturMarkLeader.Designation.Str;
            }
            #endregion
            
            //Заполнение толщины и стали из таблицы. Это для чертежей подсборок/стыковки
            DataWeightAndSize.SetThicknessandSteel();

            ILibraryManager libraryManager = Application.LibraryManager;
            string pathlibrary = $"{Path.GetDirectoryName(libraryManager.CurrentLibrary.PathName)}"; //Получить путь к папаке библиотеки
            string pathToleranceAuto = $"{pathlibrary}\\Resources\\Steel.txt";
            if (File.Exists(pathToleranceAuto))
            {
                using (StreamReader sr = File.OpenText(pathToleranceAuto))
                {
                    WindowWeightAndSize.lb_steel.Items.Clear();
                    while (!sr.EndOfStream)
                    {
                        WindowWeightAndSize.lb_steel.Items.Add(sr.ReadLine());
                    }
                }
            }

            if (width < length)
            {
                WindowWeightAndSize.tb_width.Text = $"{width}"; //Передаем ширину в форму
                WindowWeightAndSize.tb_length.Text = $"{length}"; //Передаем длину в форму
            }
            else
            {
                WindowWeightAndSize.tb_width.Text = $"{length}"; //Передаем ширину в форму
                WindowWeightAndSize.tb_length.Text = $"{width}"; //Передаем длину в форму
            }

            WindowWeightAndSize.tb_yardage.Text = $"{Math.Round(ksinertiaParam.F)}"; //Передаем площадь в форму
            WindowWeightAndSize.Weight(); //Вызываю вычисление массы
            ksdocument2D.ksWriteGroupToClip(group, true); //Копируем группу в буфер обмена
            
            Win32 = NativeWindow.FromHandle((IntPtr)kompas.ksGetHWindow()); //Получаю окно компаса по дескриптору
            WindowWeightAndSize.Show(Win32); //Показываю окно дочерним к компасу
        }

        /// <summary>
        /// Копирование текста из элементов модели
        /// </summary>
        private void CopyText()
        {
            List<string> copytext = new List<string>();
            
            IKompasDocument kompasDocument = Application.ActiveDocument;
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)(kompasDocument);
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();

            document2DAPI5.ksUndoContainer(true);
            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            object selectObject = selectionManager.SelectedObjects;
            if (selectObject == null)
            {
                Application.MessageBoxEx("Выберите элемент!", "Внимание", 64);
                return;
            }
            if (selectObject is object[] selectObjects)
            {
                foreach (var selectObjectItem in selectObjects)
                {
                    if (selectObjectItem is IDrawingObject)
                    {
                        string gettextresult = GetText((IDrawingObject)selectObjectItem);
                        if (gettextresult != "") copytext.Add(gettextresult);
                    }
                }
            }
            if (selectObject is IDrawingObject drawingObject)
            {
                string gettextresult = GetText(drawingObject);
                if(gettextresult != "") copytext.Add(gettextresult);
            }
            document2DAPI5.ksUndoContainer(false);
            if (copytext.Count != 0)
            {

                Excel.CopyToExcel(string.Join("\r\n", copytext), $"<table><tr><td>{string.Join("</td></tr><tr><td>", copytext)}</td></tr></table>");
                Application.MessageBoxEx("Скопировано.", "Готово.", 64);
            }
            else
            {
                Application.MessageBoxEx("Не получилось скопировать.", "Ошибка.", 64);
            }

            string GetText(IDrawingObject drawingObject1)
            {
                switch (drawingObject1.Type)
                {
                    case KompasAPIObjectTypeEnum.ksObjectDrawingText: // Текст на чертеже
                        {
                            return ((IText)drawingObject1).Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectLeader: // Линия выноска
                        {
                            string leaderresult = "";
                            ILeader leader = (ILeader)drawingObject1;
                            if (leader.TextOnShelf.Str != "") leaderresult += leader.TextOnShelf.Str;
                            if (leader.TextUnderShelf.Str != "") leaderresult += $" {leader.TextUnderShelf.Str}";
                            if (leader.TextOnBranch.Str != "") leaderresult += $" {leader.TextOnBranch.Str}";
                            if (leader.TextUnderBranch.Str != "") leaderresult += $" {leader.TextUnderBranch.Str}";
                            if (leader.TextAfterShelf.Str != "") leaderresult += $" {leader.TextAfterShelf.Str}";
                            return leaderresult.Trim();
                        }
                    case KompasAPIObjectTypeEnum.ksObjectMarkLeader: // Обозначения маркироваки - позиция
                        {
                            IMarkLeader markLeader = (IMarkLeader)drawingObject1;
                            return markLeader.Designation.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectPositionLeader: // Обозначение позиции - мы не используем
                        {
                            IPositionLeader positionLeader = (IPositionLeader)drawingObject1;
                            return positionLeader.Positions.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectCutLine: // Линия разреза машиностроения
                        {
                            ICutLine cutLine = (ICutLine)drawingObject1;
                            return cutLine.Text.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectBuildingCutLine: // Линия разреза строительная
                        {
                            ICutLine cutLine = (ICutLine)drawingObject1;
                            return cutLine.Text.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectUnitMarking: // Обозначение узла - узел
                        {
                            IUnitMarking unitMarking = (IUnitMarking)drawingObject1;
                            return $"{unitMarking.TextUp.Str} {unitMarking.TextDown.Str}".Trim();
                        }
                    case KompasAPIObjectTypeEnum.ksObjectRemoteElement: // Выносной элемент - узел
                        {
                            IRemoteElement remoteElement = (IRemoteElement)drawingObject1;
                            return $"{remoteElement.TextUp.Str} {remoteElement.AdditionalText.Str}".Trim();
                        }
                    #region Размеры
                    case KompasAPIObjectTypeEnum.ksObjectAngleDimension: // Угловой размер
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str.Replace("@1~", "°");
                        }
                    case KompasAPIObjectTypeEnum.ksObjectArcDimension: // Размер дуги окружности
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectBreakLineDimension: // Линейрый размер с обрывом
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectDiametralDimension: // Диаметральный размер
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectHeightDimension: // Размер высоты
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectLineDimension: // Линейный размер
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectRadialDimension: // Радиальный размер
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    case KompasAPIObjectTypeEnum.ksObjectBreakRadialDimension: // Редиальный размер с изломом
                        {
                            IDimensionText dimensionText = (IDimensionText)drawingObject1;
                            return dimensionText.NominalText.Str;
                        }
                    #endregion
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// Расставить условные обозначения отверстий
        /// </summary>
        private void PlaceSymbolHole()
        {
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();
            if (kompas.ksYesNo("Заменить окружности на условные обозначения отверстий?") != 1) return;
            Dictionary<double, List<ICircle>> circleList = new Dictionary<double, List<ICircle>>(); //Хранение диаметров окружностей и их координат
            string lostHole = $"Нет условных обозначение для следующих диаметров:{Environment.NewLine}";
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)Application.ActiveDocument;
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)kompasDocument2D;
            IKompasDocument1 kompasDocument1 = (IKompasDocument1)kompasDocument2D;
            ILibraryManager libraryManager = Application.LibraryManager;
            string pathlibrary = $"{Path.GetDirectoryName(libraryManager.CurrentLibrary.PathName)}"; //Получить путь к папаке библиотеки
            document2DAPI5.ksUndoContainer(true);
            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            dynamic selected = selectionManager.SelectedObjects;
            List<object> selectedObjects = new List<object>();
            if (selected == null) //Если не выбраны объекты чертежа поиск окружностей по всему виду
            {
                IViewsAndLayersManager viewsAndLayersManager = kompasDocument2D.ViewsAndLayersManager;
                IViews views = viewsAndLayersManager.Views;
                IView view = views.ActiveView;
                //Заполняем словарь
                IDrawingContainer drawingContainer = (IDrawingContainer)view;
                foreach (ICircle circle in drawingContainer.Circles)
                {
                    if (circleList.ContainsKey(circle.Radius * 2))
                    {
                        circleList[circle.Radius * 2].Add(circle);
                    }
                    else
                    {
                        circleList.Add(circle.Radius * 2, new List<ICircle> { circle });
                    }
                }
            }
            else if (selected is object[]) //Если выбраны объекты чертежа поиск окружностей по выбранным объектам
            {
                selectedObjects.AddRange(selected);
                //Заполняем словарь
                foreach (object item in selectedObjects)
                {
                    if (item is ICircle circle)
                    {
                        if (circleList.ContainsKey(circle.Radius * 2))
                        {
                            circleList[circle.Radius * 2].Add(circle);
                        }
                        else
                        {
                            circleList.Add(circle.Radius * 2, new List<ICircle> { circle });
                        }
                    }
                }
            }
            else //Если выбран только один объект чертежа
            {
                selectedObjects.Add(selected);
                //Заполняем словарь
                foreach (object item in selectedObjects)
                {
                    if (item is ICircle circle)
                    {
                        if (circleList.ContainsKey(circle.Radius * 2))
                        {
                            circleList[circle.Radius * 2].Add(circle);
                        }
                        else
                        {
                            circleList.Add(circle.Radius * 2, new List<ICircle> { circle });
                        }
                    }
                }
            }
            foreach (var diameter in circleList.Keys)
            {
                string pathHole = $@"{pathlibrary}\Hole\D{diameter}.frw";
                //Проверка наличия файла с условным обозначением
                if (!File.Exists($"{pathHole}"))
                {
                    lostHole += $"ø{diameter}: {circleList[diameter].Count}шт.{Environment.NewLine}";
                    continue;
                }
                IDrawingGroups drawingGroups = kompasDocument2D1.DrawingGroups;
                IDrawingGroup drawingGroup = drawingGroups.Add(true, $"D{diameter}");
                drawingGroup.ReadFragment(pathHole,true,0,0,1,0,true);
                IMacroObject macro = drawingGroup.Objects[27];
                macro.Name = $"D{diameter}";
                drawingGroup.Store();

                ICopyObjectParam copyObjectParam = (ICopyObjectParam)kompasDocument1.GetInterface(KompasAPIObjectTypeEnum.ksObjectCopyObjectParam);
                copyObjectParam.XOld = 0;
                copyObjectParam.YOld = 0;
                //Копируем условное обозначание в центры нужных отверстий
                foreach (var circle in circleList[diameter])
                {
                    copyObjectParam.XNew = circle.Xc;
                    copyObjectParam.YNew = circle.Yc;
                    kompasDocument2D1.CopyObjects(drawingGroup, copyObjectParam);
                    kompasDocument1.Delete(circle);
                }
                drawingGroup.Delete();
            }
            document2DAPI5.ksUndoContainer(false);
            if (lostHole != $"Нет условных обозначение для следующих диаметров:{Environment.NewLine}")
            {
                MessageBox.Show($"{lostHole}");
            }
        }

        /// <summary>
        /// Убрать илипоказать разрыв вида
        /// </summary>
        private void BreakView()
        {
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)Application.ActiveDocument;
            IViewsAndLayersManager viewsAndLayersManager = kompasDocument2D.ViewsAndLayersManager;
            IViews views = viewsAndLayersManager.Views;
            IView view = views.ActiveView;
            IBreakViewParam breakViewParam = (IBreakViewParam)view;
            if (breakViewParam.BreaksCount == 0)
            {
                return;
            }
            if (breakViewParam.BreaksVisible == false)
            {
                breakViewParam.BreaksVisible = true;
            }
            else
            {
                breakViewParam.BreaksVisible = false;
            }
            view.Update();
        }

        /// <summary>
        /// Вставить точки по координатам из текстового файла
        /// </summary>
        private void InsertPointXY()
        {
            string log = "";
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.DefaultExt = "txt";
            dialog.Filter = "Text files (*.txt)|*.txt";
            string resultDialog = "";
            string openText = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                resultDialog = dialog.FileName;
            }
            if (!File.Exists(resultDialog))
            {
                return;
            }
            try
            {
                using (StreamReader reader = new StreamReader(resultDialog, System.Text.Encoding.UTF8))
                {
                    openText = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}");
                return;
            }
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)Application.ActiveDocument;
            IViewsAndLayersManager viewsAndLayersManager = kompasDocument2D.ViewsAndLayersManager;
            Document2D document2D = kompas.ActiveDocument2D();
            IViews views = viewsAndLayersManager.Views;
            IView view = views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;
            ISymbols2DContainer symbols2DContainer = (ISymbols2DContainer)view;
            ILeaders leaders = symbols2DContainer.Leaders;
            IPoints points = drawingContainer.Points;
            document2D.ksUndoContainer(true);
            foreach (string line in openText.Split(new string[] { "\r\n", "\r", "\n" },StringSplitOptions.None))
            {
                string[] colums = line.Split(new string[] { "\t", " "}, 3, StringSplitOptions.None);
                if (colums.Length > 1)
                {
                    IPoint point = points.Add();
                    try
                    {
                        point.X = double.Parse(colums[0]);
                        point.Y = double.Parse(colums[1]);
                        point.Style = 4; //Квадратная точка
                        point.Update();
                    }
                    catch (Exception)
                    {
                        point.Delete();
                        log += $"{line}\n";
                        continue;
                    }
                    if (colums.Length > 2)
                    {
                        IBaseLeader baseLeader = leaders.Add(DrawingObjectTypeEnum.ksDrLeader);
                        baseLeader.ArrowType = ksArrowEnum.ksPoint;
                        ILeader leader = (ILeader)baseLeader;
                        IText text = leader.TextOnShelf;
                        text.Str += colums[2];
                        IBranchs branchs = (IBranchs)baseLeader;
                        branchs.X0 = point.X + 10 / view.Scale;
                        branchs.Y0 = point.Y + 10 / view.Scale;
                        branchs.AddBranchByPoint(1, point.X, point.Y);
                        baseLeader.Update();
                    }
                }
            }
            document2D.ksUndoContainer(false);
            /*
            if (log != "")
            {
                kompas.ksMessage($"Проверьте правильность записи чисел координат. Не удалось расставить точки:\n{log} ");
            }
            */
        }

        /// <summary>
        /// Вставить шероховатость в зависимости от категории кромок и толщины детали
        /// </summary>
        private void InsertRough()
        {
            ILibraryManager libraryManager = Application.LibraryManager;
            string pathlibrary = $"{Path.GetDirectoryName(libraryManager.CurrentLibrary.PathName)}"; //Получить путь к папаке библиотеки
            Sto_012 sto_012_2018 = null;
            Sto_012 sto_012_2007 = null;
            try
            {
                sto_012_2007 = JsonUtils.Deserialize<Sto_012>($"{pathlibrary}\\Resources\\CTO-ГК «Трансстрой»-012-2007.json");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в файле - CTO-ГК «Трансстрой»-012-2007.json. Загружены значения по умолчанию");
            }
            try
            {
                sto_012_2018 = JsonUtils.Deserialize<Sto_012>($"{pathlibrary}\\Resources\\CTO-ГК «Трансстрой»-012-2018.json");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в файле - CTO-ГК «Трансстрой»-012-2018.json. Загружены значения по умолчанию");
            }

            //Создаю СТО
            if (sto_012_2018 == null)
            {
                sto_012_2018 = new Sto_012
                (
                new int[][]
                    {
                        new int[] { 2, 12, 50 },
                        new int[] { 14, 30, 60 },
                        new int[] { 32, 60, 70 }
                    },
                new int[][]
                    {
                        new int[] { 2, 12, 50 },
                        new int[] { 14, 30, 60 },
                        new int[] { 32, 60, 70 }
                    },
                new int[][]
                    {
                        new int[] { 2, 12, 50 },
                        new int[] { 14, 30, 60 },
                        new int[] { 32, 60, 70 }
                    }
                );
                try
                {
                    JsonUtils.Serialize($"{pathlibrary}\\Resources\\CTO-ГК «Трансстрой»-012-2018.json", sto_012_2018);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалос сохранить файл CTO-ГК «Трансстрой»-012-2018.json. Обратитесь к администратору");
                }
            }
            if (sto_012_2007 == null)
            {
                sto_012_2007 = new Sto_012
                (
                new int[][]
                    {
                        new int[] { 2, 12, 50 },
                        new int[] { 14, 30, 80 },
                        new int[] { 32, 60, 160 }
                    },
                new int[][]
                    {
                        new int[] { 2, 12, 80 },
                        new int[] { 14, 30, 160 },
                        new int[] { 32, 60, 320 }
                    },
                new int[][]
                    {
                        new int[] { 2, 12, 160 },
                        new int[] { 14, 30, 320 },
                        new int[] { 32, 60, 320 }
                    }
                );
                try
                {
                    JsonUtils.Serialize($"{pathlibrary}\\Resources\\CTO-ГК «Трансстрой»-012-2007.json", sto_012_2007);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалос сохранить файл CTO-ГК «Трансстрой»-012-2007.json. Обратитесь к администратору");
                }
            }


            IDrawingDocument kompasDocument = (IDrawingDocument)Application.ActiveDocument;
            ILayoutSheets layoutSheets = kompasDocument.LayoutSheets;
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            IStamp stamp = layoutSheet.Stamp;
            IText text3 = stamp.Text[3];
            string text3Str = text3.Str;
            string thickness = "";
            if (text3Str != "")
            {
                string[] profile = text3Str.Split("$dsm; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (profile.Length > 4)
                {
                    thickness = profile[1];
                }
            }

            RougForm roughWindow = new RougForm();
            roughWindow.tb_thickness.Text = thickness;
            roughWindow.rb_Sto_2018.Checked = Settings.Default.rb_Sto_2018;
            roughWindow.rb_Sto_2007.Checked = Settings.Default.rb_Sto_2007;
            roughWindow.ShowDialog();
            if (roughWindow.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            Settings.Default.rb_Sto_2018 = roughWindow.rb_Sto_2018.Checked;
            Settings.Default.rb_Sto_2007 = roughWindow.rb_Sto_2007.Checked;
            Settings.Default.Save();
            int thicknessInt;
            try
            {
                thicknessInt = int.Parse(roughWindow.tb_thickness.Text);
            }
            catch (Exception)
            {
                kompas.ksMessage("Ошибка в написании толщины");
                return;
            }

            int roug = 0;
            if (roughWindow.rb_Sto_2018.Checked)
            {
                roug = sto_012_2018.GetRough(roughWindow.RoughKat, thicknessInt);
                if (roug == 0)
                {
                    kompas.ksMessage("Не найдена указанная толщина");
                }
            }
            else
            {
                roug = sto_012_2007.GetRough(roughWindow.RoughKat, thicknessInt);
                if (roug == 0)
                {
                    kompas.ksMessage("Не найдена указанная толщина");
                }
            }
            ISpecRough specRough = kompasDocument.SpecRough;
            if (specRough != null)
            {
                specRough.Text = $"Rz {roug}";
                specRough.AddSign = false;
                specRough.SignType = ksRoughSignEnum.ksNoProcessingType;
                specRough.Distance = 2;
                specRough.Update();
            }


        }

        /// <summary>
        /// Настройки библиотеки
        /// </summary>
        private void LibrarySettings()
        {
            Win32 = NativeWindow.FromHandle((IntPtr)kompas.ksGetHWindow()); //Получаю окно компаса по дескриптору
            WindowLibrarySettings.ShowDialog(Win32);
        }

        /// <summary>
        /// Копирование данных из штампа: нименование, масса, номер листа
        /// </summary>
        private void CopyDataFromStamp()
        {
            DataWeightAndSize.KompasDocument = Application.ActiveDocument;
            string plainText = $"{DataWeightAndSize.GetCellStamp(2)}\t{DataWeightAndSize.GetCellStamp(5)}\t{DataWeightAndSize.GetCellStamp(16001)}";
            string htmlText = $"<table><tr><td>{DataWeightAndSize.GetCellStamp(2)}</td><td>{DataWeightAndSize.GetCellStamp(5)}<td>{DataWeightAndSize.GetCellStamp(16001)}</td>" +
                $"</tr></table>";
            Excel.CopyToExcel(plainText, htmlText);
        }

        /// <summary>
        /// Простановка допусков на размеры
        /// </summary>
        private void SetTolerance()
        {
            ILibraryManager libraryManager = Application.LibraryManager;
            string pathlibrary = $"{Path.GetDirectoryName(libraryManager.CurrentLibrary.PathName)}"; //Получить путь к папке библиотеки
            string pathToleranceAuto = $"{pathlibrary}\\Resources\\ToleranceAuto.txt";
            string pathToleranceDefault = $"{pathlibrary}\\Resources\\ToleranceDefault.txt";
            List<double[]> toleranceAuto = new List<double[]>();
            List<string> toleranceDefault= new List<string>();

            if (File.Exists(pathToleranceAuto))
            {
                using (StreamReader sr = File.OpenText(pathToleranceAuto))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] temp = sr.ReadLine().Split(' ');
                        try
                        {
                            toleranceAuto.Add(
                            new double[]
                            {
                                double.Parse(temp[0], CultureInfo.DefaultThreadCurrentCulture),
                                double.Parse(temp[1], CultureInfo.DefaultThreadCurrentCulture),
                                double.Parse(temp[2], CultureInfo.DefaultThreadCurrentCulture),
                            });
                        }
                        catch (Exception)
                        {
                            Application.MessageBoxEx("В файле с допусками ошибка в числах.", "Ошибка", 64);
                        }
                    }
                }
            }

            if (File.Exists(pathToleranceDefault))
            {
                using (StreamReader sr = File.OpenText(pathToleranceDefault))
                {
                    while (!sr.EndOfStream)
                    {
                        toleranceDefault.Add(sr.ReadLine());
                    }
                }
            }

            IKompasDocument kompasDocument = Application.ActiveDocument;
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)(kompasDocument);
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();
           
            document2DAPI5.ksUndoContainer(true);

            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            dynamic selectedobjects = selectionManager.SelectedObjects;
            if (selectedobjects == null) return;
            FormTolerance formTolerance = new FormTolerance();
            formTolerance.lb_tolerance_default.Items.AddRange(toleranceDefault.ToArray());
            formTolerance.lb_history.Items.AddRange(setToleranceHistory.ToArray());
            if (selectedobjects is object)
            {
                if (selectedobjects is IDimensionText dimensionText)
                {
                    //Подставляю в форму данные допусков из выбранного размера
                    formTolerance.tb_Up.Text = dimensionText.HighDeviation.Str;
                    formTolerance.tb_Down.Text = dimensionText.LowDeviation.Str;
                    formTolerance.ShowDialog();
                    if (formTolerance.DialogResult == DialogResult.Cancel)
                    {
                        if (formTolerance.historyisclear) setToleranceHistory.Clear();
                        return;
                    }
                    SetDimensionText(dimensionText, formTolerance.autotolerance);
                }
            }

            if (selectedobjects is object[] objects)
            {
                formTolerance.ShowDialog();
                if (formTolerance.DialogResult == DialogResult.Cancel)
                {
                    if (formTolerance.historyisclear) setToleranceHistory.Clear();
                    return;
                }
                foreach (var item in objects)
                {
                    if (item is IDimensionText dimensionText)
                    {
                        SetDimensionText(dimensionText, formTolerance.autotolerance);
                    }
                }
            }
            if (formTolerance.historyisclear) setToleranceHistory.Clear();
            if (setToleranceHistory.IndexOf($"{formTolerance.tb_Up.Text}/{formTolerance.tb_Down.Text}") == -1 
                && !formTolerance.autotolerance && !formTolerance.historyisclear && !formTolerance.toleranceclear
                && !formTolerance.tolerancedefault && (formTolerance.tb_Up.Text != "" || formTolerance.tb_Down.Text != ""))
            {
                setToleranceHistory.Add($"{formTolerance.tb_Up.Text}/{formTolerance.tb_Down.Text}");
            }

            document2DAPI5.ksUndoContainer(false);

            //Метод простановки допусков/припусков
            void SetDimensionText(IDimensionText dimensionText, bool auto)
            {
                dimensionText.HasTolerance = true;
                //Если выбрана очистка допуска
                if (formTolerance.toleranceclear)
                {
                    dimensionText.HighDeviation.Str = $"";
                    dimensionText.LowDeviation.Str = $"";
                    dimensionText.DeviationOn = false;
                    dimensionText.TextAlign = ksDimensionTextAlignEnum.ksDimACentre;
                    ((IDrawingObject)dimensionText).Update();
                    return;
                }
                //Если выбрана автоматическая простановка допуска
                if (auto)
                {
                    foreach (var item in toleranceAuto)
                    {
                        if (item.Length != 3) continue;
                        if (dimensionText.NominalValue >= item[1] && dimensionText.NominalValue < item[2])
                        {
                            dimensionText.HighDeviation.Str = $"+{item[0]}";
                            dimensionText.LowDeviation.Str = $"-{item[0]}";
                            dimensionText.DeviationOn = true;
                            dimensionText.TextAlign = ksDimensionTextAlignEnum.ksDimACentre;
                            ((IDrawingObject)dimensionText).Update();
                            return;
                        }
                    }
                    Application.MessageBoxEx("Не удалось автоматически проставить допуски. Проверьте файл с допусками.", "Ошибка", 64);
                }
                else if (formTolerance.tb_Up.Text != "" || formTolerance.tb_Down.Text != "")
                {
                    dimensionText.HighDeviation.Str = formTolerance.tb_Up.Text;
                    dimensionText.LowDeviation.Str= formTolerance.tb_Down.Text;
                    dimensionText.DeviationOn = true;
                    dimensionText.TextAlign = ksDimensionTextAlignEnum.ksDimACentre;
                    ((IDrawingObject)dimensionText).Update();
                }
            }
        }
        
        /// <summary>
        /// Запись шага отверстий и т.п. типа 10х80=800
        /// </summary>
        private void StepDimension()
        {
            IKompasDocument kompasDocument = Application.ActiveDocument;
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)(kompasDocument);
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();

            document2DAPI5.ksUndoContainer(true);
            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            if (selectionManager.SelectedObjects is object[] selected)
            {
                if (selected.Length > 2)
                {
                    Application.MessageBoxEx("Выбрано больше двух элементов", "Ошибка", 64);
                    return;
                }
            }
            else
            {
                Application.MessageBoxEx("Выберите два размер", "Ошибка", 64);
                return;
            }
            IDimensionText dimensionText1;
            IDimensionText dimensionText2;
            if (selected[0] is IDimensionText && selected[1] is IDimensionText)
                {
                    dimensionText1 = (IDimensionText)selected[0];
                    dimensionText2 = (IDimensionText)selected[1];
                }
            else
            {
                Application.MessageBoxEx("Выберите два размер", "Ошибка", 64);
                return;
            }

            if (dimensionText1.NominalValue > dimensionText2.NominalValue)
            {
                if ((Math.Round(dimensionText1.NominalValue) / Math.Round(dimensionText2.NominalValue)) % 1 != 0)
                {
                    Application.MessageBoxEx("Не верный шаг", "Ошибка", 64);
                    return;
                }
                dimensionText1.Prefix.Str = $"{Math.Round(dimensionText1.NominalValue / dimensionText2.NominalValue)}х{Math.Round(dimensionText2.NominalValue)}=";
                ((ILineDimension)dimensionText1).Update();
            }
            else
            {
                if ((Math.Round(dimensionText2.NominalValue) / Math.Round(dimensionText1.NominalValue)) % 1 != 0)
                {
                    Application.MessageBoxEx("Не верный шаг", "Ошибка", 64);
                    return;
                }
                dimensionText2.Prefix.Str = $"{Math.Round(dimensionText2.NominalValue / dimensionText1.NominalValue)}х{Math.Round(dimensionText1.NominalValue)}=";
                ((ILineDimension)dimensionText2).Update();
            }
            Application.MessageBoxEx("Шаги записаны", "Готово", 64);

            document2DAPI5.ksUndoContainer(false);
        }

        /// <summary>
        /// Посчитать количество отверстий которые представленые в виде макроэлементов
        /// </summary>
        private void CountHoles()
        {
            double tolerance = 1; //Допуск 1мм
            bool overlayyError = false;
            bool severalCentersError = false;
            IKompasDocument kompasDocument = Application.ActiveDocument;
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)(kompasDocument);
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)(kompasDocument);
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();

            document2DAPI5.ksUndoContainer(true);

            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            if (!(selectionManager.SelectedObjects is object[] selectobject))
            {
                Application.MessageBoxEx("Выберите несколько макроэлементов.", "Ошибка", 64);
                return;
            }
            selectionManager.UnselectAll();
            List<double[]> coordinats = new List<double[]>();
            List<IDiametralDimension> diametralDimensions = new List<IDiametralDimension>();
            foreach (IKompasAPIObject kompasObject in selectobject.Cast<IKompasAPIObject>())
            {
                if (kompasObject is IMacroObject macroobject)
                {
                    if (!(macroobject is ISymbols2DContainer symbols2DContainer)) continue;
                    ICentreMarkers centreMarkers = symbols2DContainer.CentreMarkers;
                    if (centreMarkers.Count == 0) continue;
                    macroobject.GetPlacement(out double macroX, out double macroY, out double a, out bool mir);
                    if (centreMarkers.Count != 1)
                    {
                        if (macroobject.Parent is IView view)
                        {
                            ILayers layers = view.Layers;
                            ILayer activLayer = layers[0] as ILayer;
                            ILayer layer = null;
                            foreach (ILayer item in layers)
                            {
                                if (item.Name == "Несколько обозначений центров отверстий") layer = item;
                            }
                            if (layer == null) layer = layers.Add();
                            layer.Name = "Несколько обозначений центров отверстий";
                            layer.Color = 255;
                            layer.Update();
                            macroobject.LayerNumber = layer.LayerNumber;
                            macroobject.Update();
                            activLayer.Current = true;
                            activLayer.Update();
                            severalCentersError = true;
                        }
                        continue;
                    }
                    ICentreMarker centreMarker = centreMarkers[0] as ICentreMarker;
                    double centrX = centreMarker.X;
                    double centrY = centreMarker.Y;
                    macroobject.TransformPointToView(ref centrX, ref centrY);
                    bool isExists = false;
                    foreach (double[] coordinat in coordinats)
                    {
                        if (Math.Abs(coordinat[0] - centrX) < tolerance && Math.Abs(coordinat[1] - centrY) < tolerance)
                        {
                            isExists = true;
                        }
                    }
                    if (isExists)
                    {
                        if (macroobject.Parent is IView view)
                        {
                            ILayers layers = view.Layers;
                            ILayer activLayer = layers[0] as ILayer;
                            ILayer layer = null;
                            foreach (ILayer item in layers)
                            {
                                if(item.Name == "Наложение отверстий") layer = item;
                            }
                            if(layer == null) layer = layers.Add();
                            layer.Name = "Наложение отверстий";
                            layer.Color = 255;
                            layer.Update();
                            macroobject.LayerNumber = layer.LayerNumber;
                            macroobject.Update();
                            activLayer.Current = true;
                            activLayer.Update();
                            overlayyError = true;
                        }
                    }
                    else
                    {
                        selectionManager.Select(macroobject);
                        coordinats.Add(new double[] { centrX, centrY });
                    }
                }

                if (kompasObject is IDiametralDimension diametralDimension)
                {
                    diametralDimensions.Add(diametralDimension);
                }
            }

            if (overlayyError) MessageBox.Show("Ошибка. Есть наложение отверстий. Они вынесены в отдельный слой, проверьте. Эти макроэлементы не учтены в количестве отверстий.");
            if (severalCentersError) MessageBox.Show("Ошибка. Есть макроэлементы в которых несколько обозначений центров отверстий." +
                " Эти макроэлементы не учтены в количестве отверстий. Они вынесены в отдельный слой, проверьте.");

            if (diametralDimensions.Count == 1)
            {
                IDimensionText dimensionText = diametralDimensions[0] as IDimensionText;
                dimensionText.TextUnder.Str = $"{coordinats.Count} отв.";
                diametralDimensions[0].Update();
                Application.MessageBoxEx("Количество отверстий записано в диаметральный размер", "Готово", 64);
            }
            //TODO сделать более красивый вывод информации??
            if (diametralDimensions.Count == 0 && coordinats.Count != 0)
            {
                Clipboard.SetText($"{coordinats.Count}");
                MessageBox.Show($"Количество макроэлементов: {coordinats.Count}. Количество скопировано в буфер обмена.");
            }
            if (diametralDimensions.Count > 1)
            {
                Clipboard.SetText($"{coordinats.Count}");
                MessageBox.Show($"Количество макроэлементов: {coordinats.Count}. Выбрано несколько диаметральных размеров, " +
                    $"данные не записаны! Количество скопировано в буфер обмена.");
            }
            if (coordinats.Count == 0)
            {
                Application.MessageBoxEx("Не найдены макроэлементы с обозначением центров отверстий", "Ошибка", 64);
            }
            document2DAPI5.ksUndoContainer(false);
        }
        
        /// <summary>
        /// Меняет выделенные макроэлементы на последний выдленный макроэлемент
        /// </summary>
        private void MacroObjectsReplacement()
        {
            bool severalCentersError = false;
            IKompasDocument kompasDocument = Application.ActiveDocument;
            IKompasDocument1 kompasDocument1 = (IKompasDocument1)kompasDocument;
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)kompasDocument;
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();
            if(kompas.ksYesNo("Заменить макроэлементы?") != 1) return;

            document2DAPI5.ksUndoContainer(true);

            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            if (!(selectionManager.SelectedObjects is object[] selectobject))
            {
                Application.MessageBoxEx("Выберите несколько макроэлементов.", "Ошибка", 64);
                document2DAPI5.ksUndoContainer(false);
                return;
            }
            //Получаем последний выделенный макроэлемент. Им будем заменять остальные макроэлементы
            if (!(selectobject[selectobject.Length - 1] is IMacroObject lastMacroObject))
            {
                Application.MessageBoxEx("Последний выделенный элемент не является макроэлементом", "Ошибка", 64);
                document2DAPI5.ksUndoContainer(false);
                return;
            }

            #region Проверяем наличие центра отверстий в макроэлементе на который происходит замена
            if (!(lastMacroObject is ISymbols2DContainer symbols2DContainer2))
            {
                Application.MessageBoxEx("В макроэлементе, на который происходит замена, не найдено обозначение центра отверстия", "Ошибка", 64);
                document2DAPI5.ksUndoContainer(false);
                return;
            }
            ICentreMarkers centreMarkers2 = symbols2DContainer2.CentreMarkers;
            if (centreMarkers2.Count == 0)
            {
                Application.MessageBoxEx("В макроэлементе, на который происходит замена, не найдено обозначение центра отверстия", "Ошибка", 64);
                document2DAPI5.ksUndoContainer(false);
                return;
            }
            if (centreMarkers2.Count != 1)
            {
                Application.MessageBoxEx("В макроэлементе, на который происходит замена, найдено несколько обозначение центра отверстий. Уберите один из них", "Ошибка", 64);
                document2DAPI5.ksUndoContainer(false);
                return;
            }
            #endregion

            selectionManager.UnselectAll();
            List<double[]> coordinats = new List<double[]>();
            List<IMacroObject> macroObjects = new List<IMacroObject>();
            foreach (IKompasAPIObject kompasObject in selectobject.Cast<IKompasAPIObject>())
            {
                if (kompasObject is IMacroObject macroobject)
                {
                    if (!(macroobject is ISymbols2DContainer symbols2DContainer)) continue;
                    ICentreMarkers centreMarkers = symbols2DContainer.CentreMarkers;
                    if (centreMarkers.Count == 0) continue;
                    macroobject.GetPlacement(out double macroX, out double macroY, out double a, out bool mir);
                    if (centreMarkers.Count != 1)
                    {
                        if (macroobject.Parent is IView view)
                        {
                            ILayers layers = view.Layers;
                            ILayer activLayer = layers[0] as ILayer;
                            ILayer layer = null;
                            foreach (ILayer item in layers)
                            {
                                if (item.Name == "Несколько обозначений центров отверстий") layer = item;
                            }
                            if (layer == null) layer = layers.Add();
                            layer.Name = "Несколько обозначений центров отверстий";
                            layer.Color = 255;
                            layer.Update();
                            macroobject.LayerNumber = layer.LayerNumber;
                            macroobject.Update();
                            activLayer.Current = true;
                            activLayer.Update();
                            severalCentersError = true;
                        }
                        continue;
                    }
                    
                    ICentreMarker centreMarker = centreMarkers[0] as ICentreMarker;
                    double centrX = centreMarker.X;
                    double centrY = centreMarker.Y;
                    macroobject.TransformPointToView(ref centrX, ref centrY);
                    coordinats.Add(new double[] { centrX, centrY });
                    macroObjects.Add(macroobject);
                }
            }
            if (coordinats.Count == 0)
            {
                Application.MessageBoxEx("Не найдены макроэлементы с обозначением центров отверстий", "Ошибка", 64);
                document2DAPI5.ksUndoContainer(false);
                return;
            }
            //Получаем координаты центров отверстий последнего макроэлемента.
            double xOld = coordinats[coordinats.Count - 1][0];
            double yOld = coordinats[coordinats.Count - 1][1];
            //Удаляем координаты последнего макроэлементы
            coordinats.RemoveAt(coordinats.Count - 1);
            //Копируем новый макроэлемент по координатам
            foreach (double[] coordinat in coordinats)
            {
                ICopyObjectParam copyObjectParam = kompasDocument1.GetInterface(KompasAPIObjectTypeEnum.ksObjectCopyObjectParam) as ICopyObjectParam;
                copyObjectParam.XNew = coordinat[0];
                copyObjectParam.YNew = coordinat[1];
                copyObjectParam.XOld = xOld;
                copyObjectParam.YOld = yOld;
                kompasDocument2D1.CopyObjects(lastMacroObject, copyObjectParam);
            }
            //Удаляем старые макроэлементы
            kompasDocument1.Delete(macroObjects.ToArray());

            document2DAPI5.ksUndoContainer(false);

            if (severalCentersError) MessageBox.Show("Ошибка. Есть макроэлементы в которых несколько обозначений центров отверстий. Они не заменены и вынесены в отдельный слой, проверьте.");
            Application.MessageBoxEx("Замена завершена", "Готово", 64);
        }

        /// <summary>
        /// Сохранить PDF в папку Завершенные чертежи
        /// </summary>
        private void PrintPDF()
        {
            IKompasDocument kompasDocument = Application.ActiveDocument;
            if (kompas.ksYesNo("Сохранить PDF в папку Завершенные чертежи?") != 1) return;

            #region Получание адреса папки Завершенные чертежи

            ILibraryManager libraryManager = Application.LibraryManager;
            string pathlibrary = $"{Path.GetDirectoryName(libraryManager.CurrentLibrary.PathName)}"; //Получить путь к папаке библиотеки
            string pathAdressesFolderBZMMK = $"{pathlibrary}\\Resources\\Адреса основных папок БЗММК.txt";
            if (!File.Exists(pathAdressesFolderBZMMK))
            {
                MessageBox.Show("Не найден файл с адресом к папке \"Завершенные чертежи\" Обратитесь к разработчику.");
                return;
            }
            string readAdresses = "";
            using (StreamReader sr = new StreamReader(pathAdressesFolderBZMMK))
            {
                readAdresses = sr.ReadToEnd();
            }
            if (readAdresses == "")
            {
                MessageBox.Show($"Неудалось прочитать файл с адресами папок. Обратитесь к разработчику.");
                return;
            }
            Dictionary<string, string> adresess = new Dictionary<string, string>();
            foreach (string line in readAdresses.Split('\n'))
            {
                string[] temp = line.Split(':').Select(x => x.Trim()).ToArray();
                if (temp.Length != 2) break;
                adresess.Add(temp[0], temp[1]);
            }
            if (!adresess.ContainsKey("Завершенные чертежи"))
            {
                MessageBox.Show($"Не найден путь к папке \"Завершенные чертежи\". Обратитесь к разработчику.");
                return;
            }
            #endregion
            
            string nameorder = Array.Find(kompasDocument.PathName.Split('\\'), x => x.IndexOf("З.з.№", StringComparison.CurrentCultureIgnoreCase) != -1);
            string pathFolderSavePDF = "";
            if (Directory.Exists($"{adresess["Завершенные чертежи"]}\\{nameorder}"))
            {
                pathFolderSavePDF = $"{adresess["Завершенные чертежи"]}\\{nameorder}";
            }
            else if(Directory.Exists($"{adresess["Завершенные чертежи архив"]}\\{nameorder}"))
            {
                pathFolderSavePDF = $"{adresess["Завершенные чертежи архив"]}\\{nameorder}";
            }
            else
            {
                MessageBox.Show($"Не найдена папка заказа в Завершенных чертежах. PDF не сохранен.");
                return;
            }
            string pathSavePDF = $"{pathFolderSavePDF}\\{kompasDocument.Name.Substring(0, kompasDocument.Name.Length - 3)}pdf";
            //Проверка на существование файла и варианты что с этим делать
            if (!File.Exists(pathSavePDF))
            {
                Process.Start(pathFolderSavePDF);

                kompasDocument.SaveAs(pathSavePDF);
                if (File.Exists(pathSavePDF))
                {
                    Application.MessageBoxEx("PDF сохранен.", "Успешно", 64);
                }
                else
                {
                    MessageBox.Show($"Не удалось сохранить PDF. Возможно не хватает прав на сохранение в этой папке.");
                }
                return;
            }
            else
            {
                if (kompas.ksYesNo("Файл существует. Хотите его заменить?") != 1) return;
                DateTime olddata = File.GetLastWriteTime(pathSavePDF);
                Process.Start(pathFolderSavePDF);

                kompasDocument.SaveAs(pathSavePDF);
                if (olddata == File.GetLastWriteTime(pathSavePDF))
                {
                    MessageBox.Show("Не удалось перезаписать файл. Возможно файл кем то открыт или нет прав на этот файл.");
                }
                Application.MessageBoxEx("PDF сохранен.", "Успешно", 64);
            }
        }

        /// <summary>
        /// Запись имени файла в ячейку "Обозначение" в штампе
        /// </summary>
        private void SetNameDocumentStamp()
        {
            IKompasDocument kompasDocument = Application.ActiveDocument;
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)Application.ActiveDocument;
            IKompasDocument1 kompasDocument1 = (IKompasDocument1)Application.ActiveDocument;
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();

            document2DAPI5.ksUndoContainer(true);
            ILayoutSheets layoutSheets = kompasDocument.LayoutSheets;
            if (layoutSheets == null) return;
            if (layoutSheets.Count == 0) return;
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            // Получение листа в старых версиях чертежа. В них видимо нет возможности получить лист по номеру листа.
            if (layoutSheet == null)
            {
                foreach (ILayoutSheet item in layoutSheets)
                {
                    layoutSheet = item;
                    break;
                }
            };


            //IDocuments documents = Application.Documents;
            //IKompasDocument2D kompasDocuments2D1 = (IKompasDocument2D)documents.Open("d:\\Temp\\7\\поз. 55_ред.13.03.cdw", false, false);

            //ILayoutSheets layoutSheets1 = kompasDocuments2D1.LayoutSheets;
            //foreach (ILayoutSheet layoutSheet1 in layoutSheets1)
            //{
            //    IStamp stamp = layoutSheet1.Stamp;
            //    stamp.Text[2].Str = "123"; 
            //    stamp.Update();
            //    break;
            //}
            //kompasDocuments2D1.Close(DocumentCloseOptions.kdSaveChanges);

            //IPropertyMng propertyMng = (IPropertyMng)Application;
            //_Property property = propertyMng.GetProperty(kompasDocument, "Обозначение");
            //IPropertyKeeper propertyKeeper = (IPropertyKeeper)kompasDocument2D;
            //propertyKeeper.SetComplexPropertyValue(property,
            //    $@"<?xml version=""1.0""?>
            //        <document fromSource=""false"" expression="""" type=""string"">
            //         <property id=""base"" value=""qwe"" type=""string"" />
            //         <property id=""embodimentDelimiter"" value=""-"" type=""string"" />
            //         <property id=""embodimentNumber"" value="""" type=""string"" />
            //         <property id=""additionalDelimiter"" value=""."" type=""string"" />
            //         <property id=""additionalNumber"" value="""" type=""string"" />
            //         <property id=""documentDelimiter"" value="""" type=""string"" />
            //         <property id=""documentNumber"" value="""" type=""string"" />
            //        </document>"
            //    );
            //property.Update();
            IStamp stamp = layoutSheet.Stamp;
            if (stamp == null) return;
            string namefile = kompasDocument.Name;
            stamp.Text[2].Str = $"{namefile.Substring(0, namefile.Length-4)}";
            stamp.Update();
            document2DAPI5.ksUndoContainer(false);
            
        }
        private void SetNameDocumentStamp1()
        {
            IKompasDocument kompasDocument = Application.ActiveDocument;
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();

            document2DAPI5.ksUndoContainer(true);
            ILayoutSheets layoutSheets = kompasDocument.LayoutSheets;
            if (layoutSheets == null) return;
            if (layoutSheets.Count == 0) return;
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            // Получение листа в старых версиях чертежа. В них видимо нет возможности получить лист по номеру листа.
            if (layoutSheet == null)
            {
                foreach (ILayoutSheet item in layoutSheets)
                {
                    layoutSheet = item;
                    break;
                }
            };
            IStamp stamp = layoutSheet.Stamp;
            if (stamp == null) return;
            stamp.Text[2].Clear();
            stamp.Update();
            document2DAPI5.ksUndoContainer(false);


            string namefile = kompasDocument.Name;
            namefile = $"{namefile.Substring(0, namefile.Length - 4)}";
            Clipboard.SetText(namefile);


            Application.MessageBoxEx("Название файла документа скопировано в буфер обмена", "Готово", 64);
        }
       
        /// <summary>
        /// Открытие файла помощи
        /// </summary>
        private void OpenHelp()
        {
            ILibraryManager libraryManager = Application.LibraryManager;
            string path = $"{Path.GetDirectoryName(libraryManager.CurrentLibrary.PathName)}\\Help\\index.html"; //Получить путь к папке библиотеки
            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                Application.MessageBoxEx("Файл помощи не найден. Обратитесь к разработчику", "Ошибка", 64);
            }
        }
        #endregion


        // Головная функция библиотеки
        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
        {
            /*
            if (Registration.IDKey == null)
            {
                Registration.GetIDKey();
                Registration.EncryptKey = Registration.Encrypt(Registration.IDKey, "MagicalBlade-RelaxingKompas");
            }
            if (Registration.EncryptKey != Settings.Default.Key)
            {
                FormRegistration formRegistration = new FormRegistration();
                formRegistration.ShowDialog();
                return;
            }
            */
            kompas = (KompasObject)kompas_;
            DataWeightAndSize.Kompas = kompas;
            Application = (IApplication)kompas.ksGetApplication7();
            DataWeightAndSize.Application = Application;
            //Вызываем команды
            switch (command)
            {
                case 1: SaveContour(); break;
                case 2: CopyTable(); break;
                case 3: InsertTable(); break;
                case 4: WeightAndSize(); break;
                case 5: CopyText(); break;
                case 6: PlaceSymbolHole(); break;
                case 7: BreakView(); break;
                case 8: InsertPointXY(); break;
                case 9: InsertRough(); break;
                case 10: LibrarySettings(); break;
                case 11: CopyDataFromStamp(); break;
                case 12: SetTolerance(); break;
                case 13: StepDimension(); break;
                case 14: CountHoles(); break;
                case 15: MacroObjectsReplacement(); break;
                case 16: PrintPDF(); break;
                case 17: SetNameDocumentStamp(); break;
                case 18: SetNameDocumentStamp1(); break;



                case 999: OpenHelp(); break;
            }
        }

        public bool LibInterfaceNotifyEntry(object application)
        {
            bool result = true;

            // Захват интерфейса приложения КОМПАС
            if (kompas == null && application != null)
            {
                kompas = (KompasObject)application;

            }

            return result;
        }

        public object ExternalGetResourceModule()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        public int ExternalGetToolBarId(short barType, short index)
        {
            int result = 0;

            if (barType == 0)
            {
                result = -1;
            }
            else
            {
                switch (index)
                {
                    case 1:
                        result = 3001;
                        break;
                    case 2:
                        result = -1;
                        break;
                }
            }

            return result;
        }


        #region COM Registration
        // Эта функция выполняется при регистрации класса для COM
        // Она добавляет в ветку реестра компонента раздел Kompas_Library,
        // который сигнализирует о том, что класс является приложением Компас,
        // а также заменяет имя InprocServer32 на полное, с указанием пути.
        // Все это делается для того, чтобы иметь возможность подключить
        // библиотеку на вкладке ActiveX.
        [ComRegisterFunction]
        public static void RegisterKompasLib(Type t)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
                regKey = regKey.OpenSubKey(keyName, true);
                regKey.CreateSubKey("Kompas_Library");
                regKey = regKey.OpenSubKey("InprocServer32", true);
                regKey.SetValue(null, System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mscoree.dll");
                regKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("При регистрации класса для COM-Interop произошла ошибка:\n{0}", ex));
            }
        }

        // Эта функция удаляет раздел Kompas_Library из реестра
        [ComUnregisterFunction]
        public static void UnregisterKompasLib(Type t)
        {
            RegistryKey regKey = Registry.LocalMachine;
            string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
            RegistryKey subKey = regKey.OpenSubKey(keyName, true);
            subKey.DeleteSubKey("Kompas_Library");
            subKey.Close();
        }
        #endregion
    }
}