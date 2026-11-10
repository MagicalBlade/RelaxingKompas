using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Utils
{
    static public class Pos
    {
        static public List<PosData> GetPosData(IDrawingDocument kompasDocument)
        {            
            if(kompasDocument == null) return null;
            List<PosTable> posTables = new List<PosTable>(); 
            List<PosData> posData = new List<PosData>(); 
            IViewsAndLayersManager viewsAndLayersManager = kompasDocument.ViewsAndLayersManager;
            IViews views = viewsAndLayersManager.Views;
            foreach (IView view in views)
            {
                ISymbols2DContainer symbols2DContainer = (ISymbols2DContainer)view;
                IDrawingTables drawingTables = symbols2DContainer.DrawingTables;
                foreach (IDrawingTable drawingTable in drawingTables)
                {
                    ITable table = (ITable)drawingTable;
                    PosTable posTable = null;
                    for (int i = 0; i < table.RowsCount; i++)
                    {
                        for (int j = 0; j < table.ColumnsCount; j++)
                        {
                            if (((IText)table.Cell[i, j].Text).Str.IndexOf("поз", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                posTable = new PosTable
                                {
                                    Table = table,
                                    StartRow = i + 1,
                                    PosColumn = j
                                };
                            }
                            if (posTable != null)
                            {
                                if (((IText)table.Cell[i, j].Text).Str.IndexOf("s", StringComparison.CurrentCultureIgnoreCase) != -1
                                    || ((IText)table.Cell[i, j].Text).Str.IndexOf("толщ", StringComparison.CurrentCultureIgnoreCase) != -1)
                                {
                                    posTable.ThicknessColumn = j;
                                }
                                if (((IText)table.Cell[i, j].Text).Str.IndexOf("сечение", StringComparison.CurrentCultureIgnoreCase) != -1)
                                {
                                    posTable.SizeColumn = j;
                                }
                            }
                        }
                    }
                    if( posTable != null ) posTables.Add(posTable);
                }
            }
            
            foreach (var posTable in posTables)
            {
                for (int i = posTable.StartRow; i < posTable.Table.RowsCount; i++)
                {
                    string name = ((IText)posTable.Table.Cell[i, posTable.PosColumn].Text).Str.Trim();
                    if (name == "")
                    {
                        continue;
                    }
                    PosData posData1 = new PosData
                    {
                        Name = name
                    };
                    if (posTable.SizeColumn == -1 && posTable.ThicknessColumn != -1)
                    {
                        if (double.TryParse(((IText)posTable.Table.Cell[i, posTable.ThicknessColumn].Text).Str, out double res))
                        {
                            posData1.Thickness = res;
                        }
                    }
                    else if(posTable.SizeColumn != -1)
                    {
                        if (double.TryParse(((IText)posTable.Table.Cell[i, posTable.SizeColumn].Text).Str.Split(new char[] { 'x', 'X', 'х', 'Х' })[0], out double res))
                        {
                            posData1.Thickness = res;
                        }
                    }
                    posData.Add(posData1);
                }
            }            
            return posData;
        }

        static public string GetThickness(IDrawingDocument kompasDocument)
        {
            ILayoutSheets layoutSheets = kompasDocument.LayoutSheets;
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            // Получение листа в старых версиях чертежа. В них видимо нет возможности получить лист по номеру листа.
            if (layoutSheet == null)
            {
                foreach (ILayoutSheet item in layoutSheets)
                {
                    layoutSheet = item;
                    break;
                }
            }
            IStamp stamp = layoutSheet.Stamp;
            IText text3 = stamp.Text[3];
            string text3Str = text3.Str;
            if (text3Str != "")
            {
                string[] profile = text3Str.Split("$dsm; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (profile.Length > 4)
                {
                    return profile[1];
                }
            }
            return "";
        }        
        public class PosData
        {
            private string name;
            private double thickness;

            public string Name { get => name; set => name = value; }
            public double Thickness { get => thickness; set => thickness = value; }
        }
        private class PosTable
        {
            public ITable Table;
            public int StartRow;
            public int PosColumn;
            public int ThicknessColumn = -1;
            public int SizeColumn = -1;
        }
    }
}
