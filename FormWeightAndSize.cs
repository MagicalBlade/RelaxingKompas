using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RelaxingKompas.Data;
using KompasAPI7;

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
            comb_round.SelectedIndex = Properties.Settings.Default.Round;
            this.Location = Properties.Settings.Default.Point;
            #endregion

        }

        internal void Weight()
        {
            if (tb_thickness.Text != "" && tb_density.Text != "" && tb_yardage.Text != "")
            {
                double weight = Convert.ToDouble(tb_thickness.Text) * Convert.ToDouble(tb_density.Text) * Convert.ToDouble(tb_yardage.Text) * Math.Pow(10, -9);
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
            if (tb_thickness.Text == "")
            {
                Data.DataWeightAndSize.Application.MessageBoxEx("Введите толщину", "Ошибка", 0);
                return;
            }
            DataWeightAndSize.Weight = tb_weight.Text;

            if (cb_clipboard.Checked)
            {
                FormattingText();
            }

            if (cb_weight.Checked)
            {
                DataWeightAndSize.WriteWeightStamp();
            }

            DataWeightAndSize.WriteVariable("t", tb_thickness.Text, "Толщина");

            #region Сохранение настроек
            Properties.Settings.Default.Density = tb_density.Text;
            Properties.Settings.Default.IsClipboard = cb_clipboard.Checked;
            Properties.Settings.Default.Isweight = cb_weight.Checked;
            Properties.Settings.Default.Round = comb_round.SelectedIndex;
            Properties.Settings.Default.Point = this.Location;

            Properties.Settings.Default.Save();
            #endregion

            Hide();

            IKompasDocument kompasDocument = DataWeightAndSize.CreatFragment();
            DataWeightAndSize.PastGroup(kompasDocument);
            if (DataWeightAndSize.WindowLibrarySettings.cb_SaveFragment.Checked)
            {
                if (!DataWeightAndSize.SaveDocument(kompasDocument, "frw"))
                {
                    return;
                }
            }
            if (DataWeightAndSize.WindowLibrarySettings.cb_SaveDxf.Checked)
            {
                if (!DataWeightAndSize.SaveDocument(kompasDocument, "dxf"))
                {
                    return;
                }
            }
            if (DataWeightAndSize.WindowLibrarySettings.cb_CloseFragment.Checked)
            {
                DataWeightAndSize.CloseDocument(kompasDocument);
            }
            if (DataWeightAndSize.WindowLibrarySettings.cb_CloseDrawing.Checked)
            {
                DataWeightAndSize.CloseDocument(DataWeightAndSize.KompasDocument);
            }

        }

        private void FormattingText()
        {
            string plainText = $"{tb_pos.Text}\t{tb_thickness.Text}\t{tb_width.Text}\t{tb_length.Text}\t{tb_weight.Text}";
            string htmlText = $"<table><tr><td>{tb_pos.Text}</td><td>{tb_thickness.Text}</td><td>{tb_width.Text}</td><td>{tb_length.Text}</td><td>{tb_weight.Text}</tr></table>";
            Excel.CopyToExcel(plainText, htmlText);
        }

        private void b_settings_Click(object sender, EventArgs e)
        {
            Data.DataWeightAndSize.WindowLibrarySettings.ShowDialog();
        }
    }
}
