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
    public partial class PaymentForm : Form
    {
        public string connectionString;
        public int SessionID
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        private int sessionId;
        public TimeSpan ElapsedTime
        {
            get { return elapsedTime; }
            set { elapsedTime = value; }
        }
        private TimeSpan elapsedTime;
        private double gameAmount;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            PayButton.Enabled = false;
            LoadSessionParameters();
            FillServiceList();
        }

        private void LoadSessionParameters()
        {
            gameAmount = 0;
            NameLabel.Text = GetComputerName(SessionID);
            ChooseCategory();
            ChooseTariff();
            ChooseDiscount();
        }

        private string GetComputerName(int sessionId)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT c.computername FROM computers c,sessions s " +
                "WHERE c.ID=s.computerID AND s.ID=@session";
            command.Parameters.AddWithValue("@session", sessionId);
            object name = command.ExecuteScalar();
            connection.Close();
            if (name != null)
                return Convert.ToString(name);
            else
                return "";
        }

        private void ChooseCategory()
        {
            FillCategoryList();
            CategoryComboBox.SelectedValue = GetActiveCategory();
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
        }

        private int GetActiveCategory()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT t.categoryId FROM tariffs t,sessions s WHERE t.ID=s.tariffID AND s.ID=@session";
            command.Parameters.AddWithValue("@session", SessionID);
            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return id;
        }

        private void ChooseTariff()
        {
            int categoryId = GetActiveCategory();
            FillTariffList(categoryId);
            TariffComboBox.SelectedItem = GetActiveTariff();
        }

        private void FillTariffList(int categoryId)
        {
            TariffComboBox.SelectedIndex = -1;
            TariffComboBox.Items.Clear();
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT tariffname FROM tariffs WHERE categoryID=@id ORDER BY tariffname";
            command.Parameters.AddWithValue("@id",categoryId);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TariffComboBox.Items.Add(reader.GetString(0));
                }
            }
            reader.Close();
            connection.Close();
        }

        private string GetActiveTariff()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT t.tariffname FROM tariffs t,sessions s WHERE t.ID=s.tariffID AND s.ID=@session";
            command.Parameters.AddWithValue("@session",SessionID);
            object name = command.ExecuteScalar();
            connection.Close();
            return Convert.ToString(name);
        }

        private void ChooseDiscount()
        {
            FillDiscountList();
            SetActiveDiscount();
        }

        private void FillDiscountList()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT amount FROM discounts ORDER BY amount";
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DiscountComboBox.Items.Add(Convert.ToString(reader.GetInt32(0)));
                }
            }
            reader.Close();
            connection.Close();
        }

        private void SetActiveDiscount()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT discount, discountnote FROM sessions WHERE ID=@session";
            command.Parameters.AddWithValue("@session", SessionID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                DiscountComboBox.SelectedItem = reader.GetValue(0).ToString();
                DiscountNoteTextBox.Text = reader.GetValue(1).ToString();
                reader.Close();
            }
            connection.Close();
        }

        private void CalcSumButton_Click(object sender, EventArgs e)
        {
            if (TariffComboBox.Text == "")
                MessageBox.Show("Не задан тариф!", "ошибка!", MessageBoxButtons.OK);
            else 
            if (ServicesChecked())
            {
                UpdateSessionParameters();
                CalcSum();
                PayButton.Enabled = true;
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

        private void UpdateSessionParameters()
        {
            int discount = DiscountComboBox.Text == "" ? 0 : Convert.ToInt32(DiscountComboBox.Text);
            int tariff = GetTariffId(TariffComboBox.Text);
            string queryText = "UPDATE sessions SET discount="+Convert.ToString(discount)+ 
                ", discountnote='"+DiscountNoteTextBox.Text+ "', tariffID=" + Convert.ToString(tariff) + " WHERE ID=" + Convert.ToString(SessionID);
            ExecuteQuery(queryText);
            ApplyServices(SessionID);
        }

        private int GetTariffId(string tariffname)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID FROM tariffs WHERE tariffname=@name";
            command.Parameters.AddWithValue("@name", tariffname);
            object id = command.ExecuteScalar();
            connection.Close();
            if (id != null)
                return Convert.ToInt32(id);
            else
                return 0;
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
                queryText = "UPDATE serviceusing SET quantity =" + Convert.ToString(quantity) +
                    " WHERE sessionID=" + Convert.ToString(SessionID) + " AND serviceID=" + serviceId;
                ExecuteQuery(queryText);
            }
        }

        private void FillServiceList()
        {
            string queryText = "SELECT s.ID,s.servicename,u.quantity FROM services s,serviceusing u WHERE" +
                " s.ID=u.serviceID AND u.sessionID=" + Convert.ToString(SessionID) + " ORDER BY servicename";
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

        private void CalcSum()
        {
            gameAmount = Math.Round(CalcMinutesSum());
            int discount = DiscountComboBox.Text == "" ? 0 : Convert.ToInt32(DiscountComboBox.Text);
            double sum = gameAmount - Math.Round((gameAmount * discount) / 100) + Math.Round(CalcServicesSum());
            PaymentSumLabel.Text = Convert.ToString(sum);
        }

        private double CalcMinutesSum()
        {
            double totalminutes = ElapsedTime.TotalMinutes;
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand tariffcommand = connection.CreateCommand();
            tariffcommand.CommandText = "SELECT tariffID FROM sessions WHERE ID=@session";
            tariffcommand.Parameters.AddWithValue("@session", SessionID);
            object tariffid = tariffcommand.ExecuteScalar();
            int id = Convert.ToInt32(tariffid);
            OleDbCommand intervalcommand = connection.CreateCommand();
            intervalcommand.CommandText = "SELECT startInterval,endInterval,price,fixed FROM intervals WHERE tariffID=@tariff";
            intervalcommand.Parameters.AddWithValue("@tariff", id);
            OleDbDataReader reader = intervalcommand.ExecuteReader();
            double sum = 0;
            if (reader.HasRows)
            {
                int begin, end;
                bool fixedAmount;
                double price, minutes;
                while (reader.Read())
                {
                    begin = reader.GetInt32(0);
                    end = reader.GetInt32(1);
                    price = Convert.ToDouble(reader.GetValue(2));
                    fixedAmount = reader.GetBoolean(3);
                    if (totalminutes > 0)
                    {
                        if (totalminutes <= end)
                        {
                            minutes = fixedAmount ? 1 : (totalminutes - begin);
                            sum += minutes * price;
                            break;
                        }
                        else
                        {
                            minutes = fixedAmount ? 1 : (end - begin);
                            sum += minutes * price;
                        }
                    }
                }
                reader.Close();
            }
            connection.Close(); 
            return sum; 
        }

        private double CalcServicesSum()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT SUM(s.price*su.quantity) FROM services s,serviceusing su WHERE su.serviceID=s.ID AND su.sessionID=@session";
            command.Parameters.AddWithValue("@session",SessionID);
            object sum = command.ExecuteScalar();
            connection.Close();
            return Convert.ToDouble(sum);
        }

        private DateTime GetStartTime()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT start FROM sessions WHERE ID=@session";
            command.Parameters.AddWithValue("@session", SessionID);
            object time = command.ExecuteScalar();
            connection.Close();
            if (time != null)
                return Convert.ToDateTime(time);
            else
                return DateTime.Now;
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            CloseSession(SessionID);
            InvoiceForm invoice = new InvoiceForm { connectionString = this.connectionString, SessionID = this.SessionID};
            invoice.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CloseSession(int sessionId)
        {
            int discount = DiscountComboBox.Text == "" ? 0 : Convert.ToInt32(DiscountComboBox.Text);
            gameAmount -= Math.Round((gameAmount * discount) / 100);
            int amount = Convert.ToInt32(PaymentSumLabel.Text);
            DateTime finishTime = GetStartTime() + ElapsedTime;
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE sessions SET finish='" +finishTime+"' WHERE ID="+Convert.ToString(sessionId);
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE sessions SET totalamount=@amount,gameamount=@gameamount WHERE ID=" + Convert.ToString(sessionId);
            command.Parameters.AddWithValue("@amount",amount);
            command.Parameters.AddWithValue("@gameamount", gameAmount);
            command.ExecuteNonQuery();
            connection.Close();
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
