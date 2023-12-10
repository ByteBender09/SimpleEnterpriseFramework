using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SimpleEnterpriseFramework.DBSetting.Membership;
using SimpleEnterpriseFramework.DBSetting;
using SimpleEnterpriseFramework.DBSetting.MySQL;
using SimpleEnterpriseFramework.DBSetting.Membership.HashPassword;
using SimpleEnterpriseFramework.DBSetting.MemberShip;

namespace SimpleEnterpriseFramework
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textUserName_Enter(object sender, EventArgs e)
        {
            if (txtUsernameLogin.Text == "Account" || txtUsernameLogin.Text == "! Chưa có dữ liệu")
            {
                txtUsernameLogin.Text = "";
                txtUsernameLogin.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textUserName_Leave(object sender, EventArgs e)
        {
            if (txtUsernameLogin.Text == "")
            {
                txtUsernameLogin.Text = "Account";
                txtUsernameLogin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (txtPasswordLogin.Text == "Password" || txtPasswordLogin.Text == "! Chưa có dữ liệu")
            {
                txtPasswordLogin.Text = "";
                txtPasswordLogin.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (txtPasswordLogin.Text == "")
            {
                txtPasswordLogin.Text = "Password";
                txtPasswordLogin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (txtUsernameLogin.Text == "Account")
            {
                txtUsernameLogin.Text = "! Chưa có dữ liệu";
                txtUsernameLogin.ForeColor = System.Drawing.Color.Red;
            }
            if (txtPasswordLogin.Text == "Password")
            {
                txtPasswordLogin.Text = "! Chưa có dữ liệu";
                txtPasswordLogin.ForeColor = System.Drawing.Color.Red;
            }
            if (txtUsernameLogin.Text != "Account" && txtPasswordLogin.Text != "Password" && txtUsernameLogin.Text != "" && txtPasswordLogin.Text != "" && txtUsernameLogin.Text != "! Chưa có dữ liệu" && txtPasswordLogin.Text != "! Chưa có dữ liệu")
            {
                string username = txtUsernameLogin.Text.Trim();
                string password = HashPassword.hashPassword(txtPasswordLogin.Text.Trim());
                Membership p = new Membership(SingletonDatabase.getInstance().connString);
                if (p.Login(username, password))
                {
                    MessageBox.Show("Login success");
                    this.Hide();
                    MainForm main = new MainForm();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
        }
    }
}
