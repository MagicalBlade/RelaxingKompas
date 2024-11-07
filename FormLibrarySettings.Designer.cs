namespace RelaxingKompas
{
    partial class FormLibrarySettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_SaveFragment = new System.Windows.Forms.CheckBox();
            this.cb_CloseDrawing = new System.Windows.Forms.CheckBox();
            this.cb_CreatFragment = new System.Windows.Forms.CheckBox();
            this.cb_SaveDxf = new System.Windows.Forms.CheckBox();
            this.cb_CloseFragment = new System.Windows.Forms.CheckBox();
            this.cb_3Ddetail = new System.Windows.Forms.CheckBox();
            this.cb_Creat3Ddetail = new System.Windows.Forms.CheckBox();
            this.cb_Close3Ddetail = new System.Windows.Forms.CheckBox();
            this.b_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_typehead = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_plane = new System.Windows.Forms.ComboBox();
            this.b_FolderDialog = new System.Windows.Forms.Button();
            this.tb_PathExcelFile = new System.Windows.Forms.TextBox();
            this.rb_onDirectory = new System.Windows.Forms.RadioButton();
            this.rb_here = new System.Windows.Forms.RadioButton();
            this.tb_NameExcelFile = new System.Windows.Forms.TextBox();
            this.l_NameExcelFile = new System.Windows.Forms.Label();
            this.cb_Excel = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cb_isUseOrder = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nud_searchMax = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_toleranceAlign = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_betweenLD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cb_exists_dxf = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_searchMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_toleranceAlign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_betweenLD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_SaveFragment);
            this.groupBox1.Controls.Add(this.cb_CloseDrawing);
            this.groupBox1.Controls.Add(this.cb_CreatFragment);
            this.groupBox1.Controls.Add(this.cb_SaveDxf);
            this.groupBox1.Controls.Add(this.cb_CloseFragment);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общие";
            // 
            // cb_SaveFragment
            // 
            this.cb_SaveFragment.AutoSize = true;
            this.cb_SaveFragment.Location = new System.Drawing.Point(6, 42);
            this.cb_SaveFragment.Name = "cb_SaveFragment";
            this.cb_SaveFragment.Size = new System.Drawing.Size(132, 17);
            this.cb_SaveFragment.TabIndex = 1;
            this.cb_SaveFragment.Text = "Сохранять фрагмент";
            this.cb_SaveFragment.UseVisualStyleBackColor = true;
            // 
            // cb_CloseDrawing
            // 
            this.cb_CloseDrawing.AutoSize = true;
            this.cb_CloseDrawing.Location = new System.Drawing.Point(6, 111);
            this.cb_CloseDrawing.Name = "cb_CloseDrawing";
            this.cb_CloseDrawing.Size = new System.Drawing.Size(109, 17);
            this.cb_CloseDrawing.TabIndex = 0;
            this.cb_CloseDrawing.Text = "Закрыть чертеж";
            this.cb_CloseDrawing.UseVisualStyleBackColor = true;
            // 
            // cb_CreatFragment
            // 
            this.cb_CreatFragment.AutoSize = true;
            this.cb_CreatFragment.Location = new System.Drawing.Point(6, 19);
            this.cb_CreatFragment.Name = "cb_CreatFragment";
            this.cb_CreatFragment.Size = new System.Drawing.Size(121, 17);
            this.cb_CreatFragment.TabIndex = 0;
            this.cb_CreatFragment.Text = "Создать фрагмент";
            this.cb_CreatFragment.UseVisualStyleBackColor = true;
            this.cb_CreatFragment.CheckedChanged += new System.EventHandler(this.cb_CreatFragment_CheckedChanged);
            // 
            // cb_SaveDxf
            // 
            this.cb_SaveDxf.AutoSize = true;
            this.cb_SaveDxf.Location = new System.Drawing.Point(6, 65);
            this.cb_SaveDxf.Name = "cb_SaveDxf";
            this.cb_SaveDxf.Size = new System.Drawing.Size(96, 17);
            this.cb_SaveDxf.TabIndex = 0;
            this.cb_SaveDxf.Text = "Сохранять dxf";
            this.cb_SaveDxf.UseVisualStyleBackColor = true;
            // 
            // cb_CloseFragment
            // 
            this.cb_CloseFragment.AutoSize = true;
            this.cb_CloseFragment.Location = new System.Drawing.Point(6, 88);
            this.cb_CloseFragment.Name = "cb_CloseFragment";
            this.cb_CloseFragment.Size = new System.Drawing.Size(123, 17);
            this.cb_CloseFragment.TabIndex = 0;
            this.cb_CloseFragment.Text = "Закрыть фрагмент";
            this.cb_CloseFragment.UseVisualStyleBackColor = true;
            // 
            // cb_3Ddetail
            // 
            this.cb_3Ddetail.AutoSize = true;
            this.cb_3Ddetail.Location = new System.Drawing.Point(6, 42);
            this.cb_3Ddetail.Name = "cb_3Ddetail";
            this.cb_3Ddetail.Size = new System.Drawing.Size(134, 17);
            this.cb_3Ddetail.TabIndex = 1;
            this.cb_3Ddetail.Text = "Сохранять 3D деталь";
            this.cb_3Ddetail.UseVisualStyleBackColor = true;
            // 
            // cb_Creat3Ddetail
            // 
            this.cb_Creat3Ddetail.AutoSize = true;
            this.cb_Creat3Ddetail.Location = new System.Drawing.Point(6, 19);
            this.cb_Creat3Ddetail.Name = "cb_Creat3Ddetail";
            this.cb_Creat3Ddetail.Size = new System.Drawing.Size(123, 17);
            this.cb_Creat3Ddetail.TabIndex = 1;
            this.cb_Creat3Ddetail.Text = "Создать 3D деталь";
            this.cb_Creat3Ddetail.UseVisualStyleBackColor = true;
            this.cb_Creat3Ddetail.CheckedChanged += new System.EventHandler(this.cb_Creat3Ddetail_CheckedChanged);
            // 
            // cb_Close3Ddetail
            // 
            this.cb_Close3Ddetail.AutoSize = true;
            this.cb_Close3Ddetail.Location = new System.Drawing.Point(6, 65);
            this.cb_Close3Ddetail.Name = "cb_Close3Ddetail";
            this.cb_Close3Ddetail.Size = new System.Drawing.Size(125, 17);
            this.cb_Close3Ddetail.TabIndex = 0;
            this.cb_Close3Ddetail.Text = "Закрыть 3D деталь";
            this.cb_Close3Ddetail.UseVisualStyleBackColor = true;
            // 
            // b_save
            // 
            this.b_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_save.Location = new System.Drawing.Point(241, 232);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 0;
            this.b_save.Text = "ОК";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_typehead);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmb_plane);
            this.groupBox2.Controls.Add(this.b_FolderDialog);
            this.groupBox2.Controls.Add(this.tb_PathExcelFile);
            this.groupBox2.Controls.Add(this.rb_onDirectory);
            this.groupBox2.Controls.Add(this.rb_here);
            this.groupBox2.Controls.Add(this.tb_NameExcelFile);
            this.groupBox2.Controls.Add(this.l_NameExcelFile);
            this.groupBox2.Controls.Add(this.cb_Excel);
            this.groupBox2.Controls.Add(this.cb_3Ddetail);
            this.groupBox2.Controls.Add(this.cb_Close3Ddetail);
            this.groupBox2.Controls.Add(this.cb_Creat3Ddetail);
            this.groupBox2.Location = new System.Drawing.Point(155, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Посчитать массу";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип шапки в Excel файле:";
            // 
            // cb_typehead
            // 
            this.cb_typehead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_typehead.FormattingEnabled = true;
            this.cb_typehead.Items.AddRange(new object[] {
            "Поз|Кол.т|Кол.н|Сечение|Длина|Сталь|Вес,ед|Вес,общ|Лист|Площадь",
            "Поз|Кол.т|Кол.н|Толщина|Ширина|Длина|Вес,ед|Вес,общ|Сталь|Лист|Площадь"});
            this.cb_typehead.Location = new System.Drawing.Point(144, 143);
            this.cb_typehead.Name = "cb_typehead";
            this.cb_typehead.Size = new System.Drawing.Size(226, 21);
            this.cb_typehead.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Плоскость выдавливания";
            // 
            // cmb_plane
            // 
            this.cmb_plane.AutoCompleteCustomSource.AddRange(new string[] {
            "Сверху",
            "Снизу",
            "Спереди",
            "Сзади",
            "Слева",
            "Справа"});
            this.cmb_plane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_plane.FormattingEnabled = true;
            this.cmb_plane.Items.AddRange(new object[] {
            "Сверху",
            "Снизу",
            "Спереди",
            "Сзади",
            "Слева",
            "Справа"});
            this.cmb_plane.Location = new System.Drawing.Point(8, 103);
            this.cmb_plane.Margin = new System.Windows.Forms.Padding(5);
            this.cmb_plane.Name = "cmb_plane";
            this.cmb_plane.Size = new System.Drawing.Size(121, 21);
            this.cmb_plane.TabIndex = 9;
            // 
            // b_FolderDialog
            // 
            this.b_FolderDialog.Location = new System.Drawing.Point(265, 114);
            this.b_FolderDialog.Name = "b_FolderDialog";
            this.b_FolderDialog.Size = new System.Drawing.Size(75, 23);
            this.b_FolderDialog.TabIndex = 8;
            this.b_FolderDialog.Text = "Обзор";
            this.b_FolderDialog.UseVisualStyleBackColor = true;
            this.b_FolderDialog.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_PathExcelFile
            // 
            this.tb_PathExcelFile.Location = new System.Drawing.Point(245, 88);
            this.tb_PathExcelFile.Name = "tb_PathExcelFile";
            this.tb_PathExcelFile.Size = new System.Drawing.Size(125, 20);
            this.tb_PathExcelFile.TabIndex = 7;
            // 
            // rb_onDirectory
            // 
            this.rb_onDirectory.AutoSize = true;
            this.rb_onDirectory.Location = new System.Drawing.Point(159, 88);
            this.rb_onDirectory.Name = "rb_onDirectory";
            this.rb_onDirectory.Size = new System.Drawing.Size(80, 17);
            this.rb_onDirectory.TabIndex = 6;
            this.rb_onDirectory.Text = "По адресу:";
            this.rb_onDirectory.UseVisualStyleBackColor = true;
            // 
            // rb_here
            // 
            this.rb_here.AutoSize = true;
            this.rb_here.Checked = true;
            this.rb_here.Location = new System.Drawing.Point(159, 64);
            this.rb_here.Name = "rb_here";
            this.rb_here.Size = new System.Drawing.Size(127, 17);
            this.rb_here.TabIndex = 5;
            this.rb_here.TabStop = true;
            this.rb_here.Text = "В папке с чертежом";
            this.rb_here.UseVisualStyleBackColor = true;
            // 
            // tb_NameExcelFile
            // 
            this.tb_NameExcelFile.Location = new System.Drawing.Point(229, 42);
            this.tb_NameExcelFile.Name = "tb_NameExcelFile";
            this.tb_NameExcelFile.Size = new System.Drawing.Size(141, 20);
            this.tb_NameExcelFile.TabIndex = 4;
            this.tb_NameExcelFile.Text = "Спецификация металла";
            // 
            // l_NameExcelFile
            // 
            this.l_NameExcelFile.AutoSize = true;
            this.l_NameExcelFile.Location = new System.Drawing.Point(156, 46);
            this.l_NameExcelFile.Name = "l_NameExcelFile";
            this.l_NameExcelFile.Size = new System.Drawing.Size(67, 13);
            this.l_NameExcelFile.TabIndex = 3;
            this.l_NameExcelFile.Text = "Имя файла:";
            // 
            // cb_Excel
            // 
            this.cb_Excel.AutoSize = true;
            this.cb_Excel.Location = new System.Drawing.Point(159, 19);
            this.cb_Excel.Name = "cb_Excel";
            this.cb_Excel.Size = new System.Drawing.Size(141, 17);
            this.cb_Excel.TabIndex = 2;
            this.cb_Excel.Text = "Записать в Excel файл";
            this.cb_Excel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 226);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cb_exists_dxf);
            this.tabPage1.Controls.Add(this.cb_isUseOrder);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Посчитать массу";
            // 
            // cb_isUseOrder
            // 
            this.cb_isUseOrder.AutoSize = true;
            this.cb_isUseOrder.Location = new System.Drawing.Point(12, 154);
            this.cb_isUseOrder.Name = "cb_isUseOrder";
            this.cb_isUseOrder.Size = new System.Drawing.Size(142, 17);
            this.cb_isUseOrder.TabIndex = 2;
            this.cb_isUseOrder.Text = "Разделять по заказам";
            this.toolTip1.SetToolTip(this.cb_isUseOrder, "Разделять по заказам контуры и фрагменты");
            this.cb_isUseOrder.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.nud_searchMax);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.nud_toleranceAlign);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.nud_betweenLD);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Выровнять размеры";
            // 
            // nud_searchMax
            // 
            this.nud_searchMax.DecimalPlaces = 2;
            this.nud_searchMax.Location = new System.Drawing.Point(208, 58);
            this.nud_searchMax.Name = "nud_searchMax";
            this.nud_searchMax.Size = new System.Drawing.Size(75, 20);
            this.nud_searchMax.TabIndex = 1;
            this.nud_searchMax.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Максимальное расстояние поиска:";
            // 
            // nud_toleranceAlign
            // 
            this.nud_toleranceAlign.DecimalPlaces = 2;
            this.nud_toleranceAlign.Location = new System.Drawing.Point(208, 32);
            this.nud_toleranceAlign.Name = "nud_toleranceAlign";
            this.nud_toleranceAlign.Size = new System.Drawing.Size(75, 20);
            this.nud_toleranceAlign.TabIndex = 1;
            this.nud_toleranceAlign.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Расстояние поиска размеров:";
            // 
            // nud_betweenLD
            // 
            this.nud_betweenLD.DecimalPlaces = 2;
            this.nud_betweenLD.Location = new System.Drawing.Point(208, 6);
            this.nud_betweenLD.Name = "nud_betweenLD";
            this.nud_betweenLD.Size = new System.Drawing.Size(75, 20);
            this.nud_betweenLD.TabIndex = 1;
            this.nud_betweenLD.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Расстояние между размерами:";
            // 
            // cb_exists_dxf
            // 
            this.cb_exists_dxf.AutoSize = true;
            this.cb_exists_dxf.Checked = true;
            this.cb_exists_dxf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_exists_dxf.Location = new System.Drawing.Point(12, 177);
            this.cb_exists_dxf.Name = "cb_exists_dxf";
            this.cb_exists_dxf.Size = new System.Drawing.Size(193, 17);
            this.cb_exists_dxf.TabIndex = 3;
            this.cb_exists_dxf.Text = "Спрашивать при замене контура";
            this.cb_exists_dxf.UseVisualStyleBackColor = true;
            // 
            // FormLibrarySettings
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 268);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.b_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FormLibrarySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_searchMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_toleranceAlign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_betweenLD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_save;
        internal System.Windows.Forms.CheckBox cb_CloseFragment;
        internal System.Windows.Forms.CheckBox cb_CloseDrawing;
        internal System.Windows.Forms.CheckBox cb_SaveFragment;
        internal System.Windows.Forms.CheckBox cb_SaveDxf;
        internal System.Windows.Forms.CheckBox cb_3Ddetail;
        internal System.Windows.Forms.CheckBox cb_Close3Ddetail;
        internal System.Windows.Forms.CheckBox cb_Creat3Ddetail;
        internal System.Windows.Forms.CheckBox cb_CreatFragment;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.CheckBox cb_Excel;
        private System.Windows.Forms.Label l_NameExcelFile;
        internal System.Windows.Forms.TextBox tb_NameExcelFile;
        internal System.Windows.Forms.RadioButton rb_onDirectory;
        internal System.Windows.Forms.RadioButton rb_here;
        private System.Windows.Forms.Button b_FolderDialog;
        internal System.Windows.Forms.TextBox tb_PathExcelFile;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmb_plane;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown nud_betweenLD;
        internal System.Windows.Forms.NumericUpDown nud_toleranceAlign;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.NumericUpDown nud_searchMax;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_typehead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.CheckBox cb_isUseOrder;
        internal System.Windows.Forms.CheckBox cb_exists_dxf;
    }
}