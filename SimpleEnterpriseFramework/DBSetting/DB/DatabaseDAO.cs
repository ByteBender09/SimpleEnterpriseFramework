using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    public abstract class DatabaseDAO
    {
        protected DatabaseProcessor databaseProcessor;

        //get data from table
        public abstract DataTable GetAllData(string tableName);
        //get primary key
        public abstract string GetPrimaryKey(string tableName);
        //get all _fields name
        public abstract List<string> GetAllFieldsName(string tableName);
        //insert
        public abstract bool Insert(Dictionary<string, object> data, string tableName);
        //delete
        public abstract bool Delete(string tableName, object valueOfPrimaryKey);
        //delete2
        public abstract bool Delete(string tableName, Dictionary<string, object> data);
        //update
        public abstract bool Update(Dictionary<string, object> data, string tableName);
        //create table to store accounts membership
        public abstract void CreateMemberTable();
        //check username and password when user login
        public abstract bool CheckUserLogin(string username, string password);
        //create new user
        public abstract bool CreateNewUser(string username, string password);
        //user sign out
        public abstract bool SignOut(string username);
    }
}
