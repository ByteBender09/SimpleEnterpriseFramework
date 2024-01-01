using System;
using System.Drawing;
using System.Windows.Forms;

public interface ITextBoxBuilder
{
    ITextBoxBuilder WithName(string name);
    ITextBoxBuilder WithTabIndex(int tabIndex);
    ITextBoxBuilder WithTabStop(bool tabStop);
    ITextBoxBuilder WithText(string text);
    ITextBoxBuilder WithForeColor(Color foreColor);
    ITextBoxBuilder WithBorderStyle(BorderStyle borderStyle);
    ITextBoxBuilder WithLocation(Point location);
    ITextBoxBuilder WithSize(Size size);
    ITextBoxBuilder WithEnterEventHandler(EventHandler handler);
    ITextBoxBuilder WithLeaveEventHandler(EventHandler handler);

    TextBox Build();
}
