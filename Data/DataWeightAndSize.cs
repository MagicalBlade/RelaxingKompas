using Kompas6API5;
using Kompas6Constants;
using KompasAPI7;
using System;
using System.IO;
using System.Windows;

namespace RelaxingKompas.Data
{
    static class DataWeightAndSize
    {
        public static FormWeightAndSize FormWeightAndSize { get => _formWeightAndSize; set => _formWeightAndSize = value; }

        static private FormWeightAndSize _formWeightAndSize;

        public static FormLibrarySettings WindowLibrarySettings { get => _windowLibrarySettings; set => _windowLibrarySettings = value; }

        private static FormLibrarySettings _windowLibrarySettings;

        static private string _weight;
        public static string Weight { get => _weight; set => _weight = value; }

        public static KompasObject Kompas { get => _kompas; set => _kompas = value; }

        private static KompasObject _kompas;

        public static IApplication Application { get => _application; set => _application = value; }

        private static IApplication _application;

        public static IKompasDocument KompasDocument { get => _kompasDocument; set => _kompasDocument = value; }

        static private IKompasDocument _kompasDocument;
        /// <summary>
        /// Запись массы в штамп
        /// </summary>
        static public void WriteWeightStamp()
        {
            ILayoutSheets layoutSheets = KompasDocument.LayoutSheets;
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            IStamp stamp = layoutSheet.Stamp;
            IText text = stamp.Text[5];
            text.Str = $"{Weight}";
            stamp.Update();
            layoutSheet.Update();
        }
        /// <summary>
        /// Получение данных из ячейки штампа
        /// </summary>
        /// <param name="NumberCell"></param>
        /// <returns></returns>
        static public string GetCellStamp(int NumberCell)
        {
            ILayoutSheets layoutSheets = KompasDocument.LayoutSheets;
            if (layoutSheets == null) return "";
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            if (layoutSheet == null) return "";
            IStamp stamp = layoutSheet.Stamp;
            if (stamp == null) return "";
            IText text = stamp.Text[NumberCell];
            return text.Str;
        }
        /// <summary>
        /// Создать новый документ-фрагмент
        /// </summary>
        /// <returns></returns>
        static public IKompasDocument CreatFragment()
        {
            IDocuments documents = Application.Documents;
            IKompasDocument kompasDocument = documents.Add(Kompas6Constants.DocumentTypeEnum.ksDocumentFragment, true);
            return kompasDocument;
        }
        /// <summary>
        /// Вставить группу в документ
        /// </summary>
        /// <param name="kompasDocument"></param>
        static public void PastGroup(IKompasDocument kompasDocument)
        {
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)kompasDocument;
            IDrawingGroups drawingGroups = kompasDocument2D1.DrawingGroups;
            IDrawingGroup drawingGroup = drawingGroups.Add(true, "");
            drawingGroup.ReadFromClip(false, false);

            ksDocument2D document2D = (ksDocument2D)Kompas.ActiveDocument2D();

            #region Габаритный прямоугольник
            ksRectParam rectParam = Kompas.GetParamStruct((short)StructType2DEnum.ko_RectParam);
            document2D.ksGetObjGabaritRect(drawingGroup.Reference, rectParam);
            ksMathPointParam mathPointParam = rectParam.GetpBot(); 
            #endregion
            document2D.ksMoveObj(drawingGroup.Reference, -mathPointParam.x, -mathPointParam.y);//Перемещаем группу в начало координат
            document2D.ksDestroyObjects(drawingGroup.Reference);
            drawingGroup.Store(); //Вставляем группу

            #region Разрушить контуры
            IKompasDocument2D kompasDocument2D = (IKompasDocument2D)kompasDocument;
            IViewsAndLayersManager viewsAndLayersManager = kompasDocument2D.ViewsAndLayersManager;
            IViews views = viewsAndLayersManager.Views;
            IView view = views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;
            IDrawingContours drawingContours = drawingContainer.DrawingContours;
            foreach (IDrawingContour item in drawingContours)
            {
                document2D.ksDestroyObjects(item.Reference); //Разрушение контура
            } 
            #endregion
        }
        /// <summary>
        /// Закрыть документ
        /// </summary>
        /// <param name="kompasDocument"></param>
        static public void CloseDocument(IKompasDocument kompasDocument)
        {
            kompasDocument.Close(DocumentCloseOptions.kdDoNotSaveChanges);
        }
        /// <summary>
        /// Сохранить документ
        /// </summary>
        /// <param name="kompasDocument"></param>
        /// <param name="TypeFile"></param>
        /// <returns></returns>
        static public bool SaveDocument(IKompasDocument kompasDocument, string TypeFile)
        {
            string nameDocument = KompasDocument.PathName;
            nameDocument = nameDocument.Substring(0, nameDocument.Length - 3);
            if (TypeFile == "frw")
            {
                if (!CheckFile())
                {
                    return false;
                }
                kompasDocument.SaveAs($"{nameDocument}frw");
            }
            if (TypeFile == "dxf")
            {
                if (!CheckFile())
                {
                    return false;
                }
                ksDocument2D ksdocument2D = (ksDocument2D)Kompas.ActiveDocument2D();
                ksdocument2D.ksSaveToDXF($"{nameDocument}dxf");
            }
            return true;
            ///<summary> Проверка на возможность пересохранения файла ///</summary>
            bool CheckFile()
            {
                if (File.Exists($"{nameDocument}{TypeFile}"))
                {
                    try
                    {
                        using (FileStream stream = File.Open($"{nameDocument}{TypeFile}", FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            stream.Close();
                        }
                    }
                    catch (IOException)
                    {

                        Kompas.ksMessage($"Не получается сохранить {TypeFile}. Проверьте доступ к файлу. Возможно он открыт в другой программе.");
                        return false;
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// Запись переменных в документ
        /// </summary>
        /// <param name="kompasDocument"></param>
        /// <param name="NameVariable"></param>
        /// <param name="Value"></param>
        /// <param name="Note"></param>
        static public void WriteVariable(IKompasDocument kompasDocument, string NameVariable, string Value, string Note)
        {
            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)kompasDocument;
            IVariable7 variable = kompasDocument2D1.Variable[false, NameVariable];
            if (variable == null)
            {
                IVariable7 newvariable = kompasDocument2D1.AddVariable(NameVariable, Convert.ToDouble(Value), Note);
                newvariable.Note = Note;
            }
            else
            {
                variable.Expression = Value;
                variable.External= true; //Внешняя переменная
            }
            kompasDocument2D1.RebuildDocument();
        }
    }
}
