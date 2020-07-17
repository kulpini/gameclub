using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class MainForm : Form
    {
        static string pathToDb = AppDomain.CurrentDomain.BaseDirectory + "\\gameclub.mdb";
        public string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathToDb;
        public string user;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm { connectionString = this.connectionString};
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                user = loginForm.LoginComboBox.Text;
                if (user != "administrator")
                    StripMenu.Visible = false;
            }
        }

        private void ChangePasswordMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm passwordForm = new ChangePasswordForm();
            passwordForm.ShowDialog();
            if (passwordForm.DialogResult==DialogResult.OK)
            {
                string newpassword = passwordForm.NewPasswordTextBox.Text;
                ChangePassword(newpassword);
                MessageBox.Show("Пароль успешно изменён.","изменение пароля",MessageBoxButtons.OK);
            }
        }

        private void ChangePassword(string newPassword)
        {
            string queryText = "UPDATE users SET [password]='"+ newPassword + "' WHERE [login]='administrator'";
            ExecuteQuery(queryText);
        }

        private void ExecuteQuery(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UsersMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm { connectionString = this.connectionString};
            usersForm.ShowDialog();
        }
    }
}
