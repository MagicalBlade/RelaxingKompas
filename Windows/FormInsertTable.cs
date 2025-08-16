using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RelaxingKompas.Windows
{
    public partial class FormInsertTable : Form
    {
        private string pathExamples;

        public string PathExamples { get => pathExamples; set => pathExamples = value; }

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

        private void b_examples_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(PathExamples))
            {
                Process.Start(PathExamples);
            }
        }
    }
}
