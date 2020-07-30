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
    public partial class AddComputerForm : Form
    {
        public string ComputerName
        {
            set { NameTextBox.Text = value; }
            get { return NameTextBox.Text; }
        }

        public AddComputerForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Trim() != "")
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Не задано название компьютера","Ошибка!",MessageBoxButtons.OK);
        }
    }
}
