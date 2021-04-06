using QuanLyKho.dao;
using QuanLyKho.DAO;
using System;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormCapTaiKhoan : Form
    {
        public FormCapTaiKhoan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = txtMaNV.Text;
            string name = txtTenNV.Text;
            DateTime dob = dateTimePicker1.Value;
            bool gender = true;
            if (radioButtonNam.Checked)
            {
                gender = true;
            }
            else
            {
                gender = false;
            }
            string phoneNumber = txtSdt.Text;
            DateTime dayOne = dateTimePicker2.Value;
            string identity = txtCMND.Text;
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            Employee employee = new Employee(username, password, code, name, dob, gender, phoneNumber, dayOne, identity);


            if (username == "" || username == null)
            {
                MessageBox.Show("Mời bạn nhập tên đăng nhập");
                textBox1.Focus();
                return;
            }
            if (password == "" || password == null)
            {
                MessageBox.Show("Mời bạn nhập mật khẩu");
                textBox2.Focus();
                return;
            }
            if (identity == "" || identity == null)
            {
                MessageBox.Show("Mời bạn nhập CMND");
                txtCMND.Focus();
                return;
            }
            if (code == "" || code == null)
            {
                MessageBox.Show("Mời bạn nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (name == "" || name == null)
            {
                MessageBox.Show("Mời bạn nhập tên nhân vi");
                txtTenNV.Focus();
                return;
            }

            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Mật khẩu không trùng");
                return;
            }
            if (EmployeeDAO.Instance.addAccount(employee))
            {
                if (!EmployeeDAO.Instance.checkAccountStatus(username, password))
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

        private void button3_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            DateTime dob = System.DateTime.Now;
            radioButtonNam.Checked = true;
            txtSdt.Text = "";
            DateTime dayOne = System.DateTime.Now;
            txtCMND.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDangNhap form = new FormDangNhap();
            form.Show();
            this.Hide();
        }
    }
}
