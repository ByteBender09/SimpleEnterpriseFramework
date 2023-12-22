using System.Windows.Forms;

public interface IMemberShipHandler
{
    bool CheckCondition(string username, string password);
    void Handle(TextBox textBox, string errorMessage);
}
