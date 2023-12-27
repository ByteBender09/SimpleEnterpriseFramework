using System;
using System.Drawing;
using System.Windows.Forms;

public class SEPTextBoxBuilder
{
    private TextBox _textBox;

    public SEPTextBoxBuilder()
    {
        _textBox = new TextBox();
        _textBox.AutoSize = true;
        _textBox.Font = new Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    }

    public SEPTextBoxBuilder WithName(string name)
    {
        _textBox.Name = name;
        return this;
    }

    public SEPTextBoxBuilder WithTabIndex(int tabIndex)
    {
        _textBox.TabIndex = tabIndex;
        return this;
    }

    public SEPTextBoxBuilder WithTabStop(bool tabStop)
    {
        _textBox.TabStop = tabStop;
        return this;
    }

    public SEPTextBoxBuilder WithText(string text)
    {
        _textBox.Text = text;
        return this;
    }

    public SEPTextBoxBuilder WithForeColor(Color foreColor)
    {
        _textBox.ForeColor = foreColor;
        return this;
    }

    public SEPTextBoxBuilder WithBackColor(Color backColor)
    {
        _textBox.BackColor = backColor;
        return this;
    }

    public SEPTextBoxBuilder WithBorderStyle(BorderStyle borderStyle)
    {
        _textBox.BorderStyle = borderStyle;
        return this;
    }

    public SEPTextBoxBuilder WithLocation(Point location)
    {
        _textBox.Location = location;
        return this;
    }

    public SEPTextBoxBuilder WithSize(Size size)
    {
        _textBox.Size = size;
        return this;
    }

    public SEPTextBoxBuilder WithAnchorStyles(AnchorStyles anchorStyles)
    {
        _textBox.Anchor = anchorStyles;
        return this;
    }

    public SEPTextBoxBuilder WithEventHandler(EventHandler eh)
    {
        _textBox.Click += eh;
        return this;
    }

    public TextBox Build()
    {
        return _textBox;
    }

    public SEPTextBoxBuilder WithEnterEventHandler(EventHandler handler)
    {
        _textBox.Enter += handler;
        return this;
    }

    public SEPTextBoxBuilder WithLeaveEventHandler(EventHandler handler)
    {
        _textBox.Leave += handler;
        return this;
    }
}

