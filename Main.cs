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

namespace RelaxingKompas
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Main

    {
        private KompasObject _kompas;

        public KompasObject kompas { get => _kompas; set => _kompas = value; }
        
        private ksDocument2D _activedocument2D;
        public ksDocument2D activedocument2D { get => _activedocument2D; set => _activedocument2D = value; }



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
                    command = -1;
                    itemType = 3; // "ENDMENU"
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
            //Сохраняем в dxf
            if (File.Exists($"{namedxf}dxf"))
            {
                try
                {
                    using (FileStream stream = File.Open($"{namedxf}dxf", FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        stream.Close();
                    }
                }
                catch (IOException)
                {

                    kompas.ksMessage("Не получается сохранить dxf. Проверьте доступ к файлу. Возможно он открыт в другой программе.");
                    return;
                }
            }
            newactivedocument2D.ksSaveToDXF($"{namedxf}dxf");
            activedocument2D.ksCloseDocument();
            newactivedocument2D.ksCloseDocument();
        }
        #endregion

        private void Table()
        {
            IApplication application = kompas.ksGetApplication7();
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)application.ActiveDocument;
            ISelectionManager selectionManager = kompasDocument2D1.SelectionManager;
            IKompasAPIObject selecobjects =  selectionManager.SelectedObjects;
            
            if (selecobjects.Type != KompasAPIObjectTypeEnum.ksObjectDrawingTable)
            {
                return;
            }
            ITable table = (ITable)selecobjects;

            #region Оформляем таблицу для буфера обмена
            string plainText = ""; //Таблица для текстового формата
            string copytable = "<table>"; //Таблица для html формата
            string[,] tablestring = new string[table.RowsCount, table.ColumnsCount];
            for (int rows = 0; rows < table.RowsCount; rows++)
            {
                copytable += "<tr>";
                for (int colum = 0; colum < table.ColumnsCount; colum++)
                {
                    ITableCell tableCell = table.Cell[rows, colum];
                    IText text = (IText)tableCell.Text;
                    tablestring[rows, colum] = text.Str;
                    copytable += $"<td>{text.Str}</td>";
                    plainText += text.Str + "\t";
                }
                copytable += "</tr>";
                plainText += "\n";
            }
            copytable += "</table>"; 
            #endregion


            var dataObject = new DataObject();

            #region Заготовка текста для оформления html формата буфера обмена
            string head = "Version:0.9\r\n" +
                    "StartHTML: 000000000\r\n" +
                    "EndHTML: 000000000\r\n" +
                    "StartFragment: 000000000\r\n" +
                    "EndFragment: 000000000\r\n";
            string starthtml = "<html><body>\r\n";
            string startfragment = "<!--StartFragment-->";
            string endfragment = "<!--EndFragment-->";
            string endhtml = "</body>\r\n" +
                    "</html>\r\n"; 
            #endregion

            string StartHTMLIndex = Encoding.UTF8.GetByteCount(head).ToString("D9");
            string EndHTMLIndex = Encoding.UTF8.GetByteCount(head + starthtml + startfragment + copytable + endfragment + endhtml).ToString("D9");
            string StartFragmentIndex = Encoding.UTF8.GetByteCount(head + starthtml).ToString("D9");
            string EndFragmentIndex = Encoding.UTF8.GetByteCount(head + starthtml + startfragment + copytable + endfragment).ToString("D9");
            
            string htmlFormat = head + starthtml + startfragment + copytable + endfragment + endhtml; //Строка в html формате

            #region Подставляем позиции начали/окончания разделов
            htmlFormat = htmlFormat.Replace("StartHTML: 000000000\r\n", $"StartHTML: {StartHTMLIndex}\r\n");
            htmlFormat = htmlFormat.Replace("EndHTML: 000000000\r\n", $"EndHTML: {EndHTMLIndex}\r\n");
            htmlFormat = htmlFormat.Replace("StartFragment: 000000000\r\n", $"StartFragment: {StartFragmentIndex}\r\n");
            htmlFormat = htmlFormat.Replace("EndFragment: 000000000\r\n", $"EndFragment: {EndFragmentIndex}\r\n");
            #endregion

            #region Проверка на поддержку русского языка и если надо конвертируем в UTF8 кодировку
            var otherDotNetHostEncoding = Encoding.Default.CodePage != Encoding.UTF8.CodePage;
            var oldDonNet = otherDotNetHostEncoding || Environment.Version.Major < 4 && htmlFormat.Length != Encoding.UTF8.GetByteCount(htmlFormat);
            if (otherDotNetHostEncoding || oldDonNet)
            {
                htmlFormat = Encoding.Default.GetString(Encoding.UTF8.GetBytes(htmlFormat)); //Конвертируем в UTF8 кодировку
            } 
            #endregion

            dataObject.SetData(DataFormats.Html, true, htmlFormat); //Подготавливаем html формат
            dataObject.SetData(DataFormats.Text, true, plainText); //Подготавливаем текстовый формат
            dataObject.SetData(DataFormats.UnicodeText, true, plainText); //Подготавливаем Unicode формат
            Clipboard.SetDataObject(dataObject); //Копируем в буфер обмена
        }

        #endregion


        // Головная функция библиотеки
        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
        {
            kompas = (KompasObject)kompas_;

            //Вызываем команды
            switch (command)
            {
                case 1: SaveContour(); break;
                case 2: Table(); break;
            }
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
