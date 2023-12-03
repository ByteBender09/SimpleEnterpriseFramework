using SimpleEnterpriseFramework.DBSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEnterpriseFramework
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database databases = new Database();
            List<string> list = databases.GetDatabaseNames(); // Lấy cái CSDL từ máy lên
            SelectDB sldb = new SelectDB(list); // Render list CSDL lên comboBox
            Application.EnableVisualStyles();
            Application.Run(sldb);
        }
    }
}
