using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    class MySqlProcessor : DatabaseProcessor
    {
        protected MySqlConnection connectionMySQL;

        public MySqlProcessor(string connection)
        {
            this.connectionMySQL = new MySqlConnection(connection);
        }

        public override DataTable GetAllData(string sqlCommand)
        {
            connectionMySQL.Open();
            try
            {
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand, connectionMySQL);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                connectionMySQL.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                connectionMySQL.Close();
            }
        }

        public override bool isExist(string sqlCommand)
        {
            MySqlCommand sqlCommand1 = new MySqlCommand(sqlCommand, connectionMySQL);
            connectionMySQL.Open();

            MySqlDataReader reader = sqlCommand1.ExecuteReader();
            // return true if have more than 1 row
            if (reader.Read() == true)
            {
                connectionMySQL.Close();
                return true;
            }
            connectionMySQL.Close();
            return false;
        }

        public override int QueryData(string sqlCommand)
        {
            MySqlCommand sqlCommand1 = new MySqlCommand(sqlCommand, connectionMySQL);
            connectionMySQL.Open();

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
                connectionMySQL.Close();
            }
            return i;
        }

        public override int QueryDataNoMatterEncodingType(string sqlCommand, Dictionary<string, object> parameters)
        {
            MySqlCommand sqlCommand1 = new MySqlCommand(sqlCommand, connectionMySQL);

            foreach (var entry in parameters)
            {
                sqlCommand1.Parameters.AddWithValue("@" + entry.Key, entry.Value ?? DBNull.Value);
            }

            connectionMySQL.Open();
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
                connectionMySQL.Close();
            }
            return rowsAffected;
        }
    }
}
