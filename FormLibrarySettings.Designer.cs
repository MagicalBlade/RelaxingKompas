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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_SaveFragment = new System.Windows.Forms.CheckBox();
            this.cb_SaveDxf = new System.Windows.Forms.CheckBox();
            this.cb_CloseDrawing = new System.Windows.Forms.CheckBox();
            this.cb_CloseFragment = new System.Windows.Forms.CheckBox();
            this.b_save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_SaveFragment);
            this.groupBox1.Controls.Add(this.cb_SaveDxf);
            this.groupBox1.Controls.Add(this.cb_CloseDrawing);
            this.groupBox1.Controls.Add(this.cb_CloseFragment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общие";
            // 
            // cb_SaveFragment
            // 
            this.cb_SaveFragment.AutoSize = true;
            this.cb_SaveFragment.Location = new System.Drawing.Point(6, 89);
            this.cb_SaveFragment.Name = "cb_SaveFragment";
            this.cb_SaveFragment.Size = new System.Drawing.Size(132, 17);
            this.cb_SaveFragment.TabIndex = 1;
            this.cb_SaveFragment.Text = "Сохранять фрагмент";
            this.cb_SaveFragment.UseVisualStyleBackColor = true;
            // 
            // cb_SaveDxf
            // 
            this.cb_SaveDxf.AutoSize = true;
            this.cb_SaveDxf.Location = new System.Drawing.Point(7, 66);
            this.cb_SaveDxf.Name = "cb_SaveDxf";
            this.cb_SaveDxf.Size = new System.Drawing.Size(96, 17);
            this.cb_SaveDxf.TabIndex = 0;
            this.cb_SaveDxf.Text = "Сохранять dxf";
            this.cb_SaveDxf.UseVisualStyleBackColor = true;
            // 
            // cb_CloseDrawing
            // 
            this.cb_CloseDrawing.AutoSize = true;
            this.cb_CloseDrawing.Location = new System.Drawing.Point(7, 43);
            this.cb_CloseDrawing.Name = "cb_CloseDrawing";
            this.cb_CloseDrawing.Size = new System.Drawing.Size(109, 17);
            this.cb_CloseDrawing.TabIndex = 0;
            this.cb_CloseDrawing.Text = "Закрыть чертеж";
            this.cb_CloseDrawing.UseVisualStyleBackColor = true;
            // 
            // cb_CloseFragment
            // 
            this.cb_CloseFragment.AutoSize = true;
            this.cb_CloseFragment.Location = new System.Drawing.Point(7, 20);
            this.cb_CloseFragment.Name = "cb_CloseFragment";
            this.cb_CloseFragment.Size = new System.Drawing.Size(123, 17);
            this.cb_CloseFragment.TabIndex = 0;
            this.cb_CloseFragment.Text = "Закрыть фрагмент";
            this.cb_CloseFragment.UseVisualStyleBackColor = true;
            // 
            // b_save
            // 
            this.b_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_save.Location = new System.Drawing.Point(67, 164);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 0;
            this.b_save.Text = "ОК";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // FormLibrarySettings
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 199);
            this.ControlBox = false;
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "FormLibrarySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_save;
        internal System.Windows.Forms.CheckBox cb_CloseFragment;
        internal System.Windows.Forms.CheckBox cb_CloseDrawing;
        internal System.Windows.Forms.CheckBox cb_SaveFragment;
        internal System.Windows.Forms.CheckBox cb_SaveDxf;
    }
}