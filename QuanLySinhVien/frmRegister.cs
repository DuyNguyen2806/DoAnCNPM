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
    public partial class frmRegister : Form
    {
        Model1 db = new Model1();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim()== ""|| txtPass.Text.Trim()== ""|| txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Vui long nhap du thong tin");
                return;

            }
            string username = txtUserName.Text.Trim();
            string password = txtPass.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Kiểm tra xem tên người dùng đã tồn tại chưa
            if (db.Accounts.Any(u => u.UserName == username))
            {
                MessageBox.Show("Tên người dùng đã tồn tại.");
                return;
            }

           
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        
            var user = new Account
            {
                UserName = username,
                Password = hashedPassword,
                Email = email
            };
            try
            {
                db.Accounts.Add(user);
                MessageBox.Show("Dang ky thanh cong:  ",
                           "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.SaveChanges();
                frmLogin frmLogin = new frmLogin();
                this.Hide();
                frmLogin.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
