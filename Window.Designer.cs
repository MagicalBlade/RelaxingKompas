namespace RelaxingKompas
{
    partial class Window
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
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.DialogResult = System.Windows.Forms.DialogResult.No;
            this.b_ok.Location = new System.Drawing.Point(172, 213);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 0;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            // 
            // tb_thickness
            // 
            this.tb_thickness.Location = new System.Drawing.Point(35, 123);
            this.tb_thickness.Name = "tb_thickness";
            this.tb_thickness.Size = new System.Drawing.Size(100, 20);
            this.tb_thickness.TabIndex = 1;
            this.tb_thickness.TextChanged += new System.EventHandler(this.tb_thickness_TextChanged);
            // 
            // tb_density
            // 
            this.tb_density.Location = new System.Drawing.Point(162, 123);
            this.tb_density.Name = "tb_density";
            this.tb_density.Size = new System.Drawing.Size(100, 20);
            this.tb_density.TabIndex = 2;
            this.tb_density.Text = "7850";
            this.tb_density.TextChanged += new System.EventHandler(this.tb_density_TextChanged);
            // 
            // tb_weight
            // 
            this.tb_weight.Location = new System.Drawing.Point(162, 174);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.ReadOnly = true;
            this.tb_weight.Size = new System.Drawing.Size(100, 20);
            this.tb_weight.TabIndex = 3;
            // 
            // l_thickness
            // 
            this.l_thickness.AutoSize = true;
            this.l_thickness.Location = new System.Drawing.Point(55, 107);
            this.l_thickness.Name = "l_thickness";
            this.l_thickness.Size = new System.Drawing.Size(53, 13);
            this.l_thickness.TabIndex = 4;
            this.l_thickness.Text = "Толщина";
            // 
            // l_density
            // 
            this.l_density.AutoSize = true;
            this.l_density.Location = new System.Drawing.Point(179, 107);
            this.l_density.Name = "l_density";
            this.l_density.Size = new System.Drawing.Size(61, 13);
            this.l_density.TabIndex = 5;
            this.l_density.Text = "Плотность";
            // 
            // l_weight
            // 
            this.l_weight.AutoSize = true;
            this.l_weight.Location = new System.Drawing.Point(190, 158);
            this.l_weight.Name = "l_weight";
            this.l_weight.Size = new System.Drawing.Size(40, 13);
            this.l_weight.TabIndex = 6;
            this.l_weight.Text = "Масса";
            // 
            // l_yardage
            // 
            this.l_yardage.AutoSize = true;
            this.l_yardage.Location = new System.Drawing.Point(352, 107);
            this.l_yardage.Name = "l_yardage";
            this.l_yardage.Size = new System.Drawing.Size(54, 13);
            this.l_yardage.TabIndex = 7;
            this.l_yardage.Text = "Площадь";
            // 
            // tb_yardage
            // 
            this.tb_yardage.Location = new System.Drawing.Point(330, 123);
            this.tb_yardage.Name = "tb_yardage";
            this.tb_yardage.ReadOnly = true;
            this.tb_yardage.Size = new System.Drawing.Size(100, 20);
            this.tb_yardage.TabIndex = 8;
            // 
            // cb_clipboard
            // 
            this.cb_clipboard.AutoSize = true;
            this.cb_clipboard.Location = new System.Drawing.Point(182, 13);
            this.cb_clipboard.Name = "cb_clipboard";
            this.cb_clipboard.Size = new System.Drawing.Size(176, 17);
            this.cb_clipboard.TabIndex = 9;
            this.cb_clipboard.Text = "Скопировать в буфер обмена";
            this.cb_clipboard.UseVisualStyleBackColor = true;
            // 
            // cb_weight
            // 
            this.cb_weight.AutoSize = true;
            this.cb_weight.Location = new System.Drawing.Point(182, 49);
            this.cb_weight.Name = "cb_weight";
            this.cb_weight.Size = new System.Drawing.Size(153, 17);
            this.cb_weight.TabIndex = 10;
            this.cb_weight.Text = "Записать массу в штамп";
            this.cb_weight.UseVisualStyleBackColor = true;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
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
            this.Name = "Window";
            this.Text = "Window";
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
    }
}