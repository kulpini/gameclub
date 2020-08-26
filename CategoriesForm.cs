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
    public partial class CategoriesForm : Form
    {
        public string connectionString;
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void ShowCategories()
        {
            string queryText = "SELECT * FROM categories ORDER BY category";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryText, connectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "categories");
            CategoriesDataGrid.DataSource = dataset.Tables["categories"].DefaultView;
            CategoriesDataGrid.Columns["ID"].Visible = false;
            CategoriesDataGrid.Columns["category"].Width = 250;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CategoriesDataGrid.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Удалить категорию?\n(Удаление приведёт к удалению тарифов в этой категории)", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int index = CategoriesDataGrid.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(CategoriesDataGrid[0,index].Value);
                    DeleteCategory(id);
                    ShowCategories();
                }
            }
            else
                MessageBox.Show("Не выбрана категория для удаления!","ошибка!",MessageBoxButtons.OK);
        }

        private void DeleteCategory(int categoryId)
        {
            string queryText = "DELETE FROM categories WHERE ID="+Convert.ToString(categoryId);
            ExecuteQuery(queryText);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddCategoryForm addForm = new AddCategoryForm();
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                string queryText = "INSERT INTO categories(category) VALUES ('"+addForm.CategoryName+"')";
                ExecuteQuery(queryText);
                ShowCategories();
            }
        }

        private void ExecuteQuery(string queryText)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = queryText;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (CategoriesDataGrid.CurrentCell != null)
            {
                int index = CategoriesDataGrid.CurrentCell.RowIndex;
                int id = Convert.ToInt32(CategoriesDataGrid[0,index].Value);
                string name = Convert.ToString(CategoriesDataGrid[1,index].Value);
                AddCategoryForm editForm = new AddCategoryForm { CategoryName = name};
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    name = editForm.CategoryName;
                    string queryText = "UPDATE categories SET category='"+name+"' WHERE ID="+Convert.ToString(id);
                    ExecuteQuery(queryText);
                    ShowCategories();
                }
            }
            else
                MessageBox.Show("Не выбрана категория для редактирования!","ошибка!",MessageBoxButtons.OK);
        }
    }
}
