using RelaxingKompas.Data;
using System;
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
            cb_Creat3Ddetail.Checked = Properties.Settings.Default.IsCreat3Ddetail;
            cb_CreatFragment.Checked = Properties.Settings.Default.IsCreatFragment;
            cb_Excel.Checked = Properties.Settings.Default.isExcel;
            tb_NameExcelFile.Text = Properties.Settings.Default.NameExcelFile;
            rb_here.Checked = Properties.Settings.Default.rb_here;
            rb_onDirectory.Checked = Properties.Settings.Default.rb_onDirectory;
            tb_PathExcelFile.Text = Properties.Settings.Default.tb_PathExcelFile;
            cmb_plane.SelectedIndex = Properties.Settings.Default.cmb_plane;
            nud_betweenLD.Value = Properties.Settings.Default.betweenLD;
            nud_toleranceAlign.Value = Properties.Settings.Default.toleranceAlign;
            nud_searchMax.Value = Properties.Settings.Default.searchMax;
            cb_typehead.SelectedIndex = Properties.Settings.Default.FormLibrarySettings_cb_typehead;
            cb_isUseOrder.Checked = Properties.Settings.Default.FormLibrarySettings_cb_isUseOrder;
            cb_exists_dxf.Checked = Properties.Settings.Default.FormLibrarySettings_cb_exists_dxf;
            cb_typeModeling.SelectedIndex = Properties.Settings.Default.FormLibrarySettings_cb_typeModelingSelectedIndex;
            nud_CountHoles_tolerance.Value = Properties.Settings.Default.FormLibrarySettings_nud_CountHoles_tolerance;
            nud_CountCircle_tolerance.Value = Properties.Settings.Default.FormLibrarySettings_nud_CountCircle_tolerance;
            nud_CountCircle_tolerance_Diametr.Value = Properties.Settings.Default.FormLibrarySettings_nud_CountCircle_tolerance_Diametr;

            #endregion

            Check3Ddetail();
            CheckFragment();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (DataWeightAndSize.FormWeightAndSize != null)
            {
                DataWeightAndSize.FormWeightAndSize.cb_savefragment.Checked = cb_SaveFragment.Checked;
                DataWeightAndSize.FormWeightAndSize.cb_savedxf.Checked = cb_SaveDxf.Checked;
            }

            #region Сохранение настроек
            Properties.Settings.Default.CloseDrawing = cb_CloseDrawing.Checked;
            Properties.Settings.Default.CloseFragment = cb_CloseFragment.Checked;
            Properties.Settings.Default.SaveDxf = cb_SaveDxf.Checked;
            Properties.Settings.Default.SaveFragment = cb_SaveFragment.Checked;
            Properties.Settings.Default.Is3Ddetail= cb_3Ddetail.Checked;
            Properties.Settings.Default.IsClose3Ddetail= cb_Close3Ddetail.Checked;
            Properties.Settings.Default.IsCreat3Ddetail= cb_Creat3Ddetail.Checked;
            Properties.Settings.Default.IsCreatFragment= cb_CreatFragment.Checked;
            Properties.Settings.Default.isExcel = cb_Excel.Checked;
            Properties.Settings.Default.NameExcelFile = tb_NameExcelFile.Text;
            Properties.Settings.Default.rb_here = rb_here.Checked;
            Properties.Settings.Default.rb_onDirectory = rb_onDirectory.Checked;
            Properties.Settings.Default.tb_PathExcelFile = tb_PathExcelFile.Text;
            Properties.Settings.Default.cmb_plane = cmb_plane.SelectedIndex;
            Properties.Settings.Default.betweenLD = nud_betweenLD.Value;
            Properties.Settings.Default.toleranceAlign = nud_toleranceAlign.Value;
            Properties.Settings.Default.searchMax = nud_searchMax.Value;
            Properties.Settings.Default.FormLibrarySettings_cb_typehead = cb_typehead.SelectedIndex;
            Properties.Settings.Default.FormLibrarySettings_cb_isUseOrder = cb_isUseOrder.Checked;
            Properties.Settings.Default.FormLibrarySettings_cb_exists_dxf= cb_exists_dxf.Checked;
            Properties.Settings.Default.FormLibrarySettings_cb_typeModelingSelectedIndex = cb_typeModeling.SelectedIndex;
            Properties.Settings.Default.FormLibrarySettings_nud_CountHoles_tolerance = nud_CountHoles_tolerance.Value;
            Properties.Settings.Default.FormLibrarySettings_nud_CountCircle_tolerance = nud_CountCircle_tolerance.Value;
            Properties.Settings.Default.FormLibrarySettings_nud_CountCircle_tolerance_Diametr = nud_CountCircle_tolerance_Diametr.Value;
            Properties.Settings.Default.Save();
            #endregion
        }

        private void cb_Creat3Ddetail_CheckedChanged(object sender, EventArgs e)
        {
            Check3Ddetail();
        }

        private void Check3Ddetail ()
        {
            #region Галочки создания детали
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
            #endregion
        }
        private void CheckFragment()
        {
            #region Галочки создания фрагмента
            if (!cb_CreatFragment.Checked)
            {
                cb_SaveDxf.Checked = false;
                cb_SaveFragment.Checked = false;
                cb_CloseFragment.Checked = false;

                cb_SaveDxf.Enabled = false;
                cb_SaveFragment.Enabled = false;
                cb_CloseFragment.Enabled = false;
            }
            else
            {
                cb_SaveDxf.Enabled = true;
                cb_SaveFragment.Enabled = true;
                cb_CloseFragment.Enabled = true;
            } 
            #endregion
        }

        private void cb_CreatFragment_CheckedChanged(object sender, EventArgs e)
        {
            CheckFragment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tb_PathExcelFile.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
