namespace RelaxingKompas.Windows
{
    partial class FormInsertTable
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
            this.gb_InsertType = new System.Windows.Forms.GroupBox();
            this.rb_TopRight = new System.Windows.Forms.RadioButton();
            this.rb_Manual = new System.Windows.Forms.RadioButton();
            this.b_OK = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.gb_InsertType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_InsertType
            // 
            this.gb_InsertType.Controls.Add(this.rb_Manual);
            this.gb_InsertType.Controls.Add(this.rb_TopRight);
            this.gb_InsertType.Location = new System.Drawing.Point(12, 12);
            this.gb_InsertType.Name = "gb_InsertType";
            this.gb_InsertType.Size = new System.Drawing.Size(203, 75);
            this.gb_InsertType.TabIndex = 0;
            this.gb_InsertType.TabStop = false;
            this.gb_InsertType.Text = "Разместить таблицу";
            // 
            // rb_TopRight
            // 
            this.rb_TopRight.AutoSize = true;
            this.rb_TopRight.Checked = true;
            this.rb_TopRight.Location = new System.Drawing.Point(6, 19);
            this.rb_TopRight.Name = "rb_TopRight";
            this.rb_TopRight.Size = new System.Drawing.Size(179, 17);
            this.rb_TopRight.TabIndex = 0;
            this.rb_TopRight.TabStop = true;
            this.rb_TopRight.Text = "Правый верхний угол чертежа";
            this.rb_TopRight.UseVisualStyleBackColor = true;
            // 
            // rb_Manual
            // 
            this.rb_Manual.AutoSize = true;
            this.rb_Manual.Location = new System.Drawing.Point(6, 42);
            this.rb_Manual.Name = "rb_Manual";
            this.rb_Manual.Size = new System.Drawing.Size(98, 17);
            this.rb_Manual.TabIndex = 0;
            this.rb_Manual.Text = "Указать точку";
            this.rb_Manual.UseVisualStyleBackColor = true;
            // 
            // b_OK
            // 
            this.b_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_OK.Location = new System.Drawing.Point(121, 315);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 23);
            this.b_OK.TabIndex = 1;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = true;
            // 
            // b_Cancel
            // 
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(278, 315);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 1;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            // 
            // FormInsertTable
            // 
            this.AcceptButton = this.b_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.gb_InsertType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInsertTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.gb_InsertType.ResumeLayout(false);
            this.gb_InsertType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.RadioButton rb_Manual;
        internal System.Windows.Forms.RadioButton rb_TopRight;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.Button b_Cancel;
        internal System.Windows.Forms.GroupBox gb_InsertType;
    }
}