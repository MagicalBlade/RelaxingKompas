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
            string[] header = new string[]
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
            string[] dataexport = new string[]
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
                    rowcount = worksheet.LastRowUsed().RowNumber() + 1;
                    InsertInformation(worksheet, dataexport);
                }
                else
                {
                    InsertInformation(worksheet, dataexport);
                }
                workbook.Save();
            }
            else
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Позиции");

                #region Пишем шапку
                if (worksheet != null)
                {
                    worksheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell(1, 1).Value = header[0];
                    worksheet.Cell(1, 1).DataType = XLDataType.Text;
                    worksheet.Cell(1, 2).Value = header[1];
                    worksheet.Cell(1, 2).DataType = XLDataType.Text;
                    worksheet.Cell(1, 3).Value = header[2];
                    worksheet.Cell(1, 3).DataType = XLDataType.Text;
                    worksheet.Cell(1, 4).Value = header[3];
                    worksheet.Cell(1, 4).DataType = XLDataType.Text;
                    worksheet.Cell(1, 5).Value = header[4];
                    worksheet.Cell(1, 5).DataType = XLDataType.Text;
                    worksheet.Cell(1, 6).Value = header[5];
                    worksheet.Cell(1, 6).DataType = XLDataType.Text;
                    worksheet.Cell(1, 7).Value = header[6];
                    worksheet.Cell(1, 7).DataType = XLDataType.Text;
                    worksheet.Cell(1, 8).Value = header[7];
                    worksheet.Cell(1, 8).DataType = XLDataType.Text;
                    worksheet.Cell(1, 9).Value = header[8];
                    worksheet.Cell(1, 9).DataType = XLDataType.Text;
                    worksheet.Cell(1, 10).Value = header[9];
                    worksheet.Cell(1, 10).DataType = XLDataType.Text;
                }
                //Ширина колонки по содержимому
                worksheet.Columns(1, header.Length).AdjustToContents();
                #endregion
                rowcount = 2;
                InsertInformation(worksheet, dataexport);

                workbook.SaveAs($"{PathExcelFile}{NameExcelFile}.xlsx");
            }

            void InsertInformation(IXLWorksheet worksheet, string[] export)
            {
                if (worksheet != null)
                {
                    worksheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell(rowcount, 1).Value = export[0];
                    if (export[0].IndexOf('.') != -1)
                    {
                        worksheet.Cell(rowcount, 1).DataType = XLDataType.Text;

                    }
                    else
                    {
                        try
                        {
                            worksheet.Cell(rowcount, 1).DataType = XLDataType.Number;
                        }
                        catch (Exception)
                        {
                            worksheet.Cell(rowcount, 1).DataType = XLDataType.Text;
                        }
                    }
                    worksheet.Cell(rowcount, 2).Value = export[1];
                    worksheet.Cell(rowcount, 2).DataType = XLDataType.Number;
                    worksheet.Cell(rowcount, 3).Value = export[2];
                    worksheet.Cell(rowcount, 3).DataType = XLDataType.Number;
                    worksheet.Cell(rowcount, 4).Value = export[3];
                    worksheet.Cell(rowcount, 4).DataType = XLDataType.Text;
                    worksheet.Cell(rowcount, 5).Value = export[4];
                    worksheet.Cell(rowcount, 5).DataType = XLDataType.Number;
                    worksheet.Cell(rowcount, 6).Value = export[5];
                    worksheet.Cell(rowcount, 6).DataType = XLDataType.Text;
                    worksheet.Cell(rowcount, 7).Value = export[6];
                    worksheet.Cell(rowcount, 7).DataType = XLDataType.Number;
                    worksheet.Cell(rowcount, 8).Value = export[7];
                    worksheet.Cell(rowcount, 8).DataType = XLDataType.Number;
                    worksheet.Cell(rowcount, 9).Value = export[8];
                    try
                    {
                        worksheet.Cell(rowcount, 9).DataType = XLDataType.Number;
                    }
                    catch (Exception)
                    {
                        worksheet.Cell(rowcount, 9).DataType = XLDataType.Text;
                    }
                    worksheet.Cell(rowcount, 10).Value = export[9];
                    worksheet.Cell(rowcount, 10).DataType = XLDataType.Number;
                }
                //Ширина колонки по содержимому
                worksheet.Columns(1, export.Length).AdjustToContents(); 
            }
            return;
        }
    }
}
