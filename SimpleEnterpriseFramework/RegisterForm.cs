using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEnterpriseFramework
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Account" || textBox1.Text == "! Chưa có dữ liệu")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Account";
                textBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password" || textBox2.Text == "! Chưa có dữ liệu")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "RePassword" || textBox3.Text == "! Chưa có dữ liệu" || textBox3.Text == "! RePassword incorrect")
            {
                textBox3.Text = "";
                textBox3.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "RePassword";
                textBox3.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Account")
            {
                textBox1.Text = "! Chưa có dữ liệu";
                textBox1.ForeColor = System.Drawing.Color.Red;
            }
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "! Chưa có dữ liệu";
                textBox2.ForeColor = System.Drawing.Color.Red;
            }
            if (textBox3.Text == "RePassword")
            {
                textBox3.Text = "! Chưa có dữ liệu";
                textBox3.ForeColor = System.Drawing.Color.Red;
            }
            if (textBox2.Text != "Password" && textBox3.Text != "RePassword")
            {
                if (textBox2.Text != textBox3.Text)
                {
                    textBox3.Text = "! RePassword incorrect";
                    textBox3.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
