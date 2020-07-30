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
        private TimeSpan timeElapsed;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
                user = loginForm.LoginComboBox.Text;
                if (user != "administrator")
                    menuStrip.Visible = false;
                userId = loginForm.userId;
                UserNameLabel.Text = GetUserName();
                StartWorking();
            }
            else Application.Exit();
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
            DataGridViewButtonColumn btnStartColumn = new DataGridViewButtonColumn { Name = "startbutton", Width = 200 };
            ComputersDataGrid.Columns.Add(btnStartColumn);
            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn { Name = "time",Width = 100 };
            ComputersDataGrid.Columns.Add(timeColumn);
            DataGridViewButtonColumn btnSumColumn = new DataGridViewButtonColumn { Name = "sumbutton", Width = 200 };
            ComputersDataGrid.Columns.Add(btnSumColumn);
            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn { Name = "amount", Width = 80 };
            ComputersDataGrid.Columns.Add(amountColumn);
            DataGridViewButtonColumn btnPayColumn = new DataGridViewButtonColumn { Name = "paybutton", Width = 200 };
            ComputersDataGrid.Columns.Add(btnPayColumn);
            for (int i = 0; i < ComputersDataGrid.RowCount; i++)
            {
                ComputersDataGrid[2, i].Value = "Старт / Стоп";
                ComputersDataGrid[3, i].Value = "00:00:00";
                ComputersDataGrid[4, i].Value = "Сумма";
                ComputersDataGrid[5, i].Value = "0";
                ComputersDataGrid[6, i].Value = "Оплата...";
            }
        }

        private void InitSettings()
        {
            int size = ComputersDataGrid.RowCount;
            active = new int[size];
            seconds = new int[size];
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
            string queryText = "UPDATE userlist SET [password]='"+ newPassword + "' WHERE [login]='administrator'";
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
        }

        private void StopWorking()
        {
            string queryText = "UPDATE working SET endWork='"+DateTime.Now.ToString()+"' WHERE userID="+Convert.ToString(userId)+
                " AND ID=(SELECT max(ID) FROM working)";
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
            StopWorking();
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
                    active[row] = 1;
                else
                    active[row] = 0;
            }
            if (e.ColumnIndex == 4)
            {
                int ID = Convert.ToInt32(ComputersDataGrid[0, row].Value);
                int secondsPassed = seconds[row];
                ComputersDataGrid[5, row].Value = CalcAmount(ID, secondsPassed);
            }
            if (e.ColumnIndex == 6) 
            {
                seconds[row] = 0;
                active[row] = 0;
            }
        }

        private int CalcAmount(int computerId,int seconds)
        {
            return 150;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<active.Length;i++)
            {
                seconds[i] += active[i];
                timeElapsed = TimeSpan.FromSeconds(seconds[i]);
                ComputersDataGrid[3, i].Value = timeElapsed.ToString("hh':'mm':'ss");
            }
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

        private void TariffsMenuItem_Click(object sender, EventArgs e)
        {
            TariffForm tariffForm = new TariffForm { connectionString = this.connectionString};
            tariffForm.ShowDialog();
        }
    }
}
