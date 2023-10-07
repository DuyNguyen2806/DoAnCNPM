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
    public partial class frmSearch : Form
    {
        Model1 db = new Model1();
        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
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


        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void tìmTheoLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchByClass frmSearch = new frmSearchByClass();
            frmSearch.ShowDialog();
        }

        private void tìmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchByName frmSearchByName = new frmSearchByName();    
            frmSearchByName.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
