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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsOldPasswordCorrect())
                if (NewPasswordTextBox.Text.Trim() == "")
                    MessageBox.Show("Внимание! Не задан новый пароль!","Ошибка!",MessageBoxButtons.OK);
                else
                {
                    if (NewPasswordConfirmed())
                        this.DialogResult = DialogResult.OK;
                    else
                        MessageBox.Show("Ошибка подтверждения нового пароля!", "Ошибка!", MessageBoxButtons.OK);
                }
            else
                MessageBox.Show("Введён неверный текущий пароль!", "Ошибка!", MessageBoxButtons.OK);
        }

        private bool IsOldPasswordCorrect()
        {
            string oldpassword = OldPasswordTextBox.Text;
            string queryText = "SELECT password FROM userlist WHERE login='administrator'";
            MainForm form = new MainForm();
            OleDbConnection connection = new OleDbConnection(form.connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            string password = Convert.ToString(command.ExecuteScalar());
            return password.Equals(oldpassword);
        }

        private bool NewPasswordConfirmed()
        {
            return NewPasswordTextBox.Text.Equals(ConfirmPasswordTextBox.Text);
        }
    }
}
