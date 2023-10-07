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

namespace QuanLySinhVien
{
    public partial class frmFaculty : Form
    {
        Model1 db = new Model1();
        public frmFaculty()
        {
            InitializeComponent();
        }

        private void frmFaculty_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Departments.ToList();
            dataGridView1.Columns[2].Visible = false;
          

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            Department d = new Department();
            d.DepartmentID = txtID.Text.Trim();
            d.DepartmentName = txtName.Text.Trim();
            try
            {
                db.Departments.Add(d);
                MessageBox.Show("Da them thanh cong:  ",
                           "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.SaveChanges();
                frmFaculty_Load(sender, e);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)

        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            var rs = db.Departments.FirstOrDefault(d=>d.DepartmentID ==txtID.Text.Trim());
            if(rs != null)
            {
                rs.DepartmentID = txtID.Text.Trim();
                rs.DepartmentName = txtName.Text.Trim();
            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Da sua thanh cong:  ",
                        "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmFaculty_Load(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            var rs = db.Departments.FirstOrDefault(d => d.DepartmentID == txtID.Text.Trim());
            if (rs != null)
            {
                rs.DepartmentID = txtID.Text.Trim();
                rs.DepartmentName = txtName.Text.Trim();
            }
            try
            {
                db.Departments.Remove(rs);
                MessageBox.Show("Da xoa thanh cong:  ",
                        "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.SaveChanges() ;
                frmFaculty_Load(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
