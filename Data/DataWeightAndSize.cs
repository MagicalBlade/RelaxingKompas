using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KompasAPI7;
using RelaxingKompas;

namespace RelaxingKompas.Data
{
    static class DataWeightAndSize
    {
        static public string Thickness { get => _thickness; set => _thickness = value; }

        static private string _thickness = "10";

        static private string _density = "7850";
        static public string Density { get => _density; set => _density = value; }

        static private string _weight;
        public static string Weight { get => _weight; set => _weight = value; }

        static private bool _isClipboard = true;
        static public bool IsClipboard { get => _isClipboard; set => _isClipboard = value; }

        static private bool _isweight = false;
        static public bool Isweight { get => _isweight; set => _isweight = value; }

        static private int _round = 0;
        static public int Round { get => _round; set => _round = value; }
        public static IKompasDocument KompasDocument { get => _kompasDocument; set => _kompasDocument = value; }

        static private IKompasDocument _kompasDocument;

        static public void ClipboardText()
        {
            Clipboard.SetText(DataWeightAndSize.Weight);
        }

        static public void WriteWeightStamp()
        {
            ILayoutSheets layoutSheets = KompasDocument.LayoutSheets;
            ILayoutSheet layoutSheet = layoutSheets.ItemByNumber[1];
            IStamp stamp = layoutSheet.Stamp;
            IText text = stamp.Text[5];
            text.Str = $"{DataWeightAndSize.Weight}";
            stamp.Update();
            layoutSheet.Update();
        }
    }
}
