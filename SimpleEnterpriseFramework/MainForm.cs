using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.InterfaceForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SimpleEnterpriseFramework.Components;
using System.ComponentModel;

namespace SimpleEnterpriseFramework
{
    public partial class MainForm : Form
    {
        private SEPButton btnDeleteRow;
        public MainForm(List<string> tables)
        {
            InitializeComponent();
            InitializeLayout();
            InitDataGridView(tables);
        }

        private void InitializeLayout()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

            SEPButton btnAddRow = new SEPButton(
                "btnAddRow",
                "New Row",
                Color.FromArgb(31, 38, 62),
                Color.White,
                new Point(0, 79),
                new Size(313, 64),
                ((Image)resources.GetObject("btnAddRow.Image")),
                (sender, args) =>
                {
                    btnAddRow_Click(sender, args);
                }
            );

            SEPButton btnEditRow = new SEPButton(
                "btnEditRow",
                "Edit Row",
                Color.FromArgb(31, 38, 62),
                Color.White,
                new Point(0, 151),
                new Size(309, 64),
                ((Image)resources.GetObject("btnEditRow.Image")),
                (sender, args) =>
                {
                    btnAddRow_Click(sender, args);
                }
            );

            btnDeleteRow = new SEPButton(
                "btnDeleteRow",
                "Delete Row",
                Color.FromArgb(31, 38, 62),
                Color.White,
                new Point(0, 223),
                new Size(309, 64),
                ((Image)resources.GetObject("btnDeleteRow.Image")),
                (sender, args) =>
                {
                    btnDelete_Click(sender, args);
                }
            );

            btnDeleteRow.MouseEnter += new EventHandler(btnDelete_MouseEnter);
            btnDeleteRow.MouseLeave += new EventHandler(btnDelete_MouseLeave);

            SEPButton btnLogout = new SEPButton(
                "btnLogout",
                "Logout",
                Color.FromArgb(31, 38, 62),
                Color.White,
                new Point(0, 628),
                new Size(309, 64),
                ((Image)resources.GetObject("btnLogout.Image")),
                (sender, args) =>
                {
                    btnLogout_Click(sender, args);
                }
            );

            panel3.Controls.Add(btnAddRow);
            panel3.Controls.Add(btnEditRow);
            panel3.Controls.Add(btnDeleteRow);
            panel3.Controls.Add(btnLogout);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
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
