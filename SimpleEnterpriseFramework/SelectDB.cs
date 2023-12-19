using SimpleEnterpriseFramework.DBSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SimpleEnterpriseFramework.DependencyInjection;
using SimpleEnterpriseFramework.InterfaceForm;

namespace SimpleEnterpriseFramework
{
    public partial class SelectDB : Form
    {
        public SelectDB(List<string> databaseNames)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(databaseNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
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
