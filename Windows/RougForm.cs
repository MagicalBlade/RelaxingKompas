using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using RelaxingKompas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RelaxingKompas.Windows
{
    public partial class RougForm : Form
    {
        private Sto_012 sto_012_2018;
        private Sto_012 sto_012_2007;
        private int _roughKat;
        public int RoughKat { get => _roughKat; set => _roughKat = value; }
        internal Sto_012 Sto_012_2018 { get => sto_012_2018; set => sto_012_2018 = value; }
        internal Sto_012 Sto_012_2007 { get => sto_012_2007; set => sto_012_2007 = value; }

        public RougForm()
        {
            InitializeComponent();
        }


        private void b_kat1_Click(object sender, EventArgs e)
        {
            RoughKat = 1;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void b_kat2_Click(object sender, EventArgs e)
        {
            RoughKat = 2;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void b_kat3_Click(object sender, EventArgs e)
        {
            RoughKat = 3;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RougForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_thickness.Focused) return;
            switch (e.KeyChar)
            {
                case '1':
                    RoughKat = 1;
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
                case '2':
                    RoughKat = 2;
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
                case '3':
                    RoughKat = 3;
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
                default:
                    break;
            }
            
        }

        private void dgv_Pos_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string thickness = ((RelaxingKompas.Utils.Pos.PosData)dataGridView.SelectedCells[0].OwningRow.DataBoundItem).Thickness.ToString();
            if (thickness != null && thickness.Trim() != "")
            {
                tb_thickness.Text = thickness;
            }
        }

        private void rb_Sto_2018_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSTO();
        }
        public void ChangeSTO()
        {
            dgv_rz.Rows.Clear();
            if (rb_Sto_2018.Checked)
            {
                foreach (var item in Sto_012_2018.RoughKat1)
                {
                    dgv_rz.Rows.Add("1", $"{item[0]}-{item[1]}", item[2]);
                }
                foreach (var item in Sto_012_2018.RoughKat2)
                {
                    dgv_rz.Rows.Add("2", $"{item[0]}-{item[1]}", item[2]);
                }
                foreach (var item in Sto_012_2018.RoughKat3)
                {
                    dgv_rz.Rows.Add("3", $"{item[0]}-{item[1]}", item[2]);
                }
            }
            else
            {
                foreach (var item in Sto_012_2007.RoughKat1)
                {
                    dgv_rz.Rows.Add("1", $"{item[0]}-{item[1]}", item[2]);
                }
                foreach (var item in Sto_012_2007.RoughKat2)
                {
                    dgv_rz.Rows.Add("2", $"{item[0]}-{item[1]}", item[2]);
                }
                foreach (var item in Sto_012_2007.RoughKat3)
                {
                    dgv_rz.Rows.Add("3", $"{item[0]}-{item[1]}", item[2]);
                }
            }
        }
    }
}
