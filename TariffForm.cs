﻿using System;
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
    public partial class TariffForm : Form
    {
        public string connectionString;
        private int categoryId;
        public TariffForm()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TariffsDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить тариф из списка?","",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int row = TariffsDataGrid.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(TariffsDataGrid[0,row].Value);
                    DeleteTariff(id);
                    ShowTariffs();
                }
            }
            else
                MessageBox.Show("Не выбран тариф для удаления!","Ошибка",MessageBoxButtons.OK);
        }

        private void TafiffForm_Load(object sender, EventArgs e)
        {
            FillCategoryList();
        }

        private void FillCategoryList()
        {
            string queryText = "SELECT * FROM categories ORDER BY category";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CategoryComboBox.DataSource = table;
            CategoryComboBox.DisplayMember = "category";
            CategoryComboBox.ValueMember = "ID";
        }

        private void ShowTariffs()
        {
            string queryText = "SELECT * FROM tariffs WHERE categoryID="+Convert.ToString(categoryId)+" ORDER BY tariffname";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "tariffs");
            TariffsDataGrid.DataSource = dataset.Tables["tariffs"].DefaultView;
            TariffsDataGrid.Columns["ID"].Visible = false;
            TariffsDataGrid.Columns["tariffname"].Width = 210;
            TariffsDataGrid.Columns["categoryID"].Visible = false;
        }

        private void DeleteTariff(int tariffId)
        {
            string queryText = "DELETE FROM tariffs WHERE ID="+Convert.ToString(tariffId);
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
            if (TariffsDataGrid.CurrentCell != null)
            {
                int row = TariffsDataGrid.CurrentCell.RowIndex;
                int id = Convert.ToInt32(TariffsDataGrid[0,row].Value);
                string name = Convert.ToString(TariffsDataGrid[1,row].Value);
                AddTariffForm editForm = new AddTariffForm { TariffId = id,TariffName = name, connectionString = this.connectionString};
                editForm.ShowDialog();
                ShowTariffs();
            }
            else
                MessageBox.Show("Не выбран тариф для редактирования!","Ошибка!",MessageBoxButtons.OK);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddTariffForm addForm = new AddTariffForm { connectionString = this.connectionString};
            addForm.ShowDialog();
            ShowTariffs();
        }

        private void TariffsDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = TariffsDataGrid.CurrentCell.RowIndex;
            int id = Convert.ToInt32(TariffsDataGrid[0,row].Value);
            ShowIntervals(id);
        }

        private void ShowIntervals(int tariffId)
        {
            string queryText = "SELECT startInterval,endInterval,price,fixed FROM intervals WHERE tariffID=" + Convert.ToString(tariffId)+" ORDER BY startInterval";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "intervals");
            IntervalsDataGrid.DataSource = dataset.Tables["intervals"].DefaultView;
            IntervalsDataGrid.Columns["startInterval"].HeaderText = "нач.,мин.";
            IntervalsDataGrid.Columns["startInterval"].Width = 80;
            IntervalsDataGrid.Columns["endInterval"].HeaderText = "кон.,мин.";
            IntervalsDataGrid.Columns["endInterval"].Width = 80;
            IntervalsDataGrid.Columns["price"].HeaderText = "стоимость.,грн.";
            IntervalsDataGrid.Columns["price"].Width = 150;
            IntervalsDataGrid.Columns["fixed"].HeaderText ="Фиксир.стоим.";
            IntervalsDataGrid.Columns["price"].Width = 120;
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            CategoriesForm categoriesForm = new CategoriesForm { connectionString = this.connectionString };
            categoriesForm.ShowDialog();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView row = CategoryComboBox.SelectedItem as DataRowView;
            if (row != null)
            {
                categoryId = Convert.ToInt32(row["ID"]);
                ShowTariffs();
            }
        }
    }
}
