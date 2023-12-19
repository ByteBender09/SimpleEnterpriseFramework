namespace SimpleEnterpriseFramework
{
    partial class SelectDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDB));
            panel1 = new System.Windows.Forms.Panel();
            comboBox2 = new System.Windows.Forms.ComboBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            pn_logo = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(pn_logo);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(404, 283);
            panel1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] {
            "MySQL",
            "SQL Server"});
            comboBox2.Location = new System.Drawing.Point(65, 111);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(260, 26);
            comboBox2.TabIndex = 5;
            comboBox2.TabStop = false;
            comboBox2.Text = "Select Data Manage Tool";
            // 
            // comboBox1
            // 
            comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(65, 162);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(260, 26);
            comboBox1.TabIndex = 3;
            comboBox1.TabStop = false;
            comboBox1.Text = "Select Database";
            // 
            // pn_logo
            // 
            pn_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_logo.BackgroundImage")));
            pn_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pn_logo.Location = new System.Drawing.Point(65, 37);
            pn_logo.Margin = new System.Windows.Forms.Padding(4);
            pn_logo.Name = "pn_logo";
            pn_logo.Size = new System.Drawing.Size(260, 52);
            pn_logo.TabIndex = 2;
            // 
            // SelectDB
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(404, 283);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectDB";
            Text = "SelectDB";

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pn_logo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}