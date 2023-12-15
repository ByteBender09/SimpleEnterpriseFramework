using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.DBSetting.DB
{
    public abstract class DatabaseProcessor
    {
        protected SqlConnection connection;

        public abstract DataTable GetAllData(string sqlCommand);
        public abstract int QueryData(string sqlCommand);
        public abstract int QueryDataNoMatterEncodingType(string sqlCommand, Dictionary<string, object> parameters);
        public abstract bool isExist(string sqlCommand);
    }
}
