using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class AddTariffForm : Form
    {
        public string connectionString;
        public string TariffName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }
        public int TariffId
        {
            get { return tariffId; }
            set { tariffId = value; }
        }
        private int tariffId;
        public AddTariffForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Trim() == "")
                MessageBox.Show("Не задано название тарифа!","ошибка!",MessageBoxButtons.OK); 
            else if (IntervalsDataGrid.RowCount==0)
                MessageBox.Show("Не заданы интервалы тарифа!", "ошибка!", MessageBoxButtons.OK);
            else
            {
                if (CheckGridRows())
                {
                    if (TariffId != 0)
                        UpdateTariff();
                    else
                        SaveTariff();
                    this.DialogResult = DialogResult.OK;
                }
            }    
        }

        private void UpdateTariff()
        {
            string queryText = "UPDATE tariffs SET tariffname='" + TariffName + "' WHERE ID=" + Convert.ToString(TariffId);
            ExecuteQuery(queryText);
            queryText = "DELETE FROM intervals WHERE tariffID="+Convert.ToString(TariffId);
            ExecuteQuery(queryText);
            SaveIntervals(TariffId);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int num = IntervalsDataGrid.RowCount;
            AddInterval(num);
        }

        private void AddInterval(int number)
        {
            IntervalsDataGrid.Rows.Add();
            IntervalsDataGrid[0, number].Value = number == 0? 0 : IntervalsDataGrid[1, number - 1].Value;
        }

        private bool CheckGridRows()
        {
            bool result=true;
            for (int i = 0; i < IntervalsDataGrid.RowCount; i++)
            {
                result = CheckDataInRow(i);
                if (!result)
                    break;
                else
                {
                    result = CheckFormatInRow(i);
                    if (!result)
                        break;
                }
            }
            return result;
        }

        private bool CheckDataInRow(int rowindex)
        {
            string startInterval = Convert.ToString(IntervalsDataGrid[0, rowindex].Value);
            string endInterval = Convert.ToString(IntervalsDataGrid[1, rowindex].Value);
            string amount = Convert.ToString(IntervalsDataGrid[2, rowindex].Value);
            if (startInterval.Trim() == "")
            {
                MessageBox.Show($"Ошибка в строке {rowindex + 1} ! \nНе задано начало диапазона", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
            if (endInterval.Trim() == "")
            {
                MessageBox.Show($"Ошибка в строке {rowindex + 1} ! \nНе задан конец диапазона", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
            if (amount.Trim() == "")
            {
                MessageBox.Show($"Ошибка в строке {rowindex + 1} ! \nНе задана стоимость", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
            else return true;
        }

        private void SaveTariff()
        {
            string queryText = "INSERT INTO tariffs(tariffname) VALUES ('"+TariffName+"')";
            int tariffId = AppendTariff(queryText);
            SaveIntervals(tariffId);
        }

        private void SaveIntervals(int tariffId)
        {
            string queryText, start, end, amount;
            for (int i = 0; i < IntervalsDataGrid.RowCount; i++)
            {
                start = Convert.ToString(IntervalsDataGrid[0, i].Value);
                end = Convert.ToString(IntervalsDataGrid[1, i].Value);
                amount = Convert.ToString(IntervalsDataGrid[2, i].Value);
                queryText = "INSERT INTO intervals (tariffID,startInterval,endInterval,price) VALUES (" +
                    Convert.ToString(tariffId) + "," + start + "," + end + "," + amount + ")";
                ExecuteQuery(queryText);
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

        private int AppendTariff(string queryText)
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

        private bool CheckFormatInRow(int rowindex)
        {
            try
            {
                int start = Convert.ToInt32(IntervalsDataGrid[0, rowindex].Value);
                int end = Convert.ToInt32(IntervalsDataGrid[1, rowindex].Value);
                int amount = Convert.ToInt32(IntervalsDataGrid[2, rowindex].Value);
                return CheckInterval(start, end, rowindex);
            }
            catch
            {
                MessageBox.Show($"Ошибка в строке {rowindex + 1} ! \nНеправильный формат числа", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        private bool CheckInterval(int start, int end, int rowindex)
        {
            if (end <= start)
            {
                MessageBox.Show($"Ошибка в строке {rowindex + 1} ! \nОкончание интервала должно быть больше, чем начало", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
            else
                return true;
        }

        private void IntervalsDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowCount = IntervalsDataGrid.RowCount;
            if (rowCount > 0)
            {
                for (int i = 0; i < IntervalsDataGrid.RowCount - 1; i++)
                    IntervalsDataGrid[0, i + 1].Value = IntervalsDataGrid[1, i].Value;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (IntervalsDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить интервал из списка?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int row = IntervalsDataGrid.CurrentCell.RowIndex;
                    IntervalsDataGrid.Rows.RemoveAt(row);
                }
            }
            else
                MessageBox.Show("", "", MessageBoxButtons.OK);
        }

        private void AddTariffForm_Load(object sender, EventArgs e)
        {
            if (TariffId!=0)
                ShowIntervals();
        }

        private void ShowIntervals()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT startInterval,endInterval,price FROM intervals WHERE tariffID=@tariff ORDER BY startInterval";
            command.Parameters.AddWithValue("tariff",TariffId);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    IntervalsDataGrid.Rows.Add();
                    IntervalsDataGrid[0, i].Value = Convert.ToString(reader.GetValue(0));
                    IntervalsDataGrid[1, i].Value = Convert.ToString(reader.GetValue(1));
                    IntervalsDataGrid[2, i].Value = Convert.ToString(reader.GetValue(2));
                    i++;
                }
            }
            IntervalsDataGrid.Columns[0].Width =125;
            IntervalsDataGrid.Columns[1].Width =125;
            IntervalsDataGrid.Columns[2].Width =160;
            reader.Close();
            connection.Close();
        }
    }
}
