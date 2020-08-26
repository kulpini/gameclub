using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class MainForm : Form
    {
        public int userId;
        static string pathToDb = AppDomain.CurrentDomain.BaseDirectory + "\\gameclub.mdb";
        public string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathToDb;
        public string user;
        private int[] active;
        private int[] seconds;
        private int[] sessions;
        private TimeSpan timeElapsed;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginUser();
            ShowComputers();
            InitSettings();
        }

        private void LoginUser()
        {
            LoginForm loginForm = new LoginForm { connectionString = this.connectionString };
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                StopWorking();
                this.Visible = true;
                user = loginForm.LoginComboBox.Text;
                if (user != "administrator")
                    menuStrip.Visible = false;
                else
                    menuStrip.Visible = true;
                userId = loginForm.userId;
                UserNameLabel.Text = GetUserName();
                StartWorking();
            }
            else if (userId==0) 
                Application.Exit();
        }

        private void ShowComputers()
        {
            string queryText = "SELECT * FROM computers ORDER BY computername";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset,"computers");
            ComputersDataGrid.DataSource = dataset.Tables["computers"].DefaultView;
            ComputersDataGrid.Columns["ID"].Visible = false;
            ComputersDataGrid.Columns["computername"].Width = 200;
            DataGridViewButtonColumn btnStartColumn = new DataGridViewButtonColumn { Name = "startbutton", Width = 150 };
            ComputersDataGrid.Columns.Add(btnStartColumn);
            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn { Name = "time",Width = 100 };
            ComputersDataGrid.Columns.Add(timeColumn);
            DataGridViewTextBoxColumn sumColumn = new DataGridViewTextBoxColumn { Name = "sum", Width = 100 };
            ComputersDataGrid.Columns.Add(sumColumn);
            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn { Name = "amount", Width = 80 };
            ComputersDataGrid.Columns.Add(amountColumn);
            DataGridViewTextBoxColumn uahColumn = new DataGridViewTextBoxColumn { Name = "uah", Width = 80 };
            ComputersDataGrid.Columns.Add(uahColumn);
            DataGridViewButtonColumn btnServicesColumn = new DataGridViewButtonColumn { Name = "services", Width = 80 };
            ComputersDataGrid.Columns.Add(btnServicesColumn);
            DataGridViewButtonColumn btnPayColumn = new DataGridViewButtonColumn { Name = "paybutton", Width = 150 };
            ComputersDataGrid.Columns.Add(btnPayColumn);
            for (int i = 0; i < ComputersDataGrid.RowCount; i++)
            {
                ComputersDataGrid[2, i].Value = "Старт / Стоп";
                ComputersDataGrid[3, i].Value = "00:00:00";
                ComputersDataGrid[4, i].Value = "Сумма -";
                ComputersDataGrid[5, i].Value = "0";
                ComputersDataGrid[6, i].Value = "грн.";
                ComputersDataGrid[7, i].Value = "(+)";
                ComputersDataGrid[8, i].Value = "Оплата...";
            }
        }

        private void InitSettings()
        {
            int size = ComputersDataGrid.RowCount;
            active = new int[size];
            seconds = new int[size];
            sessions = new int[size];
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();
        }

        private void StartWorking()
        {
            string queryText = "INSERT INTO working(userID,startWork) VALUES("+Convert.ToString(userId)+",'"+DateTime.Now.ToString()+"')";
            ExecuteQuery(queryText);
        }

        private string GetUserName()
        {
            string queryText = "SELECT username FROM userlist WHERE ID="+Convert.ToInt32(userId);
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            return Convert.ToString(command.ExecuteScalar());
        }

        private void ChangePasswordMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm passwordForm = new ChangePasswordForm();
            passwordForm.ShowDialog();
            if (passwordForm.DialogResult==DialogResult.OK)
            {
                string newpassword = passwordForm.NewPasswordTextBox.Text;
                ChangePassword(newpassword);
                MessageBox.Show("Пароль успешно изменён.","изменение пароля",MessageBoxButtons.OK);
            }
        }

        private void ChangePassword(string newPassword)
        {
            string queryText = "UPDATE userlist SET [password]='"+ Crypto.EncodeDecrypt(newPassword) + "' WHERE [login]='administrator'";
            ExecuteQuery(queryText);
        }

        private void ExecuteQuery(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryText, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UsersMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm { connectionString = this.connectionString};
            usersForm.ShowDialog();
        }

        private void ComputersMenuItem_Click(object sender, EventArgs e)
        {
            ComputersForm computersForm = new ComputersForm { connectionString = this.connectionString };
            computersForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWorking();
            CloseActiveSessions();
        }

        private void StopWorking()
        {
            string queryText = "UPDATE working SET endWork='"+DateTime.Now.ToString()+"' WHERE userID="+Convert.ToString(userId)+
                " AND ID=(SELECT max(ID) FROM working)";
            ExecuteQuery(queryText);
        }

        private void CloseActiveSessions()
        {
            DateTime end = DateTime.Now;
            string queryText = "UPDATE sessions SET finish='"+ DateTime.Now.ToString()+"' WHERE finish IS NULL";
            ExecuteQuery(queryText);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            contextMenu.Show(ExitButton, new System.Drawing.Point(25, 25));
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeUserMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginUser();
            this.Show();
        }

        private void WorkedHoursMenuItem_Click(object sender, EventArgs e)
        {
            WorkedHoursForm hoursForm = new WorkedHoursForm { connectionString = this.connectionString};
            hoursForm.ShowDialog();
        }

        private void ComputersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (e.ColumnIndex == 2)
            {
                if (active[row] == 0)
                {
                    if (sessions[row] == 0)
                    {
                        int computerId = Convert.ToInt32(ComputersDataGrid[0, row].Value);
                        StartPlayingForm playingForm = new StartPlayingForm { connectionString = this.connectionString, ComputerID = computerId };
                        playingForm.ShowDialog();
                        if (playingForm.DialogResult == DialogResult.OK)
                        {
                            active[row] = 1;
                            sessions[row] = playingForm.SessionID;
                        }
                    }
                    else
                        active[row] = 1;
                }
                else
                    active[row] = 0;
            }
            if (e.ColumnIndex == 7)
            {
                if (sessions[row] != 0)
                {
                    ApplyingServicesForm serviceForm = new ApplyingServicesForm { connectionString = this.connectionString, SessionID = sessions[row] };
                    serviceForm.ShowDialog();
                }
            }
            if (e.ColumnIndex == 8) 
            {
                active[row] = 0;
                PaymentForm paymentForm = new PaymentForm { connectionString = this.connectionString, SessionID = sessions[row], ElapsedTime = TimeSpan.FromSeconds(seconds[row]) };
                paymentForm.ShowDialog();
                if (paymentForm.DialogResult == DialogResult.Cancel)
                {
                    active[row] = 1;
                }
                else
                {
                    seconds[row] = 0;
                    sessions[row] = 0;
                    ComputersDataGrid[5, row].Value = "0";
                }
            }
        }

        private DateTime GetStartTime(int sessionId)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT start FROM sessions WHERE ID=@session";
            command.Parameters.AddWithValue("@session",sessionId);
            object time = command.ExecuteScalar();
            connection.Close();
            return Convert.ToDateTime(time);
        }

        private int GetTariffId(int sessionId)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT tariffID FROM sessions WHERE ID=@session";
            command.Parameters.AddWithValue("@session", sessionId);
            object id = command.ExecuteScalar();
            connection.Close();
            return Convert.ToInt32(id);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<active.Length;i++)
            {
                seconds[i] += active[i];
                timeElapsed = TimeSpan.FromSeconds(seconds[i]);
                ComputersDataGrid[3, i].Value = timeElapsed.ToString("hh':'mm':'ss");
                if (active[i] != 0)
                    ComputersDataGrid[5, i].Value = CalcSum(sessions[i],timeElapsed);                   
            }
        }

        private string CalcSum(int sessionId, TimeSpan elapsed)
        {
            double sum = Math.Round(CalcMinutesSum(sessionId, elapsed) + CalcServicesSum(sessionId),2);
            return Convert.ToString(sum);
        }

        private double CalcMinutesSum(int sessionId, TimeSpan elapsed)
        {
            double totalminutes = elapsed.TotalMinutes;
            int id = GetTariffId(sessionId);
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT startInterval,endInterval,price,fixed FROM intervals WHERE tariffID=@tariff ORDER BY startinterval";
            command.Parameters.AddWithValue("@tariff", id);
            OleDbDataReader reader = command.ExecuteReader();
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
            int discount = GetDiscount(sessionId);
            return sum * (100 - discount) / 100;
        }

        private int GetDiscount(int sessionId)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT discount FROM sessions WHERE ID=@session";
            command.Parameters.AddWithValue("@session",sessionId);
            object discount = command.ExecuteScalar();
            connection.Close();
            return Convert.ToInt32(discount);
        }

        private double CalcServicesSum(int sessionId)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT SUM(s.price*su.quantity) FROM services s,serviceusing su WHERE su.serviceID=s.ID AND su.sessionID=@session";
            command.Parameters.AddWithValue("@session", sessionId);
            object sum = command.ExecuteScalar();
            connection.Close();
            return Convert.ToDouble(sum);
        }

        private void DiscountsMenuItem_Click(object sender, EventArgs e)
        {
            DiscountForm discountForm = new DiscountForm { connectionString = this.connectionString };
            discountForm.ShowDialog();
        }

        private void ServicesMenuItem_Click(object sender, EventArgs e)
        {
            ServicesForm servicesForm = new ServicesForm { connectionString = this.connectionString };
            servicesForm.ShowDialog();
        }

        private void KassaReportMenuItem_Click(object sender, EventArgs e)
        {
            ReportRequestForm reportForm = new ReportRequestForm { connectionString = this.connectionString};
            reportForm.ShowDialog();
        }

        private void TariffsMenuItem_Click(object sender, EventArgs e)
        {
            TariffForm tariffForm = new TariffForm { connectionString = this.connectionString };
            tariffForm.ShowDialog();
        }

        private void CategoriesMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm categoriesForm = new CategoriesForm { connectionString = this.connectionString };
            categoriesForm.ShowDialog();
        }

        private void CashierReportButton_Click(object sender, EventArgs e)
        {
            ReportRequestForm reportForm = new ReportRequestForm { connectionString = this.connectionString };
            reportForm.ShowDialog();
        }
    }
}
