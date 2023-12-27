using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimpleEnterpriseFramework.DBSetting;
using SimpleEnterpriseFramework.DBSetting.Membership.HashPassword;
using SimpleEnterpriseFramework.DBSetting.MemberShip;
using SimpleEnterpriseFramework.InterfaceForm;
using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.Factories;
using SEPFramework.Forms;
using System.Xml.Linq;

namespace SimpleEnterpriseFramework
{
    public partial class LoginForm : SEPForm, ILoginForm
    {
        public event EventHandler LoginClicked;
        private TextBox txtUsernameLogin;
        private TextBox txtPasswordLogin;
        private Panel panel2 = new Panel();

        public LoginForm() : this("Login")
        {

        }
        public LoginForm(string name) : base(name, "Login Form", new Size(width: 800, height: 480))
        {
            InitializeComponent();

            FactoryPanel factoryPanel = new FactoryPanel();
            factoryPanel.CreateFLPanelControls(panel2, "panel2", new Size(468, 452), new Point(335, 0), 1, SystemColors.ButtonHighlight);

            txtUsernameLogin = new SEPTextBoxBuilder()
                .WithName("txtUsernameLogin")
                .WithText("")
                .WithTabIndex(9)
                .WithTabStop(true)
                .WithForeColor(SystemColors.InfoText)
                .WithBorderStyle(BorderStyle.None)
                .WithSize(new Size(306, 20))
                .WithLocation(new Point(111, 140))
                .WithEnterEventHandler((sender, e) => { textUserName_Enter(sender, e); })
                .WithLeaveEventHandler((sender, e) => { textUserName_Leave(sender, e); })
                .Build();
            txtPasswordLogin = new SEPTextBoxBuilder()
                .WithName("txtPasswordLogin")
                .WithText("Password")
                .WithTabIndex(12)
                .WithTabStop(false)
                .WithForeColor(SystemColors.ScrollBar)
                .WithBorderStyle(BorderStyle.None)
                .WithSize(new Size(306, 20))
                .WithLocation(new Point(111, 216))
                .WithEnterEventHandler((sender, e) => { textPassword_Enter(sender, e); })
                .WithLeaveEventHandler((sender, e) => { textPassword_Leave(sender, e); })
                .Build();

            // Gắn sự kiện cho nút đăng nhập
            Button btnLogin = new SEPButtonBuilder()
                .WithName("btnLogin")
                .WithText("LOGIN")
                .WithBackColor(Color.FromArgb(31, 38, 62))
                .WithForeColor(Color.White)
                .WithLocation(new Point(45, 328))
                .WithSize(new Size(372, 43))
                .WithEventHandler((sender, e) => { login_Click(sender, e); })
                .Build();

            panel2.SuspendLayout();
            panel2.Controls.Add(isShow);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtUsernameLogin);
            panel2.Controls.Add(txtPasswordLogin);
            panel2.Controls.Add(btnLogin);
            Controls.Add(panel2);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        public void ShowForm()
        {
            this.Show();
        }

        public void HideForm()
        {
            this.Hide();
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string GetUsername()
        {
            return txtUsernameLogin.Text;
        }

        public string GetPassword()
        {
            return txtPasswordLogin.Text;
        }

        public void ClearUsername()
        {
            txtUsernameLogin.Text = "";
            txtUsernameLogin.ForeColor = Color.Black;
        }

        public void ClearPassword()
        {
            txtPasswordLogin.UseSystemPasswordChar = false;
            txtPasswordLogin.Text = "Password";
            txtPasswordLogin.ForeColor = SystemColors.ScrollBar;
        }

        public void SetTables(List<string> tables)
        {
            // Xử lý logic hiển thị danh sách bảng sau khi đăng nhập thành công
            MainForm main = new MainForm(tables, "Main Form");
            main.ShowDialog();
        }

        // Gọi sự kiện đăng nhập khi người dùng nhấn nút đăng nhập
        private void OnLoginClicked()
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }

        private void textUserName_Enter(object sender, EventArgs e)
        {
            if (txtUsernameLogin.Text == "Account" || txtUsernameLogin.Text == "! Chưa có dữ liệu")
            {
                txtUsernameLogin.Text = "";
                txtUsernameLogin.ForeColor = Color.Black;
            }
        }

        private void textUserName_Leave(object sender, EventArgs e)
        {
            if (txtUsernameLogin.Text == "")
            {
                txtUsernameLogin.Text = "Account";
                txtUsernameLogin.ForeColor = SystemColors.ScrollBar;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (txtPasswordLogin.Text == "Password" || txtPasswordLogin.Text == "! Chưa có dữ liệu")
            {
                txtPasswordLogin.UseSystemPasswordChar = true;
                txtPasswordLogin.Text = "";
                txtPasswordLogin.ForeColor = Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (txtPasswordLogin.Text == "")
            {
                txtPasswordLogin.UseSystemPasswordChar = false;
                txtPasswordLogin.Text = "Password";
                txtPasswordLogin.ForeColor = SystemColors.ScrollBar;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            string username = txtUsernameLogin.Text.Trim();
            string password = HashPassword.hashPassword(txtPasswordLogin.Text.Trim());

            LoginHandlerChain loginHandlerChain = new LoginHandlerChain();
            bool canLogin = loginHandlerChain.TryLogin(username, password, txtUsernameLogin, txtPasswordLogin);

            if (canLogin)
            {
                Membership p = new Membership(SingletonDatabase.getInstance().connString);
                if (p.Login(username, password))
                {
                    MessageBox.Show("Đăng nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    // Get list tables name in database
                    List<string> tables = SingletonDatabase.getInstance().GetAllTablesName();
                    MainForm main = new MainForm(tables, "Main Form");
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HideForm();
            IoCContainer.Register<IRegisterForm, RegisterForm>();
            IRegisterForm register = IoCContainer.Resolve<IRegisterForm>();
            register.ShowForm();
        }

        private void isShow_CheckedChanged(object sender, EventArgs e)
        {
            if (isShow.Checked)
            {
                txtPasswordLogin.UseSystemPasswordChar = false;

                return;
            }
            txtPasswordLogin.UseSystemPasswordChar = true;
        }
    }
}
