using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SimpleEnterpriseFramework.DBSetting.MySQL
{
    public class MySQL : IDisposable
    {
        private readonly string _connectionString;
        private MySqlConnection _connection;

        public MySQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool OpenConnection()
        {
            try
            {
                _connection = new MySqlConnection(_connectionString);
                _connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
                return false;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
