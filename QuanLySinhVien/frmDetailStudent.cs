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
    public partial class frmDetailStudent : Form
    {
        public frmDetailStudent(Student s, Class c)
        {
            InitializeComponent();
            label14.Text = s.StudentID.ToString();
            label13.Text = s.FullName.ToString();
            label12.Text = s.DateOfBirth.ToString();
            label11.Text = s.Gender.ToString();
            label10.Text = s.Email.ToString();
            label9.Text = c.ClassName.ToString();
            label8.Text = c.Department.DepartmentName.ToString();
        }
    }
}
