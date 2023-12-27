using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SEPFramework.Forms;
using SimpleEnterpriseFramework.DBSetting;
using SimpleEnterpriseFramework.DBSetting.DB;
using SimpleEnterpriseFramework.Factories;

namespace SimpleEnterpriseFramework
{
    public partial class HandleForm : SEPForm
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

        public HandleForm(MainForm mainForm, SaveType type, DataGridViewRow row, string tableName) : base(tableName, "Handle Form", new Size(width: 480, height: 450))
        {
            InitializeComponent();
            this.mainFormRef = mainForm;
            this._tableName = tableName;
            this._sType = type;

            Button btnCancel = new SEPButtonBuilder()
                .WithName("btncancel")
                .WithText("Cancel")
                .WithBackColor(Color.FromArgb(255, 255, 255))
                .WithForeColor(Color.Black)
                .WithLocation(new Point(130, 208))
                .WithSize(new Size(116, 4))
                .WithAnchorStyles(AnchorStyles.Right)
                .WithEventHandler((sender, e) => { btnCancel_Click(sender, e); })
                .Build();


            Button btnConfirm = new SEPButtonBuilder()
                .WithName("btnConfirm")
                .WithText("")
                .WithBackColor(Color.FromArgb(255, 255, 255))
                .WithForeColor(Color.Black)
                .WithLocation(new Point(236, 4))
                .WithSize(new Size(100, 32))
                .WithAnchorStyles(AnchorStyles.Left)
                .WithEventHandler((sender, e) => { btnConfirm_Click(sender, e); })
                .Build();

            buttonLayoutPanel.Controls.Add(btnCancel, 0, 0);
            buttonLayoutPanel.Controls.Add(btnConfirm, 2, 0);
            panelBtn.Controls.Add(buttonLayoutPanel);
            Controls.Add(panelBtn);
            panelBtn.ResumeLayout(false);
            buttonLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);

            

            if (type == SaveType.Insert)
            {
                Text = "INSERT";
                btnConfirm.Text = "Insert";
            }
             else
            {
                Text = "UPDATE";
                btnConfirm.Text = "Update";
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
