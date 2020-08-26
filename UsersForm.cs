using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class UsersForm : Form
    {
        public string connectionString;
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            ShowUsers();
        }

        private void ShowUsers()
        {
            string queryText = "SELECT * FROM userlist WHERE login<>'administrator' ORDER BY login";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "users");
            UsersDataGrid.DataSource = dataset.Tables["users"].DefaultView;
            UsersDataGrid.Columns["ID"].Visible = false;
            UsersDataGrid.Columns["login"].HeaderText = "Логин";
            UsersDataGrid.Columns["login"].Width = 120;
            UsersDataGrid.Columns["password"].Visible = false;
            UsersDataGrid.Columns["username"].HeaderText = "Имя пользователя";
            UsersDataGrid.Columns["username"].Width = 300;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (UsersDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить запись?","",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int index = UsersDataGrid.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(UsersDataGrid[0,index].Value);
                    DeleteUser(id);
                    ShowUsers();
                }
            }
            else
                MessageBox.Show("Не выбрана запись для удаления!","Ошибка!",MessageBoxButtons.OK);
        }

        private void DeleteUser(int userId)
        {
            string queryText = "DELETE FROM userlist WHERE ID="+Convert.ToString(userId);
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (UsersDataGrid.CurrentCell != null)
            {
                int index = UsersDataGrid.CurrentCell.RowIndex;
                int userId = Convert.ToInt32(UsersDataGrid[0, index].Value);
                string userLogin = Convert.ToString(UsersDataGrid[1, index].Value);
                string userPassword = Convert.ToString(UsersDataGrid[2, index].Value);
                string userName = Convert.ToString(UsersDataGrid[3, index].Value);
                AddUserForm editForm = new AddUserForm { UserLogin = userLogin, Password = userPassword, UserName = userName };
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    userLogin = editForm.UserLogin;
                    userPassword = editForm.Password;
                    userName = editForm.UserName;
                    string queryText = "UPDATE userlist SET [login]='"+userLogin+"',[password]='"+ Crypto.EncodeDecrypt(userPassword) +"',[username]='"+userName
                        +"' WHERE ID="+Convert.ToString(userId);
                    ExecuteQuery(queryText);
                    ShowUsers();
                }
            }
            else
                MessageBox.Show("Не выбран пользователь для редактирования!","Ошибка!",MessageBoxButtons.OK);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();
            addForm.ShowDialog();
            if (addForm.DialogResult==DialogResult.OK)
            {
                string userLogin = addForm.UserLogin;
                string userPassword = addForm.Password;
                string userName = addForm.UserName;
                string queryText = "INSERT INTO userlist([login],[password],username) VALUES ('"+ userLogin + "','"+ Crypto.EncodeDecrypt(userPassword) + "','"+ userName + "')";
                ExecuteQuery(queryText);
                ShowUsers();
            }
        }
    }
}
