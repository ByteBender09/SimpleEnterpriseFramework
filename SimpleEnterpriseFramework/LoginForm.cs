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
    public partial class LoginForm : Form
    {
        public LoginForm()
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
            if (textBox1.Text != "Account" && textBox2.Text != "Password")
            {
                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
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
