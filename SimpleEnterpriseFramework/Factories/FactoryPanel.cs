using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace SimpleEnterpriseFramework.Factories
{
    class FactoryPanel
    {
        public TableLayoutPanel CreateTLPabelDockFillFormControls(string panelName, List<FormTextField> controls)
        {
            TableLayoutPanel panel = new TableLayoutPanel() { Name = panelName, Dock = DockStyle.Fill, Padding = new Padding(0, 2, 0, 0) };
            panel.RowCount = controls.Count;
            panel.ColumnCount = 1;

            for (int i = 0; i < controls.Count; ++i)
            {
                panel.Controls.Add(controls[i].ControlLabel, 0, i);
                panel.Controls.Add(controls[i].ControlTextBox, 1, i);
            }

            panel.Controls.Add(new Control());
            return panel;
        }
    }
}
