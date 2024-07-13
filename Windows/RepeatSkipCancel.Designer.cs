namespace RelaxingKompas.Windows
{
    partial class RepeatSkipCancel
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
            this.b_Retry = new System.Windows.Forms.Button();
            this.b_Ignore = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_Retry
            // 
            this.b_Retry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.b_Retry.Location = new System.Drawing.Point(31, 13);
            this.b_Retry.Name = "b_Retry";
            this.b_Retry.Size = new System.Drawing.Size(75, 23);
            this.b_Retry.TabIndex = 0;
            this.b_Retry.Text = "Повторить";
            this.b_Retry.UseVisualStyleBackColor = true;
            // 
            // b_Ignore
            // 
            this.b_Ignore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.b_Ignore.Location = new System.Drawing.Point(138, 13);
            this.b_Ignore.Name = "b_Ignore";
            this.b_Ignore.Size = new System.Drawing.Size(75, 23);
            this.b_Ignore.TabIndex = 1;
            this.b_Ignore.Text = "Пропустить";
            this.b_Ignore.UseVisualStyleBackColor = true;
            // 
            // b_Cancel
            // 
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(245, 13);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 2;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            // 
            // RepeatSkipCancel
            // 
            this.AcceptButton = this.b_Retry;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(350, 49);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_Ignore);
            this.Controls.Add(this.b_Retry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "RepeatSkipCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RepeatSkipCancel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_Retry;
        private System.Windows.Forms.Button b_Ignore;
        private System.Windows.Forms.Button b_Cancel;
    }
}