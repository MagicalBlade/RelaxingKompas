namespace RelaxingKompas.Windows
{
    partial class FormTolerance
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
            this.b_cancel = new System.Windows.Forms.Button();
            this.tb_Up = new System.Windows.Forms.TextBox();
            this.tb_Down = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_ok.Location = new System.Drawing.Point(134, 179);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 0;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(264, 178);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 1;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            // 
            // tb_Up
            // 
            this.tb_Up.Location = new System.Drawing.Point(238, 72);
            this.tb_Up.Name = "tb_Up";
            this.tb_Up.Size = new System.Drawing.Size(100, 20);
            this.tb_Up.TabIndex = 2;
            // 
            // tb_Down
            // 
            this.tb_Down.Location = new System.Drawing.Point(238, 114);
            this.tb_Down.Name = "tb_Down";
            this.tb_Down.Size = new System.Drawing.Size(100, 20);
            this.tb_Down.TabIndex = 2;
            // 
            // FormTolerance
            // 
            this.AcceptButton = this.b_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(510, 268);
            this.Controls.Add(this.tb_Down);
            this.Controls.Add(this.tb_Up);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Name = "FormTolerance";
            this.Text = "FormTolerance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.TextBox tb_Up;
        private System.Windows.Forms.TextBox tb_Down;
    }
}