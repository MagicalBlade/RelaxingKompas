﻿namespace RelaxingKompas
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
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(45, 216);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 0;
            this.b_ok.Text = "Выполнить";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // tb_thickness
            // 
            this.tb_thickness.Location = new System.Drawing.Point(35, 123);
            this.tb_thickness.Margin = new System.Windows.Forms.Padding(5);
            this.tb_thickness.Name = "tb_thickness";
            this.tb_thickness.Size = new System.Drawing.Size(100, 20);
            this.tb_thickness.TabIndex = 1;
            this.tb_thickness.Text = "10";
            this.tb_thickness.TextChanged += new System.EventHandler(this.tb_thickness_TextChanged);
            // 
            // tb_density
            // 
            this.tb_density.Location = new System.Drawing.Point(162, 123);
            this.tb_density.Margin = new System.Windows.Forms.Padding(5);
            this.tb_density.Name = "tb_density";
            this.tb_density.Size = new System.Drawing.Size(100, 20);
            this.tb_density.TabIndex = 2;
            this.tb_density.Text = "7850";
            this.tb_density.TextChanged += new System.EventHandler(this.tb_density_TextChanged);
            // 
            // tb_weight
            // 
            this.tb_weight.Location = new System.Drawing.Point(35, 179);
            this.tb_weight.Margin = new System.Windows.Forms.Padding(5);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(100, 20);
            this.tb_weight.TabIndex = 3;
            // 
            // l_thickness
            // 
            this.l_thickness.AutoSize = true;
            this.l_thickness.Location = new System.Drawing.Point(48, 99);
            this.l_thickness.Name = "l_thickness";
            this.l_thickness.Padding = new System.Windows.Forms.Padding(3);
            this.l_thickness.Size = new System.Drawing.Size(59, 19);
            this.l_thickness.TabIndex = 4;
            this.l_thickness.Text = "Толщина";
            // 
            // l_density
            // 
            this.l_density.AutoSize = true;
            this.l_density.Location = new System.Drawing.Point(178, 99);
            this.l_density.Name = "l_density";
            this.l_density.Padding = new System.Windows.Forms.Padding(3);
            this.l_density.Size = new System.Drawing.Size(67, 19);
            this.l_density.TabIndex = 5;
            this.l_density.Text = "Плотность";
            // 
            // l_weight
            // 
            this.l_weight.AutoSize = true;
            this.l_weight.Location = new System.Drawing.Point(61, 155);
            this.l_weight.Name = "l_weight";
            this.l_weight.Padding = new System.Windows.Forms.Padding(3);
            this.l_weight.Size = new System.Drawing.Size(46, 19);
            this.l_weight.TabIndex = 6;
            this.l_weight.Text = "Масса";
            // 
            // l_yardage
            // 
            this.l_yardage.AutoSize = true;
            this.l_yardage.Location = new System.Drawing.Point(348, 99);
            this.l_yardage.Name = "l_yardage";
            this.l_yardage.Padding = new System.Windows.Forms.Padding(3);
            this.l_yardage.Size = new System.Drawing.Size(60, 19);
            this.l_yardage.TabIndex = 7;
            this.l_yardage.Text = "Площадь";
            // 
            // tb_yardage
            // 
            this.tb_yardage.Location = new System.Drawing.Point(330, 123);
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
            this.cb_clipboard.Location = new System.Drawing.Point(162, 179);
            this.cb_clipboard.Name = "cb_clipboard";
            this.cb_clipboard.Size = new System.Drawing.Size(176, 17);
            this.cb_clipboard.TabIndex = 9;
            this.cb_clipboard.Text = "Скопировать в буфер обмена";
            this.cb_clipboard.UseVisualStyleBackColor = true;
            // 
            // cb_weight
            // 
            this.cb_weight.AutoSize = true;
            this.cb_weight.Location = new System.Drawing.Point(162, 215);
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
            this.comb_round.Location = new System.Drawing.Point(16, 33);
            this.comb_round.Margin = new System.Windows.Forms.Padding(5);
            this.comb_round.Name = "comb_round";
            this.comb_round.Size = new System.Drawing.Size(119, 21);
            this.comb_round.TabIndex = 11;
            this.comb_round.TextChanged += new System.EventHandler(this.comb_round_TextChanged);
            // 
            // l_round
            // 
            this.l_round.AutoSize = true;
            this.l_round.Location = new System.Drawing.Point(21, 9);
            this.l_round.Name = "l_round";
            this.l_round.Padding = new System.Windows.Forms.Padding(3);
            this.l_round.Size = new System.Drawing.Size(110, 19);
            this.l_round.TabIndex = 12;
            this.l_round.Text = "Округление массы";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(206, 60);
            this.tb_width.Margin = new System.Windows.Forms.Padding(5);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(100, 20);
            this.tb_width.TabIndex = 13;
            // 
            // tb_length
            // 
            this.tb_length.Location = new System.Drawing.Point(312, 60);
            this.tb_length.Margin = new System.Windows.Forms.Padding(5);
            this.tb_length.Name = "tb_length";
            this.tb_length.Size = new System.Drawing.Size(100, 20);
            this.tb_length.TabIndex = 14;
            // 
            // l_width
            // 
            this.l_width.AutoSize = true;
            this.l_width.Location = new System.Drawing.Point(234, 36);
            this.l_width.Name = "l_width";
            this.l_width.Padding = new System.Windows.Forms.Padding(3);
            this.l_width.Size = new System.Drawing.Size(52, 19);
            this.l_width.TabIndex = 15;
            this.l_width.Text = "Ширина";
            // 
            // l_length
            // 
            this.l_length.AutoSize = true;
            this.l_length.Location = new System.Drawing.Point(338, 36);
            this.l_length.Name = "l_length";
            this.l_length.Padding = new System.Windows.Forms.Padding(3);
            this.l_length.Size = new System.Drawing.Size(46, 19);
            this.l_length.TabIndex = 16;
            this.l_length.Text = "Длина";
            // 
            // FormWeightAndSize
            // 
            this.AcceptButton = this.b_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.l_length);
            this.Controls.Add(this.l_width);
            this.Controls.Add(this.tb_length);
            this.Controls.Add(this.tb_width);
            this.Controls.Add(this.l_round);
            this.Controls.Add(this.comb_round);
            this.Controls.Add(this.cb_weight);
            this.Controls.Add(this.cb_clipboard);
            this.Controls.Add(this.tb_yardage);
            this.Controls.Add(this.l_yardage);
            this.Controls.Add(this.l_weight);
            this.Controls.Add(this.l_density);
            this.Controls.Add(this.l_thickness);
            this.Controls.Add(this.tb_weight);
            this.Controls.Add(this.tb_density);
            this.Controls.Add(this.tb_thickness);
            this.Controls.Add(this.b_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWeightAndSize";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подсчет массы";
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
    }
}