using SimpleEnterpriseFramework.DBSetting.DB;


namespace SimpleEnterpriseFramework.DBSetting.MemberShip
{
    class Membership
    {
        private DatabaseDAO databaseDAO;

        public Membership(string connectionString)
        {
            databaseDAO = new SqlServerDAO(connectionString);
            //se duoc khoi tao khi bat dau chuong trinh, Initial Catalog se khong duoc khoi tao, dbo.member se duoc luu o database master
            databaseDAO.CreateMemberTable();
        }

        public bool Login(string username, string password)
        {
            if (databaseDAO.CheckUserLogin(username, password))
            {
                return true;
            }
            return false;
        }

        public bool Register(string username, string password)
        {
            if (databaseDAO.CreateNewUser(username, password))
            {
                return true;
            }
            return false;
        }

        public bool Logout(string username)
        {
            if (databaseDAO.SignOut(username))
            {
                return true;
            }
            return false;
        }
    }
}
