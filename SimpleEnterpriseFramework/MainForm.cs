using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Hide();
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

            dataGridView.CellMouseDoubleClick += OnCellDoubleClicked;
        }

        private void OnCellDoubleClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRowCollection = dataGridView.SelectedRows;
            if (selectedRowCollection.Count <= 0)
            {
                MessageBox.Show("Error: No row selected");
            }
            else
            {
                DataGridViewRow selectedFirstRow = selectedRowCollection[0];
                new HandleForm(HandleForm.SaveType.Update, selectedFirstRow).Show();
            }   
        }

        public Dictionary<string, object> RowDataToDict(int rowIndex)
        {
            return dataGridView.Rows[rowIndex]
                .Cells
                .Cast<DataGridViewCell>()
                .Aggregate(new Dictionary<string, object>(), (acc, item) =>
                {
                    acc[dataGridView.Columns[item.ColumnIndex].HeaderText] = item.Value;
                    return acc;
                });
        }
    }
}
