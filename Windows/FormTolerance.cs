using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace RelaxingKompas.Windows
{
    public partial class FormTolerance : Form
    {
        private string tb_Up_oldvalue;
        private string tb_Down_oldvalue;
        public bool historyisclear = false;
        public bool toleranceclear = false;
        public bool autotolerance = false;

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

        private void tb_Up_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length == 1)
            {
                if ("+-0123456789.,".IndexOf(textBox.Text) == -1)
                {
                    textBox.Text = tb_Up_oldvalue;
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }
            if (textBox.Text.Split(new char[] { '.', ',' }).Length -1 > 1)
            {
                textBox.Text = tb_Up_oldvalue;
                textBox.SelectionStart = textBox.Text.Length;
                return;
            }
            for (int i = 1; i < textBox.TextLength; i++)
            {
                if (!char.IsNumber(textBox.Text[i]) && textBox.Text[i] != '.' && textBox.Text[i] != ',')
                {
                    textBox.Text = tb_Up_oldvalue;
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }
            tb_Up_oldvalue = textBox.Text;
        }

        private void tb_Down_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length == 1)
            {
                if ("+-0123456789.,".IndexOf(textBox.Text) == -1)
                {
                    textBox.Text = tb_Down_oldvalue;
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }
            if (textBox.Text.Split(new char[] { '.', ',' }).Length - 1 > 1)
            {
                textBox.Text = tb_Down_oldvalue;
                textBox.SelectionStart = textBox.Text.Length;
                return;
            }
            for (int i = 1; i < textBox.TextLength; i++)
            {
                if (!char.IsNumber(textBox.Text[i]) && textBox.Text[i] != '.' && textBox.Text[i] != ',')
                {
                    textBox.Text = tb_Down_oldvalue;
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }
            tb_Down_oldvalue = textBox.Text;
        }

        private void tb_Up_Enter(object sender, EventArgs e)
        {
            tb_Up.BeginInvoke(new Action(tb_Up.SelectAll));
        }
        private void tb_Down_Enter(object sender, EventArgs e)
        {
            tb_Down.BeginInvoke(new Action(tb_Down.SelectAll));
        }
        private void lb_history_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lb_history.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string text = lb_history.SelectedItem as string;
                string[] toleranse = text.Split('/');
                tb_Up.Text = toleranse[0];
                tb_Down.Text = toleranse[1];
                DialogResult = DialogResult.OK;
            }
        }

        private void lb_tolerance_default_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lb_tolerance_default.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string text = lb_tolerance_default.SelectedItem as string;
                string[] toleranse = text.Split('/');
                tb_Up.Text = toleranse[0];
                tb_Down.Text = toleranse[1];
                DialogResult = DialogResult.OK;
            }
        }

        private void b_clear_history_Click(object sender, EventArgs e)
        {
            lb_history.Items.Clear();
            historyisclear = true;
        }

        private void b_auto_Click(object sender, EventArgs e)
        {
            autotolerance = true;
            DialogResult = DialogResult.OK;
        }

        private void b_clear_tolerance_Click(object sender, EventArgs e)
        {
            toleranceclear = true;
            DialogResult = DialogResult.OK;
        }


    }
}
