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

        List<FormTextField> _fields = new List<FormTextField>();

        public HandleForm(SaveType type, DataGridViewRow row)
        {
            InitializeComponent();

            if (type == SaveType.Insert) this.Text = "INSERT"; else this.Text = "UPDATE";

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
    }
}
