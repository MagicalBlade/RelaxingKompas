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
            this.rb_Manual = new System.Windows.Forms.RadioButton();
            this.rb_TopRight = new System.Windows.Forms.RadioButton();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.gb_TypeTable = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_SpecNotWeldMark = new System.Windows.Forms.RadioButton();
            this.rb_SpecManyMarks = new System.Windows.Forms.RadioButton();
            this.rb_SpecMain = new System.Windows.Forms.RadioButton();
            this.b_examples = new System.Windows.Forms.Button();
            this.rb_SpecMainIntermediate = new System.Windows.Forms.RadioButton();
            this.rb_MMS = new System.Windows.Forms.RadioButton();
            this.rb_MMSIntermediate = new System.Windows.Forms.RadioButton();
            this.gb_InsertType.SuspendLayout();
            this.gb_TypeTable.SuspendLayout();
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
            // b_Cancel
            // 
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(326, 286);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 1;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            // 
            // gb_TypeTable
            // 
            this.gb_TypeTable.Controls.Add(this.label2);
            this.gb_TypeTable.Controls.Add(this.label1);
            this.gb_TypeTable.Controls.Add(this.rb_SpecNotWeldMark);
            this.gb_TypeTable.Controls.Add(this.rb_SpecManyMarks);
            this.gb_TypeTable.Controls.Add(this.rb_SpecMainIntermediate);
            this.gb_TypeTable.Controls.Add(this.rb_MMSIntermediate);
            this.gb_TypeTable.Controls.Add(this.rb_MMS);
            this.gb_TypeTable.Controls.Add(this.rb_SpecMain);
            this.gb_TypeTable.Location = new System.Drawing.Point(12, 93);
            this.gb_TypeTable.Name = "gb_TypeTable";
            this.gb_TypeTable.Size = new System.Drawing.Size(615, 140);
            this.gb_TypeTable.TabIndex = 2;
            this.gb_TypeTable.TabStop = false;
            this.gb_TypeTable.Text = "Выберите тип таблицы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(117, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Другие таблицы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(96, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Спецификация металла";
            // 
            // rb_SpecNotWeldMark
            // 
            this.rb_SpecNotWeldMark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_SpecNotWeldMark.AutoSize = true;
            this.rb_SpecNotWeldMark.Location = new System.Drawing.Point(395, 36);
            this.rb_SpecNotWeldMark.Name = "rb_SpecNotWeldMark";
            this.rb_SpecNotWeldMark.Size = new System.Drawing.Size(117, 23);
            this.rb_SpecNotWeldMark.TabIndex = 0;
            this.rb_SpecNotWeldMark.TabStop = true;
            this.rb_SpecNotWeldMark.Text = "Без сварных марок";
            this.rb_SpecNotWeldMark.UseVisualStyleBackColor = true;
            this.rb_SpecNotWeldMark.CheckedChanged += new System.EventHandler(this.RadioButton_Result_OK);
            // 
            // rb_SpecManyMarks
            // 
            this.rb_SpecManyMarks.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_SpecManyMarks.AutoSize = true;
            this.rb_SpecManyMarks.Location = new System.Drawing.Point(235, 36);
            this.rb_SpecManyMarks.Name = "rb_SpecManyMarks";
            this.rb_SpecManyMarks.Size = new System.Drawing.Size(154, 23);
            this.rb_SpecManyMarks.TabIndex = 0;
            this.rb_SpecManyMarks.TabStop = true;
            this.rb_SpecManyMarks.Text = "Несколько сварных марок";
            this.rb_SpecManyMarks.UseVisualStyleBackColor = true;
            this.rb_SpecManyMarks.CheckedChanged += new System.EventHandler(this.RadioButton_Result_OK);
            // 
            // rb_SpecMain
            // 
            this.rb_SpecMain.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_SpecMain.AutoSize = true;
            this.rb_SpecMain.Location = new System.Drawing.Point(6, 36);
            this.rb_SpecMain.Name = "rb_SpecMain";
            this.rb_SpecMain.Size = new System.Drawing.Size(67, 23);
            this.rb_SpecMain.TabIndex = 0;
            this.rb_SpecMain.TabStop = true;
            this.rb_SpecMain.Text = "Основная";
            this.rb_SpecMain.UseVisualStyleBackColor = true;
            this.rb_SpecMain.CheckedChanged += new System.EventHandler(this.RadioButton_Result_OK);
            // 
            // b_examples
            // 
            this.b_examples.Location = new System.Drawing.Point(221, 12);
            this.b_examples.Name = "b_examples";
            this.b_examples.Size = new System.Drawing.Size(109, 23);
            this.b_examples.TabIndex = 3;
            this.b_examples.Text = "Примеры таблиц";
            this.b_examples.UseVisualStyleBackColor = true;
            this.b_examples.Click += new System.EventHandler(this.b_examples_Click);
            // 
            // rb_SpecMainIntermediate
            // 
            this.rb_SpecMainIntermediate.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_SpecMainIntermediate.AutoSize = true;
            this.rb_SpecMainIntermediate.Location = new System.Drawing.Point(79, 36);
            this.rb_SpecMainIntermediate.Name = "rb_SpecMainIntermediate";
            this.rb_SpecMainIntermediate.Size = new System.Drawing.Size(149, 23);
            this.rb_SpecMainIntermediate.TabIndex = 0;
            this.rb_SpecMainIntermediate.TabStop = true;
            this.rb_SpecMainIntermediate.Text = "Основная промежуточная";
            this.rb_SpecMainIntermediate.UseVisualStyleBackColor = true;
            this.rb_SpecMainIntermediate.CheckedChanged += new System.EventHandler(this.RadioButton_Result_OK);
            // 
            // rb_MMS
            // 
            this.rb_MMS.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_MMS.AutoSize = true;
            this.rb_MMS.Location = new System.Drawing.Point(6, 96);
            this.rb_MMS.Name = "rb_MMS";
            this.rb_MMS.Size = new System.Drawing.Size(42, 23);
            this.rb_MMS.TabIndex = 0;
            this.rb_MMS.TabStop = true;
            this.rb_MMS.Text = "ММС";
            this.rb_MMS.UseVisualStyleBackColor = true;
            this.rb_MMS.CheckedChanged += new System.EventHandler(this.RadioButton_Result_OK);
            // 
            // rb_MMSIntermediate
            // 
            this.rb_MMSIntermediate.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_MMSIntermediate.AutoSize = true;
            this.rb_MMSIntermediate.Location = new System.Drawing.Point(54, 96);
            this.rb_MMSIntermediate.Name = "rb_MMSIntermediate";
            this.rb_MMSIntermediate.Size = new System.Drawing.Size(124, 23);
            this.rb_MMSIntermediate.TabIndex = 0;
            this.rb_MMSIntermediate.TabStop = true;
            this.rb_MMSIntermediate.Text = "ММС промежуточная";
            this.rb_MMSIntermediate.UseVisualStyleBackColor = true;
            this.rb_MMSIntermediate.CheckedChanged += new System.EventHandler(this.RadioButton_Result_OK);
            // 
            // FormInsertTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(639, 312);
            this.Controls.Add(this.b_examples);
            this.Controls.Add(this.gb_TypeTable);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.gb_InsertType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInsertTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.gb_InsertType.ResumeLayout(false);
            this.gb_InsertType.PerformLayout();
            this.gb_TypeTable.ResumeLayout(false);
            this.gb_TypeTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.RadioButton rb_Manual;
        internal System.Windows.Forms.RadioButton rb_TopRight;
        private System.Windows.Forms.Button b_Cancel;
        internal System.Windows.Forms.GroupBox gb_InsertType;
        internal System.Windows.Forms.RadioButton rb_SpecMain;
        internal System.Windows.Forms.RadioButton rb_SpecNotWeldMark;
        internal System.Windows.Forms.RadioButton rb_SpecManyMarks;
        internal System.Windows.Forms.GroupBox gb_TypeTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_examples;
        internal System.Windows.Forms.RadioButton rb_SpecMainIntermediate;
        internal System.Windows.Forms.RadioButton rb_MMS;
        internal System.Windows.Forms.RadioButton rb_MMSIntermediate;
    }
}