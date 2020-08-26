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
    public partial class ApplyingServicesForm : Form
    {
        public string connectionString;
        public int SessionID
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        private int sessionId;
        public ApplyingServicesForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ServicesChecked())
            {
                ApplyServices(SessionID);
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ServicesChecked()
        {
            bool result = true;
            for (int i = 0; i < ServicesDataGrid.RowCount; i++)
            {
                try
                {
                    int quantity = Convert.ToInt32(ServicesDataGrid[2, i].Value);
                    if (quantity < 0)
                    {
                        MessageBox.Show($"Ошибка в {i + 1} строке \nКоличество не может быть отрицательным", "", MessageBoxButtons.OK);
                        result = false;
                        break;
                    }
                }
                catch
                {
                    MessageBox.Show($"Ошибка в {i + 1} строке \nНеверный формат числа", "", MessageBoxButtons.OK);
                    result = false;
                    break;
                }
            }
            return result;
        }

        private void ExecuteQuery(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void ApplyServices(int sessionID)
        {
            string queryText, serviceId;
            int quantity;
            for (int i = 0; i < ServicesDataGrid.RowCount; i++)
            {
                quantity = Convert.ToInt32(ServicesDataGrid[2, i].Value);
                serviceId = Convert.ToString(ServicesDataGrid[0, i].Value);
                queryText = "UPDATE serviceusing SET quantity ="+ Convert.ToString(quantity) + 
                    " WHERE sessionID=" + Convert.ToString(SessionID) + " AND serviceID=" + serviceId;
                ExecuteQuery(queryText);
            }
        }

        private void ApplyingServicesForm_Load(object sender, EventArgs e)
        {
            FillServiceList();
        }

        private void FillServiceList()
        {
            string queryText = "SELECT s.ID,s.servicename,u.quantity FROM services s,serviceusing u WHERE" +
                " s.ID=u.serviceID AND u.sessionID="+Convert.ToString(SessionID)+" ORDER BY servicename";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "services");
            ServicesDataGrid.DataSource = dataset.Tables["services"].DefaultView;
            ServicesDataGrid.Columns["ID"].Visible = false;
            ServicesDataGrid.Columns["servicename"].Width = 150;
            ServicesDataGrid.Columns["servicename"].DefaultCellStyle.BackColor = Color.LightGray;
            ServicesDataGrid.Columns["servicename"].ReadOnly = true;
            ServicesDataGrid.Columns["quantity"].Width = 70;
            ServicesDataGrid.Columns.Add("unit", "");
            ServicesDataGrid.Columns["unit"].Width = 50;
            ServicesDataGrid.Columns["unit"].DefaultCellStyle.BackColor = Color.LightGray;
            ServicesDataGrid.Columns["unit"].ReadOnly = true;
            for (int i = 0; i < ServicesDataGrid.RowCount; i++)
            {
                ServicesDataGrid[3, i].Value = "шт.";
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
