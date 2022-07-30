using ClosedXML.Excel;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RelaxingKompas.Data
{
    static internal class Excel
    {
        public static void CopyToExcel(string plainText, string htmlText)
        {
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
            string EndHTMLIndex = Encoding.UTF8.GetByteCount(head + starthtml + startfragment + htmlText + endfragment + endhtml).ToString("D9");
            string StartFragmentIndex = Encoding.UTF8.GetByteCount(head + starthtml).ToString("D9");
            string EndFragmentIndex = Encoding.UTF8.GetByteCount(head + starthtml + startfragment + htmlText + endfragment).ToString("D9");

            string htmlFormat = head + starthtml + startfragment + htmlText + endfragment + endhtml; //Строка в html формате

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

        public static bool WriteExcelFile()
        {
            string Path = DataWeightAndSize.KompasDocument.Path;
            int rowcount = 0;
            if (File.Exists($"{Path}Спецификация металла.xlsx"))
            {
                string[][] export = new string[1][];
                export[0] = new string[]
                {
                DataWeightAndSize.FormWeightAndSize.tb_pos.Text,
                DataWeightAndSize.Thickness.ToString(),
                DataWeightAndSize.FormWeightAndSize.tb_width.Text,
                DataWeightAndSize.FormWeightAndSize.tb_length.Text,
                DataWeightAndSize.FormWeightAndSize.tb_steel.Text,
                DataWeightAndSize.FormWeightAndSize.tb_weight.Text,
                DataWeightAndSize.FormWeightAndSize.tb_yardage.Text
                };
                XLWorkbook workbook = new XLWorkbook($"{Path}Спецификация металла.xlsx");
                IXLWorksheet worksheet = workbook.Worksheets.Worksheet(1);

                rowcount = worksheet.LastRowUsed().RowNumber();
                InsertInformation(worksheet, export);
                workbook.Save();
            }
            else
            {
                string[][] export = new string[2][];
                export[0] = new string[]
                {
                "Позиция",
                "Толщина",
                "Ширина",
                "Длина",
                "Сталь",
                "Вес, ед.",
                "Площадь"
                };
                export[1] = new string[]
                {
                DataWeightAndSize.FormWeightAndSize.tb_pos.Text,
                DataWeightAndSize.Thickness.ToString(),
                DataWeightAndSize.FormWeightAndSize.tb_width.Text,
                DataWeightAndSize.FormWeightAndSize.tb_length.Text,
                DataWeightAndSize.FormWeightAndSize.tb_steel.Text,
                DataWeightAndSize.FormWeightAndSize.tb_weight.Text,
                DataWeightAndSize.FormWeightAndSize.tb_yardage.Text
                };
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Позиции");
                InsertInformation(worksheet, export);
                workbook.SaveAs($"{Path}Спецификация металла.xlsx");
            }

            void InsertInformation(IXLWorksheet worksheet, string[][] export)
            {
                if (worksheet != null)
                {
                    for (int i = 0; i < export.Length; i++)
                    {
                        for (int j = 0; j < export[i].Length; j++)
                        {
                            worksheet.Cell(rowcount + i + 1, j + 1).Value = export[i][j];
                            worksheet.Cell(rowcount + i + 1, j + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);                            
                        }
                    }
                }
                worksheet.Columns(1, export[0].Length).AdjustToContents();
            }
            return true;
        }
    }
}
