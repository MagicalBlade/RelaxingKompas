using KompasAPI7;
using System.Windows;

namespace RelaxingKompas.Data
{
    static class DataWeightAndSize
    {
        static private string _weight;
        public static string Weight { get => _weight; set => _weight = value; }
       
        public static IKompasDocument KompasDocument { get => _kompasDocument; set => _kompasDocument = value; }

        static private IKompasDocument _kompasDocument;

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
    }
}
