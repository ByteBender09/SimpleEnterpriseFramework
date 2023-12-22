using SimpleEnterpriseFramework.DBSetting;
using SimpleEnterpriseFramework.DBSetting.MemberShip;
using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.InterfaceForm;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class EmptyFieldHandler : IMemberShipHandler
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

public class RePasswordHandler : IMemberShipHandler
{
    public bool CheckCondition(string username, string password)
    {
        return password != "Password" && password != "" && password != username;
    }

    public void Handle(TextBox textBox, string errorMessage)
    {
        textBox.UseSystemPasswordChar = false;
        textBox.Text = errorMessage;
        textBox.ForeColor = Color.Red;
    }
}

public class RegisterHandlerChain
{
    private readonly List<IMemberShipHandler> _handlers;

    public RegisterHandlerChain()
    {
        _handlers = new List<IMemberShipHandler>();
        InitializeHandlers();
    }

    private void InitializeHandlers()
    {
        _handlers.Add(new EmptyFieldHandler());
        _handlers.Add(new RePasswordHandler());
        _handlers.Add(new InvalidAccountHandler());
    }

    public bool TryRegister(string username, string password, string rePassword, TextBox usernameTextBox, TextBox passwordTextBox, TextBox rePasswordTextBox)
    {
        foreach (var handler in _handlers)
        {
            if (username == "Account" || username == "")
            {
                handler.Handle(usernameTextBox, "! Chưa có dữ liệu");
                return false;
            }
            else if (passwordTextBox.Text == "Password" || passwordTextBox.Text == "")
            {
                handler.Handle(passwordTextBox, "! Chưa có dữ liệu");
                return false;
            } 
            else if (rePassword != passwordTextBox.Text)
            {
                handler.Handle(rePasswordTextBox, "! RePassword incorrect");
                return false;
            }
        }

        // Thực hiện đăng ký tài khoản
        Membership p = new Membership(SingletonDatabase.getInstance().connString);
        if (p.Register(username, password))
        {
            MessageBox.Show("Đăng ký thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ILoginForm login = IoCContainer.Resolve<ILoginForm>();
            login.ShowForm();
        }
        else
        {
            MessageBox.Show("Tên tài khoản đã tồn tại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return true;
    }
}
