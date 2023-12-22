using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class EmptyDataHandler : IMemberShipHandler
{
    public bool CheckCondition(string username, string password)
    {
        return string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password);
    }

    public void Handle(TextBox textBox, string errorMessage)
    {
        textBox.Text = errorMessage;
        textBox.ForeColor = Color.Red;
    }
}

public class InvalidAccountHandler : IMemberShipHandler
{
    public bool CheckCondition(string username, string password)
    {
        return username == "Account" || password == "Password";
    }

    public void Handle(TextBox textBox, string errorMessage)
    {
        if (textBox.Name == "txtUsernameLogin" && textBox.Text == "Account")
        {
            textBox.Text = errorMessage;
        }
        else if (textBox.Name == "txtPasswordLogin" && textBox.Text == "Password")
        {
            textBox.Text = errorMessage;
        }
        textBox.ForeColor = Color.Red;
    }
}

public class LoginHandlerChain
{
    private readonly List<IMemberShipHandler> _handlers;

    public LoginHandlerChain()
    {
        _handlers = new List<IMemberShipHandler>();
        InitializeHandlers();
    }

    private void InitializeHandlers()
    {
        _handlers.Add(new EmptyDataHandler());
        _handlers.Add(new InvalidAccountHandler());
    }

    public bool TryLogin(string username, string password, TextBox usernameTextBox, TextBox passwordTextBox)
    {
        foreach (var handler in _handlers)
        {
            if (handler.CheckCondition(username, password))
            {
                handler.Handle(usernameTextBox, "! Chưa có dữ liệu");
                handler.Handle(passwordTextBox, "! Chưa có dữ liệu");
                return false;
            }
        }

        return true;
    }
}
