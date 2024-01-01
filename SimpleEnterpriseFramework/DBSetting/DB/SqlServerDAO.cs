using SimpleEnterpriseFramework.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    class SqlServerDAO : DatabaseDAO
    {
        //constructor
        public SqlServerDAO(string connection)
        {
            databaseProcessor = new SqlServerProcessor(connection);
        }

        //override function
        // - for membership
        public override void CreateMemberTable()
        {
            //check is Member table is exists or not
            string sql1 = "select * from information_schema.tables where table_schema = 'dbo' and table_name = 'member'";
            DataTable dataTable = databaseProcessor.GetAllData(sql1);
            bool isExistTable = dataTable.Rows.Count == 0;
            //create table store member(username, password) name 'Member'
            Console.WriteLine(isExistTable + "");
            if (isExistTable)
            {
                string sql2 = "create table member(id int not null identity(1,1) primary key, username varchar(30), password varchar(30), isLogin bit)";
                try
                {
                    databaseProcessor.QueryData(sql2);
                }
                catch (Exception e) {
                    Debug.Print(e.ToString());
                }
            }
        }

        public override bool CreateNewUser(string username, string password)
        {
            ILogger errorLogger = new ErrorLogger(textFileLogger);
            ILogger successLogger = new SuccessLogger(textFileLogger);

            string sql1 = $"select * from member where username = '{username}'";
            DataTable dataTable = databaseProcessor.GetAllData(sql1);
            bool userExisted = dataTable.Rows.Count != 0;
            if (userExisted)
            {
                errorLogger.Log("Error create new user.");
                return false;
            }
            else
            {
                string sql2 = $"insert into member values('{username}', '{password}', 'false')";
                if (databaseProcessor.QueryData(sql2) != 0)
                {
                    successLogger.Log("Success create new user.");
                    return true;
                }

                return false;
            }
        }

        public override bool Authentication(string username, string password)
        {
            string sql = $"select * from member where username = '{username}'";
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
                string sql = $"update member set isLogin = 'true' where username = '{username}'";
                if (databaseProcessor.QueryData(sql) != 0)
                    return true;
            }
            return false;
        }

        // - for CRUD 
        public override DataTable GetAllData(string tableName)
        {
            string sql = "select * from " + tableName;
            DataTable dataTable = databaseProcessor.GetAllData(sql);
            return dataTable;
        }

        public override string GetPrimaryKey(string tableName)
        {
            string sql = "select u.column_name, c.constraint_name from information_schema.table_constraints as c  " +
                "inner join information_schema.key_column_usage as u on c.constraint_name = u.constraint_name " +
                "where u.table_name = '" + tableName + "' and c.table_name = '" + tableName + "' and c.constraint_type = 'primary key'";
            DataTable dataTable = databaseProcessor.GetAllData(sql);
            return dataTable.Rows[0][0].ToString();
        }

        public override List<string> GetAllFieldsName(string tableName)
        {
            string sql = $"select column_name from information_schema.columns where table_name = N'{tableName}'";
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
                    MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    errorLogger.Log("Error insert.");
                    MessageBox.Show("Thêm thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error insert.");
                MessageBox.Show("Thêm thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    errorLogger.Log("Error update.");
                    MessageBox.Show("Cập nhật thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error update.");
                MessageBox.Show("Cập nhật thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sql = $"delete from {tableName} where {primaryKey} = '{valueOfPrimaryKey}'";
            else sql = $"delete from {tableName} where {primaryKey} = {valueOfPrimaryKey}";
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
                MessageBox.Show("Không có điều kiện để xóa");
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
                    MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    errorLogger.Log("Error delete.");
                    MessageBox.Show("Không có dữ liệu để xóa hoặc xóa thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorLogger.Log("Error delete.");
                MessageBox.Show("Xóa thất bại: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
