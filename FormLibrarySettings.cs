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
    public partial class FormLibrarySettings : Form
    {
        public FormLibrarySettings()
        {
            InitializeComponent();
            #region Загрузка настроек
            cb_CloseDrawing.Checked = Properties.Settings.Default.CloseDrawing;
            cb_CloseFragment.Checked = Properties.Settings.Default.CloseFragment;
            cb_SaveDxf.Checked = Properties.Settings.Default.SaveDxf;
            cb_SaveFragment.Checked = Properties.Settings.Default.SaveFragment; 
            cb_3Ddetail.Checked = Properties.Settings.Default.Is3Ddetail;
            cb_Close3Ddetail.Checked = Properties.Settings.Default.IsClose3Ddetail;
            #endregion
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            #region Сохранение настроек
            Properties.Settings.Default.CloseDrawing = cb_CloseDrawing.Checked;
            Properties.Settings.Default.CloseFragment = cb_CloseFragment.Checked;
            Properties.Settings.Default.SaveDxf = cb_SaveDxf.Checked;
            Properties.Settings.Default.SaveFragment = cb_SaveFragment.Checked;
            Properties.Settings.Default.Is3Ddetail= cb_3Ddetail.Checked;
            Properties.Settings.Default.IsClose3Ddetail= cb_Close3Ddetail.Checked;
            Properties.Settings.Default.Save();
            #endregion
        }

        private void cb_Creat3Ddetail_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_Creat3Ddetail.Checked)
            {
                cb_3Ddetail.Checked = false;
                cb_Close3Ddetail.Checked = false;
                cb_3Ddetail.Enabled = false;
                cb_Close3Ddetail.Enabled = false;
            }
            else
            {
                cb_3Ddetail.Enabled = true;
                cb_Close3Ddetail.Enabled = true;
            }
        }
    }
}
