using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DAO
{
    class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set { instance = value; }
        }
        private EmployeeDAO() { }
        public bool changePassword(string username, string oldPass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" exec SP_CapNhatMK @username , @password , @newPassword ",
                new object[] { username, oldPass, newPass });

            return result > 0;
        }

        public bool login(string username, string password)
        {
            string sql = "  SP_Login @password , @password ";
            DataTable table = DataProvider.Instance.ExecuteQuery(sql, new object[] { username, password });
            return table.Rows.Count > 0;
        }

        // neu flag =1 : acc - active
        public bool checkAccountStatus(string username, string password)
        {
            string sql = "  SP_CheckAcc @password , @password ";
            DataTable table = DataProvider.Instance.ExecuteQuery(sql, new object[] { username, password });
            return table.Rows.Count > 0;
        }
    }
}
