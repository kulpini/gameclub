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
    public partial class ComputersForm : Form
    {
        public string connectionString;
        public ComputersForm()
        {
            InitializeComponent();
        }

        private void ComputersForm_Load(object sender, EventArgs e)
        {
            ShowComputers();
        }

        private void ShowComputers()
        {
            string queryText = "SELECT * FROM computers ORDER BY computername";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "computers");
            ComputersDataGrid.DataSource = dataset.Tables["computers"].DefaultView;
            ComputersDataGrid.Columns["ID"].Visible = false;
            ComputersDataGrid.Columns["computername"].HeaderText = "Наименование компьютера";
            ComputersDataGrid.Columns["computername"].Width = 250;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ComputersDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить компьютер из списка?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int index = ComputersDataGrid.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(ComputersDataGrid[0, index].Value);
                    DeleteComputer(id);
                    ShowComputers();
                }

            }
            else
                MessageBox.Show("Не выбрана запись для удаления","Ошибка!",MessageBoxButtons.OK);
        }

        private void DeleteComputer(int id)
        {
            string queryText = "DELETE FROM computers WHERE ID=" + Convert.ToString(id);
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (ComputersDataGrid.CurrentCell != null)
            {
                int index = ComputersDataGrid.CurrentCell.RowIndex;
                string computerName = Convert.ToString(ComputersDataGrid[1, index].Value);
                AddComputerForm editForm = new AddComputerForm { ComputerName = computerName};
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    int ID = Convert.ToInt32(ComputersDataGrid[0, index].Value);
                    computerName = editForm.ComputerName;
                    EditComputer(ID, computerName);
                    ShowComputers();
                }
            }
            else
                MessageBox.Show("Не выбрана запись для редактирования!","Ошибка!",MessageBoxButtons.OK);
        }

        private void EditComputer(int id, string newname)
        {
            string queryText = "UPDATE computers SET computername='" + newname + "' WHERE ID=" + Convert.ToString(id);
            ExecuteQuery(queryText);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddComputerForm addForm = new AddComputerForm();
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                string computerName = addForm.ComputerName;
                AddComputer(computerName);
                ShowComputers();
            }
        }

        private void AddComputer(string computername)
        {
            string queryText = "INSERT INTO computers(computername) VALUES ('"+computername+"')";
            ExecuteQuery(queryText);
        }
    }
}
