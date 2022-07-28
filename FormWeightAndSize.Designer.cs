namespace RelaxingKompas
{
    partial class FormWeightAndSize
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
            this.b_ok = new System.Windows.Forms.Button();
            this.tb_thickness = new System.Windows.Forms.TextBox();
            this.tb_density = new System.Windows.Forms.TextBox();
            this.tb_weight = new System.Windows.Forms.TextBox();
            this.l_thickness = new System.Windows.Forms.Label();
            this.l_density = new System.Windows.Forms.Label();
            this.l_weight = new System.Windows.Forms.Label();
            this.l_yardage = new System.Windows.Forms.Label();
            this.tb_yardage = new System.Windows.Forms.TextBox();
            this.cb_clipboard = new System.Windows.Forms.CheckBox();
            this.cb_weight = new System.Windows.Forms.CheckBox();
            this.comb_round = new System.Windows.Forms.ComboBox();
            this.l_round = new System.Windows.Forms.Label();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.tb_length = new System.Windows.Forms.TextBox();
            this.l_width = new System.Windows.Forms.Label();
            this.l_length = new System.Windows.Forms.Label();
            this.tb_pos = new System.Windows.Forms.TextBox();
            this.l_pos = new System.Windows.Forms.Label();
            this.tb_sheet = new System.Windows.Forms.TextBox();
            this.l_sheet = new System.Windows.Forms.Label();
            this.tb_steel = new System.Windows.Forms.TextBox();
            this.l_steel = new System.Windows.Forms.Label();
            this.b_settings = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(158, 183);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 1;
            this.b_ok.Text = "Выполнить";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // tb_thickness
            // 
            this.tb_thickness.Location = new System.Drawing.Point(103, 153);
            this.tb_thickness.Margin = new System.Windows.Forms.Padding(5);
            this.tb_thickness.Name = "tb_thickness";
            this.tb_thickness.Size = new System.Drawing.Size(56, 20);
            this.tb_thickness.TabIndex = 0;
            this.tb_thickness.Text = "10";
            this.tb_thickness.TextChanged += new System.EventHandler(this.tb_thickness_TextChanged);
            // 
            // tb_density
            // 
            this.tb_density.Location = new System.Drawing.Point(94, 96);
            this.tb_density.Margin = new System.Windows.Forms.Padding(5);
            this.tb_density.Name = "tb_density";
            this.tb_density.Size = new System.Drawing.Size(77, 20);
            this.tb_density.TabIndex = 2;
            this.tb_density.Text = "7850";
            this.tb_density.TextChanged += new System.EventHandler(this.tb_density_TextChanged);
            // 
            // tb_weight
            // 
            this.tb_weight.Location = new System.Drawing.Point(378, 153);
            this.tb_weight.Margin = new System.Windows.Forms.Padding(5);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(46, 20);
            this.tb_weight.TabIndex = 3;
            // 
            // l_thickness
            // 
            this.l_thickness.AutoSize = true;
            this.l_thickness.Location = new System.Drawing.Point(100, 129);
            this.l_thickness.Name = "l_thickness";
            this.l_thickness.Padding = new System.Windows.Forms.Padding(3);
            this.l_thickness.Size = new System.Drawing.Size(59, 19);
            this.l_thickness.TabIndex = 4;
            this.l_thickness.Text = "Толщина";
            this.l_thickness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_density
            // 
            this.l_density.AutoSize = true;
            this.l_density.Location = new System.Drawing.Point(104, 72);
            this.l_density.Name = "l_density";
            this.l_density.Padding = new System.Windows.Forms.Padding(3);
            this.l_density.Size = new System.Drawing.Size(67, 19);
            this.l_density.TabIndex = 5;
            this.l_density.Text = "Плотность";
            // 
            // l_weight
            // 
            this.l_weight.AutoSize = true;
            this.l_weight.Location = new System.Drawing.Point(378, 129);
            this.l_weight.Name = "l_weight";
            this.l_weight.Padding = new System.Windows.Forms.Padding(3);
            this.l_weight.Size = new System.Drawing.Size(46, 19);
            this.l_weight.TabIndex = 6;
            this.l_weight.Text = "Масса";
            // 
            // l_yardage
            // 
            this.l_yardage.AutoSize = true;
            this.l_yardage.Location = new System.Drawing.Point(328, 71);
            this.l_yardage.Name = "l_yardage";
            this.l_yardage.Padding = new System.Windows.Forms.Padding(3);
            this.l_yardage.Size = new System.Drawing.Size(60, 19);
            this.l_yardage.TabIndex = 7;
            this.l_yardage.Text = "Площадь";
            // 
            // tb_yardage
            // 
            this.tb_yardage.Location = new System.Drawing.Point(310, 95);
            this.tb_yardage.Margin = new System.Windows.Forms.Padding(5);
            this.tb_yardage.Name = "tb_yardage";
            this.tb_yardage.ReadOnly = true;
            this.tb_yardage.Size = new System.Drawing.Size(100, 20);
            this.tb_yardage.TabIndex = 8;
            // 
            // cb_clipboard
            // 
            this.cb_clipboard.AutoSize = true;
            this.cb_clipboard.Checked = true;
            this.cb_clipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_clipboard.Location = new System.Drawing.Point(190, 16);
            this.cb_clipboard.Name = "cb_clipboard";
            this.cb_clipboard.Size = new System.Drawing.Size(217, 17);
            this.cb_clipboard.TabIndex = 9;
            this.cb_clipboard.Text = "Скопировать данные в буфер обмена";
            this.cb_clipboard.UseVisualStyleBackColor = true;
            // 
            // cb_weight
            // 
            this.cb_weight.AutoSize = true;
            this.cb_weight.Location = new System.Drawing.Point(190, 39);
            this.cb_weight.Name = "cb_weight";
            this.cb_weight.Size = new System.Drawing.Size(153, 17);
            this.cb_weight.TabIndex = 10;
            this.cb_weight.Text = "Записать массу в штамп";
            this.cb_weight.UseVisualStyleBackColor = true;
            // 
            // comb_round
            // 
            this.comb_round.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_round.FormattingEnabled = true;
            this.comb_round.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comb_round.Items.AddRange(new object[] {
            "0",
            "0,1",
            "0,01",
            "0,001",
            "0,0001",
            "0,00001",
            "0,000001"});
            this.comb_round.Location = new System.Drawing.Point(181, 95);
            this.comb_round.Margin = new System.Windows.Forms.Padding(5);
            this.comb_round.Name = "comb_round";
            this.comb_round.Size = new System.Drawing.Size(119, 21);
            this.comb_round.TabIndex = 11;
            this.comb_round.TextChanged += new System.EventHandler(this.comb_round_TextChanged);
            // 
            // l_round
            // 
            this.l_round.AutoSize = true;
            this.l_round.Location = new System.Drawing.Point(186, 71);
            this.l_round.Name = "l_round";
            this.l_round.Padding = new System.Windows.Forms.Padding(3);
            this.l_round.Size = new System.Drawing.Size(110, 19);
            this.l_round.TabIndex = 12;
            this.l_round.Text = "Округление массы";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(169, 153);
            this.tb_width.Margin = new System.Windows.Forms.Padding(5);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(49, 20);
            this.tb_width.TabIndex = 13;
            // 
            // tb_length
            // 
            this.tb_length.Location = new System.Drawing.Point(228, 153);
            this.tb_length.Margin = new System.Windows.Forms.Padding(5);
            this.tb_length.Name = "tb_length";
            this.tb_length.Size = new System.Drawing.Size(58, 20);
            this.tb_length.TabIndex = 14;
            // 
            // l_width
            // 
            this.l_width.AutoSize = true;
            this.l_width.Location = new System.Drawing.Point(166, 129);
            this.l_width.Name = "l_width";
            this.l_width.Padding = new System.Windows.Forms.Padding(3);
            this.l_width.Size = new System.Drawing.Size(52, 19);
            this.l_width.TabIndex = 15;
            this.l_width.Text = "Ширина";
            // 
            // l_length
            // 
            this.l_length.AutoSize = true;
            this.l_length.Location = new System.Drawing.Point(240, 129);
            this.l_length.Name = "l_length";
            this.l_length.Padding = new System.Windows.Forms.Padding(3);
            this.l_length.Size = new System.Drawing.Size(46, 19);
            this.l_length.TabIndex = 16;
            this.l_length.Text = "Длина";
            // 
            // tb_pos
            // 
            this.tb_pos.Location = new System.Drawing.Point(12, 153);
            this.tb_pos.Name = "tb_pos";
            this.tb_pos.Size = new System.Drawing.Size(83, 20);
            this.tb_pos.TabIndex = 17;
            // 
            // l_pos
            // 
            this.l_pos.AutoSize = true;
            this.l_pos.Location = new System.Drawing.Point(26, 129);
            this.l_pos.Name = "l_pos";
            this.l_pos.Padding = new System.Windows.Forms.Padding(3);
            this.l_pos.Size = new System.Drawing.Size(57, 19);
            this.l_pos.TabIndex = 4;
            this.l_pos.Text = "Позиция";
            this.l_pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_sheet
            // 
            this.tb_sheet.Location = new System.Drawing.Point(434, 153);
            this.tb_sheet.Margin = new System.Windows.Forms.Padding(5);
            this.tb_sheet.Name = "tb_sheet";
            this.tb_sheet.Size = new System.Drawing.Size(53, 20);
            this.tb_sheet.TabIndex = 3;
            // 
            // l_sheet
            // 
            this.l_sheet.AutoSize = true;
            this.l_sheet.Location = new System.Drawing.Point(434, 129);
            this.l_sheet.Name = "l_sheet";
            this.l_sheet.Padding = new System.Windows.Forms.Padding(3);
            this.l_sheet.Size = new System.Drawing.Size(56, 19);
            this.l_sheet.TabIndex = 6;
            this.l_sheet.Text = "№ листа";
            // 
            // tb_steel
            // 
            this.tb_steel.Location = new System.Drawing.Point(296, 153);
            this.tb_steel.Margin = new System.Windows.Forms.Padding(5);
            this.tb_steel.Name = "tb_steel";
            this.tb_steel.Size = new System.Drawing.Size(72, 20);
            this.tb_steel.TabIndex = 13;
            // 
            // l_steel
            // 
            this.l_steel.AutoSize = true;
            this.l_steel.Location = new System.Drawing.Point(310, 129);
            this.l_steel.Name = "l_steel";
            this.l_steel.Padding = new System.Windows.Forms.Padding(3);
            this.l_steel.Size = new System.Drawing.Size(43, 19);
            this.l_steel.TabIndex = 15;
            this.l_steel.Text = "Сталь";
            // 
            // b_settings
            // 
            this.b_settings.Location = new System.Drawing.Point(44, 30);
            this.b_settings.Name = "b_settings";
            this.b_settings.Size = new System.Drawing.Size(75, 23);
            this.b_settings.TabIndex = 18;
            this.b_settings.Text = "Настройки";
            this.b_settings.UseVisualStyleBackColor = true;
            this.b_settings.Click += new System.EventHandler(this.b_settings_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(243, 183);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 1;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // FormWeightAndSize
            // 
            this.AcceptButton = this.b_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(496, 213);
            this.Controls.Add(this.b_settings);
            this.Controls.Add(this.tb_pos);
            this.Controls.Add(this.l_length);
            this.Controls.Add(this.l_steel);
            this.Controls.Add(this.l_width);
            this.Controls.Add(this.tb_length);
            this.Controls.Add(this.tb_steel);
            this.Controls.Add(this.tb_width);
            this.Controls.Add(this.l_round);
            this.Controls.Add(this.comb_round);
            this.Controls.Add(this.cb_weight);
            this.Controls.Add(this.cb_clipboard);
            this.Controls.Add(this.tb_yardage);
            this.Controls.Add(this.l_yardage);
            this.Controls.Add(this.l_sheet);
            this.Controls.Add(this.l_weight);
            this.Controls.Add(this.l_density);
            this.Controls.Add(this.l_pos);
            this.Controls.Add(this.l_thickness);
            this.Controls.Add(this.tb_sheet);
            this.Controls.Add(this.tb_weight);
            this.Controls.Add(this.tb_density);
            this.Controls.Add(this.tb_thickness);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FormWeightAndSize";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Подсчет массы по площади";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWeightAndSize_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button b_ok;
        internal System.Windows.Forms.TextBox tb_thickness;
        internal System.Windows.Forms.TextBox tb_density;
        internal System.Windows.Forms.TextBox tb_weight;
        private System.Windows.Forms.Label l_thickness;
        private System.Windows.Forms.Label l_density;
        private System.Windows.Forms.Label l_weight;
        private System.Windows.Forms.Label l_yardage;
        internal System.Windows.Forms.TextBox tb_yardage;
        internal System.Windows.Forms.CheckBox cb_clipboard;
        internal System.Windows.Forms.CheckBox cb_weight;
        internal System.Windows.Forms.ComboBox comb_round;
        private System.Windows.Forms.Label l_round;
        internal System.Windows.Forms.TextBox tb_width;
        internal System.Windows.Forms.TextBox tb_length;
        private System.Windows.Forms.Label l_width;
        private System.Windows.Forms.Label l_length;
        internal System.Windows.Forms.TextBox tb_pos;
        private System.Windows.Forms.Label l_pos;
        internal System.Windows.Forms.TextBox tb_sheet;
        private System.Windows.Forms.Label l_sheet;
        internal System.Windows.Forms.TextBox tb_steel;
        private System.Windows.Forms.Label l_steel;
        private System.Windows.Forms.Button b_settings;
        internal System.Windows.Forms.Button b_Cancel;
    }
}