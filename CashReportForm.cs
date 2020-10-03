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
        private int xPos;
        Bitmap headerImage,footerImage;
        private PrintDocument printDocument = new PrintDocument();
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
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            DateLabel.Text = ReportDate.ToString("d");
            SumLabel.Text = Convert.ToString(GetSumOfDay(ReportDate));
            FillServiceList(ReportDate);
            FillGamingList(ReportDate);
        }

        private void printDocument_PrintPage(System.Object sender, PrintPageEventArgs e)
        {
            int bandWidth = 220;
            int printHeight = 50;
            e.Graphics.DrawImage(headerImage, 0, 0, bandWidth, printHeight);
            PrintGrid(e);
            printHeight = 150;
            e.Graphics.DrawImage(footerImage, 0, xPos, bandWidth, printHeight);
        }

        private void PrintGrid(PrintPageEventArgs e)
        {
            xPos = 68;
            string time, sum, discount, note;
            e.Graphics.DrawString(string.Format("{0,-8}|","время"), new Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 0, 50);
            e.Graphics.DrawString(string.Format("{0,-8}|", "оплата"), new Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 47, 50);
            e.Graphics.DrawString(string.Format("{0,-8}|", "скидка"), new Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 94, 50);
            e.Graphics.DrawString(string.Format("{0,-11}", "примечание"), new Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 141, 50);
            e.Graphics.DrawString(new string('-',50), new Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 0, 58);
            for (int row = 0; row < GamingDataGrid.RowCount; row++)
            {
                time = Convert.ToString(GamingDataGrid[0, row].Value);
                sum = "  "+Convert.ToString(GamingDataGrid[1, row].Value)+" грн.";
                discount = Convert.ToString(GamingDataGrid[3, row].Value);
                discount = discount=="" ? "" : discount.Substring(7);
                note = Convert.ToString(GamingDataGrid[4, row].Value);
                e.Graphics.DrawString(time.PadRight(8,' '), new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, 0, xPos);
                e.Graphics.DrawString(sum.PadLeft(9,' '), new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, 47, xPos);
                e.Graphics.DrawString(discount.PadLeft(5,' ').PadRight(7,' '), new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, 94, xPos);
                e.Graphics.DrawString(note, new Font("Times New Roman", 5, FontStyle.Bold), Brushes.Black, 141, xPos);
                xPos += 12;
            }
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
            ServicesDataGrid.Columns["servicename"].Width = 150;
            ServicesDataGrid.Columns["quantity"].Width = 30;
            ServicesDataGrid.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["units"].Width = 60;
            ServicesDataGrid.Columns["units"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["price"].Width = 50;
            ServicesDataGrid.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ServicesDataGrid.Columns["equal"].Width = 35;
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
            command.CommandText = "SELECT s.start,s.finish,s.discount,s.discountnote,s.gameamount,t.tariffname " +
                "FROM sessions s,tariffs t WHERE start>=@begin AND finish<=@end AND t.ID=s.tariffID ORDER BY start";
            command.Parameters.AddWithValue("@begin", dayBegin);
            command.Parameters.AddWithValue("@end", dayEnd);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                DateTime start, finish;
                TimeSpan elapsed;
                string discount, note, tariffname;
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
                    tariffname = reader.GetString(5);
                    GamingDataGrid.Rows.Add(start.ToString("T"),elapsed.ToString("hh':'mm':'ss"),tariffname,amount,"грн.",discount,note);
                }
                reader.Close();
            }
            connection.Close();
            GamingDataGrid.ClearSelection();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            CaptureHeader();
            CaptureFooter();
            try
            {
                printDocument.Print();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при печати чека.\nОбратитесь к администратору.", "системная ошибка", MessageBoxButtons.OK);
            }
        }

        private void CaptureHeader()
        {
            Size s = MainHeaderPanel.Size;
            headerImage = new Bitmap(s.Width, s.Height);
            MainHeaderPanel.DrawToBitmap(headerImage, MainHeaderPanel.ClientRectangle);
        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CaptureFooter()
        {
            Size s = MainFooterPanel.Size;
            footerImage = new Bitmap(s.Width, s.Height);
            MainFooterPanel.DrawToBitmap(footerImage, MainFooterPanel.ClientRectangle);
        }
    }
}
