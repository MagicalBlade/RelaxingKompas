using Kompas6API5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace RelaxingKompas.Event
{
    internal class ApplicationEvent : ksKompasObjectNotify
    {
        public bool ApplicationDestroy()
        {

            return true;
        }


        // koBeginCloseAllDocument - Начало закрытия всех открытых документов
        public bool BeginCloseAllDocument()
        {
            bool res = true;
 
            return res;
        }


        // koBeginCreate - Начало создания документа(до диалога выбора типа)
        public bool BeginCreate(int docType)
        {
            bool res = true;
      
            return res;
        }


        // koOpenDocumenBegin - Начало открытия документа
        public bool BeginOpenDocument(string fileName)
        {
    
                return true;
        }


        // koBeginOpenFile - Начало открытия документа(до диалога выбора имени)
        public bool BeginOpenFile()
        {
            bool res = true;
            
            return res;
        }


        // koActiveDocument - Переключение на другой активный документ
        public bool ChangeActiveDocument(object newDoc, int docType)
        {
            return true;
        }


        // koCreateDocument - Документ создан
        public bool CreateDocument(object newDoc, int docType)
        {
            return true;
        }


        // koOpenDocumen - Документ открыт
        public bool OpenDocument(object newDoc, int docType)
        {
            return true;
        }

        // koKeyDown - Событие клавиатуры
        public bool KeyDown(ref int key, int flags, bool system)
        {
            
            return true;
        }

        // koKeyUp - Событие клавиатуры
        public bool KeyUp(ref int key, int flags, bool system)
        {
            return true;
        }

        // koKeyPress - Событие клавиатуры
        public bool KeyPress(ref int key, bool system)
        {
            //var key1 = Key.G;
            //var target = Keyboard.FocusedElement;
            //target.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice,PresentationSource.FromVisual((System.Windows.Media.Visual)target),0,key1));
            return true;
        }

        public bool BeginReguestFiles(int type, ref object files)
        {
            return true;
        }

        public bool BeginChoiceMaterial(int MaterialPropertyId)
        {
            return true;
        }
        public bool ChoiceMaterial(int MaterialPropertyId, string material, double density)
        {
            return true;
        }

        public bool IsNeedConvertToSavePrevious(object pDoc, int docType, int saveVersion, object saveToPreviusParam, ref bool needConvert)
        {
            return true;
        }

        public bool BeginConvertToSavePrevious(object pDoc, int docType, int saveVersion, object saveToPreviusParam)
        {
            return true;
        }

        public bool EndConvertToSavePrevious(object pDoc, int docType, int saveVersion, object saveToPreviusParam)
        {
            return true;
        }

        public bool ChangeTheme(int newTheme)
        {
            return true;
        }
    }
}
