
using System.Windows.Forms;

namespace SimpleEnterpriseFramework
{
    partial class HandleForm
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
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.buttonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelBtn.SuspendLayout();
            this.buttonLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBody
            // 
            this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBody.Location = new System.Drawing.Point(0, 50);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(200, 100);
            this.panelBody.TabIndex = 1;
            // 
            // panelBtn
            // 
            this.panelBtn.Controls.Add(this.buttonLayoutPanel);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtn.Location = new System.Drawing.Point(5, 410);
            this.panelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(445, 40);
            this.panelBtn.TabIndex = 5;
            // 
            // buttonLayoutPanel
            // 
            this.buttonLayoutPanel.ColumnCount = 3;
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonLayoutPanel.Name = "buttonLayoutPanel";
            this.buttonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buttonLayoutPanel.Size = new System.Drawing.Size(445, 40);
            this.buttonLayoutPanel.TabIndex = 0;

            // 
            // HandleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.panelBtn);
            this.Name = "HandleForm";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 30, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        #endregion

        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelBtn;
        private TableLayoutPanel buttonLayoutPanel;
    }
}