using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    class SqlServerProcessor: DatabaseProcessor
    {
        public SqlServerProcessor(string connection)
        {
            this.connection = new SqlConnection(connection);
        }

        public override DataTable GetAllData(string sqlCommand)
        {
            connection.Open();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand, connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public override bool isExist(string sqlCommand)
        {
            SqlCommand sqlCommand1 = new SqlCommand(sqlCommand, connection);
            connection.Open();

            SqlDataReader reader = sqlCommand1.ExecuteReader();
            //return true if have more than 1 row
            if (reader.Read() == true)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public override int QueryData(string sqlCommand)
        {
            SqlCommand sqlCommand1 = new SqlCommand(sqlCommand, connection);
            connection.Open();

            int i = 1;
            try
            {
                i = sqlCommand1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return i;
        }

        public override int QueryDataNoMatterEncodingType(string sqlCommand, Dictionary<string, object> parameters)
        {
            SqlCommand sqlCommand1 = new SqlCommand(sqlCommand, connection);

            foreach (var entry in parameters)
            {
                sqlCommand1.Parameters.AddWithValue("@" + entry.Key, entry.Value ?? DBNull.Value);
            }

            connection.Open();
            int rowsAffected = 0;
            try
            {
                rowsAffected = sqlCommand1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected;
        }

    }
}
