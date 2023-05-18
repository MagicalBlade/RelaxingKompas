namespace RelaxingKompas.Windows
{
    partial class RougForm
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
            this.b_kat1 = new System.Windows.Forms.Button();
            this.b_kat2 = new System.Windows.Forms.Button();
            this.b_kat3 = new System.Windows.Forms.Button();
            this.tb_thickness = new System.Windows.Forms.TextBox();
            this.l_thickness = new System.Windows.Forms.Label();
            this.b_cancel = new System.Windows.Forms.Button();
            this.rb_Sto_2007 = new System.Windows.Forms.RadioButton();
            this.rb_Sto_2018 = new System.Windows.Forms.RadioButton();
            this.gb_Sto = new System.Windows.Forms.GroupBox();
            this.gb_kat = new System.Windows.Forms.GroupBox();
            this.gb_Sto.SuspendLayout();
            this.gb_kat.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_kat1
            // 
            this.b_kat1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_kat1.Location = new System.Drawing.Point(16, 26);
            this.b_kat1.Name = "b_kat1";
            this.b_kat1.Size = new System.Drawing.Size(30, 30);
            this.b_kat1.TabIndex = 0;
            this.b_kat1.Text = "1";
            this.b_kat1.UseVisualStyleBackColor = true;
            this.b_kat1.Click += new System.EventHandler(this.b_kat1_Click);
            // 
            // b_kat2
            // 
            this.b_kat2.Location = new System.Drawing.Point(69, 26);
            this.b_kat2.Name = "b_kat2";
            this.b_kat2.Size = new System.Drawing.Size(30, 30);
            this.b_kat2.TabIndex = 1;
            this.b_kat2.Text = "2";
            this.b_kat2.UseVisualStyleBackColor = true;
            this.b_kat2.Click += new System.EventHandler(this.b_kat2_Click);
            // 
            // b_kat3
            // 
            this.b_kat3.Location = new System.Drawing.Point(119, 26);
            this.b_kat3.Name = "b_kat3";
            this.b_kat3.Size = new System.Drawing.Size(30, 30);
            this.b_kat3.TabIndex = 2;
            this.b_kat3.Text = "3";
            this.b_kat3.UseVisualStyleBackColor = true;
            this.b_kat3.Click += new System.EventHandler(this.b_kat3_Click);
            // 
            // tb_thickness
            // 
            this.tb_thickness.Location = new System.Drawing.Point(57, 107);
            this.tb_thickness.Name = "tb_thickness";
            this.tb_thickness.Size = new System.Drawing.Size(100, 20);
            this.tb_thickness.TabIndex = 3;
            // 
            // l_thickness
            // 
            this.l_thickness.AutoSize = true;
            this.l_thickness.Location = new System.Drawing.Point(34, 91);
            this.l_thickness.Name = "l_thickness";
            this.l_thickness.Size = new System.Drawing.Size(136, 13);
            this.l_thickness.TabIndex = 1;
            this.l_thickness.Text = "Укажите толщину детали";
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(72, 209);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 4;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            // 
            // rb_Sto_2007
            // 
            this.rb_Sto_2007.AutoSize = true;
            this.rb_Sto_2007.Location = new System.Drawing.Point(0, 19);
            this.rb_Sto_2007.Name = "rb_Sto_2007";
            this.rb_Sto_2007.Size = new System.Drawing.Size(186, 17);
            this.rb_Sto_2007.TabIndex = 5;
            this.rb_Sto_2007.Text = "СТО-ГК «Трансстрой»-012-2007";
            this.rb_Sto_2007.UseVisualStyleBackColor = true;
            // 
            // rb_Sto_2018
            // 
            this.rb_Sto_2018.AutoSize = true;
            this.rb_Sto_2018.Checked = true;
            this.rb_Sto_2018.Location = new System.Drawing.Point(0, 42);
            this.rb_Sto_2018.Name = "rb_Sto_2018";
            this.rb_Sto_2018.Size = new System.Drawing.Size(186, 17);
            this.rb_Sto_2018.TabIndex = 6;
            this.rb_Sto_2018.TabStop = true;
            this.rb_Sto_2018.Text = "СТО-ГК «Трансстрой»-012-2018";
            this.rb_Sto_2018.UseVisualStyleBackColor = true;
            // 
            // gb_Sto
            // 
            this.gb_Sto.Controls.Add(this.rb_Sto_2007);
            this.gb_Sto.Controls.Add(this.rb_Sto_2018);
            this.gb_Sto.Location = new System.Drawing.Point(12, 12);
            this.gb_Sto.Name = "gb_Sto";
            this.gb_Sto.Size = new System.Drawing.Size(196, 76);
            this.gb_Sto.TabIndex = 7;
            this.gb_Sto.TabStop = false;
            this.gb_Sto.Text = "Выбор СТО";
            // 
            // gb_kat
            // 
            this.gb_kat.Controls.Add(this.b_kat2);
            this.gb_kat.Controls.Add(this.b_kat1);
            this.gb_kat.Controls.Add(this.b_kat3);
            this.gb_kat.Location = new System.Drawing.Point(21, 133);
            this.gb_kat.Name = "gb_kat";
            this.gb_kat.Size = new System.Drawing.Size(177, 70);
            this.gb_kat.TabIndex = 0;
            this.gb_kat.TabStop = false;
            this.gb_kat.Text = "Выберите категорию кромки";
            // 
            // RougForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(221, 244);
            this.Controls.Add(this.gb_kat);
            this.Controls.Add(this.gb_Sto);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.tb_thickness);
            this.Controls.Add(this.l_thickness);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "RougForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Категория кромки";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RougForm_KeyPress);
            this.gb_Sto.ResumeLayout(false);
            this.gb_Sto.PerformLayout();
            this.gb_kat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_kat1;
        private System.Windows.Forms.Button b_kat2;
        private System.Windows.Forms.Button b_kat3;
        private System.Windows.Forms.Label l_thickness;
        internal System.Windows.Forms.TextBox tb_thickness;
        private System.Windows.Forms.Button b_cancel;
        internal System.Windows.Forms.RadioButton rb_Sto_2007;
        internal System.Windows.Forms.RadioButton rb_Sto_2018;
        internal System.Windows.Forms.GroupBox gb_Sto;
        private System.Windows.Forms.GroupBox gb_kat;
    }
}