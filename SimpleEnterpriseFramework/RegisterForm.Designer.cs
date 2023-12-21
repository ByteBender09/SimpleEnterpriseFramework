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
            this.txtPasswordRegister = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserNameRegister = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.isShow = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pn_logo = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPasswordRegister
            // 
            this.txtPasswordRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasswordRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordRegister.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPasswordRegister.Location = new System.Drawing.Point(111, 193);
            this.txtPasswordRegister.Name = "txtPasswordRegister";
            this.txtPasswordRegister.Size = new System.Drawing.Size(306, 20);
            this.txtPasswordRegister.TabIndex = 12;
            this.txtPasswordRegister.TabStop = false;
            this.txtPasswordRegister.Text = "Password";
            this.txtPasswordRegister.Enter += new System.EventHandler(this.textPassword_Enter);
            this.txtPasswordRegister.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(111, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(306, 2);
            this.label8.TabIndex = 11;
            this.label8.Text = "label8";
            this.label8.UseMnemonic = false;
            // 
            // txtUserNameRegister
            // 
            this.txtUserNameRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserNameRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNameRegister.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtUserNameRegister.Location = new System.Drawing.Point(111, 126);
            this.txtUserNameRegister.Name = "txtUserNameRegister";
            this.txtUserNameRegister.Size = new System.Drawing.Size(306, 20);
            this.txtUserNameRegister.TabIndex = 9;
            this.txtUserNameRegister.Enter += new System.EventHandler(this.textUserName_Enter);
            this.txtUserNameRegister.Leave += new System.EventHandler(this.textUserName_Leave);
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(111, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(306, 2);
            this.label7.TabIndex = 8;
            this.label7.Text = "label7";
            this.label7.UseMnemonic = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.isShow);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.txtRePassword);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.txtPasswordRegister);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtUserNameRegister);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(333, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 452);
            this.panel2.TabIndex = 3;
            // 
            // isShow
            // 
            this.isShow.AutoSize = true;
            this.isShow.Location = new System.Drawing.Point(111, 303);
            this.isShow.Name = "isShow";
            this.isShow.Size = new System.Drawing.Size(124, 20);
            this.isShow.TabIndex = 19;
            this.isShow.Text = "Show password";
            this.isShow.UseVisualStyleBackColor = true;
            this.isShow.CheckedChanged += new System.EventHandler(this.isShow_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SimpleEnterpriseFramework.Properties.Resources.PinClipart_com_ship_clipart_black_and_1303682;
            this.pictureBox3.Location = new System.Drawing.Point(45, 254);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // txtRePassword
            // 
            this.txtRePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRePassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRePassword.Location = new System.Drawing.Point(111, 260);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.Size = new System.Drawing.Size(306, 20);
            this.txtRePassword.TabIndex = 17;
            this.txtRePassword.TabStop = false;
            this.txtRePassword.Text = "RePassword";
            this.txtRePassword.Enter += new System.EventHandler(this.textRePassword_Enter);
            this.txtRePassword.Leave += new System.EventHandler(this.textRePassword_Leave);
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(111, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 2);
            this.label9.TabIndex = 16;
            this.label9.Text = "label9";
            this.label9.UseMnemonic = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(42, 335);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(179, 16);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Do you have an account yet?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SimpleEnterpriseFramework.Properties.Resources.PinClipart_com_ship_clipart_black_and_1303682;
            this.pictureBox2.Location = new System.Drawing.Point(45, 187);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimpleEnterpriseFramework.Properties.Resources.avatar_icon_images_20;
            this.pictureBox1.Location = new System.Drawing.Point(45, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.label6.Location = new System.Drawing.Point(40, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 27);
            this.label6.TabIndex = 6;
            this.label6.Text = "Register new account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(199, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Chính - Khôi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(217, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Develop By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(130, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 34);
            this.label3.TabIndex = 3;
            this.label3.Text = "Framework";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(50, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "Simple Enterprise";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcom to the";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pn_logo);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 452);
            this.panel1.TabIndex = 2;
            // 
            // pn_logo
            // 
            this.pn_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_logo.BackgroundImage")));
            this.pn_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pn_logo.Location = new System.Drawing.Point(34, 35);
            this.pn_logo.Margin = new System.Windows.Forms.Padding(4);
            this.pn_logo.Name = "pn_logo";
            this.pn_logo.Size = new System.Drawing.Size(260, 52);
            this.pn_logo.TabIndex = 1;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            //this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();

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
        private System.Windows.Forms.CheckBox isShow;
    }
}