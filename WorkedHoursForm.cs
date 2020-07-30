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
    public partial class WorkedHoursForm : Form
    {
        public string connectionString;
        public WorkedHoursForm()
        {
            InitializeComponent();
        }

        private void WorkedHoursForm_Load(object sender, EventArgs e)
        {
            YearUpDown.Value = DateTime.Today.Year;
            FillUserNamesList();
        }

        private void FillUserNamesList()
        {
            string queryText = "SELECT username FROM userlist WHERE login<>'administrator' ORDER BY username";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserNameComboBox.Items.Add(reader.GetString(0));
            }
        }

        private void CalcHoursButton_Click(object sender, EventArgs e)
        {
            if (UserNameComboBox.Text == "")
                MessageBox.Show("Не выбран пользователь!", "ошибка!", MessageBoxButtons.OK);
            else if (MonthComboBox.Text == "")
                MessageBox.Show("Не задан месяц!", "ошибка!", MessageBoxButtons.OK);
            else 
            {
                string userName = UserNameComboBox.Text;
                int id = GetUserId(userName);
                int month = MonthComboBox.SelectedIndex + 1;
                int year = (int)YearUpDown.Value;
                int minutes = CalcWorkedHours(id, month, year);
                PeriodLabel.Text = "за " + MonthComboBox.Text + " " + Convert.ToString(year) + " года";
                TimeSpan span = TimeSpan.FromMinutes(minutes);
                HoursLabel.Text = span.ToString("hh':'mm");
            }
        }

        private int GetUserId(string userName)
        {
            string queryText = "SELECT ID FROM userlist WHERE username='"+userName+"'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private int CalcWorkedHours(int userId,int month, int year)
        {
            string start = "01." + GetMonthString(month) + "." + Convert.ToString(year) + " 00:00:00";
            DateTime startDate = Convert.ToDateTime(start);
            string end = Convert.ToString(DateTime.DaysInMonth(year,month))+"."+ GetMonthString(month) +
                "." + Convert.ToString(year) + " 23:59:59";
            DateTime endDate = Convert.ToDateTime(end);
            string queryText = "SELECT SUM(Datediff('n',startWork,endWork)) FROM working "+
                "WHERE userID=@user AND (startWork BETWEEN@date1 AND @date2) AND (endWork BETWEEN @date1 AND @date2)";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.Parameters.AddWithValue("user",userId);
            command.Parameters.AddWithValue("date1",startDate);
            command.Parameters.AddWithValue("date2",endDate);
            if (command.ExecuteScalar() != DBNull.Value)
                return Convert.ToInt32(command.ExecuteScalar());
            else
                return 0;
        }

        private string GetMonthString(int monthnumber)
        {
            if (monthnumber < 10)
                return "0" + Convert.ToString(monthnumber);
            else
                return Convert.ToString(monthnumber);
        }
    }
}
