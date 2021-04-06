using QuanLyKho.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if(username =="" || username== null)
            {
                MessageBox.Show("Mời bạn nhập tên đăng nhập");
                return;
            }
            if (password == "" || password == null)
            {
                MessageBox.Show("Mời bạn nhập mật khẩu");
                return;
            }
            if (EmployeeDAO.Instance.login(username,password))
            {
                if (!EmployeeDAO.Instance.checkAccountStatus(username,password))
                {
                    MessageBox.Show("Tài khoản đã bị khóa! Vui lòng liên hệ admin để biết thêm chi tiết!");
                    return;
                }
                FormTrangChu f = new FormTrangChu(username);
                this.Hide();
                f.ShowDialog(); // khi dialog mất đi thid login sẽ hiện lên
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
    }
}
