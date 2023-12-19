using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SEPButton(string name, string text, Color backColor, Color foreColor, Point location, Size size, EventHandler eh) : this(name, text, backColor, foreColor, location, size)
        {
            Click += eh;
        }
    }
}
