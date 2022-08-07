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
using RelaxingKompas.Properties;

namespace RelaxingKompas
{
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void b_Registration_Click(object sender, EventArgs e)
        {
            if (tb_RKey.Text == Registration.EncryptKey)
            {
                Settings.Default.Key = tb_RKey.Text;
                Settings.Default.Save();
                MessageBox.Show("Регистрация прошла успешно.");
                this.Close();
            }
            else
            {
                l_eror.Text = "Не верный ключ";
            }
        }
    }
}
