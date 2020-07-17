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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компьютерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скидкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(229, 213);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(560, 38);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1816, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StripMenu
            // 
            this.StripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersMenuItem,
            this.компьютерыToolStripMenuItem,
            this.прайсToolStripMenuItem,
            this.скидкиToolStripMenuItem,
            this.toolStripSeparator1,
            this.ChangePasswordMenuItem});
            this.StripMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StripMenu.ForeColor = System.Drawing.Color.MediumBlue;
            this.StripMenu.Name = "StripMenu";
            this.StripMenu.Size = new System.Drawing.Size(202, 26);
            this.StripMenu.Text = "Администрирование";
            // 
            // UsersMenuItem
            // 
            this.UsersMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.UsersMenuItem.Name = "UsersMenuItem";
            this.UsersMenuItem.Size = new System.Drawing.Size(233, 26);
            this.UsersMenuItem.Text = "Пользователи...";
            this.UsersMenuItem.Click += new System.EventHandler(this.UsersMenuItem_Click);
            // 
            // компьютерыToolStripMenuItem
            // 
            this.компьютерыToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.компьютерыToolStripMenuItem.Name = "компьютерыToolStripMenuItem";
            this.компьютерыToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.компьютерыToolStripMenuItem.Text = "Компьютеры...";
            // 
            // прайсToolStripMenuItem
            // 
            this.прайсToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.прайсToolStripMenuItem.Name = "прайсToolStripMenuItem";
            this.прайсToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.прайсToolStripMenuItem.Text = "Прайс";
            // 
            // скидкиToolStripMenuItem
            // 
            this.скидкиToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.скидкиToolStripMenuItem.Name = "скидкиToolStripMenuItem";
            this.скидкиToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.скидкиToolStripMenuItem.Text = "Скидки";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // ChangePasswordMenuItem
            // 
            this.ChangePasswordMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.ChangePasswordMenuItem.Name = "ChangePasswordMenuItem";
            this.ChangePasswordMenuItem.Size = new System.Drawing.Size(233, 26);
            this.ChangePasswordMenuItem.Text = "Сменить пароль";
            this.ChangePasswordMenuItem.Click += new System.EventHandler(this.ChangePasswordMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1816, 678);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт игрового времени";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StripMenu;
        private System.Windows.Forms.ToolStripMenuItem UsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компьютерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скидкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordMenuItem;
    }
}

