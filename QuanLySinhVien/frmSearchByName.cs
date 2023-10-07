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
    public partial class frmSearchByName : Form
    {
        Model1 db = new Model1();
        
        public frmSearchByName()
        {
            InitializeComponent();
           

        }

        private void frmSearchByName_Load(object sender, EventArgs e)
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
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();
            var query = db.Students.Where(student => student.FullName.Contains(key)).ToList();
            var listSV = query.Select(x => new
            {
                Id = x.StudentID,
                TenSV = x.FullName,
                Dob = x.DateOfBirth,
                gender = x.Gender,
                email = x.Email,
                classes = x.ClassID,
            }).ToList();
            dataGridView1.DataSource = listSV;
        }
    }
}
