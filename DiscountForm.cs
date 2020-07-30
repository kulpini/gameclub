using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class DiscountForm : Form
    {
        public string connectionString;
        public DiscountForm()
        {
            InitializeComponent();
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            ShowDiscounts();
        }

        private void ShowDiscounts()
        {
            string queryText = "SELECT * FROM discounts ORDER BY amount";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "discounts");
            DiscountDataGrid.DataSource = dataset.Tables["discounts"].DefaultView;
            DiscountDataGrid.Columns["ID"].Visible = false;
            DiscountDataGrid.Columns["amount"].Width = 150;
            DiscountDataGrid.Columns["amount"].HeaderText = "Размер скидки";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DiscountDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить запись?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int index = DiscountDataGrid.CurrentCell.RowIndex;
                    string ID = Convert.ToString(DiscountDataGrid[0, index].Value);
                    string queryText = "DELETE FROM discounts WHERE ID=" + ID;
                    ExecuteQuery(queryText);
                    ShowDiscounts();
                }
            }
            else
                MessageBox.Show("Не выбрана запись для удаления!", "Ошибка!", MessageBoxButtons.OK);
        }

        private void ExecuteQuery(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (DiscountTextBox.Text.Trim()!="")
            {
                try
                {
                    int discount = Convert.ToInt32(DiscountTextBox.Text);
                    string queryText = "INSERT INTO discounts (amount) VALUES ("+Convert.ToString(discount)+")";
                    ExecuteQuery(queryText);
                    ShowDiscounts();
                }
                catch
                {
                    MessageBox.Show("неверный формат числа", "ошибка", MessageBoxButtons.OK);
                }
            }
        }
    }
}
