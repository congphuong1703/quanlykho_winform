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
    public partial class FormTrangChu : Form
    {
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrangChu form = new FormTrangChu();
            form.Show();
            this.Hide();
        }

        private void cấpTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCapTaiKhoan form = new FormCapTaiKhoan();
            form.Show();
            this.Hide();
        }

        private void khóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaTaiKhoan form = new FormKhoaTaiKhoan();
            form.Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau form = new FormDoiMatKhau();
            form.Show();
            this.Hide();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap form = new FormDangNhap();
            form.Show();
            this.Hide();
        }
    }
}
