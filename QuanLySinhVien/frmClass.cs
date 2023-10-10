using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLySinhVien
{
    public partial class frmClass : Form
    {
        Model1 db = new Model1();
        public frmClass()
        {
            InitializeComponent();
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            var query = from classes in db.Classes
                        join falcuty in db.Departments
                        on classes.DepartmentID equals falcuty.DepartmentID
                        select new
                        {
                            classes.ClassID,
                            classes.ClassName,
                            falcuty.DepartmentName
                        };
            dataGridView1.DataSource = query.ToList();
            List<Department> departments = db.Departments.ToList();
            fillDataCBB(departments);
            cbbKhoa.SelectedItem = null;            
            
        }

        private void fillDataCBB(List<Department> departments)
        {
            cbbKhoa.DataSource = departments;
            cbbKhoa.DisplayMember = "DepartmentName";
            cbbKhoa.ValueMember = "DepartmentID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbKhoa.SelectedItem == null)
            {
                MessageBox.Show("Chua chon khoa cho lop", "Loi khi them",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Class c = new Class();
            if(!checkInput(txtTen.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Loi khi them",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            c.ClassName = txtTen.Text;
            c.DepartmentID = cbbKhoa.SelectedValue.ToString().Trim();
            try
            {
                db.Classes.Add(c);
                MessageBox.Show("Da them thanh cong:  ",
                           "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.SaveChanges();
                frmClass_Load(sender, e);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        

        private bool checkInput(string v)
        {
            var listCLass = db.Classes.ToList();
            foreach (var c in listCLass)
            {
                if (string.IsNullOrEmpty(v) || c.ClassName.Equals(v))  
                    return false; 
               
            }
            return true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            cbbKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
