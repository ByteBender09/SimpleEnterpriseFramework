using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SEPFramework.Forms
{
    public partial class SEPForm : Form
    {
        private static readonly Size t_minSize = new Size(width: 500, height: 300);

        // This panel contains main content in the center of form
        protected Panel panelMain;

        private SEPForm()
        {
            MinimumSize = t_minSize;
        }

        protected SEPForm(string name, string titleText, Size size) : this()
        {
            Name = name;
            SetUpLayouts();
            SetUpSize(size);
        }
        private void SetUpLayouts()
        {
            Controls.Clear();
            Controls.AddRange(new Control[] { this.panelMain });
        }
        private void SetUpSize(Size size)
        {
            Size = size;
        }
    }
}
