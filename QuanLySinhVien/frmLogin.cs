using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmLogin : Form
    {
        Model1 db = new Model1();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" || txtPass.Text.Trim() == "" )
            {
                MessageBox.Show("Vui long nhap du thong tin");
                return;

            }
            string username = txtUserName.Text.Trim();
            string password = txtPass.Text.Trim();
            var user = db.Accounts.FirstOrDefault(u => u.UserName == username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.Show();

            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác.");
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            this.Hide();
            frmRegister.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
