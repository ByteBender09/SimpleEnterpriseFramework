using System;
using System.Drawing;
using System.Windows.Forms;

public class SEPTextBoxBuilder : ITextBoxBuilder
{
    private TextBox _textBox;

    public SEPTextBoxBuilder()
    {
        _textBox = new TextBox();
        _textBox.AutoSize = true;
        _textBox.Font = new Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    }

    public ITextBoxBuilder WithName(string name)
    {
        _textBox.Name = name;
        return this;
    }

    public ITextBoxBuilder WithTabIndex(int tabIndex)
    {
        _textBox.TabIndex = tabIndex;
        return this;
    }

    public ITextBoxBuilder WithTabStop(bool tabStop)
    {
        _textBox.TabStop = tabStop;
        return this;
    }

    public ITextBoxBuilder WithText(string text)
    {
        _textBox.Text = text;
        return this;
    }

    public ITextBoxBuilder WithForeColor(Color foreColor)
    {
        _textBox.ForeColor = foreColor;
        return this;
    }

    public ITextBoxBuilder WithBorderStyle(BorderStyle borderStyle)
    {
        _textBox.BorderStyle = borderStyle;
        return this;
    }

    public ITextBoxBuilder WithLocation(Point location)
    {
        _textBox.Location = location;
        return this;
    }

    public ITextBoxBuilder WithSize(Size size)
    {
        _textBox.Size = size;
        return this;
    }

    public ITextBoxBuilder WithEnterEventHandler(EventHandler handler)
    {
        _textBox.Enter += handler;
        return this;
    }

    public ITextBoxBuilder WithLeaveEventHandler(EventHandler handler)
    {
        _textBox.Leave += handler;
        return this;
    }

    public TextBox Build()
    {
        return _textBox;
    }
}

