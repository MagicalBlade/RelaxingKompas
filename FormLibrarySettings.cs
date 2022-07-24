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
            cb_CloseDrawing.Checked = Properties.Settings.Default.CloseDrawing;
            cb_CloseFragment.Checked = Properties.Settings.Default.CloseFragment;
            cb_SaveDxf.Checked = Properties.Settings.Default.SaveDxf;
            cb_SaveFragment.Checked = Properties.Settings.Default.SaveFragment;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CloseDrawing = cb_CloseDrawing.Checked;
            Properties.Settings.Default.CloseFragment = cb_CloseFragment.Checked;
            Properties.Settings.Default.SaveDxf = cb_SaveDxf.Checked;
            Properties.Settings.Default.SaveFragment = cb_SaveFragment.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
