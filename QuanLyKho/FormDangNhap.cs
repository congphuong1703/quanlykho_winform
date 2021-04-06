using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = openSQL();
            string query = "select flag from employee where username = '" + username.Text + "'and password = '" + password.Text + "';";

            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if(reader[0].ToString().Equals('0'))
                {
                    const string message = "Tài khoản bị khóa!";
                    const string caption = "Đăng nhập";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
                FormTrangChu form = new FormTrangChu();
                form.Show();
                this.Hide();
            }
            else
            {
                const string message = "Tài khoản hoặc mật khẩu sai!";
                const string caption = "Đăng nhập";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                username.Focus();
            }
            connect.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            password.PasswordChar = showPassword.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
