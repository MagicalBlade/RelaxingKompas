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

namespace RelaxingKompas.Windows.Utils
{
    public partial class WindowMessageTextBox: Form
    {
        public WindowMessageTextBox()
        {
            InitializeComponent();
        }

        private void WindowMessageTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Form form = (Form)sender;
            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
            }
        }
    }
}
