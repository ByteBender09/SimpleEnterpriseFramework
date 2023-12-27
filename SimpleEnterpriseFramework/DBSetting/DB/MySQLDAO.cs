using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using SimpleEnterpriseFramework.Logger;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    class MySqlDAO : DatabaseDAO
    {
        // Constructor
        private readonly ILogger textFileLogger = new TextFileLogger();

        public MySqlDAO(string connection)
        {
            databaseProcessor = new MySqlProcessor(connection);
        }

        // Override function for membership
        public override void CreateMemberTable()
        {
            // Check if the Member table exists or not
            string sql1 = "SELECT * FROM information_schema.tables WHERE table_schema = 'dbo' AND table_name = 'member'";
            DataTable dataTable = databaseProcessor.GetAllData(sql1);
            bool isExistTable = dataTable.Rows.Count == 0;

            // Create the table to store members (username, password) named 'Member'
            Console.WriteLine(isExistTable + "");
            if (isExistTable)
            {
                string sql2 = "CREATE TABLE member(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, username VARCHAR(30), password VARCHAR(30), isLogin BOOLEAN)";
                try
                {
                    databaseProcessor.QueryData(sql2);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public override bool CreateNewUser(string username, string password)
        {
            ILogger errorLogger = new ErrorLogger(textFileLogger);
            ILogger successLogger = new SuccessLogger(textFileLogger);

            string sql1 = $"SELECT * FROM member WHERE username = '{username}'";
            DataTable dataTable = databaseProcessor.GetAllData(sql1);
            bool userExisted = dataTable.Rows.Count != 0;

            if (userExisted)
            {
                errorLogger.Log("Error creating a new user.");
                return false;
            }
            else
            {
                string sql2 = $"INSERT INTO member (username, password, isLogin) VALUES ('{username}', '{password}', 'false')";
                if (databaseProcessor.QueryData(sql2) != 0)
                {
                    successLogger.Log("Success creating a new user.");
                    return true;
                }

                return false;
            }
        }

        private bool Authentication(string username, string password)
        {
            string sql = $"SELECT * FROM member WHERE username = '{username}'";
            DataTable data = databaseProcessor.GetAllData(sql);

            if (data.Rows.Count != 0)
            {
                string user = data.Rows[0][1].ToString();
                string pass = data.Rows[0][2].ToString();
                return username == user && password == pass;
            }

            return false;
        }

        public override bool CheckUserLogin(string username, string password)
        {
            if (Authentication(username, password))
            {
                string sql = $"UPDATE member SET isLogin = true WHERE username = '{username}'";
                if (databaseProcessor.QueryData(sql) != 0)
                    return true;
            }

            return false;
        }

        public override bool SignOut(string username)
        {
            string sql = $"UPDATE member SET isLogin = false WHERE username = '{username}'";
            if (databaseProcessor.QueryData(sql) != 0)
            {
                return true;
            }

            return false;
        }

        // Override functions for CRUD
        public override DataTable GetAllData(string tableName)
        {
            string sql = $"SELECT * FROM {tableName}";
            DataTable dataTable = databaseProcessor.GetAllData(sql);
            return dataTable;
        }

        public override string GetPrimaryKey(string tableName)
        {
            string sql = $"SELECT u.column_name, c.constraint_name FROM information_schema.table_constraints as c " +
                $"INNER JOIN information_schema.key_column_usage as u ON c.constraint_name = u.constraint_name " +
                $"WHERE u.table_name = '{tableName}' AND c.table_name = '{tableName}' AND c.constraint_type = 'primary key'";
            DataTable dataTable = databaseProcessor.GetAllData(sql);
            return dataTable.Rows[0][0].ToString();
        }

        public override List<string> GetAllFieldsName(string tableName)
        {
            string sql = $"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}'";
            DataTable dataTable = databaseProcessor.GetAllData(sql);
            List<string> fieldsName = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    fieldsName.Add(item.ToString());
                }
            }
            return fieldsName;
        }

        public override bool Insert(Dictionary<string, object> data, string tableName)
        {
            ILogger errorLogger = new ErrorLogger(textFileLogger);
            ILogger successLogger = new SuccessLogger(textFileLogger);
            string columns = string.Join(", ", data.Keys);
            string parameters = string.Join(", ", data.Keys.Select(k => "@" + k));

            string sql = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

            try
            {
                int rowsAffected = databaseProcessor.QueryDataNoMatterEncodingType(sql, data);
                if (rowsAffected > 0)
                {
                    successLogger.Log("Success insert.");
                    return true;
                }
                else
                {
                    errorLogger.Log("Error insert.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error insert.");
                throw ex;
            }
        }

        public override bool Update(Dictionary<string, object> data, string tableName)
        {
            ILogger errorLogger = new ErrorLogger(textFileLogger);
            ILogger successLogger = new SuccessLogger(textFileLogger);
            string primaryKey = GetPrimaryKey(tableName);
            string columnsToUpdate = string.Join(", ", data.Where(kv => kv.Key != primaryKey).Select(kv =>
            {
                if (kv.Value.GetType() == typeof(string))
                    return $"{kv.Key} = @{kv.Key}";
                return $"{kv.Key} = {kv.Value}";
            }));

            string sql = $"UPDATE {tableName} SET {columnsToUpdate} WHERE {primaryKey} = @{primaryKey}";

            try
            {
                data.TryGetValue(primaryKey, out object primaryKeyValue);

                int rowsAffected = databaseProcessor.QueryDataNoMatterEncodingType(sql, data);
                if (rowsAffected > 0)
                {
                    successLogger.Log("Success update.");
                    return true;
                }
                else
                {
                    errorLogger.Log("Error update.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error update.");
                throw ex;
            }
        }

        public override bool Delete(string tableName, object valueOfPrimaryKey)
        {
            ILogger errorLogger = new ErrorLogger(textFileLogger);
            ILogger successLogger = new SuccessLogger(textFileLogger);
            string primaryKey = GetPrimaryKey(tableName);
            string sql = "";
            if (valueOfPrimaryKey.GetType() == typeof(string))
                sql = $"DELETE FROM {tableName} WHERE {primaryKey} = '{valueOfPrimaryKey}'";
            else sql = $"DELETE FROM {tableName} WHERE {primaryKey} = {valueOfPrimaryKey}";
            try
            {
                successLogger.Log("Success delete.");
                databaseProcessor.QueryData(sql);
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error delete.");
                throw ex;
            }
            return true;
        }

        public override bool Delete(string tableName, Dictionary<string, object> data)
        {
            ILogger errorLogger = new ErrorLogger(textFileLogger);
            ILogger successLogger = new SuccessLogger(textFileLogger);
            string primaryKey = data.Keys.FirstOrDefault();

            if (primaryKey == null)
            {
                Console.WriteLine("Không có điều kiện để xóa");
                return false;
            }

            string sql = $"DELETE FROM {tableName} WHERE {primaryKey} = @{primaryKey}";

            try
            {
                object primaryKeyValue;
                data.TryGetValue(primaryKey, out primaryKeyValue);

                int rowsAffected = databaseProcessor.QueryDataNoMatterEncodingType(sql, new Dictionary<string, object> { { primaryKey, primaryKeyValue } });

                if (rowsAffected > 0)
                {
                    successLogger.Log("Success delete.");
                    return true;
                }
                else
                {
                    errorLogger.Log("Error delete.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error delete.");
                throw ex;
            }
        }
    }
}
