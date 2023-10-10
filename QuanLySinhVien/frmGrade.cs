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
            List<Class> listClass = db.Classes.ToList();
            fillDataCBB(listClass);
            cbbClass.SelectedItem = null;
        }
        private void fillDataCBB(List<Class> classes)
        {
            cbbClass.DataSource = classes;
            cbbClass.DisplayMember = "ClassName";
            cbbClass.ValueMember = "ClassID";

        }

        private void cbbClass_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbClass.SelectedValue != null)
            {
                if (int.TryParse(cbbClass.SelectedValue.ToString(), out int selectedClassID))
                {
                    var studentsForClass = db.Students.Where(s => s.ClassID == selectedClassID).ToList();
                    dataGridView1.DataSource = studentsForClass;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
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
                g.Student.FullName,
                g.Class.ClassName,
                g.Subject,
                g.Score
            })
            .ToList();
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
