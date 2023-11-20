namespace RelaxingKompas.Windows
{
    partial class FormPlaceSymbolHole
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
            this.b_canscel = new System.Windows.Forms.Button();
            this.b_circle = new System.Windows.Forms.Button();
            this.b_center = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_canscel
            // 
            this.b_canscel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_canscel.Location = new System.Drawing.Point(232, 12);
            this.b_canscel.Name = "b_canscel";
            this.b_canscel.Size = new System.Drawing.Size(83, 23);
            this.b_canscel.TabIndex = 3;
            this.b_canscel.Text = "Отмена";
            this.b_canscel.UseVisualStyleBackColor = true;
            // 
            // b_circle
            // 
            this.b_circle.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_circle.Location = new System.Drawing.Point(12, 12);
            this.b_circle.Name = "b_circle";
            this.b_circle.Size = new System.Drawing.Size(83, 23);
            this.b_circle.TabIndex = 0;
            this.b_circle.Text = "Окружности";
            this.b_circle.UseVisualStyleBackColor = true;
            this.b_circle.Click += new System.EventHandler(this.b_circle_Click);
            // 
            // b_center
            // 
            this.b_center.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_center.Location = new System.Drawing.Point(122, 12);
            this.b_center.Name = "b_center";
            this.b_center.Size = new System.Drawing.Size(83, 23);
            this.b_center.TabIndex = 1;
            this.b_center.Text = "Центр";
            this.b_center.UseVisualStyleBackColor = true;
            this.b_center.Click += new System.EventHandler(this.b_center_Click);
            // 
            // FormPlaceSymbolHole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_canscel;
            this.ClientSize = new System.Drawing.Size(339, 51);
            this.Controls.Add(this.b_center);
            this.Controls.Add(this.b_circle);
            this.Controls.Add(this.b_canscel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPlaceSymbolHole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Тип элемента";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_canscel;
        private System.Windows.Forms.Button b_circle;
        private System.Windows.Forms.Button b_center;
    }
}