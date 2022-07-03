using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RelaxingKompas
{
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class Main
    {
		private KompasObject _kompas;

        public KompasObject kompas { get => _kompas; set => _kompas = value; }


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
                    command = -1;
                    itemType = 3; // "ENDMENU"
                    break;
            }
            return result;
        }

        #endregion

        #region Команды

        #region Копиравание геометрии со стилем линии "основная" в новый документ типа "фрагмент" и сохранение его в формате "dxf"

        private void SaveContour()
        {
            ksDocument2D activedocument2D = (ksDocument2D)kompas.ActiveDocument2D();
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
                ldefin2d.LINESEG_OBJ,
                ldefin2d.CIRCLE_OBJ,
                ldefin2d.ARC_OBJ,
                ldefin2d.BEZIER_OBJ,
                ldefin2d.CONTOUR_OBJ,
                ldefin2d.POLYLINE_OBJ,
                ldefin2d.ELLIPSE_OBJ,
                ldefin2d.NURBS_OBJ,
                ldefin2d.ELLIPSE_ARC_OBJ,
                ldefin2d.RECTANGLE_OBJ,
                ldefin2d.REGULARPOLYGON_OBJ,
                ldefin2d.EQUID_OBJ,
                ldefin2d.WAVELINE_OBJ,
                ldefin2d.MULTILINE_OBJ,
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
            activedocument2D.ksCloseDocument();

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
            newactivedocument2D.ksCloseDocument();
        } 
        #endregion

        #endregion


        // Головная функция библиотеки
        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
		{
			kompas = (KompasObject)kompas_;

			//Вызываем команды
			switch (command)
			{
				case 1: SaveContour(); break;
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
