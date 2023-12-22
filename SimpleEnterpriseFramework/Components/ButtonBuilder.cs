using System;
using System.Drawing;
using System.Windows.Forms;

public class SEPButtonBuilder
{
    private Button _button;

    public SEPButtonBuilder()
    {
        _button = new Button();
        _button.TabIndex = 0;
        _button.UseVisualStyleBackColor = false;
        _button.AutoSize = true;
        _button.Cursor = Cursors.Hand;
        _button.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
    }

    public SEPButtonBuilder WithName(string name)
    {
        _button.Name = name;
        return this;
    }

    public SEPButtonBuilder WithText(string text)
    {
        _button.Text = text;
        return this;
    }

    public SEPButtonBuilder WithBackColor(Color backColor)
    {
        _button.BackColor = backColor;
        return this;
    }

    public SEPButtonBuilder WithForeColor(Color foreColor)
    {
        _button.ForeColor = foreColor;
        return this;
    }

    public SEPButtonBuilder WithLocation(Point location)
    {
        _button.Location = location;
        return this;
    }

    public SEPButtonBuilder WithSize(Size size)
    {
        _button.Size = size;
        return this;
    }

    public SEPButtonBuilder WithImage(Image image)
    {
        _button.Image = image;
        _button.RightToLeft = RightToLeft.No;
        _button.ImageAlign = ContentAlignment.MiddleLeft;
        _button.Padding = new Padding(15, 0, 0, 0);
        _button.Margin = new Padding(4);
        _button.FlatAppearance.BorderSize = 0;
        _button.FlatStyle = FlatStyle.Flat;
        _button.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        _button.UseVisualStyleBackColor = true;
        return this;
    }

    public SEPButtonBuilder WithAnchorStyles(AnchorStyles anchorStyles)
    {
        _button.Anchor = anchorStyles;
        return this;
    }

    public SEPButtonBuilder WithEventHandler(EventHandler eh)
    {
        _button.Click += eh;
        return this;
    }

    public Button Build()
    {
        return _button;
    }

    public SEPButtonBuilder WithMouseEnterEventHandler(EventHandler handler)
    {
        _button.MouseEnter += handler;
        return this;
    }

    public SEPButtonBuilder WithMouseLeaveEventHandler(EventHandler handler)
    {
        _button.MouseLeave += handler;
        return this;
    }
}

