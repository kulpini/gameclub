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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SumLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.GamingDataGrid = new System.Windows.Forms.DataGridView();
            this.elapsedtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicesDataGrid = new System.Windows.Forms.DataGridView();
            this.DateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamingDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SumLabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 580);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 70);
            this.panel1.TabIndex = 0;
            // 
            // SumLabel
            // 
            this.SumLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumLabel.ForeColor = System.Drawing.Color.Maroon;
            this.SumLabel.Location = new System.Drawing.Point(525, 17);
            this.SumLabel.Name = "SumLabel";
            this.SumLabel.Size = new System.Drawing.Size(128, 27);
            this.SumLabel.TabIndex = 58;
            this.SumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(659, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 27);
            this.label6.TabIndex = 57;
            this.label6.Text = "грн.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(317, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 26);
            this.label2.TabIndex = 49;
            this.label2.Text = "Всего за день:";
            // 
            // ReportPanel
            // 
            this.ReportPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ReportPanel.Controls.Add(this.GamingDataGrid);
            this.ReportPanel.Controls.Add(this.ServicesDataGrid);
            this.ReportPanel.Controls.Add(this.DateLabel);
            this.ReportPanel.Controls.Add(this.label1);
            this.ReportPanel.Controls.Add(this.label4);
            this.ReportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPanel.Location = new System.Drawing.Point(0, 0);
            this.ReportPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(733, 580);
            this.ReportPanel.TabIndex = 1;
            // 
            // GamingDataGrid
            // 
            this.GamingDataGrid.AllowUserToAddRows = false;
            this.GamingDataGrid.AllowUserToDeleteRows = false;
            this.GamingDataGrid.AllowUserToResizeColumns = false;
            this.GamingDataGrid.AllowUserToResizeRows = false;
            this.GamingDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GamingDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GamingDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GamingDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GamingDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GamingDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elapsedtime,
            this.amount,
            this.uah,
            this.discount,
            this.note});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GamingDataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.GamingDataGrid.Location = new System.Drawing.Point(13, 89);
            this.GamingDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GamingDataGrid.Name = "GamingDataGrid";
            this.GamingDataGrid.ReadOnly = true;
            this.GamingDataGrid.RowHeadersVisible = false;
            this.GamingDataGrid.RowHeadersWidth = 51;
            this.GamingDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GamingDataGrid.Size = new System.Drawing.Size(704, 274);
            this.GamingDataGrid.TabIndex = 58;
            // 
            // elapsedtime
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.elapsedtime.DefaultCellStyle = dataGridViewCellStyle2;
            this.elapsedtime.HeaderText = "время";
            this.elapsedtime.MinimumWidth = 6;
            this.elapsedtime.Name = "elapsedtime";
            this.elapsedtime.ReadOnly = true;
            this.elapsedtime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.elapsedtime.Width = 80;
            // 
            // amount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.amount.HeaderText = "оплата";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 70;
            // 
            // uah
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.uah.DefaultCellStyle = dataGridViewCellStyle4;
            this.uah.HeaderText = "";
            this.uah.MinimumWidth = 6;
            this.uah.Name = "uah";
            this.uah.ReadOnly = true;
            this.uah.Width = 40;
            // 
            // discount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.discount.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServicesDataGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.ServicesDataGrid.Enabled = false;
            this.ServicesDataGrid.Location = new System.Drawing.Point(13, 398);
            this.ServicesDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServicesDataGrid.Name = "ServicesDataGrid";
            this.ServicesDataGrid.ReadOnly = true;
            this.ServicesDataGrid.RowHeadersVisible = false;
            this.ServicesDataGrid.RowHeadersWidth = 51;
            this.ServicesDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ServicesDataGrid.Size = new System.Drawing.Size(567, 165);
            this.ServicesDataGrid.TabIndex = 57;
            // 
            // DateLabel
            // 
            this.DateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateLabel.ForeColor = System.Drawing.Color.Maroon;
            this.DateLabel.Location = new System.Drawing.Point(15, 37);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(703, 27);
            this.DateLabel.TabIndex = 55;
            this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(703, 26);
            this.label1.TabIndex = 54;
            this.label1.Text = "Кассовый отчёт за";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(15, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 26);
            this.label4.TabIndex = 49;
            this.label4.Text = "дополнительные  услуги:";
            // 
            // CashReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 650);
            this.Controls.Add(this.ReportPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кассовый отчёт за выбранную дату";
            this.Load += new System.EventHandler(this.CashReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ReportPanel.ResumeLayout(false);
            this.ReportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamingDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DataGridView ServicesDataGrid;
        private System.Windows.Forms.Label SumLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GamingDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn elapsedtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn uah;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}