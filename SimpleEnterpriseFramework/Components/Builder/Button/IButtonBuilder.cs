using System;
using System.Drawing;
using System.Windows.Forms;

public interface IButtonBuilder
{
    IButtonBuilder WithName(string name);
    IButtonBuilder WithText(string text);
    IButtonBuilder WithBackColor(Color backColor);
    IButtonBuilder WithForeColor(Color foreColor);
    IButtonBuilder WithLocation(Point location);
    IButtonBuilder WithSize(Size size);
    IButtonBuilder WithImage(Image image);
    IButtonBuilder WithAnchorStyles(AnchorStyles anchorStyles);
    IButtonBuilder WithEventHandler(EventHandler eh);
    IButtonBuilder WithMouseEnterEventHandler(EventHandler handler);
    IButtonBuilder WithMouseLeaveEventHandler(EventHandler handler);

    Button Build();
}

