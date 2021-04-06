using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        public SqlConnection openSQL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public Boolean check()
        {

            if (string.IsNullOrEmpty(oldPassword.Text) || string.IsNullOrEmpty(newPassword.Text)
               || string.IsNullOrEmpty(confirmPassword.Text))
            {
                return false;
            }
         
            return true;
        }

        private void goHome()
        {
            FormTrangChu form = new FormTrangChu();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goHome();
        }
    }
}
