using QuanLyKho.dao;
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
            int result = DataProvider.Instance.ExecuteNonQuery(" exec SP_CapNhatMK @username , @password , @newPass ",
                new object[] { username, oldPass, newPass });

            return result > 0;
        }

        public bool login(string username, string password)
        {
            string sql = "  SP_Login @username , @password ";
            DataTable table = DataProvider.Instance.ExecuteQuery(sql, new object[] { username, password });
            return table.Rows.Count > 0;
        }       

        public bool addAccount(Employee employee)
        {
            string sql = "  SP_addAccount @username , @password ,@code,@name,@dob,@phoneNumber,@gender,@dayOne,@identify";
            DataTable table = DataProvider.Instance.ExecuteQuery(sql, new object[] { employee.username, employee.password , employee .code,
            employee.name,employee.dob,employee.phoneNumber,employee.gender == true ? 1 : 0,employee.dayOne,employee.identity});
            return table.Rows.Count > 0;
        }

        // neu flag =1 : acc - active
        public bool checkAccountStatus(string username, string password)
        {
            string sql = "  SP_CheckAcc @username , @password ";
            DataTable table = DataProvider.Instance.ExecuteQuery(sql, new object[] { username, password });
            return table.Rows.Count > 0;
        }

        public bool insertAccount(string username, string oldPass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" exec SP_CapNhatMK @username , @password , @newPassword ",
                new object[] { username, oldPass, newPass });

            return result > 0;
        }

        public DataTable loadTaiKhoan()
        {
            string sql = "  SP_LoadTaiKhoan ";
            return DataProvider.Instance.ExecuteQuery(sql);
        }
         
        public bool dongTaiKhoan(string username)
        {
            string sql = "  SP_DongTaiKhoan @username  ";
            int result = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { username });

            return result > 0;
        }
    }
}
