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
    public partial class AddServiceForm : Form
    {
        public string ServiceName
        {
            set { NameTextBox.Text = value; }
            get { return NameTextBox.Text; }
        }

        public int Price
        {
            set { PriceTextBox.Text = Convert.ToString(value); }
            get { return Convert.ToInt32(PriceTextBox.Text); }
        }

        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
