using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SimpleEnterpriseFramework.DBSetting.DB;
using SimpleEnterpriseFramework.DBSetting;
using System.Windows.Forms;

namespace SimpleEnterpriseFramework
{
    partial class MainForm
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
        /// 
        /// 
        private readonly SqlServerDAO _sqlServerDao = new SqlServerDAO(SingletonDatabase.getInstance().connString);
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dbCombobox = new System.Windows.Forms.ComboBox();
            this.lb_Tables = new System.Windows.Forms.Label();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnEditRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.lb_service = new System.Windows.Forms.Label();
            this.pn_logo = new System.Windows.Forms.Panel();
            this.panelHeading = new System.Windows.Forms.Panel();
            this.lb_viewdata = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelHeading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pn_logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 783);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.dbCombobox);
            this.panel3.Controls.Add(this.lb_Tables);
            this.panel3.Controls.Add(this.btnDeleteRow);
            this.panel3.Controls.Add(this.btnEditRow);
            this.panel3.Controls.Add(this.btnAddRow);
            this.panel3.Controls.Add(this.lb_service);
            this.panel3.Location = new System.Drawing.Point(0, 90);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 689);
            this.panel3.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 628);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogout.Size = new System.Drawing.Size(309, 64);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dbCombobox
            // 
            this.dbCombobox.DisplayMember = "(none)";
            this.dbCombobox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbCombobox.FormattingEnabled = true;
            this.dbCombobox.ItemHeight = 21;
            this.dbCombobox.Location = new System.Drawing.Point(16, 379);
            this.dbCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.dbCombobox.Name = "dbCombobox";
            this.dbCombobox.Size = new System.Drawing.Size(291, 29);
            this.dbCombobox.TabIndex = 5;
            this.dbCombobox.Text = "Select table";
            // 
            // lb_Tables
            // 
            this.lb_Tables.AutoSize = true;
            this.lb_Tables.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Tables.Location = new System.Drawing.Point(20, 327);
            this.lb_Tables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Tables.Name = "lb_Tables";
            this.lb_Tables.Size = new System.Drawing.Size(97, 37);
            this.lb_Tables.TabIndex = 4;
            this.lb_Tables.Text = "Tables";
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.FlatAppearance.BorderSize = 0;
            this.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRow.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRow.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRow.Image")));
            this.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.Location = new System.Drawing.Point(0, 223);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDeleteRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeleteRow.Size = new System.Drawing.Size(309, 64);
            this.btnDeleteRow.TabIndex = 3;
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            this.btnDeleteRow.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditRow
            // 
            this.btnEditRow.FlatAppearance.BorderSize = 0;
            this.btnEditRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRow.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRow.ForeColor = System.Drawing.Color.White;
            this.btnEditRow.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRow.Image")));
            this.btnEditRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditRow.Location = new System.Drawing.Point(0, 151);
            this.btnEditRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditRow.Name = "btnEditRow";
            this.btnEditRow.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEditRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditRow.Size = new System.Drawing.Size(309, 64);
            this.btnEditRow.TabIndex = 2;
            this.btnEditRow.Text = "Edit Row";
            this.btnEditRow.UseVisualStyleBackColor = true;
            this.btnEditRow.Click += new System.EventHandler(this.btnEditRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.FlatAppearance.BorderSize = 0;
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRow.Location = new System.Drawing.Point(0, 79);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAddRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddRow.Size = new System.Drawing.Size(313, 64);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "New Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // lb_service
            // 
            this.lb_service.AutoSize = true;
            this.lb_service.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_service.Location = new System.Drawing.Point(20, 12);
            this.lb_service.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_service.Name = "lb_service";
            this.lb_service.Size = new System.Drawing.Size(110, 37);
            this.lb_service.TabIndex = 0;
            this.lb_service.Text = "Service";
            // 
            // pn_logo
            // 
            this.pn_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_logo.BackgroundImage")));
            this.pn_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pn_logo.Location = new System.Drawing.Point(27, 15);
            this.pn_logo.Margin = new System.Windows.Forms.Padding(4);
            this.pn_logo.Name = "pn_logo";
            this.pn_logo.Size = new System.Drawing.Size(260, 52);
            this.pn_logo.TabIndex = 0;
            // 
            // panelHeading
            // 
            this.panelHeading.BackColor = System.Drawing.Color.White;
            this.panelHeading.Controls.Add(this.lb_viewdata);
            this.panelHeading.Controls.Add(this.label2);
            this.panelHeading.Location = new System.Drawing.Point(313, 0);
            this.panelHeading.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(1349, 73);
            this.panelHeading.TabIndex = 1;
            // 
            // lb_viewdata
            // 
            this.lb_viewdata.AutoSize = true;
            this.lb_viewdata.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_viewdata.ForeColor = System.Drawing.Color.Black;
            this.lb_viewdata.Location = new System.Drawing.Point(32, 17);
            this.lb_viewdata.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_viewdata.Name = "lb_viewdata";
            this.lb_viewdata.Size = new System.Drawing.Size(148, 37);
            this.lb_viewdata.TabIndex = 1;
            this.lb_viewdata.Text = "View Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // dataGridView
            // 
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.EditMode = DataGridViewEditMode.EditOnF2;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(254)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView.Location = new System.Drawing.Point(315, 80);
            this.dataGridView.Name = "dataGridView";

            // Headings
            this.dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.ColumnHeadersHeight = 50;
            this.dataGridView.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;

            this.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView.Size = new System.Drawing.Size(1225, 703);
            this.dataGridView.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1540, 783);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelHeading);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Manage DB Form";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pn_logo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_service;
        private System.Windows.Forms.Panel panelHeading;
        private System.Windows.Forms.Label lb_viewdata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnEditRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Label lb_Tables;
        private System.Windows.Forms.ComboBox dbCombobox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLogout;
    }
}