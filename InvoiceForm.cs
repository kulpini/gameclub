using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Drawing.Imaging;

namespace gameclub
{
    public partial class InvoiceForm : Form
    {
        Bitmap memoryImage;
        private PrintDocument printDocument = new PrintDocument();
        public string connectionString;
        public int SessionID
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        private int sessionId;
        public double PaymentSum
        {
            get { return paymentsum; }
            set { paymentsum = value; }
        }
        private double paymentsum;
        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            FillServiceList();
            FillGameProperties();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void FillServiceList()
        {
            string queryText = "SELECT s.servicename,u.quantity,'unit'as units,s.price,'equal' as equal,u.quantity*s.price as amount,'uah' as uah FROM services s,serviceusing u WHERE" +
    " s.ID=u.serviceID AND u.sessionID=" + Convert.ToString(SessionID) + " AND u.quantity>0 ORDER BY servicename";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
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
            ServicesDataGrid.Columns["uah"].DefaultCellStyle.Font = new Font("Times New Roman",14, FontStyle.Bold);
            ServicesDataGrid.Columns["uah"].DefaultCellStyle.ForeColor = Color.Maroon;
        }

        private void FillGameProperties()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT s.start,s.finish,s.gameamount,s.totalamount,s.discount,c.computername FROM sessions s,computers c " +
                "WHERE s.ID=@session AND s.computerID=c.ID";
            command.Parameters.AddWithValue("@session", SessionID);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            DateTime start = reader.GetDateTime(0);
            DateTime finish = reader.GetDateTime(1);
            TimeSpan elapsed = finish-start;
            int gameamount = reader.GetInt32(2);
            int discount = reader.GetInt32(4);
            double totalgameamount = 100 * gameamount / (100 - discount);
            totalgameamount = Math.Round(totalgameamount);
            GameSumLabel.Text = Convert.ToString(totalgameamount);
            
            DiscountLabel.Text = Convert.ToString(discount);
            int discountsum = gameamount - (int)totalgameamount;
            DiscountSumLabel.Text = Convert.ToString(discountsum);
            NameLabel.Text = reader.GetString(5);
            SessionTimeLabel.Text = elapsed.ToString("hh':'mm':'ss");
            PaymentSumLabel.Text = Convert.ToString(reader.GetInt32(3));
            PaymentTimeLabel.Text = DateTime.Now.ToString("G");
            reader.Close();
            connection.Close();
        }

        private void CaptureScreen()
        {
            Size s = InvoicePanel.Size;
            memoryImage = new Bitmap(s.Width, s.Height);
            InvoicePanel.DrawToBitmap(memoryImage,InvoicePanel.ClientRectangle);
        }

        private void printDocument_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            try
            {
                printDocument.Print();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при печати чека.\nОбратитесь к администратору.","системная ошибка",MessageBoxButtons.OK);
            }     
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
