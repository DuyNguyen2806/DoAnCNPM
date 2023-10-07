using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmListStudent : Form
    {
        Model1 db = new Model1();
        bool isEdit;            //Kiem tra xem co dang sua hoac them khong
        bool isAdd;

        public frmListStudent()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListStudent_Load(object sender, EventArgs e)
        {
            var query = from student in db.Students
                        join classes in db.Classes
                        on student.ClassID equals classes.ClassID
                        select new
                        {
                            student.StudentID,
                            student.FullName,
                            student.DateOfBirth,
                            student.Gender,
                            student.Email,
                            classes.ClassName
                        };
            dataGridView1.DataSource = query.ToList();
            cbbLop.DataSource = db.Classes.ToList();
            cbbLop.DisplayMember = "ClassName";
            cbbLop.ValueMember = "ClassID";


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbLop.SelectedItem == null)
            {
                MessageBox.Show("Chua chon lop cho sv", "Loi khi them",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Student s = new Student();
            if (CheckID(txtID.Text))
            {
                s.StudentID = txtID.Text.Trim();
            }else
            {
                MessageBox.Show("Ma sinh vien da ton tai", "Loi khi them",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            s.FullName = txtName.Text.Trim();
            if (DateTime.TryParseExact(mtbBirthday.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                s.DateOfBirth = birthDate; // Gán ngày sinh đã chuyển đổi cho DateOfBirth
            }
            else
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Lỗi khi thêm",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckGender(txtGender.Text.Trim()))
            {
                s.Gender = txtGender.Text.Trim();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại giới tính", "Lỗi khi thêm",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckEmail(txtEmail.Text))
            {
                s.Email = txtEmail.Text.Trim();
            }
            else
            {
                MessageBox.Show("Email không hợp lệ", "Lỗi khi thêm",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            s.ClassID = Convert.ToInt32(cbbLop.SelectedValue);
            try
            {
                db.Students.Add(s);
                MessageBox.Show("Da them thanh cong:  " ,
                           "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.SaveChanges();
                frmListStudent_Load(sender, e);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckEmail(string email)
        {
           if(email.Length >10 && email.Contains("@gmail.com"))
            {
                return true;
            }

           return false;
        }

        private bool CheckID(string id)
        {
            var listStu = db.Students.ToList();
            foreach (var s in listStu)
            {
                if (s.StudentID.Equals(id)) return false;
            }
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != null &&
                DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), out DateTime dateValue))
            {
                
                mtbBirthday.Text = dateValue.ToString("dd/MM/yyyy");
            }
            else
            {
                
                mtbBirthday.Text = string.Empty; 
            }
           
            txtGender.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            cbbLop.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var rs = db.Students.FirstOrDefault(s=>s.StudentID == txtID.Text.Trim());  
            if (rs != null)
            {
                rs.FullName = txtName.Text.Trim();
                if (DateTime.TryParseExact(mtbBirthday.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                {
                    rs.DateOfBirth = birthDate; // Gán ngày sinh đã chuyển đổi cho DateOfBirth
                }
                else
                {
                    MessageBox.Show("Ngày sinh không hợp lệ", "Lỗi khi thêm",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(CheckGender(txtGender.Text.Trim()))
                {
                    rs.Gender = txtGender.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại giới tính", "Lỗi khi thêm",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CheckEmail(txtEmail.Text))
                {
                    rs.Email = txtEmail.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Email không hợp lệ", "Lỗi khi thêm",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                rs.ClassID = Convert.ToInt32(cbbLop.SelectedValue);
                

            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Da sua thanh cong:  ",
                          "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmListStudent_Load(sender, e);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool CheckGender(string gender)
        {
            if (gender.ToLower() == "nam" || gender.ToLower() == "nu" || gender.ToLower() == "nữ")
                return true;
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rs = db.Students.FirstOrDefault(s => s.StudentID == txtID.Text.Trim());
            if (rs != null)
            {
                db.Students.Remove(rs);
                MessageBox.Show("Da xoa:  " ,
                          "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.SaveChanges();
                frmListStudent_Load(sender, e);
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Student s = db.Students.FirstOrDefault(st=>st.StudentID == txtID.Text.Trim());
            int CurrentClass =Convert.ToInt32 (cbbLop.SelectedValue);
            Class c = db.Classes.FirstOrDefault(cl=> cl.ClassID == CurrentClass );
            frmDetailStudent detailStudent = new frmDetailStudent(s, c);
            detailStudent.ShowDialog();
        }
    }
}
