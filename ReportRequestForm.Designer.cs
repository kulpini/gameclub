namespace gameclub
{
    partial class ReportRequestForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ReportDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MakeReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кассовый отчёт за";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportDatePicker
            // 
            this.ReportDatePicker.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportDatePicker.Location = new System.Drawing.Point(120, 68);
            this.ReportDatePicker.Name = "ReportDatePicker";
            this.ReportDatePicker.Size = new System.Drawing.Size(242, 34);
            this.ReportDatePicker.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.ExitButton.Location = new System.Drawing.Point(302, 178);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(202, 54);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Отмена";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MakeReportButton
            // 
            this.MakeReportButton.FlatAppearance.BorderSize = 0;
            this.MakeReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MakeReportButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MakeReportButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.MakeReportButton.Location = new System.Drawing.Point(36, 178);
            this.MakeReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.MakeReportButton.Name = "MakeReportButton";
            this.MakeReportButton.Size = new System.Drawing.Size(204, 54);
            this.MakeReportButton.TabIndex = 8;
            this.MakeReportButton.Text = "Сформировать";
            this.MakeReportButton.UseVisualStyleBackColor = true;
            this.MakeReportButton.Click += new System.EventHandler(this.MakeReportButton_Click);
            // 
            // ReportRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 243);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MakeReportButton);
            this.Controls.Add(this.ReportDatePicker);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кассовый отчёт";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ReportDatePicker;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MakeReportButton;
    }
}