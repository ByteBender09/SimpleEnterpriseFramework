using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleEnterpriseFramework.Components;
using SimpleEnterpriseFramework.DBSetting;
using SimpleEnterpriseFramework.DBSetting.Membership.HashPassword;
using SimpleEnterpriseFramework.DBSetting.MemberShip;
using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.InterfaceForm;


namespace SimpleEnterpriseFramework
{
    public partial class RegisterForm : Form, IRegisterForm
    {
        public RegisterForm()
        {
            InitializeComponent();

            SEPButton btnRegister = new SEPButton("btnRegister", "REGISTER", Color.FromArgb(31, 38, 62), Color.White, new Point(45, 363), new Size(372, 43),
                (sender, agrs) =>
                {
                    register_Click(sender, agrs);
                }
                );
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
            if (txtUserNameRegister.Text == "Account" || txtUserNameRegister.Text == "")
            {
                txtUserNameRegister.Text = "! Chưa có dữ liệu";
                txtUserNameRegister.ForeColor = Color.Red;
            }
            if (txtPasswordRegister.Text == "Password" || txtPasswordRegister.Text == "")
            {
                txtPasswordRegister.Text = "! Chưa có dữ liệu";
                txtPasswordRegister.ForeColor = Color.Red;
            }
            if (txtRePassword.Text == "RePassword")
            {
                txtRePassword.Text = "! Chưa có dữ liệu";
                txtRePassword.ForeColor = Color.Red;
            }
            if (txtPasswordRegister.Text != "Password" && txtRePassword.Text != "RePassword")
            {
                if (txtPasswordRegister.Text != txtRePassword.Text && txtRePassword.Text != "! RePassword incorrect" && txtRePassword.Text != "! Chưa có dữ liệu")
                {
                    txtRePassword.UseSystemPasswordChar = false;
                    txtRePassword.Text = "! RePassword incorrect";
                    txtRePassword.ForeColor = Color.Red;
                }
                else if (txtPasswordRegister.Text == txtRePassword.Text && txtRePassword.Text != "! RePassword incorrect" && txtRePassword.Text != "! Chưa có dữ liệu")
                {
                    string username = txtUserNameRegister.Text.Trim();
                    string password = HashPassword.hashPassword(txtPasswordRegister.Text.Trim());
                    Membership p = new Membership(SingletonDatabase.getInstance().connString);
                    if (p.Register(username, password))
                    {
                        MessageBox.Show("Đăng ký thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        ILoginForm login = IoCContainer.Resolve<ILoginForm>();
                        login.ShowForm();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
    }
}
