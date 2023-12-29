using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    class SqlServerProcessor: DatabaseProcessor
    {
        protected SqlConnection connectionSqlServer;

        public SqlServerProcessor(string connection)
        {
            this.connectionSqlServer = new SqlConnection(connection);
        }

        public override DataTable GetAllData(string sqlCommand)
        {
            connectionSqlServer.Open();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand, connectionSqlServer);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                connectionSqlServer.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                connectionSqlServer.Close();
            }
        }

        public override bool isExist(string sqlCommand)
        {
            SqlCommand sqlCommand1 = new SqlCommand(sqlCommand, connectionSqlServer);
            connectionSqlServer.Open();

            SqlDataReader reader = sqlCommand1.ExecuteReader();
            //return true if have more than 1 row
            if (reader.Read() == true)
            {
                connectionSqlServer.Close();
                return true;
            }
            connectionSqlServer.Close();
            return false;
        }

        public override int QueryData(string sqlCommand)
        {
            SqlCommand sqlCommand1 = new SqlCommand(sqlCommand, connectionSqlServer);
            connectionSqlServer.Open();

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
                connectionSqlServer.Close();
            }
            return i;
        }

        public override int QueryDataNoMatterEncodingType(string sqlCommand, Dictionary<string, object> parameters)
        {
            SqlCommand sqlCommand1 = new SqlCommand(sqlCommand, connectionSqlServer);

            foreach (var entry in parameters)
            {
                sqlCommand1.Parameters.AddWithValue("@" + entry.Key, entry.Value ?? DBNull.Value);
            }

            connectionSqlServer.Open();
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
                connectionSqlServer.Close();
            }
            return rowsAffected;
        }

    }
}
