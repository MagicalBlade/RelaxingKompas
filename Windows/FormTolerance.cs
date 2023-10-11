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
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;

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
        private void tb_Up_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Windows.Forms.Control.ModifierKeys == Keys.Control || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            //string text = ((System.Windows.Forms.TextBox)sender).Text;
            //text += e.KeyChar;
            //Regex reg = new Regex(@"^([+-.,]|\d)+");
            //if (reg.IsMatch(text))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled= true;
            //}

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            switch (textBox.Text.Length)
            {
                case 0:
                    if ("+-0123456789.,".IndexOf(e.KeyChar) != -1)
                    {
                        e.Handled = false;
                        return;
                    }
                    break;
                default:
                    if (char.IsNumber(e.KeyChar))
                    {
                        e.Handled = false;
                        return;
                    }
                    if (".,".IndexOf(e.KeyChar) != -1)
                    {
                        if (textBox.Text.IndexOf(e.KeyChar) == -1)
                        {
                            e.Handled = false;
                            return;
                        }
                    }
                    break;
            }
            e.Handled = true;
        }

        private void tb_Up_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            if (textBox.Text.Length == 2)
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                this.errorProvider1.SetError(textBox, "Bad");
            }
        }
    }
}
