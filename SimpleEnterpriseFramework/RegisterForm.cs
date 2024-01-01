using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using SEPFramework.Forms;
using SimpleEnterpriseFramework.DBSetting.Membership.HashPassword;
using SimpleEnterpriseFramework.Factories;
using SimpleEnterpriseFramework.InterfaceForm;


namespace SimpleEnterpriseFramework
{
    public partial class RegisterForm : SEPForm, IRegisterForm
    {
        private readonly Panel panel2 = new Panel();
        public RegisterForm() : this("Register")
        {

        }
        public RegisterForm(string name) : base(name, "Register Form", new Size(width: 800, height: 480))
        {
            InitializeComponent();

            FactoryPanel factoryPanel = new FactoryPanel();
            panel2 = factoryPanel.CreateFLPanelControls("panel2", new Size(468, 452), new Point(333, -1), 3, SystemColors.ButtonHighlight);

            Button btnRegister = new SEPButtonBuilder()
                .WithName("btnRegister")
                .WithText("REGISTER")
                .WithBackColor(Color.FromArgb(31, 38, 62))
                .WithForeColor(Color.White)
                .WithLocation(new Point(45, 363))
                .WithSize(new Size(372, 43))
                .WithEventHandler((sender, e) => { register_Click(sender, e); })
                .Build();

            panel2.SuspendLayout();
            panel2.Controls.Add(isShow);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(txtRePassword);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtPasswordRegister);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtUserNameRegister);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnRegister);
            Controls.Add(panel2);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        public event EventHandler RegisterClicked;

        public void ShowForm()
        {
            this.ShowDialog();
        }

        public void HideForm()
        {
            this.Hide();
        }

        private void textUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserNameRegister.Text == "Account" || txtUserNameRegister.Text == "! Chưa có dữ liệu")
            {
                txtUserNameRegister.Text = "";
                txtUserNameRegister.ForeColor = Color.Black;
            }
        }

        private void textUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserNameRegister.Text == "")
            {
                txtUserNameRegister.Text = "Account";
                txtUserNameRegister.ForeColor = SystemColors.ScrollBar;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (txtPasswordRegister.Text == "Password" || txtPasswordRegister.Text == "! Chưa có dữ liệu")
            {
                txtPasswordRegister.UseSystemPasswordChar = true;
                txtPasswordRegister.Text = "";
                txtPasswordRegister.ForeColor = Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (txtPasswordRegister.Text == "")
            {
                txtPasswordRegister.UseSystemPasswordChar = false;
                txtPasswordRegister.Text = "Password";
                txtPasswordRegister.ForeColor = SystemColors.ScrollBar;
            }
        }

        private void textRePassword_Enter(object sender, EventArgs e)
        {
            if (txtRePassword.Text == "RePassword" || txtRePassword.Text == "! Chưa có dữ liệu" || txtRePassword.Text == "! RePassword incorrect")
            {
                txtRePassword.UseSystemPasswordChar = true;
                txtRePassword.Text = "";
                txtRePassword.ForeColor = Color.Black;
            }
        }

        private void textRePassword_Leave(object sender, EventArgs e)
        {
            if (txtRePassword.Text == "")
            {
                txtRePassword.UseSystemPasswordChar = false;
                txtRePassword.Text = "RePassword";
                txtRePassword.ForeColor = SystemColors.ScrollBar;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void register_Click(object sender, EventArgs e)
        {
            string username = txtUserNameRegister.Text.Trim();
            string password = HashPassword.hashPassword(txtPasswordRegister.Text.Trim());

            RegisterHandlerChain registerHandlerChain = new RegisterHandlerChain();
            registerHandlerChain.TryRegister(username, password, txtRePassword.Text.Trim(), txtUserNameRegister, txtPasswordRegister, txtRePassword);
        }

        private void isShow_CheckedChanged(object sender, EventArgs e)
        {
            if (isShow.Checked)
            {
                txtPasswordRegister.UseSystemPasswordChar = false;
                txtRePassword.UseSystemPasswordChar = false;

                return;
            }
            txtPasswordRegister.UseSystemPasswordChar = true;
            txtRePassword.UseSystemPasswordChar = true;
        }
        private void OnLoginClicked()
        {
            RegisterClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
