namespace RelaxingKompas
{
    partial class FormRegistration
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
            this.tb_RKey = new System.Windows.Forms.TextBox();
            this.b_Registration = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.l_eror = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_RKey
            // 
            this.tb_RKey.Location = new System.Drawing.Point(52, 12);
            this.tb_RKey.Name = "tb_RKey";
            this.tb_RKey.Size = new System.Drawing.Size(257, 20);
            this.tb_RKey.TabIndex = 0;
            this.tb_RKey.Tag = "Введите ключ";
            // 
            // b_Registration
            // 
            this.b_Registration.Location = new System.Drawing.Point(219, 38);
            this.b_Registration.Name = "b_Registration";
            this.b_Registration.Size = new System.Drawing.Size(90, 23);
            this.b_Registration.TabIndex = 1;
            this.b_Registration.Text = "Регистрация";
            this.b_Registration.UseVisualStyleBackColor = true;
            this.b_Registration.Click += new System.EventHandler(this.b_Registration_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ключ:";
            // 
            // l_eror
            // 
            this.l_eror.AutoSize = true;
            this.l_eror.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_eror.Location = new System.Drawing.Point(49, 38);
            this.l_eror.Name = "l_eror";
            this.l_eror.Size = new System.Drawing.Size(0, 17);
            this.l_eror.TabIndex = 3;
            // 
            // FormRegistration
            // 
            this.AcceptButton = this.b_Registration;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 70);
            this.Controls.Add(this.l_eror);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Registration);
            this.Controls.Add(this.tb_RKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_RKey;
        private System.Windows.Forms.Button b_Registration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_eror;
    }
}