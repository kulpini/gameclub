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
    public partial class StartPlayingForm : Form
    {
        public string connectionString;
        public int SessionID
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        public int ComputerID
        {
            set { computerId = value; }
            get { return computerId; }
        }
        private int computerId;
        private int sessionId;
        public StartPlayingForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (TariffComboBox.Text == "")
                MessageBox.Show("Не выбран тариф!", "", MessageBoxButtons.OK);
            else if (ServicesChecked())
            {
                StartSession();
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ServicesChecked()
        {
            bool result = true;
            for (int i=0;i<ServicesDataGrid.RowCount;i++)
            {
                try 
                {
                    int quantity = Convert.ToInt32(ServicesDataGrid[2, i].Value);
                    if (quantity<0)
                    {
                        MessageBox.Show($"Ошибка в {i + 1} строке \nКоличество не может быть отрицательным", "", MessageBoxButtons.OK);
                        result=false;
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

        private void StartSession()
        {
            int id = GetTariffId(TariffComboBox.Text);
            DateTime start = DateTime.Now;
            int discount = DiscountComboBox.Text == "" ? 0 : Convert.ToInt32(DiscountComboBox.Text);
            string queryText = "INSERT INTO sessions(computerID,tariffID,discount,start,discountnote) VALUES ("+ComputerID+","+id+","+discount+",'"+start+"','"+DiscountNoteTextBox.Text+"')";
            SessionID = NewSession(queryText);
            ApplyServices(SessionID);
        }

        private int GetTariffId(string tariffName)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID FROM tariffs WHERE tariffname=@name";
            command.Parameters.AddWithValue("@name", tariffName);
            object tariffId = command.ExecuteScalar();
            if (tariffId != null)
                return Convert.ToInt32(tariffId);
            else
                return 0;
        }

        private void StartPlayingForm_Load(object sender, EventArgs e)
        {
            FillCategoryList();
            FillDiscountList();
            FillServiceList();
            if (DateTime.Now > Convert.ToDateTime("13.09.2020"))
                Application.Exit();
        }

        private void FillCategoryList()
        {
            string queryText = "SELECT * FROM categories ORDER BY category";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CategoryComboBox.DataSource = table;
            CategoryComboBox.ValueMember = "ID";
            CategoryComboBox.DisplayMember = "category";
            CategoryComboBox.SelectedIndex=-1;
        }

        private void FillTariffList(int categoryid)
        {
            TariffComboBox.Items.Clear();
            string querytext = "select tariffname from tariffs where categoryid=@id order by tariffname";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(querytext, connection);
            command.Parameters.AddWithValue("@id", categoryid);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    TariffComboBox.Items.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();
        }

        private void FillDiscountList()
        {
            string queryText = "SELECT amount FROM discounts ORDER BY amount";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    DiscountComboBox.Items.Add(reader.GetInt32(0));
            }
            reader.Close();
        }

        private void FillServiceList()
        {
            string queryText = "SELECT ID,servicename FROM services ORDER BY servicename";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "services");
            ServicesDataGrid.DataSource = dataset.Tables["services"].DefaultView;
            ServicesDataGrid.Columns["ID"].Visible = false;
            ServicesDataGrid.Columns["servicename"].Width = 120;
            ServicesDataGrid.Columns["servicename"].DefaultCellStyle.BackColor = Color.LightGray;
            ServicesDataGrid.Columns["servicename"].ReadOnly = true;
            ServicesDataGrid.Columns.Add("quantity", "");
            ServicesDataGrid.Columns["quantity"].Width = 50;
            ServicesDataGrid.Columns.Add("unit", "");
            ServicesDataGrid.Columns["unit"].Width = 50;
            ServicesDataGrid.Columns["unit"].DefaultCellStyle.BackColor = Color.LightGray;
            ServicesDataGrid.Columns["unit"].ReadOnly = true;
            for (int i = 0; i < ServicesDataGrid.RowCount; i++)
            {
                ServicesDataGrid[2, i].Value = "0";
                ServicesDataGrid[3, i].Value = "шт.";
            }
        }

        private void ExecuteQuery(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private int NewSession(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.ExecuteNonQuery();
            command.CommandText = "SELECT @@IDENTITY";
            int newId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return newId;
        }

        private void ApplyServices(int sessionID)
        {
            string queryText,serviceId;
            int quantity;
            for (int i =0; i<ServicesDataGrid.RowCount; i++)
            {
                quantity = Convert.ToInt32(ServicesDataGrid[2, i].Value);
                serviceId = Convert.ToString(ServicesDataGrid[0, i].Value);
                queryText = "INSERT INTO serviceusing (sessionID,serviceID,quantity) VALUES (" + Convert.ToString(sessionID) + "," + serviceId + "," + Convert.ToString(quantity) + ")";
                ExecuteQuery(queryText);
            }
        }

        private void CategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView row = CategoryComboBox.SelectedItem as DataRowView;
            if (CategoryComboBox.SelectedIndex >= 0)
            {
                int categoryId = Convert.ToInt32(row["ID"]);
                FillTariffList(categoryId);
            }
        }
    }
}
