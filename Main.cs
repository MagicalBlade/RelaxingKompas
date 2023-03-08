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
using System.Text;
using System.Diagnostics;
using System.Windows.Interop;
using RelaxingKompas.Data;
using System.Runtime.InteropServices.ComTypes;
using RelaxingKompas.Event;
using System.Security.Cryptography;
using RelaxingKompas.Properties;
using System.Text.RegularExpressions;

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
                    command = 6;
                    break;
                case 8:
                    result = "Вставить точки по координатам из файла";
                    command = 7;
                    break;
                case 9:
                    result = "Настройки";
                    command = 7;
                    break;
                case 10:
                    command = -1;
                    itemType = 8; // "ENDMENU"
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
            WindowWeightAndSize.tb_pos.Text = postext.Trim('.');
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
            double width = Math.Round(RightY - LeftY, MidpointRounding.AwayFromZero);
            double length = Math.Round(RightX - LeftX, MidpointRounding.AwayFromZero);
            #endregion

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

            WindowWeightAndSize.tb_yardage.Text = $"{ksinertiaParam.F}"; //Передаем площадь в форму
            WindowWeightAndSize.Weight(); //Вызываю вычисление массы
            ksdocument2D.ksWriteGroupToClip(group, true); //Копируем группу в буфер обмена
            
            Win32 = NativeWindow.FromHandle((IntPtr)kompas.ksGetHWindow()); //Получаю окно компаса по дескриптору
            WindowWeightAndSize.Show(Win32); //Показываю окно дочерним к компасу
        }

        private void LibrarySettings()
        {
            Win32 = NativeWindow.FromHandle((IntPtr)kompas.ksGetHWindow()); //Получаю окно компаса по дескриптору
            WindowLibrarySettings.ShowDialog(Win32);
        }
        /// <summary>
        /// Копирование текста из элементов модели
        /// </summary>
        private void CopyText()
        {
            Clipboard.SetText(DataWeightAndSize.CopyText());
        }

        /// <summary>
        /// Расставить условные обозначения отверстий
        /// </summary>
        private void PlaceSymbolHole()
        {
            
            ICircles circles;
            Dictionary<double, List<double[]>> circleList = new Dictionary<double, List<double[]>>(); //Хранение диаметров окружностей и их координат
            string lostHole = $"Нет условных обозначение для следующих диаметров:{Environment.NewLine}";
            string pathlibrary = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}"; //Получить путь к папаке библиотеки
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)Application.ActiveDocument;
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)kompasDocument2D;
            IKompasDocument1 kompasDocument1 = (IKompasDocument1)kompasDocument2D;
            ksDocument2D document2DAPI5 = kompas.ActiveDocument2D();
            document2DAPI5.ksUndoContainer(true);

            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            dynamic selected = selectionManager.SelectedObjects;
            List<object> selectedObjects = new List<object>();
            if (selected == null) //Если не выбраны объекты чертежа поиск окружностей по всему виду
            {
                IViewsAndLayersManager viewsAndLayersManager = kompasDocument2D.ViewsAndLayersManager;
                IViews views = viewsAndLayersManager.Views;
                IView view = views.ActiveView;
                IDrawingContainer drawingContainer = (IDrawingContainer)view;
                circles = drawingContainer.Circles;
                //Заполняем словарь
                foreach (ICircle circle in circles)
                {
                    if (circleList.ContainsKey(circle.Radius * 2))
                    {
                        circleList[circle.Radius * 2].Add(new double[] { circle.Xc, circle.Yc });
                    }
                    else
                    {
                        circleList.Add(circle.Radius * 2, new List<double[]> { new double[] { circle.Xc, circle.Yc } });
                    }
                }
            }
            else if (selected is object[]) //Если выбраны объекты чертежа поиск окружностей по выбранным объектам
            {
                selectedObjects.AddRange(selected);
                //Заполняем словарь
                foreach (object item in selectedObjects)
                {
                    if (item is ICircle)
                    {
                        ICircle circle = (ICircle)item;
                        if (circleList.ContainsKey(circle.Radius * 2))
                        {
                            circleList[circle.Radius * 2].Add(new double[] { circle.Xc, circle.Yc });
                        }
                        else
                        {
                            circleList.Add(circle.Radius * 2, new List<double[]> { new double[] { circle.Xc, circle.Yc } });
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
                    if (item is ICircle)
                    {
                        ICircle circle = (ICircle)item;
                        if (circleList.ContainsKey(circle.Radius * 2))
                        {
                            circleList[circle.Radius * 2].Add(new double[] { circle.Xc, circle.Yc });
                        }
                        else
                        {
                            circleList.Add(circle.Radius * 2, new List<double[]> { new double[] { circle.Xc, circle.Yc } });
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
                drawingGroup.Store();

                ICopyObjectParam copyObjectParam = (ICopyObjectParam)kompasDocument1.GetInterface(KompasAPIObjectTypeEnum.ksObjectCopyObjectParam);
                copyObjectParam.XOld = 0;
                copyObjectParam.YOld = 0;
                //Копируем условное обозначание в центры нужных отверстий
                foreach (var coordinates in circleList[diameter])
                {
                    copyObjectParam.XNew = coordinates[0];
                    copyObjectParam.YNew = coordinates[1];
                    kompasDocument2D1.CopyObjects(drawingGroup, copyObjectParam);
                }
                drawingGroup.Delete();
            }
            document2DAPI5.ksUndoContainer(false);
            if (lostHole != $"Нет условных обозначение для следующих диаметров:{Environment.NewLine}")
            {
                MessageBox.Show($"{lostHole}");
            }
            

        }

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
                using (StreamReader reader = new StreamReader(resultDialog, System.Text.Encoding.Default))
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
                case 9: LibrarySettings(); break;
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