using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEnterpriseFramework
{
    public partial class MainForm : Form
    {
        public MainForm(List<string> tables)
        {
            InitializeComponent();
            InitDataGridView(tables);
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDeleteRow.BackColor = Color.Red;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteRow.BackColor = Color.FromArgb(31, 38, 62);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void DbCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbCombobox.SelectedItem != null)
            {
                UpdateDataGridView(dbCombobox.SelectedItem.ToString());
            }
        }

        private void UpdateDataGridView(string selectedTable)
        {
            dataGridView.DataSource = _sqlServerDao.GetAllData(selectedTable);
        }

        private void InitDataGridView(List<string> tables)
        {
            dbCombobox.DataSource = tables;
            dbCombobox.SelectedIndexChanged += DbCombobox_SelectedIndexChanged;

            if (dbCombobox.SelectedItem != null)
            {
                UpdateDataGridView(dbCombobox.SelectedItem.ToString());
            }
        }
    }
}
