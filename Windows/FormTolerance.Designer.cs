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
            this.components = new System.ComponentModel.Container();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.tb_Up = new System.Windows.Forms.TextBox();
            this.tb_Down = new System.Windows.Forms.TextBox();
            this.l_Up = new System.Windows.Forms.Label();
            this.l_Down = new System.Windows.Forms.Label();
            this.b_plusminus = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.l_history = new System.Windows.Forms.Label();
            this.lb_history = new System.Windows.Forms.ListBox();
            this.b_clear_history = new System.Windows.Forms.Button();
            this.b_auto = new System.Windows.Forms.Button();
            this.b_clear_tolerance = new System.Windows.Forms.Button();
            this.lb_tolerance_default = new System.Windows.Forms.ListBox();
            this.l_tolerance_default = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_ok.Location = new System.Drawing.Point(119, 100);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 3;
            this.b_ok.Text = "Применить";
            this.b_ok.UseVisualStyleBackColor = true;
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(200, 100);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 4;
            this.b_cancel.Text = "Отменить";
            this.b_cancel.UseVisualStyleBackColor = true;
            // 
            // tb_Up
            // 
            this.tb_Up.Location = new System.Drawing.Point(175, 48);
            this.tb_Up.Name = "tb_Up";
            this.tb_Up.Size = new System.Drawing.Size(100, 20);
            this.tb_Up.TabIndex = 0;
            this.tb_Up.TextChanged += new System.EventHandler(this.tb_Up_TextChanged);
            this.tb_Up.Enter += new System.EventHandler(this.tb_Up_Enter);
            this.tb_Up.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Up_KeyDown);
            // 
            // tb_Down
            // 
            this.tb_Down.Location = new System.Drawing.Point(175, 73);
            this.tb_Down.Name = "tb_Down";
            this.tb_Down.Size = new System.Drawing.Size(100, 20);
            this.tb_Down.TabIndex = 1;
            this.tb_Down.TextChanged += new System.EventHandler(this.tb_Down_TextChanged);
            this.tb_Down.Enter += new System.EventHandler(this.tb_Down_Enter);
            this.tb_Down.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Down_KeyDown);
            // 
            // l_Up
            // 
            this.l_Up.AutoSize = true;
            this.l_Up.Location = new System.Drawing.Point(119, 52);
            this.l_Up.Name = "l_Up";
            this.l_Up.Size = new System.Drawing.Size(49, 13);
            this.l_Up.TabIndex = 5;
            this.l_Up.Text = "Верхнее";
            // 
            // l_Down
            // 
            this.l_Down.AutoSize = true;
            this.l_Down.Location = new System.Drawing.Point(119, 77);
            this.l_Down.Name = "l_Down";
            this.l_Down.Size = new System.Drawing.Size(47, 13);
            this.l_Down.TabIndex = 5;
            this.l_Down.Text = "Нижнее";
            // 
            // b_plusminus
            // 
            this.b_plusminus.Location = new System.Drawing.Point(281, 54);
            this.b_plusminus.Name = "b_plusminus";
            this.b_plusminus.Size = new System.Drawing.Size(32, 32);
            this.b_plusminus.TabIndex = 6;
            this.b_plusminus.Text = "+/-";
            this.b_plusminus.UseVisualStyleBackColor = true;
            this.b_plusminus.Click += new System.EventHandler(this.b_plusminus_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // l_history
            // 
            this.l_history.AutoSize = true;
            this.l_history.Location = new System.Drawing.Point(371, 9);
            this.l_history.Name = "l_history";
            this.l_history.Size = new System.Drawing.Size(50, 13);
            this.l_history.TabIndex = 10;
            this.l_history.Text = "История";
            // 
            // lb_history
            // 
            this.lb_history.FormattingEnabled = true;
            this.lb_history.Location = new System.Drawing.Point(349, 28);
            this.lb_history.Name = "lb_history";
            this.lb_history.Size = new System.Drawing.Size(95, 121);
            this.lb_history.TabIndex = 11;
            this.toolTip1.SetToolTip(this.lb_history, "История вводимых допусков. Кликните дважды мышкой на нужном.");
            this.lb_history.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_history_MouseDoubleClick);
            // 
            // b_clear_history
            // 
            this.b_clear_history.Location = new System.Drawing.Point(359, 152);
            this.b_clear_history.Name = "b_clear_history";
            this.b_clear_history.Size = new System.Drawing.Size(75, 23);
            this.b_clear_history.TabIndex = 12;
            this.b_clear_history.Text = "Очистить";
            this.toolTip1.SetToolTip(this.b_clear_history, "Очистить историю допусков.");
            this.b_clear_history.UseVisualStyleBackColor = true;
            this.b_clear_history.Click += new System.EventHandler(this.b_clear_history_Click);
            // 
            // b_auto
            // 
            this.b_auto.Location = new System.Drawing.Point(119, 12);
            this.b_auto.Name = "b_auto";
            this.b_auto.Size = new System.Drawing.Size(75, 23);
            this.b_auto.TabIndex = 13;
            this.b_auto.Text = "Авто";
            this.toolTip1.SetToolTip(this.b_auto, "Автоматический подбор допуска. Горячая клавиша - А");
            this.b_auto.UseVisualStyleBackColor = true;
            this.b_auto.Click += new System.EventHandler(this.b_auto_Click);
            // 
            // b_clear_tolerance
            // 
            this.b_clear_tolerance.Location = new System.Drawing.Point(200, 12);
            this.b_clear_tolerance.Name = "b_clear_tolerance";
            this.b_clear_tolerance.Size = new System.Drawing.Size(75, 23);
            this.b_clear_tolerance.TabIndex = 14;
            this.b_clear_tolerance.Text = "Отключить";
            this.toolTip1.SetToolTip(this.b_clear_tolerance, "Отключить допуск. Горячая клавиша - О");
            this.b_clear_tolerance.UseVisualStyleBackColor = true;
            this.b_clear_tolerance.Click += new System.EventHandler(this.b_clear_tolerance_Click);
            // 
            // lb_tolerance_default
            // 
            this.lb_tolerance_default.FormattingEnabled = true;
            this.lb_tolerance_default.Location = new System.Drawing.Point(12, 28);
            this.lb_tolerance_default.Name = "lb_tolerance_default";
            this.lb_tolerance_default.Size = new System.Drawing.Size(84, 147);
            this.lb_tolerance_default.TabIndex = 15;
            this.toolTip1.SetToolTip(this.lb_tolerance_default, "Стандартные допуски. Кликните дважды мышкой на нужном.");
            this.lb_tolerance_default.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_tolerance_default_MouseDoubleClick);
            // 
            // l_tolerance_default
            // 
            this.l_tolerance_default.AutoSize = true;
            this.l_tolerance_default.Location = new System.Drawing.Point(17, 9);
            this.l_tolerance_default.Name = "l_tolerance_default";
            this.l_tolerance_default.Size = new System.Drawing.Size(74, 13);
            this.l_tolerance_default.TabIndex = 10;
            this.l_tolerance_default.Text = "Стандартные";
            // 
            // mainBindingSource
            // 
            this.mainBindingSource.DataSource = typeof(RelaxingKompas.Main);
            // 
            // mainBindingSource1
            // 
            this.mainBindingSource1.DataSource = typeof(RelaxingKompas.Main);
            // 
            // FormTolerance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(456, 184);
            this.Controls.Add(this.lb_tolerance_default);
            this.Controls.Add(this.b_clear_tolerance);
            this.Controls.Add(this.b_auto);
            this.Controls.Add(this.b_clear_history);
            this.Controls.Add(this.lb_history);
            this.Controls.Add(this.l_tolerance_default);
            this.Controls.Add(this.l_history);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.b_plusminus);
            this.Controls.Add(this.l_Down);
            this.Controls.Add(this.l_Up);
            this.Controls.Add(this.tb_Down);
            this.Controls.Add(this.tb_Up);
            this.Controls.Add(this.b_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FormTolerance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Допуск/припуск";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormTolerance_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource1)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource mainBindingSource;
        private System.Windows.Forms.BindingSource mainBindingSource1;
        private System.Windows.Forms.Label l_history;
        internal System.Windows.Forms.ListBox lb_history;
        private System.Windows.Forms.Button b_clear_history;
        private System.Windows.Forms.Button b_auto;
        private System.Windows.Forms.Button b_clear_tolerance;
        internal System.Windows.Forms.ListBox lb_tolerance_default;
        private System.Windows.Forms.Label l_tolerance_default;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}