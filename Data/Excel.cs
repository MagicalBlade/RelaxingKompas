﻿using ClosedXML.Excel;
using System;
using System.Globalization;
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

        public static void WriteExcelFile()
        {
            string PathExcelFile = DataWeightAndSize.KompasDocument.Path;
            string NameExcelFile = "Спецификация металла";
            if (DataWeightAndSize.WindowLibrarySettings.tb_NameExcelFile.Text != "")
            {
                NameExcelFile = DataWeightAndSize.WindowLibrarySettings.tb_NameExcelFile.Text;
                foreach (char item in Path.GetInvalidFileNameChars())
                {
                    NameExcelFile = NameExcelFile.Replace(item.ToString(), "");
                }
            }
            if (DataWeightAndSize.WindowLibrarySettings.rb_onDirectory.Checked)
            {
                if (Directory.Exists(DataWeightAndSize.WindowLibrarySettings.tb_PathExcelFile.Text))
                {
                    PathExcelFile = $"{DataWeightAndSize.WindowLibrarySettings.tb_PathExcelFile.Text.TrimEnd('\\')}\\Документы из библиотеки\\Excel\\";
                    try
                    {
                        Directory.CreateDirectory(PathExcelFile);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Не удалось сохранить Excel файл. Проверьте возможность сохранения по выбранному пути.");
                        return;

                    }
                }
                else
                {
                    DataWeightAndSize.Application.MessageBoxEx($"Путь не найден. Excel файл сохранен: {PathExcelFile}", "Ошибка", 0);
                }
            }
            int rowcount = 0;
            string[][] newFileExport = new string[2][];
            newFileExport[0] = new string[]
            {
                "Позиция",
                "Кол. т.",
                "Кол. н.",
                "Сечение",
                "Длина",
                "Сталь",
                "Вес, ед.",
                "Вес, общ.",
                "Номер листа",
                "Площадь"
            };
            newFileExport[1] = new string[]
            {
                DataWeightAndSize.FormWeightAndSize.tb_pos.Text,
                "",
                "",
                $"{DataWeightAndSize.Thickness}х{DataWeightAndSize.FormWeightAndSize.tb_width.Text}",
                DataWeightAndSize.FormWeightAndSize.tb_length.Text,
                DataWeightAndSize.FormWeightAndSize.tb_steel.Text,
                DataWeightAndSize.FormWeightAndSize.tb_weight.Text,
                "",
                DataWeightAndSize.FormWeightAndSize.tb_sheet.Text,
                DataWeightAndSize.FormWeightAndSize.tb_yardage.Text
            };
            string[][] existsFileExport = new string[1][];
            existsFileExport[0] = new string[]
            {
                DataWeightAndSize.FormWeightAndSize.tb_pos.Text,
                "",
                "",
                $"{DataWeightAndSize.Thickness}х{DataWeightAndSize.FormWeightAndSize.tb_width.Text}",
                DataWeightAndSize.FormWeightAndSize.tb_length.Text,
                DataWeightAndSize.FormWeightAndSize.tb_steel.Text,
                DataWeightAndSize.FormWeightAndSize.tb_weight.Text,
                "",
                DataWeightAndSize.FormWeightAndSize.tb_sheet.Text,
                DataWeightAndSize.FormWeightAndSize.tb_yardage.Text
            };
            
            if (File.Exists($"{PathExcelFile}{NameExcelFile}.xlsx"))
            {
                XLWorkbook workbook = new XLWorkbook($"{PathExcelFile}{NameExcelFile}.xlsx");
                IXLWorksheet worksheet = workbook.Worksheet(1);
                if (worksheet.LastRowUsed() != null)
                {
                    rowcount = worksheet.LastRowUsed().RowNumber();
                    InsertInformation(worksheet, existsFileExport);
                }
                else
                {
                    InsertInformation(worksheet, newFileExport);
                }
                workbook.Save();
            }
            else
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Позиции");
                InsertInformation(worksheet, newFileExport);
                workbook.SaveAs($"{PathExcelFile}{NameExcelFile}.xlsx");
            }

            void InsertInformation(IXLWorksheet worksheet, string[][] export)
            {
                if (worksheet != null)
                {
                    worksheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    for (int i = 0; i < export.Length; i++)
                    {
                        worksheet.Cell(rowcount + i + 1, 1).Style.NumberFormat.Format = "@";
                        worksheet.Cell(rowcount + i + 1, 2).Style.NumberFormat.Format = "General";
                        worksheet.Cell(rowcount + i + 1, 3).Style.NumberFormat.Format = "General";
                        worksheet.Cell(rowcount + i + 1, 4).Style.NumberFormat.Format = "@";
                        worksheet.Cell(rowcount + i + 1, 5).Style.NumberFormat.Format = "@";
                        worksheet.Cell(rowcount + i + 1, 6).Style.NumberFormat.Format = "@";
                        worksheet.Cell(rowcount + i + 1, 7).Style.NumberFormat.Format = "General";
                        worksheet.Cell(rowcount + i + 1, 8).Style.NumberFormat.Format = "General";
                        worksheet.Cell(rowcount + i + 1, 9).Style.NumberFormat.Format = "@";
                        worksheet.Cell(rowcount + i + 1, 10).Style.NumberFormat.Format = "General";
                        
                        worksheet.Cell(rowcount + i + 1, 1).SetValue<string>(export[i][0]);
                        worksheet.Cell(rowcount + i + 1, 2).SetValue<string>(export[i][1]);
                        worksheet.Cell(rowcount + i + 1, 3).SetValue<string>(export[i][2]);
                        worksheet.Cell(rowcount + i + 1, 4).SetValue<string>(export[i][3]);
                        worksheet.Cell(rowcount + i + 1, 5).SetValue<string>(export[i][4]);
                        worksheet.Cell(rowcount + i + 1, 6).SetValue<string>(export[i][5]);
                        try
                        {
                            worksheet.Cell(rowcount + i + 1, 7).SetValue<double>(Convert.ToDouble((export[i][6]), CultureInfo.DefaultThreadCurrentCulture));
                        }
                        catch (Exception)
                        {
                            worksheet.Cell(rowcount + i + 1, 7).Style.NumberFormat.Format = "@";
                            worksheet.Cell(rowcount + i + 1, 7).SetValue<string>(export[i][6]);
                        }
                        try
                        {
                            worksheet.Cell(rowcount + i + 1, 10).SetValue<double>(Convert.ToDouble((export[i][9]), CultureInfo.DefaultThreadCurrentCulture));
                        }
                        catch (Exception)
                        {
                            worksheet.Cell(rowcount + i + 1, 10).Style.NumberFormat.Format = "@";
                            worksheet.Cell(rowcount + i + 1, 10).SetValue<string>(export[i][6]);
                        }
                        worksheet.Cell(rowcount + i + 1, 8).SetValue<string>(export[i][7]);
                        worksheet.Cell(rowcount + i + 1, 9).SetValue<string>(export[i][8]);
                    }
                }
                //Ширина колонки по содержимому
                worksheet.Columns(1, export[0].Length).AdjustToContents(); 
            }
            return;
        }
    }
}
