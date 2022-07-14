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

namespace RelaxingKompas
{
    public partial class FormWeightAndSize : Form
    {
        public FormWeightAndSize()
        {
            InitializeComponent();

            tb_density.Text = Properties.Settings.Default.Density;
            cb_clipboard.Checked = Properties.Settings.Default.IsClipboard;
            cb_weight.Checked = Properties.Settings.Default.Isweight;
            comb_round.SelectedIndex = Properties.Settings.Default.Round;

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
        
        

        private void b_ok_Click(object sender, EventArgs e)
        {
            DataWeightAndSize.Weight = tb_weight.Text;

            if (cb_clipboard.Checked)
            {
                DataWeightAndSize.ClipboardText();
            }

            if (cb_weight.Checked)
            {
                DataWeightAndSize.WriteWeightStamp();
            }

            #region Сохранение настроек
            Properties.Settings.Default.Density = tb_density.Text;
            Properties.Settings.Default.IsClipboard = cb_clipboard.Checked;
            Properties.Settings.Default.Isweight = cb_weight.Checked;
            Properties.Settings.Default.Round = comb_round.SelectedIndex;
            Properties.Settings.Default.Save(); 
            #endregion

            Hide();
        }

        private void FormWeightAndSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
