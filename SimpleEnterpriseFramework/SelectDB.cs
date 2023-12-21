using SimpleEnterpriseFramework.DBSetting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.Components;
using SimpleEnterpriseFramework.InterfaceForm;

namespace SimpleEnterpriseFramework
{
    public partial class SelectDB : Form
    {
        public SelectDB(List<string> databaseNames)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(databaseNames.ToArray());
            SEPButton btnConnect = new SEPButton("btnConnect", "CONNECT", Color.White, Color.FromArgb(31, 38, 62), new Point(130, 208), new Size(130, 43),
                (sender, agrs) =>
                {
                    btnConnect_Click(sender, agrs);
                }
                );
            panel1.Controls.Add(btnConnect);
            Controls.Add(panel1);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn DB và DataManageTool!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                IoCContainer.Register<ILoginForm, LoginForm>();
                SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
                singletonDatabase.connString = $@"Data Source=.;Initial Catalog={comboBox1.SelectedItem};Integrated Security=SSPI";
                this.Hide();
                ILoginForm login = IoCContainer.Resolve<ILoginForm>();
                login.ShowForm();
            }

        }
    }
}
