namespace gameclub
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.StripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComputersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TariffsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiscountsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServicesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkedHoursMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ComputersDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComputersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenu,
            this.учётToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1028, 27);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // StripMenu
            // 
            this.StripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersMenuItem,
            this.ComputersMenuItem,
            this.TariffsMenuItem,
            this.DiscountsMenuItem,
            this.ServicesMenuItem,
            this.toolStripSeparator1,
            this.ChangePasswordMenuItem});
            this.StripMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StripMenu.ForeColor = System.Drawing.Color.MediumBlue;
            this.StripMenu.Name = "StripMenu";
            this.StripMenu.Size = new System.Drawing.Size(164, 23);
            this.StripMenu.Text = "Администрирование";
            // 
            // UsersMenuItem
            // 
            this.UsersMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.UsersMenuItem.Name = "UsersMenuItem";
            this.UsersMenuItem.Size = new System.Drawing.Size(189, 24);
            this.UsersMenuItem.Text = "Пользователи...";
            this.UsersMenuItem.Click += new System.EventHandler(this.UsersMenuItem_Click);
            // 
            // ComputersMenuItem
            // 
            this.ComputersMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.ComputersMenuItem.Name = "ComputersMenuItem";
            this.ComputersMenuItem.Size = new System.Drawing.Size(189, 24);
            this.ComputersMenuItem.Text = "Компьютеры...";
            this.ComputersMenuItem.Click += new System.EventHandler(this.ComputersMenuItem_Click);
            // 
            // TariffsMenuItem
            // 
            this.TariffsMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.TariffsMenuItem.Name = "TariffsMenuItem";
            this.TariffsMenuItem.Size = new System.Drawing.Size(189, 24);
            this.TariffsMenuItem.Text = "Тарифы";
            this.TariffsMenuItem.Click += new System.EventHandler(this.TariffsMenuItem_Click);
            // 
            // DiscountsMenuItem
            // 
            this.DiscountsMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.DiscountsMenuItem.Name = "DiscountsMenuItem";
            this.DiscountsMenuItem.Size = new System.Drawing.Size(189, 24);
            this.DiscountsMenuItem.Text = "Скидки";
            this.DiscountsMenuItem.Click += new System.EventHandler(this.DiscountsMenuItem_Click);
            // 
            // ServicesMenuItem
            // 
            this.ServicesMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.ServicesMenuItem.Name = "ServicesMenuItem";
            this.ServicesMenuItem.Size = new System.Drawing.Size(189, 24);
            this.ServicesMenuItem.Text = "Доп.услуги";
            this.ServicesMenuItem.Click += new System.EventHandler(this.ServicesMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // ChangePasswordMenuItem
            // 
            this.ChangePasswordMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.ChangePasswordMenuItem.Name = "ChangePasswordMenuItem";
            this.ChangePasswordMenuItem.Size = new System.Drawing.Size(189, 24);
            this.ChangePasswordMenuItem.Text = "Сменить пароль";
            this.ChangePasswordMenuItem.Click += new System.EventHandler(this.ChangePasswordMenuItem_Click);
            // 
            // учётToolStripMenuItem
            // 
            this.учётToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkedHoursMenuItem,
            this.кассаToolStripMenuItem});
            this.учётToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.учётToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.учётToolStripMenuItem.Name = "учётToolStripMenuItem";
            this.учётToolStripMenuItem.Size = new System.Drawing.Size(54, 23);
            this.учётToolStripMenuItem.Text = "Учёт";
            // 
            // WorkedHoursMenuItem
            // 
            this.WorkedHoursMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.WorkedHoursMenuItem.Name = "WorkedHoursMenuItem";
            this.WorkedHoursMenuItem.Size = new System.Drawing.Size(215, 24);
            this.WorkedHoursMenuItem.Text = "Отработанные часы";
            this.WorkedHoursMenuItem.Click += new System.EventHandler(this.WorkedHoursMenuItem_Click);
            // 
            // кассаToolStripMenuItem
            // 
            this.кассаToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.кассаToolStripMenuItem.Name = "кассаToolStripMenuItem";
            this.кассаToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.кассаToolStripMenuItem.Text = "Кассовый отчёт";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 63);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.UserNameLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(102, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(861, 63);
            this.panel4.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(661, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.panel7.Size = new System.Drawing.Size(200, 63);
            this.panel7.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(13, 22);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(38, 19);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "имя";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(102, 63);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оператор:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.ExitButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(963, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(65, 63);
            this.panel2.TabIndex = 2;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(3, 10);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(59, 45);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenuItem,
            this.ChangeUserMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(244, 52);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitMenuItem.ForeColor = System.Drawing.Color.BlueViolet;
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(243, 24);
            this.ExitMenuItem.Text = "Выйти";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // ChangeUserMenuItem
            // 
            this.ChangeUserMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeUserMenuItem.ForeColor = System.Drawing.Color.BlueViolet;
            this.ChangeUserMenuItem.Name = "ChangeUserMenuItem";
            this.ChangeUserMenuItem.Size = new System.Drawing.Size(243, 24);
            this.ChangeUserMenuItem.Text = "Сменить пользователя";
            this.ChangeUserMenuItem.Click += new System.EventHandler(this.ChangeUserMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1028, 519);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel6.Controls.Add(this.ComputersDataGrid);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.panel6.Size = new System.Drawing.Size(1028, 519);
            this.panel6.TabIndex = 8;
            // 
            // ComputersDataGrid
            // 
            this.ComputersDataGrid.AllowUserToAddRows = false;
            this.ComputersDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ComputersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComputersDataGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ComputersDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.ComputersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComputersDataGrid.Location = new System.Drawing.Point(10, 10);
            this.ComputersDataGrid.Name = "ComputersDataGrid";
            this.ComputersDataGrid.RowHeadersVisible = false;
            this.ComputersDataGrid.RowHeadersWidth = 51;
            this.ComputersDataGrid.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.ComputersDataGrid.RowTemplate.Height = 40;
            this.ComputersDataGrid.Size = new System.Drawing.Size(1008, 499);
            this.ComputersDataGrid.TabIndex = 0;
            this.ComputersDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ComputersDataGrid_CellClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт игрового времени";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComputersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem StripMenu;
        private System.Windows.Forms.ToolStripMenuItem UsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComputersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TariffsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiscountsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkedHoursMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeUserMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView ComputersDataGrid;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ServicesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кассаToolStripMenuItem;
    }
}

