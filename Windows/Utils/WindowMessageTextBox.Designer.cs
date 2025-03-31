namespace RelaxingKompas.Windows.Utils
{
    partial class WindowMessageTextBox
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
            this.tb_str = new System.Windows.Forms.TextBox();
            this.b_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_str
            // 
            this.tb_str.AcceptsReturn = true;
            this.tb_str.Location = new System.Drawing.Point(12, 12);
            this.tb_str.Multiline = true;
            this.tb_str.Name = "tb_str";
            this.tb_str.ReadOnly = true;
            this.tb_str.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_str.Size = new System.Drawing.Size(200, 150);
            this.tb_str.TabIndex = 1;
            // 
            // b_OK
            // 
            this.b_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_OK.Location = new System.Drawing.Point(75, 168);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 23);
            this.b_OK.TabIndex = 0;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = true;
            // 
            // WindowMessageTextBox
            // 
            this.AcceptButton = this.b_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 202);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.tb_str);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "WindowMessageTextBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowMessageTextBox_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tb_str;
        internal System.Windows.Forms.Button b_OK;
    }
}