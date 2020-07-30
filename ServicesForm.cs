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
    public partial class ServicesForm : Form
    {
        public string connectionString;
        public ServicesForm()
        {
            InitializeComponent();
        }

        private void ServicesForm_Load(object sender, EventArgs e)
        {
            ShowServices();
        }

        private void ShowServices()
        {
            string queryText = "SELECT * FROM services ORDER BY servicename";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "services");
            ServicesDataGrid.DataSource = dataset.Tables["services"].DefaultView;
            ServicesDataGrid.Columns["ID"].Visible = false;
            ServicesDataGrid.Columns["servicename"].HeaderText = "Дополнительная услуга";
            ServicesDataGrid.Columns["servicename"].Width = 250;
            ServicesDataGrid.Columns["price"].HeaderText = "Стоимость, грн.";
            ServicesDataGrid.Columns["price"].Width = 150;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ServicesDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить услугу из списка?","",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int row = ServicesDataGrid.CurrentCell.RowIndex;
                    string id = Convert.ToString(ServicesDataGrid[0,row].Value);
                    string queryText = "DELETE FROM services WHERE ID="+id;
                    ExecuteQuery(queryText);
                    ShowServices();
                }
            }
            else
                MessageBox.Show("Не выбрана запись для удаления!","Ошибка!",MessageBoxButtons.OK);
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
            AddServiceForm addForm = new AddServiceForm();
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                string serviceName = addForm.ServiceName;
                int price = addForm.Price;
                string queryText = "INSERT INTO services (servicename,price) VALUES ('"+serviceName+"',"+Convert.ToString(price)+")";
                ExecuteQuery(queryText);
                ShowServices();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (ServicesDataGrid.CurrentCell != null)
            {
                int row = ServicesDataGrid.CurrentCell.RowIndex;
                string name = Convert.ToString(ServicesDataGrid[1, row].Value);
                int price = Convert.ToInt32(ServicesDataGrid[2, row].Value);
                AddServiceForm editForm = new AddServiceForm { ServiceName = name, Price = price};
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    name = editForm.ServiceName;
                    price = editForm.Price;
                    string queryText = "UPDATE services SET servicename='"+name+"',price="+Convert.ToString(price);
                    ExecuteQuery(queryText);
                    ShowServices();
                }
            }
            else
                MessageBox.Show("Не выбрана запись для редактирования", "Ошибка!", MessageBoxButtons.OK);
        }
    }
}
