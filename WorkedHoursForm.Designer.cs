namespace gameclub
{
    partial class WorkedHoursForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkedHoursForm));
            this.UserNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.YearUpDown = new System.Windows.Forms.NumericUpDown();
            this.CalcHoursButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PeriodLabel = new System.Windows.Forms.Label();
            this.HoursLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.YearUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameComboBox
            // 
            this.UserNameComboBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameComboBox.FormattingEnabled = true;
            this.UserNameComboBox.Location = new System.Drawing.Point(153, 27);
            this.UserNameComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserNameComboBox.Name = "UserNameComboBox";
            this.UserNameComboBox.Size = new System.Drawing.Size(311, 28);
            this.UserNameComboBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пользователь:";
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Items.AddRange(new object[] {
            "январь",
            "февраль",
            "март",
            "апрель",
            "май",
            "июнь",
            "июль",
            "август",
            "сентябрь",
            "октябрь",
            "ноябрь",
            "декабрь"});
            this.MonthComboBox.Location = new System.Drawing.Point(124, 73);
            this.MonthComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(157, 28);
            this.MonthComboBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "месяц:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "год:";
            // 
            // YearUpDown
            // 
            this.YearUpDown.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearUpDown.Location = new System.Drawing.Point(352, 73);
            this.YearUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.YearUpDown.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.YearUpDown.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.YearUpDown.Name = "YearUpDown";
            this.YearUpDown.Size = new System.Drawing.Size(62, 29);
            this.YearUpDown.TabIndex = 13;
            this.YearUpDown.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // CalcHoursButton
            // 
            this.CalcHoursButton.FlatAppearance.BorderSize = 0;
            this.CalcHoursButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalcHoursButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalcHoursButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.CalcHoursButton.Location = new System.Drawing.Point(177, 110);
            this.CalcHoursButton.Name = "CalcHoursButton";
            this.CalcHoursButton.Size = new System.Drawing.Size(139, 44);
            this.CalcHoursButton.TabIndex = 14;
            this.CalcHoursButton.Text = "Показать";
            this.CalcHoursButton.UseVisualStyleBackColor = true;
            this.CalcHoursButton.Click += new System.EventHandler(this.CalcHoursButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.HoursLabel);
            this.groupBox1.Controls.Add(this.PeriodLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(9, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 116);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // PeriodLabel
            // 
            this.PeriodLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.PeriodLabel.Location = new System.Drawing.Point(6, 16);
            this.PeriodLabel.Name = "PeriodLabel";
            this.PeriodLabel.Size = new System.Drawing.Size(451, 27);
            this.PeriodLabel.TabIndex = 17;
            this.PeriodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HoursLabel
            // 
            this.HoursLabel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HoursLabel.Location = new System.Drawing.Point(208, 66);
            this.HoursLabel.Name = "HoursLabel";
            this.HoursLabel.Size = new System.Drawing.Size(74, 27);
            this.HoursLabel.TabIndex = 21;
            this.HoursLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(299, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 20;
            this.label5.Text = "часов";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(72, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "отработано";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkedHoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CalcHoursButton);
            this.Controls.Add(this.YearUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MonthComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserNameComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkedHoursForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт отработанных часов";
            this.Load += new System.EventHandler(this.WorkedHoursForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YearUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox UserNameComboBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown YearUpDown;
        private System.Windows.Forms.Button CalcHoursButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label HoursLabel;
        private System.Windows.Forms.Label PeriodLabel;
        private System.Windows.Forms.Label label5;
    }
}