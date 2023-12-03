using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleEnterpriseFramework.DBSetting.Membership.HashPassword;
using SimpleEnterpriseFramework.DBSetting.MySQL;


namespace SimpleEnterpriseFramework
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserNameRegister.Text == "Account" || txtUserNameRegister.Text == "! Chưa có dữ liệu")
            {
                txtUserNameRegister.Text = "";
                txtUserNameRegister.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserNameRegister.Text == "")
            {
                txtUserNameRegister.Text = "Account";
                txtUserNameRegister.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (txtPasswordRegister.Text == "Password" || txtPasswordRegister.Text == "! Chưa có dữ liệu")
            {
                txtPasswordRegister.Text = "";
                txtPasswordRegister.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (txtPasswordRegister.Text == "")
            {
                txtPasswordRegister.Text = "Password";
                txtPasswordRegister.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void textRePassword_Enter(object sender, EventArgs e)
        {
            if (txtRePassword.Text == "RePassword" || txtRePassword.Text == "! Chưa có dữ liệu" || txtRePassword.Text == "! RePassword incorrect")
            {
                txtRePassword.Text = "";
                txtRePassword.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textRePassword_Leave(object sender, EventArgs e)
        {
            if (txtRePassword.Text == "")
            {
                txtRePassword.Text = "RePassword";
                txtRePassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (txtUserNameRegister.Text == "Account" || txtUserNameRegister.Text == "")
            {
                txtUserNameRegister.Text = "! Chưa có dữ liệu";
                txtUserNameRegister.ForeColor = System.Drawing.Color.Red;
            }
            if (txtPasswordRegister.Text == "Password" || txtPasswordRegister.Text == "")
            {
                txtPasswordRegister.Text = "! Chưa có dữ liệu";
                txtPasswordRegister.ForeColor = System.Drawing.Color.Red;
            }
            if (txtRePassword.Text == "RePassword")
            {
                txtRePassword.Text = "! Chưa có dữ liệu";
                txtRePassword.ForeColor = System.Drawing.Color.Red;
            }
            if (txtPasswordRegister.Text != "Password" && txtRePassword.Text != "RePassword")
            {
                if (txtPasswordRegister.Text != txtRePassword.Text && txtRePassword.Text != "! RePassword incorrect" && txtRePassword.Text != "! Chưa có dữ liệu")
                {
                    txtRePassword.Text = "! RePassword incorrect";
                    txtRePassword.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    using (var connectionHelper = new MySQL("Server=localhost;Database=account;User Id=root;Password=123456789;"))
                    {
                        if (connectionHelper.OpenConnection())
                        {
                            string account = txtUserNameRegister.Text.Trim();
                            string password = txtPasswordRegister.Text.Trim();


                            try
                            {
                                using (var command = connectionHelper.GetConnection().CreateCommand())
                                {
                                    // Kiểm tra xem tên người dùng đã tồn tại chưa
                                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                                    command.CommandText = checkUserQuery;
                                    command.Parameters.AddWithValue("@Username", account);

                                    int existingUserCount = Convert.ToInt32(command.ExecuteScalar());

                                    if (existingUserCount > 0)
                                    {
                                        MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn một tên người dùng khác.");
                                    }
                                    else
                                    {
                                        // Thêm tài khoản mới vào cơ sở dữ liệu
                                        string insertUserQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                                        command.CommandText = insertUserQuery;
                                        command.Parameters.Clear(); // Xóa các tham số cũ

                                        // Băm mật khẩu trước khi lưu vào cơ sở dữ liệu
                                        string hashedPassword = HashPassword.hashPassword(password);

                                        command.Parameters.AddWithValue("@Username", account);
                                        command.Parameters.AddWithValue("@Password", hashedPassword);

                                        int rowsAffected = command.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Đăng ký thành công");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Đăng ký thất bại");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                            }
                            finally
                            {
                                // Đóng kết nối sau khi thực hiện xong
                                connectionHelper.CloseConnection();
                            }
                        }
                    }
                }
            }
        }
    }
}
