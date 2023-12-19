using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.InterfaceForm;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = this.dataGridView.SelectedRows;
            if (selectedRows.Count <= 0)
            {
                MessageBox.Show("Chưa có dòng nào được chọn");
                return;
            }
            foreach (DataGridViewRow row in selectedRows)
            {
                _sqlServerDao.Delete(dbCombobox.SelectedItem.ToString(), this.RowDataToDict(row.Index));
                ReloadData();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            IoCContainer.Register<ILoginForm, LoginForm>();
            Hide();
            ILoginForm login = IoCContainer.Resolve<ILoginForm>();
            login.ShowForm();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            new HandleForm(this, HandleForm.SaveType.Insert, this.dataGridView.Rows[0], dbCombobox.SelectedItem.ToString()).Show();
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = this.dataGridView.SelectedRows;
            if (selectedRows.Count <= 0)
            {
                MessageBox.Show("Chưa có dòng nào được chọn!");
                return;
            }
            new HandleForm(this, HandleForm.SaveType.Update, selectedRows[0], dbCombobox.SelectedItem.ToString()).Show();
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

        public void ReloadData()
        {
            dataGridView.DataSource = _sqlServerDao.GetAllData(dbCombobox.SelectedItem.ToString());
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
                MessageBox.Show("Chưa có dòng nào được chọn!");
            }
            else
            {
                DataGridViewRow selectedFirstRow = selectedRowCollection[0];
                new HandleForm(this, HandleForm.SaveType.Update, selectedFirstRow, dbCombobox.SelectedItem.ToString()).Show();
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
