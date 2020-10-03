namespace gameclub
{
    partial class CashReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.MainFooterPanel = new System.Windows.Forms.Panel();
            this.MainHeaderPanel = new System.Windows.Forms.Panel();
            this.GamingDataGrid = new System.Windows.Forms.DataGridView();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.DateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ServicesDataGrid = new System.Windows.Forms.DataGridView();
            this.SumLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.begin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elapsedtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tariff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.ReportPanel.SuspendLayout();
            this.MainFooterPanel.SuspendLayout();
            this.MainHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamingDataGrid)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.FooterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.PrintButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 43);
            this.panel1.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(730, 6);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(142, 29);
            this.CloseButton.TabIndex = 60;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click_1);
            // 
            // PrintButton
            // 
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrintButton.Location = new System.Drawing.Point(40, 6);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(2);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(142, 29);
            this.PrintButton.TabIndex = 59;
            this.PrintButton.Text = "Распечатать";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ReportPanel
            // 
            this.ReportPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ReportPanel.Controls.Add(this.MainFooterPanel);
            this.ReportPanel.Controls.Add(this.MainHeaderPanel);
            this.ReportPanel.Controls.Add(this.GamingDataGrid);
            this.ReportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPanel.Location = new System.Drawing.Point(0, 0);
            this.ReportPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(902, 483);
            this.ReportPanel.TabIndex = 1;
            // 
            // MainFooterPanel
            // 
            this.MainFooterPanel.Controls.Add(this.FooterPanel);
            this.MainFooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainFooterPanel.Location = new System.Drawing.Point(0, 299);
            this.MainFooterPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainFooterPanel.Name = "MainFooterPanel";
            this.MainFooterPanel.Size = new System.Drawing.Size(902, 184);
            this.MainFooterPanel.TabIndex = 60;
            // 
            // MainHeaderPanel
            // 
            this.MainHeaderPanel.Controls.Add(this.HeaderPanel);
            this.MainHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.MainHeaderPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainHeaderPanel.Name = "MainHeaderPanel";
            this.MainHeaderPanel.Size = new System.Drawing.Size(902, 70);
            this.MainHeaderPanel.TabIndex = 59;
            // 
            // GamingDataGrid
            // 
            this.GamingDataGrid.AllowUserToAddRows = false;
            this.GamingDataGrid.AllowUserToDeleteRows = false;
            this.GamingDataGrid.AllowUserToResizeColumns = false;
            this.GamingDataGrid.AllowUserToResizeRows = false;
            this.GamingDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GamingDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GamingDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GamingDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GamingDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.begin,
            this.elapsedtime,
            this.tariff,
            this.amount,
            this.uah,
            this.discount,
            this.note});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GamingDataGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.GamingDataGrid.Location = new System.Drawing.Point(3, 76);
            this.GamingDataGrid.Name = "GamingDataGrid";
            this.GamingDataGrid.ReadOnly = true;
            this.GamingDataGrid.RowHeadersVisible = false;
            this.GamingDataGrid.RowHeadersWidth = 51;
            this.GamingDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GamingDataGrid.Size = new System.Drawing.Size(892, 218);
            this.GamingDataGrid.TabIndex = 58;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.DateLabel);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(446, 70);
            this.HeaderPanel.TabIndex = 57;
            // 
            // DateLabel
            // 
            this.DateLabel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateLabel.ForeColor = System.Drawing.Color.Maroon;
            this.DateLabel.Location = new System.Drawing.Point(12, 40);
            this.DateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(424, 22);
            this.DateLabel.TabIndex = 58;
            this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 31);
            this.label1.TabIndex = 57;
            this.label1.Text = "Кассовый отчёт за";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FooterPanel
            // 
            this.FooterPanel.Controls.Add(this.label4);
            this.FooterPanel.Controls.Add(this.ServicesDataGrid);
            this.FooterPanel.Controls.Add(this.SumLabel);
            this.FooterPanel.Controls.Add(this.label6);
            this.FooterPanel.Controls.Add(this.label2);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FooterPanel.Location = new System.Drawing.Point(0, 0);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(446, 184);
            this.FooterPanel.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 24);
            this.label4.TabIndex = 68;
            this.label4.Text = "дополнительные  услуги:";
            // 
            // ServicesDataGrid
            // 
            this.ServicesDataGrid.AllowUserToAddRows = false;
            this.ServicesDataGrid.AllowUserToDeleteRows = false;
            this.ServicesDataGrid.AllowUserToResizeColumns = false;
            this.ServicesDataGrid.AllowUserToResizeRows = false;
            this.ServicesDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ServicesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicesDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ServicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDataGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServicesDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.ServicesDataGrid.Enabled = false;
            this.ServicesDataGrid.Location = new System.Drawing.Point(5, 33);
            this.ServicesDataGrid.Name = "ServicesDataGrid";
            this.ServicesDataGrid.ReadOnly = true;
            this.ServicesDataGrid.RowHeadersVisible = false;
            this.ServicesDataGrid.RowHeadersWidth = 51;
            this.ServicesDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ServicesDataGrid.Size = new System.Drawing.Size(432, 105);
            this.ServicesDataGrid.TabIndex = 67;
            // 
            // SumLabel
            // 
            this.SumLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumLabel.ForeColor = System.Drawing.Color.Maroon;
            this.SumLabel.Location = new System.Drawing.Point(227, 141);
            this.SumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SumLabel.Name = "SumLabel";
            this.SumLabel.Size = new System.Drawing.Size(96, 22);
            this.SumLabel.TabIndex = 66;
            this.SumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(328, 141);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 26);
            this.label6.TabIndex = 65;
            this.label6.Text = "грн.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(40, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Всего за день:";
            // 
            // begin
            // 
            this.begin.HeaderText = "начало";
            this.begin.Name = "begin";
            this.begin.ReadOnly = true;
            // 
            // elapsedtime
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.elapsedtime.DefaultCellStyle = dataGridViewCellStyle3;
            this.elapsedtime.HeaderText = "длит-сть";
            this.elapsedtime.MinimumWidth = 6;
            this.elapsedtime.Name = "elapsedtime";
            this.elapsedtime.ReadOnly = true;
            this.elapsedtime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.elapsedtime.Width = 80;
            // 
            // tariff
            // 
            this.tariff.HeaderText = "тариф";
            this.tariff.Name = "tariff";
            this.tariff.ReadOnly = true;
            this.tariff.Width = 250;
            // 
            // amount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.amount.HeaderText = "оплата";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 70;
            // 
            // uah
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.uah.DefaultCellStyle = dataGridViewCellStyle5;
            this.uah.HeaderText = "";
            this.uah.MinimumWidth = 6;
            this.uah.Name = "uah";
            this.uah.ReadOnly = true;
            this.uah.Width = 40;
            // 
            // discount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.discount.DefaultCellStyle = dataGridViewCellStyle6;
            this.discount.HeaderText = "скидка";
            this.discount.MinimumWidth = 6;
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Width = 125;
            // 
            // note
            // 
            this.note.HeaderText = "примечание";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 210;
            // 
            // CashReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 526);
            this.Controls.Add(this.ReportPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кассовый отчёт за выбранную дату";
            this.Load += new System.EventHandler(this.CashReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.ReportPanel.ResumeLayout(false);
            this.MainFooterPanel.ResumeLayout(false);
            this.MainHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GamingDataGrid)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.FooterPanel.ResumeLayout(false);
            this.FooterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.DataGridView GamingDataGrid;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Panel MainHeaderPanel;
        private System.Windows.Forms.Panel MainFooterPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ServicesDataGrid;
        private System.Windows.Forms.Label SumLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn begin;
        private System.Windows.Forms.DataGridViewTextBoxColumn elapsedtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tariff;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn uah;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}