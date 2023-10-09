using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using ClosedXML;
using System.Text.RegularExpressions;

namespace RelaxingKompas.Windows
{
    public partial class FormTolerance : Form
    {
        public FormTolerance()
        {
            InitializeComponent();
        }

        private void b_plusminus_Click(object sender, EventArgs e)
        {
            if (tb_Up.Text != "")
            {
                string cleartext = tb_Up.Text.Trim(new char[] {' ', '+', '-'});
                tb_Up.Text = $"+{cleartext}";
                tb_Down.Text = $"-{cleartext}";

            }
        }


        private void tb_Up_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            
        }

        private void tb_Up_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = ((System.Windows.Forms.TextBox)sender).Text;
            text += e.KeyChar;
            Regex reg = new Regex(@"^([+-.,]|\d)+");
            if (reg.IsMatch(text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled= true;
            }
            

            //string reg = "+-0123456789.,";
            //foreach (char item in reg)
            //{
            //    if (e.KeyChar == item)
            //    {
            //        e.Handled = false;
            //        return;
            //    }
            //}
            //e.Handled = true;
        }
    }
}
