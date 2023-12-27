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
        private static readonly float t_defaultTitleFontSize = 20;
        private static readonly Size t_minSize = new Size(width: 500, height: 300);
        private string _titleText;

        // This panel contains main content in the center of form
        protected Panel panel2;

        protected Label _labelTitle = new Label();

        private SEPForm()
        {
            MinimumSize = t_minSize;
        }

        protected SEPForm(string name, string titleText, Size size) : this()
        {
            _titleText = titleText;
            Size = size;
            Name = name;
        }

        public SEPForm(string name, string titleText,
            Size size, Panel panelContent) : this(name, titleText, size)
        {
            panel2 = panelContent;
            
            SetUpForm();
        }

        protected void SetUpForm()
        {
            SetUpTitle();
            SetUpPanelMain();
            SetUpLayouts();
        }

        private void SetUpLayouts()
        {
            this.Controls.Clear();
            this.Controls.AddRange(new Control[] { this.panel2, this._labelTitle });
        }
        private void SetUpTitle()
        {
            _labelTitle.Text = _titleText;
            _labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            _labelTitle.Height = 50;
            _labelTitle.Font = new Font(Font.FontFamily, t_defaultTitleFontSize, FontStyle.Bold);
            _labelTitle.Dock = DockStyle.Top;
        }

        private void SetUpPanelMain()
        {
            this.panel2.Dock = DockStyle.Fill;
        }
    }
}
