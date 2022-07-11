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

namespace RelaxingKompas
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        internal void Weight()
        {
            if (tb_thickness.Text != "" && tb_density.Text != "" && tb_yardage.Text != "")
            {
                tb_weight.Text = $"{Convert.ToDouble(tb_thickness.Text) * Convert.ToDouble(tb_density.Text) * Convert.ToDouble(tb_yardage.Text) * Math.Pow(10, -9)}";
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
    }
}
