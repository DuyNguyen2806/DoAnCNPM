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
    public partial class frmMain : Form
        
    {
        Model1 dbContext = new Model1();        
        public frmMain()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void danhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListStudent student = new frmListStudent();
            student.TopLevel = false;
            student.FormBorderStyle = FormBorderStyle.None;
            student.Dock = DockStyle.Fill;
            student.Show();
            panel1.Controls.Clear();    
            panel1.Controls.Add(student);
            student.Show();
        }

        private void xemĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrade frmGrade = new frmGrade();
            frmGrade.Show();
        }

        private void xemKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaculty frmFaculty = new frmFaculty();
            frmFaculty.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            frmSearch.Show();
        }

        private void quảnLýLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClass classes = new frmClass();
            classes.TopLevel = false;
            classes.FormBorderStyle = FormBorderStyle.None;
            classes.Dock = DockStyle.Fill;
            classes.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(classes);
            classes.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaculty faculty = new frmFaculty();
            faculty.TopLevel = false;
            faculty.FormBorderStyle = FormBorderStyle.None;
            faculty.Dock = DockStyle.Fill;
            faculty.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(faculty);
            faculty.Show();
        }

        private void quảnLýBảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrade grade = new frmGrade();
            grade.TopLevel = false;
            grade.FormBorderStyle = FormBorderStyle.None;
            grade.Dock = DockStyle.Fill;
            grade.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(grade);
            grade.Show();
        }

        private void tìmKiếmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchByName searchByName = new frmSearchByName();
            searchByName.TopLevel = false;
            searchByName.FormBorderStyle = FormBorderStyle.None;
            searchByName.Dock = DockStyle.Fill;
            searchByName.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(searchByName);
            searchByName.Show();
        }

        private void tìmKiếmTheoLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchByClass searchByClass = new frmSearchByClass();
            searchByClass.TopLevel = false;
            searchByClass.FormBorderStyle = FormBorderStyle.None;
            searchByClass.Dock = DockStyle.Fill;
            searchByClass.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(searchByClass);
            searchByClass.Show();
        }

        private void xemĐiểmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmGrade grade = new frmGrade();
            grade.TopLevel = false;
            grade.FormBorderStyle = FormBorderStyle.None;
            grade.Dock = DockStyle.Fill;
            grade.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(grade);
            grade.Show();
        }
    }
}
