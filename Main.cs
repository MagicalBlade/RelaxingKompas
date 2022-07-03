using Kompas6API5;
using Microsoft.Win32;
using System;
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
        private void SaveContour()
        {
			ksDocument2D activedocument2D = (ksDocument2D)kompas.ActiveDocument2D();
			ksDocumentParam activedocumentParam = (ksDocumentParam)kompas.GetParamStruct(35);
			activedocument2D.ksGetObjParam(activedocument2D.reference, activedocumentParam, -1); //Получаем параметры активного окна
			string namefile = activedocumentParam.fileName;
			string namedxf = namefile.Substring(0, namefile.Length - 3);

			ksIterator iterator = kompas.GetIterator();
			iterator.ksCreateIterator(2, 0);
			int temp = iterator.ksMoveIterator("N");

			int newgroup = activedocument2D.ksNewGroup(1);
			activedocument2D.ksEndGroup();
			activedocument2D.ksAddObjGroup(newgroup, temp);
			activedocument2D.ksWriteGroupToClip(newgroup, true); //Копируем группу в буфер обмена
																 //MessageBox.Show(activedocument2D.ksStoreTmpGroup(newgroup).ToString());



			//activedocument2D.ksCloseDocument();
			//Создаем новый документ типа "фрагмент"
			ksDocument2D document2D = (ksDocument2D)kompas.Document2D();
			ksDocumentParam documentParam = (ksDocumentParam)kompas.GetParamStruct(35);
			documentParam.type = 3;
			document2D.ksCreateDocument(documentParam);
			ksDocument2D newactivedocument2D = (ksDocument2D)kompas.ActiveDocument2D();
			int newgroup1 = newactivedocument2D.ksReadGroupFromClip(); //Считываем буфер обмена во временную группу
			newactivedocument2D.ksStoreTmpGroup(newgroup1); //Вставляем временную группу в новый чертеж
															//newactivedocument2D.ksSaveToDXF($"{namedxf}dxf"); //Сохраняем в dxf
															//newactivedocument2D.ksCloseDocument();
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
			}

			kompas.ksMessageBoxResult();
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
