using System;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleEnterpriseFramework.Components
{
    public class SEPButton : Button
    {
        public SEPButton()
        {
            TabIndex = 0;
            UseVisualStyleBackColor = false;
            AutoSize = true;
            Cursor = Cursors.Hand;
            Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size) : this()
        {
            Name = name;
            Text = text;
            BackColor = backColor;
            ForeColor = foreColor;
            Location = location;
            Size = size;
        }

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size, AnchorStyles anchorStyles) : this(name, text, backColor, foreColor, location, size)
        {
            Name = name;
            Text = text;
            BackColor = backColor;
            ForeColor = foreColor;
            Location = location;
            Size = size;
            Anchor = anchorStyles;
        }

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size, Image image) : this()
        {
            Name = name;
            Text = text;
            BackColor = backColor;
            ForeColor = foreColor;
            Location = location;
            Size = size;
            Image = image;
            RightToLeft = RightToLeft.No;
            ImageAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(15, 0, 0, 0);
            Margin = new Padding(4);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UseVisualStyleBackColor = true;
        }

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size, EventHandler eh) : this(name, text, backColor, foreColor, location, size)
        {
            Click += eh;
        }

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size, Image image, EventHandler eh) : this(name, text, backColor, foreColor, location, size, image)
        {
            Click += eh;
        }

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size, AnchorStyles anchorStyles, EventHandler eh) : this(name, text, backColor, foreColor, location, size, anchorStyles)
        {
            Click += eh;
        }
    }
}
