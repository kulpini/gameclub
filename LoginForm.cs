using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class LoginForm : Form
    {
        public int userId;
        public string connectionString;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginComboBox.Text;
            string password = PasswordTextBox.Text;
            if (login == "")
                MessageBox.Show("Не выбран пользователь!", "Ошибка!", MessageBoxButtons.OK);
            else if (CheckUser(login, password))
            {
                userId = GetUserId(login);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Пользователь с таким именем/паролем не найден!", "Ошибка!", MessageBoxButtons.OK);
        }

        private bool CheckUser(string login, string password)
        {
            string queryText = "SELECT password FROM userlist WHERE login='" + login+"'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            string userpassword = Convert.ToString(command.ExecuteScalar());
            return userpassword == password;
        }

        private int GetUserId(string userlogin)
        {
            string queryText = "SELECT ID FROM userlist WHERE login='"+userlogin+"'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoginComboBox.Items.Clear();
            FillTheUserList();
        }

        private void FillTheUserList()
        {
            string queryText = "SELECT login FROM userlist ORDER BY ID";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LoginComboBox.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }
    }
}
