using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.DBSetting
{
    class Database
    {
        public List<string> GetDatabaseNames()
        {
            List<string> databaseNames = new List<string>();
            string connectionString = "Data Source=.; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT name from sys.databases", connection))
                {
                    using (IDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            databaseNames.Add(dataReader[0].ToString());
                        }
                    }
                }
            }

            return databaseNames;
        }

    }
}
