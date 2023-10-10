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
    public partial class frmSearchByClass : Form
    {
        Model1 db = new Model1();
        public frmSearchByClass()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? ClassID = Convert.ToInt32(cbbClass.SelectedValue);

            var query = from student in db.Students
                        where student.ClassID == ClassID
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

        private void frmSearchByClass_Load(object sender, EventArgs e)
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
            cbbClass.DataSource = db.Classes.ToList();
            cbbClass.DisplayMember = "ClassName";
            cbbClass.ValueMember = "ClassID";
            cbbClass.SelectedIndex = -1;
        }
    }
}
