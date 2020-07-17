using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class AddUserForm : Form
    {
        public string UserLogin
        { 
            get { return LoginTextBox.Text; }
            set { LoginTextBox.Text = value; }
        }
        public string Password
        {
            get { return PasswordTextBox.Text; }
            set { PasswordTextBox.Text = value; }
        }
        public string UserName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Trim() == "")
                MessageBox.Show("Не задан логин!", "", MessageBoxButtons.OK);
            else if (PasswordTextBox.Text.Trim() == "")
                MessageBox.Show("Не задан пароль!", "", MessageBoxButtons.OK);
            else
                this.DialogResult = DialogResult.OK;
        }
    }
}
