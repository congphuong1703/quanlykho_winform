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
        private string username;
        public FormTrangChu(string username)
        {
            InitializeComponent();
            this.Username = username;
        }

        public string Username { get => username; set => username = value; }

        private void khóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaTaiKhoan f = new FormKhoaTaiKhoan();
            this.Hide();
            f.ShowDialog(); 
            this.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau f = new FormDoiMatKhau(Username);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
