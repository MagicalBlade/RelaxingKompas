using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RelaxingKompas.Windows
{
    public partial class FormInsertTable : Form
    {
        public FormInsertTable()
        {
            InitializeComponent();
        }

        private void RadioButton_Result_OK(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = sender as System.Windows.Forms.RadioButton;
            Form form = radioButton.FindForm();
            form.DialogResult = DialogResult.OK;
            form.Close();
        }
    }
}
