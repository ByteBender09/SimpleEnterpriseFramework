using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    class SqlServerDAO : DatabaseDAO
    {
        //constructor
        public SqlServerDAO(string connection)
        {
            this.databaseProcessor = new SqlServerProcessor(connection);
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
                catch (Exception e) { }
            }
        }

        public override bool CreateNewUser(string username, string password)
        {
            string sql1 = $"select * from member where username = '{username}'";
            DataTable dataTable = databaseProcessor.GetAllData(sql1);
            bool userExisted = dataTable.Rows.Count != 0;
            if (userExisted)
            {
                return false;
            }
            else
            {
                string sql2 = $"insert into member values('{username}', '{password}', 'false')";
                if (databaseProcessor.QueryData(sql2) != 0)
                    return true;
                return false;
            }
        }

        private bool Authentication(string username, string password)
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

        public override bool SignOut(string username)
        {
            string sql = $"update member set isLogin = 'false' where username ='{username}'";
            if (databaseProcessor.QueryData(sql) != 0)
                return true;
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
            string sql = "insert into " + tableName + " values(";
            for (int i = 0; i < data.Count; i++)
            {
                if (i < data.Count - 1)
                {
                    if (data.ElementAt(i).Value.GetType() == typeof(string))
                        sql += ("'" + data.ElementAt(i).Value + "', ");
                    else sql += (data.ElementAt(i).Value + ", ");
                }
                else
                {
                    if (data.ElementAt(i).Value.GetType() == typeof(string))
                        sql += ("'" + data.ElementAt(i).Value + "')");
                    else sql += (data.ElementAt(i).Value + ")");
                }
            }

            try
            {
                databaseProcessor.QueryData(sql);
                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed");
                throw ex;
            }
            return true;
        }

        public override bool Update(Dictionary<string, object> data, string tableName)
        {
            string primaryKey = GetPrimaryKey(tableName);
            string sql = "update " + tableName + " set ";
            for (int i = 0; i < data.Count; i++)
            {
                if (data.ElementAt(i).Key != primaryKey)
                {
                    if (i < data.Count - 1)
                    {
                        if (data.ElementAt(i).Value.GetType() == typeof(string))
                            sql += (data.ElementAt(i).Key + " = '" + data.ElementAt(i).Value + "', ");
                        else sql += (data.ElementAt(i).Key + " = " + data.ElementAt(i).Value + ", ");
                    }
                    else
                    {
                        if (data.ElementAt(i).Value.GetType() == typeof(string))
                            sql += (data.ElementAt(i).Key + " = '" + data.ElementAt(i).Value + "'");
                        else sql += (data.ElementAt(i).Key + " = " + data.ElementAt(i).Value);
                    }
                }
            }
            if (data[primaryKey].GetType() == typeof(string))
                sql += " where " + primaryKey + " = '" + data[primaryKey] + "'";
            else sql += " where " + primaryKey + " = " + data[primaryKey];
            try
            {
                databaseProcessor.QueryData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public override bool Delete(string tableName, object valueOfPrimaryKey)
        {
            string primaryKey = GetPrimaryKey(tableName);
            string sql = "";
            if (valueOfPrimaryKey.GetType() == typeof(string))
                sql = $"delete from {tableName} where {primaryKey} = '{valueOfPrimaryKey}'";
            else sql = $"delete from {tableName} where {primaryKey} = {valueOfPrimaryKey}";
            try
            {
                databaseProcessor.QueryData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public override bool Delete(string tableName, Dictionary<string, object> data)
        {
            string sql = "delete from " + tableName + " where ";
            for (int i = 0; i < data.Count; i++)
            {
                if (i < data.Count - 1)
                {
                    if (data.Values.ElementAt(i).GetType() == typeof(string) || data.Values.ElementAt(i).GetType() == typeof(DateTime))
                        sql += data.Keys.ElementAt(i).ToString() + " = '" + data.Values.ElementAt(i) + "' and ";
                    else
                        sql += data.Keys.ElementAt(i).ToString() + " = " + data.Values.ElementAt(i) + " and ";
                }
                else
                {
                    if (data.Values.ElementAt(i).GetType() == typeof(string))
                        sql += data.Keys.ElementAt(i).ToString() + " = '" + data.Values.ElementAt(i) + "'";
                    else
                        sql += data.Keys.ElementAt(i).ToString() + " = " + data.Values.ElementAt(i);
                }
            }
            Debug.WriteLine(sql);
            try
            {
                databaseProcessor.QueryData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
