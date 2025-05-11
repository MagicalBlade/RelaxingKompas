using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelaxingKompas.Settings_Prog
{
    internal static class TempStatic
    {
        private static readonly string pathAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static InsertTable InsertTable = new InsertTable()
        {
            Gb_InsertTypeNameIsBoo = "rb_TopRight"
        };

        public static object LoadSettings<T>(string nameFile)
        {
            string dirsettings = Path.Combine(pathAppData, "KOMPAS_Libs", nameof(RelaxingKompas), "Settings");
            string pathsettings = Path.Combine(dirsettings, $"{nameFile}.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            if (File.Exists(pathsettings))
            {
                using (FileStream fs = new FileStream(pathsettings, FileMode.Open))
                {
                    return xmlSerializer.Deserialize(fs);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
