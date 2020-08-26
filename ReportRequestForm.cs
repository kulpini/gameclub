using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameclub
{
    public partial class ReportRequestForm : Form
    {
        public string connectionString;
        public ReportRequestForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void MakeReportButton_Click(object sender, EventArgs e)
        {
            CashReportForm reportForm = new CashReportForm { connectionString = this.connectionString, ReportDate = ReportDatePicker.Value };
            reportForm.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }
    }
}
