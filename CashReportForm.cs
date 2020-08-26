using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class CashReportForm : Form
    {
        public string connectionString;
        public DateTime ReportDate
        {
            set { reportdate = value; }
            get { return reportdate; }
        }
        private DateTime reportdate;
        public CashReportForm()
        {
            InitializeComponent();
        }

        private void CashReportForm_Load(object sender, EventArgs e)
        {
            DateLabel.Text = ReportDate.ToString("d");
            SumLabel.Text = Convert.ToString(GetSumOfDay(ReportDate));
            FillServiceList(ReportDate);
            FillGamingList(ReportDate);
        }

        private double GetSumOfDay(DateTime reportDate)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            DateTime dayBegin = new DateTime(reportDate.Year, reportDate.Month,reportDate.Day);
            DateTime dayEnd = dayBegin.AddSeconds(86399);
            command.CommandText = "SELECT SUM(totalamount) FROM sessions WHERE start>=@start AND finish<=@finish";
            command.Parameters.AddWithValue("@start",dayBegin);
            command.Parameters.AddWithValue("@finish",dayEnd);
            object sum = command.ExecuteScalar();
            connection.Close();
            if (sum.GetType() == typeof(DBNull))
                return 0;
            else
                return Convert.ToDouble(sum);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FillServiceList(DateTime reportDate)
        {
            DateTime dayBegin = new DateTime(reportDate.Year, reportDate.Month, reportDate.Day);
            DateTime dayEnd = dayBegin.AddSeconds(86399);
            string queryText = "SELECT sr.servicename,sum(u.quantity) as quantity,'unit'as units, sr.price,'equal' as equal, sr.price*sum(u.quantity) as amount,'uah' as uah " +
                "FROM services sr,serviceusing u,sessions s " +
                "WHERE u.sessionID=s.ID AND sr.ID=u.serviceID AND s.start>=? AND s.finish<=? AND u.quantity>0 GROUP BY servicename,price";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            adapter.SelectCommand.Parameters.AddWithValue("?", dayBegin);
            adapter.SelectCommand.Parameters.AddWithValue("?", dayEnd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "services");
            ServicesDataGrid.DataSource = dataset.Tables["services"].DefaultView;
            ServicesDataGrid.Columns["servicename"].Width = 170;
            ServicesDataGrid.Columns["quantity"].Width = 30;
            ServicesDataGrid.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["units"].Width = 50;
            ServicesDataGrid.Columns["units"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["price"].Width = 50;
            ServicesDataGrid.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["equal"].Width = 30;
            ServicesDataGrid.Columns["equal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["amount"].Width = 50;
            ServicesDataGrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ServicesDataGrid.Columns["uah"].Width = 60;
            ServicesDataGrid.Columns["uah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            for (int i = 0; i < ServicesDataGrid.RowCount; i++)
            {
                ServicesDataGrid[2, i].Value = "шт. x ";
                ServicesDataGrid[4, i].Value = " = ";
                ServicesDataGrid[6, i].Value = "грн.";
            }
            ServicesDataGrid.Columns["amount"].DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            ServicesDataGrid.Columns["amount"].DefaultCellStyle.ForeColor = Color.Maroon;
            ServicesDataGrid.Columns["uah"].DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            ServicesDataGrid.Columns["uah"].DefaultCellStyle.ForeColor = Color.Maroon;
            ServicesDataGrid.ClearSelection();
        }

        private void FillGamingList(DateTime reportDate)
        {
            DateTime dayBegin = new DateTime(reportDate.Year, reportDate.Month, reportDate.Day);
            DateTime dayEnd = dayBegin.AddSeconds(86399);
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT start,finish,discount,discountnote,gameamount " +
                "FROM sessions WHERE start>=@begin AND finish<=@end ORDER BY start";
            command.Parameters.AddWithValue("@begin", dayBegin);
            command.Parameters.AddWithValue("@end", dayEnd);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                DateTime start, finish;
                TimeSpan elapsed;
                string discount, note;
                int discountsum, amount;
                while (reader.Read())
                {
                    start = reader.GetDateTime(0);
                    finish = reader.GetDateTime(1);
                    elapsed = finish - start;
                    discountsum = reader.GetInt32(2);
                    discount = discountsum == 0 ? "" : String.Format("скидка-{0}%", discountsum);
                    note = reader.IsDBNull(3)? "": reader.GetString(3);
                    amount = reader.GetInt32(4);
                    GamingDataGrid.Rows.Add(elapsed.ToString("hh':'mm':'ss"),amount,"грн.",discount,note);
                }
                reader.Close();
            }
            connection.Close();
            GamingDataGrid.ClearSelection();
        }
    }
}
