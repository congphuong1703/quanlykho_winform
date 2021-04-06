using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormKhoaTaiKhoan : Form
    {
        public FormKhoaTaiKhoan()
        {
            comboxTaiKhoan();
            InitializeComponent();

        }

        public void comboxTaiKhoan()
        {
            SqlConnection connection = openSQL();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[selectUserNotFlag]";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        user.Items.Add(reader[0].ToString());
            }
            connection.Close();
        }

        public Boolean check()
        {

            if (string.IsNullOrEmpty(user.Text))
            {
                return false;
            }
            return true;
        }


        public SqlConnection openSQL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goHome();
        }

        private void goHome()
        {
            FormTrangChu form = new FormTrangChu();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = openSQL();
            if (!check())
            {
                const string message = "Vui lòng chọn tài khoản";
                const string caption = "Khóa tài khoản";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                user.Focus();
                con.Close();
            }
            else
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[flagging]";
                    command.Parameters.AddWithValue("@user", user.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                    const string message = "Khóa tài khoản thành công!";
                    const string caption = "Khóa tài khoản";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
                goHome();
            }
        }
    }

}
