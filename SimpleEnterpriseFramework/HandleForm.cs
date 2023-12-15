﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleEnterpriseFramework.DBSetting;
using SimpleEnterpriseFramework.DBSetting.DB;
using SimpleEnterpriseFramework.Factories;

namespace SimpleEnterpriseFramework
{
    public partial class HandleForm : Form
    {
        public enum SaveType
        {
            Insert = 0,
            Update = 1,
        }

        private MainForm mainFormRef;
        SaveType _sType;
        List<FormTextField> _fields = new List<FormTextField>();
        SqlServerDAO sqlServerDAO = new SqlServerDAO(SingletonDatabase.getInstance().connString);
        string _tableName = "";

        public HandleForm(MainForm mainForm, SaveType type, DataGridViewRow row, string tableName)
        {
            InitializeComponent();
            this.mainFormRef = mainForm;
            this._tableName = tableName;
            this._sType = type;

            if (type == SaveType.Insert)
            {
                this.Text = "INSERT";
                this.btnConfirm.Text = "Insert";
            }
             else
            {
                this.Text = "UPDATE";
                this.btnConfirm.Text = "Update";
            }

            foreach (DataGridViewColumn col in row.DataGridView.Columns)
            {
                string label = col.HeaderText;
                string value = type == SaveType.Update ? row.Cells[col.Index].Value.ToString() : "";
                _fields.Add(new FormTextField(label, value));
            }

            FactoryPanel factoryPanel = new FactoryPanel();

            panelBody = factoryPanel
                .CreateTLPabelDockFillFormControls("rowPanel", _fields);


            Controls.Add(panelBody);
        }

        public Dictionary<string, object> GetFormDataAsDict()
        {
            return this
                ._fields
                .Aggregate(new Dictionary<string, object>(), (acc, curr) =>
                {
                    acc[curr.LabelText] = curr.Value;
                    return acc;
                });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> insertDict = this.GetFormDataAsDict();
            if (this._sType == SaveType.Insert)
            {
                sqlServerDAO.Insert(insertDict, this._tableName);
            }
            else if (this._sType == SaveType.Update)
            {
                sqlServerDAO.Update(insertDict, this._tableName);
            }
            this.mainFormRef.ReloadData();
            this.Dispose();
        }
    }
}
