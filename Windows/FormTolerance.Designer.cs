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
            this.l_Up = new System.Windows.Forms.Label();
            this.l_Down = new System.Windows.Forms.Label();
            this.b_plusminus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_ok.Location = new System.Drawing.Point(137, 128);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 3;
            this.b_ok.Text = "Применить";
            this.b_ok.UseVisualStyleBackColor = true;
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(218, 128);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 4;
            this.b_cancel.Text = "Отменить";
            this.b_cancel.UseVisualStyleBackColor = true;
            // 
            // tb_Up
            // 
            this.tb_Up.Location = new System.Drawing.Point(218, 76);
            this.tb_Up.Name = "tb_Up";
            this.tb_Up.Size = new System.Drawing.Size(100, 20);
            this.tb_Up.TabIndex = 0;
            this.tb_Up.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Up_KeyDown);
            this.tb_Up.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Up_KeyPress);
            this.tb_Up.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_Up_KeyUp);
            this.tb_Up.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tb_Up_PreviewKeyDown);
            // 
            // tb_Down
            // 
            this.tb_Down.Location = new System.Drawing.Point(218, 102);
            this.tb_Down.Name = "tb_Down";
            this.tb_Down.Size = new System.Drawing.Size(100, 20);
            this.tb_Down.TabIndex = 1;
            // 
            // l_Up
            // 
            this.l_Up.AutoSize = true;
            this.l_Up.Location = new System.Drawing.Point(98, 79);
            this.l_Up.Name = "l_Up";
            this.l_Up.Size = new System.Drawing.Size(114, 13);
            this.l_Up.TabIndex = 5;
            this.l_Up.Text = "Верхнее отклонение:";
            // 
            // l_Down
            // 
            this.l_Down.AutoSize = true;
            this.l_Down.Location = new System.Drawing.Point(100, 105);
            this.l_Down.Name = "l_Down";
            this.l_Down.Size = new System.Drawing.Size(112, 13);
            this.l_Down.TabIndex = 5;
            this.l_Down.Text = "Нижнее отклонение:";
            // 
            // b_plusminus
            // 
            this.b_plusminus.Location = new System.Drawing.Point(346, 89);
            this.b_plusminus.Name = "b_plusminus";
            this.b_plusminus.Size = new System.Drawing.Size(75, 23);
            this.b_plusminus.TabIndex = 6;
            this.b_plusminus.Text = "+/-";
            this.b_plusminus.UseVisualStyleBackColor = true;
            this.b_plusminus.Click += new System.EventHandler(this.b_plusminus_Click);
            // 
            // FormTolerance
            // 
            this.AcceptButton = this.b_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(510, 268);
            this.Controls.Add(this.b_plusminus);
            this.Controls.Add(this.l_Down);
            this.Controls.Add(this.l_Up);
            this.Controls.Add(this.tb_Down);
            this.Controls.Add(this.tb_Up);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTolerance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Допуск/припуск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        internal System.Windows.Forms.TextBox tb_Up;
        internal System.Windows.Forms.TextBox tb_Down;
        private System.Windows.Forms.Label l_Up;
        private System.Windows.Forms.Label l_Down;
        private System.Windows.Forms.Button b_plusminus;
    }
}