using KompasAPI7;
using RelaxingKompas.Data;
using System;
using System.Windows.Forms;

namespace RelaxingKompas
{
    public partial class FormWeightAndSize : Form
    {
        public FormWeightAndSize()
        {
            InitializeComponent();
            #region Загрузка настроек
            tb_density.Text = Properties.Settings.Default.Density;
            cb_clipboard.Checked = Properties.Settings.Default.IsClipboard;
            cb_weight.Checked = Properties.Settings.Default.Isweight;
            cb_Excel.Checked = Properties.Settings.Default.isExcel;
            comb_round.SelectedIndex = Properties.Settings.Default.Round;
            this.Location = Properties.Settings.Default.Point;
            #endregion

        }

        internal void Weight()
        {
            //Проверка на цифры в толщине
            double thickness;
            if (!double.TryParse(tb_thickness.Text, out thickness))
            {
                tb_weight.Text = "";
            }
            DataWeightAndSize.Thickness = thickness;
            if (tb_thickness.Text != "" && tb_density.Text != "" && tb_yardage.Text != "")
            {
                double weight = DataWeightAndSize.Thickness * Convert.ToDouble(tb_density.Text) * Convert.ToDouble(tb_yardage.Text) * Math.Pow(10, -9);
                tb_weight.Text = $"{Math.Round(weight, comb_round.SelectedIndex, MidpointRounding.AwayFromZero)}";
            }
        }


        private void tb_thickness_TextChanged(object sender, EventArgs e)
        {
            Weight();
        }

        private void tb_density_TextChanged(object sender, EventArgs e)
        {
            Weight();
        }

        private void comb_round_TextChanged(object sender, EventArgs e)
        {
            Weight();
        }

        private void FormWeightAndSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            // Передаем массу
            DataWeightAndSize.Weight = tb_weight.Text;
            // Копируем в буфер обмена
            if (cb_clipboard.Checked)
            {
                FormattingText();
            }

            if (cb_weight.Checked)
            {
                DataWeightAndSize.WriteWeightStamp();
            }
            //Записуем данные в Excel файл
            if (cb_Excel.Checked)
            {
                try
                {
                    Excel.WriteExcelFile();
                }
                catch (DivideByZeroException ex)
                {

                    MessageBox.Show($"{ex}");;
                }
            }

            DataWeightAndSize.WriteVariable(DataWeightAndSize.KompasDocument, "t", DataWeightAndSize.Thickness.ToString(), "Толщина");
            DataWeightAndSize.WriteVariable(DataWeightAndSize.KompasDocument, "H", tb_width.Text, "Ширина");
            DataWeightAndSize.WriteVariable(DataWeightAndSize.KompasDocument, "L", tb_length.Text, "Длинна");
            DataWeightAndSize.WriteVariable(DataWeightAndSize.KompasDocument, "steel", "1", tb_steel.Text); //Сталь
            DataWeightAndSize.WriteVariable(DataWeightAndSize.KompasDocument, "weight", tb_weight.Text, "Вес");

            #region Сохранение настроек
            Properties.Settings.Default.Density = tb_density.Text;
            Properties.Settings.Default.IsClipboard = cb_clipboard.Checked;
            Properties.Settings.Default.Isweight = cb_weight.Checked;
            Properties.Settings.Default.isExcel = cb_Excel.Checked;
            Properties.Settings.Default.Round = comb_round.SelectedIndex;
            Properties.Settings.Default.Point = this.Location;

            Properties.Settings.Default.Save();
            #endregion

            Hide();
            //Создает новый документ-фрагмент
            if (DataWeightAndSize.WindowLibrarySettings.cb_CreatFragment.Checked)
            {
                IKompasDocument kompasDocument = DataWeightAndSize.CreatFragment();
                DataWeightAndSize.WriteVariable(kompasDocument, "t", DataWeightAndSize.Thickness.ToString(), "Толщина");
                DataWeightAndSize.WriteVariable(kompasDocument, "H", tb_width.Text, "Ширина");
                DataWeightAndSize.WriteVariable(kompasDocument, "L", tb_length.Text, "Длинна");
                DataWeightAndSize.WriteVariable(kompasDocument, "steel", "1", tb_steel.Text); //Сталь
                DataWeightAndSize.WriteVariable(kompasDocument, "weight", tb_weight.Text, "Вес");

                DataWeightAndSize.PastGroup(kompasDocument); //Вставляем в него контур
                if (DataWeightAndSize.WindowLibrarySettings.cb_SaveFragment.Checked) //Сохраняем фрагмент
                {
                    if (!DataWeightAndSize.SaveDocument(kompasDocument, "frw"))
                    {
                        return;
                    }
                }
                if (DataWeightAndSize.WindowLibrarySettings.cb_SaveDxf.Checked) //Сохраняем dxf
                {
                    if (!DataWeightAndSize.SaveDocument(kompasDocument, "dxf"))
                    {
                        return;
                    }
                }
                if (DataWeightAndSize.WindowLibrarySettings.cb_CloseFragment.Checked) //Закрываем фрагмент
                {
                    DataWeightAndSize.CloseDocument(kompasDocument);
                }
            }
            //Создаем 3D деталь
            if (DataWeightAndSize.WindowLibrarySettings.cb_Creat3Ddetail.Checked) 
            {
                DataWeightAndSize.ExtrusionSketch();
            }
            //Закрываем изначальный чертеж
            if (DataWeightAndSize.WindowLibrarySettings.cb_CloseDrawing.Checked) 
            {
                DataWeightAndSize.CloseDocument(DataWeightAndSize.KompasDocument); 
            }
        }

        private void FormattingText()
        {
            string plainText = $"{tb_pos.Text}\t{DataWeightAndSize.Thickness}\t{tb_width.Text}\t{tb_length.Text}\t{tb_steel.Text}\t{tb_weight.Text}\t{tb_yardage.Text}";
            string htmlText = $"<table><tr><td>{tb_pos.Text}</td><td>{DataWeightAndSize.Thickness}</td><td>{tb_width.Text}</td><td>{tb_length.Text}</td><td>{tb_steel.Text}</td><td>{tb_weight.Text}</td><td>{tb_yardage.Text}</tr></table>";
            Excel.CopyToExcel(plainText, htmlText);
        }

        private void b_settings_Click(object sender, EventArgs e)
        {
            Data.DataWeightAndSize.WindowLibrarySettings.ShowDialog();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
