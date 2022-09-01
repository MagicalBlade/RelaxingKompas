using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
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

        #region Данные
        //Вес
        static private string _weight;
        public static string Weight { get => _weight; set => _weight = value; }
        //Толщина
        public static double Thickness { get => _thickness; set => _thickness = value; }

        static private double _thickness = 0;
        #endregion


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
            if (layoutSheets.Count == 0) return "";
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
            drawingGroup.ReadFromClip(false, false); //Считываем буфер в группу

            ksDocument2D document2D = (ksDocument2D)Kompas.ActiveDocument2D();

            #region Габаритный прямоугольник
            ksRectParam rectParam = Kompas.GetParamStruct((short)StructType2DEnum.ko_RectParam);
            document2D.ksGetObjGabaritRect(drawingGroup.Reference, rectParam);
            ksMathPointParam mathPointParam = rectParam.GetpBot(); 
            #endregion
            document2D.ksMoveObj(drawingGroup.Reference, -mathPointParam.x, -mathPointParam.y);//Перемещаем группу в начало координат
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
        /// Закрыть документ переключиться на родительский чертеж
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
            string NameFile = FormWeightAndSize.tb_pos.Text;
            foreach (Char invalid_char in Path.GetInvalidFileNameChars())
            {
                NameFile = NameFile.Replace(invalid_char.ToString(), "");
            }
            string PathFile = $"{KompasDocument.Path}{NameFile}";
            if (TypeFile == "frw")
            {
                if (!CheckFile())
                {
                    return false;
                }
                kompasDocument.SaveAs($"{PathFile}.frw");
            }
            if (TypeFile == "dxf")
            {
                if (!CheckFile())
                {
                    return false;
                }
                ksDocument2D ksdocument2D = (ksDocument2D)Kompas.ActiveDocument2D();
                ksdocument2D.ksSaveToDXF($"{PathFile}.dxf");
            }
            return true;
            ///<summary> Проверка на возможность пересохранения файла ///</summary>
            bool CheckFile()
            {
                if (File.Exists($"{PathFile}.{TypeFile}"))
                {
                    try
                    {
                        using (FileStream stream = File.Open($"{PathFile}.{TypeFile}", FileMode.Open, FileAccess.Read, FileShare.None))
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
        /// Создаем 3D деталь
        /// </summary>
        /// <returns></returns>
        static public bool ExtrusionSketch()
        {
            string NameFile = FormWeightAndSize.tb_pos.Text;
            foreach (Char invalid_char in Path.GetInvalidFileNameChars())
            {
                NameFile = NameFile.Replace(invalid_char.ToString(), "");
            }
            IDocuments documents = Application.Documents;
            IKompasDocument3D kompasDocument3D = (IKompasDocument3D)documents.Add(DocumentTypeEnum.ksDocumentPart, true);//Создаем документ 3D деталь
            IPart7 part7 = kompasDocument3D.TopPart;
            //part7.Marking = NameFile;
            part7.Name = NameFile;
            IModelContainer modelContainer = (IModelContainer)part7;
            ISketchs sketchs = modelContainer.Sketchs;
            ISketch sketch = sketchs.Add();
            IModelObject axes3DOZ;
            IPlane3D plane;
            //Выбор плоскости выдавливания
            switch (DataWeightAndSize.WindowLibrarySettings.cmb_plane.SelectedItem)
            {
                case "Сверху":
                    sketch.DirectingObject[ksObj3dTypeEnum.o3d_axisOX] = part7.DefaultObject[ksObj3dTypeEnum.o3d_axisOY];
                    sketch.LeftHandedCS = false;
                    plane = (IPlane3D)part7.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
                    break;
                case "Снизу":
                    sketch.DirectingObject[ksObj3dTypeEnum.o3d_axisOY] = part7.DefaultObject[ksObj3dTypeEnum.o3d_axisOX];
                    sketch.LeftHandedCS = true;
                    plane = (IPlane3D)part7.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
                    break;
                case "Спереди":
                    sketch.DirectingObject[ksObj3dTypeEnum.o3d_axisOY] = part7.DefaultObject[ksObj3dTypeEnum.o3d_axisOZ];
                    sketch.LeftHandedCS = true;
                    plane = (IPlane3D)part7.DefaultObject[ksObj3dTypeEnum.o3d_planeYOZ];
                    break;
                case "Сзади":
                    sketch.DirectingObject[ksObj3dTypeEnum.o3d_axisOY] = part7.DefaultObject[ksObj3dTypeEnum.o3d_axisOZ];
                    sketch.LeftHandedCS = false;
                    plane = (IPlane3D)part7.DefaultObject[ksObj3dTypeEnum.o3d_planeYOZ];
                    break;
                case "Слева":
                    sketch.DirectingObject[ksObj3dTypeEnum.o3d_axisOY] = part7.DefaultObject[ksObj3dTypeEnum.o3d_axisOZ];
                    sketch.LeftHandedCS = true;
                    plane = (IPlane3D)part7.DefaultObject[ksObj3dTypeEnum.o3d_planeXOZ];
                    break;
                case "Справа":
                    sketch.DirectingObject[ksObj3dTypeEnum.o3d_axisOY] = part7.DefaultObject[ksObj3dTypeEnum.o3d_axisOZ];
                    sketch.LeftHandedCS = false;
                    plane = (IPlane3D)part7.DefaultObject[ksObj3dTypeEnum.o3d_planeXOZ];
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Не выбрана плоскость");
                    return true;
            }
            
            sketch.Plane = plane;
            part7.Update();

            string PathFile = $"{KompasDocument.Path}{part7.Name}.m3d";

            IKompasDocument kompasDocument = sketch.BeginEdit(); //Начало формирования эскиза

            IKompasDocument2D1 kompasDocument2D1 = (IKompasDocument2D1)kompasDocument;
            IDrawingGroups drawingGroups = kompasDocument2D1.DrawingGroups;
            IDrawingGroup drawingGroup = drawingGroups.Add(true, "");
            drawingGroup.ReadFromClip(false, false); //Считываем буфер в группу

            #region Габаритный прямоугольник
            ksRectParam rectParam = Kompas.GetParamStruct((short)StructType2DEnum.ko_RectParam);
            ksDocument2D document2D = (ksDocument2D)Kompas.ksGetDocumentByReference(kompasDocument.Reference);
            document2D.ksGetObjGabaritRect(drawingGroup.Reference, rectParam);
            ksMathPointParam mathPointParam = rectParam.GetpBot();
            #endregion
            //Перемещаем группу в начало координат
            document2D.ksMoveObj(drawingGroup.Reference, -mathPointParam.x, -mathPointParam.y);
            //Вставляем группу
            drawingGroup.Store();
            //Закончили формировать эскиз
            sketch.EndEdit();
            sketch.Update();

            kompasDocument3D.Active = true;
            //WriteVariable(kompasDocument, "t", FormWeightAndSize.tb_thickness.Text, "Толщина");
            //WriteVariable(kompasDocument, "H", FormWeightAndSize.tb_width.Text, "Ширина");
            //WriteVariable(kompasDocument, "L", FormWeightAndSize.tb_length.Text, "Длинна");
            //WriteVariable(kompasDocument, "steel", "1", FormWeightAndSize.tb_steel.Text); //Сталь


            #region Выдавливаем эскиз
            IExtrusions extrusions = modelContainer.Extrusions;
            IExtrusion extrusion = extrusions.Add(ksObj3dTypeEnum.o3d_bossExtrusion);
            extrusion.Direction = ksDirectionTypeEnum.dtMiddlePlane; //Выдавливание "симметрично"
            extrusion.Sketch = (Sketch)sketch;

            if (Thickness == 0)
            {
                Application.MessageBoxEx("Не указана толщина. Выдавливание произведено с толщиной равно единице.", "ошибка", 0);
                extrusion.Depth[true] = 1; //Толщина выдавливания
            }
            else
            {
                extrusion.Depth[true] = Thickness; //Толщина выдавливания
            }

            if (!extrusion.Update())
            {
                Application.MessageBoxEx("не удалось выдавить", "ошибка", 0);
                return false;
            }
            if (WindowLibrarySettings.cb_3Ddetail.Checked)
            {
                kompasDocument3D.SaveAs(PathFile);
                if (kompasDocument3D.Name == "")
                {
                    Application.MessageBoxEx("не удалось сохранить", "ошибка", 0);
                    return false;
                }
            }

            if (WindowLibrarySettings.cb_Close3Ddetail.Checked) //Закрываем 3D деталь
            {
                kompasDocument3D.Close(DocumentCloseOptions.kdDoNotSaveChanges);
            }

            #endregion
            return true;
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
            if (Value == "" && variable != null)
            {
                variable.Expression = "0";
                kompasDocument2D1.RebuildDocument();
                return;
            }
            if (variable == null)
            {
                IVariable7 newvariable = kompasDocument2D1.AddVariable(NameVariable, 0, Note);
                if (Value == "")
                {
                    newvariable.Expression = "0";
                }
                else
                {
                    newvariable.Expression = Value;
                }
                newvariable.Note = Note;
                newvariable.External = true;
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
