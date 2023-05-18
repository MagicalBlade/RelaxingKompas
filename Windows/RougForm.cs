using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
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
        private int _roughKat;
        public int RoughKat { get => _roughKat; set => _roughKat = value; }
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
    }
}
