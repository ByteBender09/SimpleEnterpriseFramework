namespace SimpleEnterpriseFramework
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            btnRegister = new System.Windows.Forms.Button();
            txtPasswordRegister = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtUserNameRegister = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            txtRePassword = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            pn_logo = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegister.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnRegister.ForeColor = System.Drawing.Color.White;
            btnRegister.Location = new System.Drawing.Point(45, 342);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(372, 43);
            btnRegister.TabIndex = 14;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += new System.EventHandler(register_Click);
            // 
            // txtPasswordRegister
            // 
            txtPasswordRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtPasswordRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPasswordRegister.ForeColor = System.Drawing.SystemColors.ScrollBar;
            txtPasswordRegister.Location = new System.Drawing.Point(111, 193);
            txtPasswordRegister.Name = "txtPasswordRegister";
            txtPasswordRegister.Size = new System.Drawing.Size(306, 20);
            txtPasswordRegister.TabIndex = 12;
            txtPasswordRegister.TabStop = false;
            txtPasswordRegister.Text = "Password";
            txtPasswordRegister.Enter += new System.EventHandler(textPassword_Enter);
            txtPasswordRegister.Leave += new System.EventHandler(textPassword_Leave);
            // 
            // label8
            // 
            label8.AllowDrop = true;
            label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label8.Location = new System.Drawing.Point(111, 221);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(306, 2);
            label8.TabIndex = 11;
            label8.Text = "label8";
            label8.UseMnemonic = false;
            // 
            // txtUserNameRegister
            // 
            txtUserNameRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtUserNameRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtUserNameRegister.ForeColor = System.Drawing.SystemColors.InfoText;
            txtUserNameRegister.Location = new System.Drawing.Point(111, 126);
            txtUserNameRegister.Name = "txtUserNameRegister";
            txtUserNameRegister.Size = new System.Drawing.Size(306, 20);
            txtUserNameRegister.TabIndex = 9;
            txtUserNameRegister.Enter += new System.EventHandler(textUserName_Enter);
            txtUserNameRegister.Leave += new System.EventHandler(textUserName_Leave);
            // 
            // label7
            // 
            label7.AllowDrop = true;
            label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label7.Location = new System.Drawing.Point(111, 154);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(306, 2);
            label7.TabIndex = 8;
            label7.Text = "label7";
            label7.UseMnemonic = false;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(txtRePassword);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(btnRegister);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtPasswordRegister);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtUserNameRegister);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Location = new System.Drawing.Point(333, -1);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(468, 452);
            panel2.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = global::SimpleEnterpriseFramework.Properties.Resources.PinClipart_com_ship_clipart_black_and_1303682;
            pictureBox3.Location = new System.Drawing.Point(45, 254);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(40, 36);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 18;
            pictureBox3.TabStop = false;
            // 
            // txtRePassword
            // 
            txtRePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtRePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRePassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            txtRePassword.Location = new System.Drawing.Point(111, 260);
            txtRePassword.Name = "txtRePassword";
            txtRePassword.Size = new System.Drawing.Size(306, 20);
            txtRePassword.TabIndex = 17;
            txtRePassword.TabStop = false;
            txtRePassword.Text = "RePassword";
            txtRePassword.Enter += new System.EventHandler(textRePassword_Enter);
            txtRePassword.Leave += new System.EventHandler(textRePassword_Leave);
            // 
            // label9
            // 
            label9.AllowDrop = true;
            label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label9.Location = new System.Drawing.Point(111, 288);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(306, 2);
            label9.TabIndex = 16;
            label9.Text = "label9";
            label9.UseMnemonic = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(42, 314);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(179, 16);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Do you have an account yet?";
            linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
            // 
            // pictureBox2
            // 
            pictureBox2.Image = global::SimpleEnterpriseFramework.Properties.Resources.PinClipart_com_ship_clipart_black_and_1303682;
            pictureBox2.Location = new System.Drawing.Point(45, 187);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(40, 36);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = global::SimpleEnterpriseFramework.Properties.Resources.avatar_icon_images_20;
            pictureBox1.Location = new System.Drawing.Point(45, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(40, 36);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            label6.Location = new System.Drawing.Point(40, 54);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(254, 27);
            label6.TabIndex = 6;
            label6.Text = "Register new account";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(199, 394);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(86, 17);
            label5.TabIndex = 5;
            label5.Text = "Chính - Khôi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(217, 374);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(65, 15);
            label4.TabIndex = 4;
            label4.Text = "Develop By";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(130, 248);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(164, 34);
            label3.TabIndex = 3;
            label3.Text = "Framework";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(50, 206);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(244, 34);
            label2.TabIndex = 2;
            label2.Text = "Simple Enterprise";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(77, 160);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(217, 34);
            label1.TabIndex = 1;
            label1.Text = "Welcom to the";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pn_logo);
            panel1.Location = new System.Drawing.Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(331, 452);
            panel1.TabIndex = 2;
            // 
            // pn_logo
            // 
            pn_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_logo.BackgroundImage")));
            pn_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pn_logo.Location = new System.Drawing.Point(34, 35);
            pn_logo.Margin = new System.Windows.Forms.Padding(4);
            pn_logo.Name = "pn_logo";
            pn_logo.Size = new System.Drawing.Size(260, 52);
            pn_logo.TabIndex = 1;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "RegisterForm";
            Text = "RegisterForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPasswordRegister;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserNameRegister;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pn_logo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtRePassword;
        private System.Windows.Forms.Label label9;
    }
}