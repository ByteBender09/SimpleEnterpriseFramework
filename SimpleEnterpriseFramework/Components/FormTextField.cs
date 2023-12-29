using System.Windows.Forms;
using System.Drawing;

namespace SimpleEnterpriseFramework
{
    class FormTextField
    {
        private Label _label;
        private TextBox _textBox;

        public string Value
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }

        public string LabelText
        {
            get { return _label.Text; }
            set { _label.Text = value; }
        }

        public Label ControlLabel
        {
            get { return _label; }
            set { _label = value; }
        }

        public TextBox ControlTextBox
        {
            get { return _textBox; }
            set { _textBox = value; }
        }

        public FormTextField()
        {
            _label = new Label();
            _label.AutoSize = true;
            _label.Dock = DockStyle.Left;
            _label.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _label.Margin = new Padding(4, 0, 4, 0);
            _label.TabIndex = 1;
            _label.TextAlign = ContentAlignment.MiddleCenter;

            _textBox = new TextBox();
            _textBox.Multiline = false;
            _textBox.AcceptsReturn = true;
            _textBox.AcceptsTab = false;
            _textBox.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right);
            _textBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _textBox.Margin = new Padding(4, 4, 4, 4);
            _textBox.TabIndex = 2;
        }

        public FormTextField(string labelText, string value) : this()
        {
            _label.Text = labelText;
            _textBox.Text = value;
        }
    }
}
