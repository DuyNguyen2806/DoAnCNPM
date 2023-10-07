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
    public partial class frmGrade : Form
    {
        Model1 db = new Model1();
        public frmGrade()
        {
            InitializeComponent();
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            cbbClass.DataSource = db.Classes.ToList();
            cbbClass.DisplayMember = "ClassName";
            cbbClass.ValueMember = "ClassID";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
           

        }

        private void cbbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void SelectClassForStudent(int selectedStudentID)

        {

           
           
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void DisplayGradesByClass(int ClassID)
        {
            var gradesForClass = db.Grades.Where(g => g.ClassID == ClassID).ToList();

            dataGridView1.DataSource = gradesForClass;
            
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbClass_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbClass.SelectedValue != null)
            {
                if (int.TryParse(cbbClass.SelectedValue.ToString(), out int selectedClassID))
                {
                    var studentsForClass = db.Students.Where(s => s.ClassID == selectedClassID).ToList();
                    dataGridView1.DataSource = studentsForClass;
                }
                else
                {
                    
                }
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            int selectedClassID = (int)cbbClass.SelectedValue;
            var grades = db.Grades
            .Where(g => g.ClassID == selectedClassID)
            .Select(g => new
            {
                g.StudentID,
                g.Class.ClassName,
                g.Subject,
                g.Score
            })
            .ToList();

            // Đặt kết quả truy vấn vào DataGridView
            dataGridView1.DataSource = grades;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string studentID = row.Cells["StudentID"].Value.ToString();
                
                int classID = Convert.ToInt32(row.Cells[5].Value);
                frmAddGrade addGradeForm = new frmAddGrade(studentID, classID);
                addGradeForm.ShowDialog();
            }
        }

    }
}
