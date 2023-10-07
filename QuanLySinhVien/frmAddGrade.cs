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

    public partial class frmAddGrade : Form
    {
        Model1 db = new Model1();
        private string StudentID { get; set; }
        private int ClassID { get; set; }

 

        public frmAddGrade(string studentID, int classID)

        {
            InitializeComponent();
            this.StudentID = studentID;
            this.ClassID = classID;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string subject = txtMonHoc.Text.Trim();
            int score = Convert.ToInt32(txtDiem.Text.Trim());       
           
            Grade g = new Grade();
            g.StudentID = this.StudentID;
            g.ClassID = ClassID;
            g.Score = score;
            g.Subject = subject;

            try
            {
                db.Grades.Add(g);
                db.SaveChanges();
                MessageBox.Show("Da them thanh cong ", StudentID, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Loi");
            }
        }
    }
}

