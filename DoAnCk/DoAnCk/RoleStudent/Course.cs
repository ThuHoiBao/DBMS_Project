using DoAnCk.RoleTeacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk.RoleStudent
{
    public partial class Course : Form
    {
        Main main;
        public Course(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Course_Load(object sender, EventArgs e)
        {

        }

        private void btnViewDecument_Click(object sender, EventArgs e)
        {
            //string idCourse = txtIdCourse.Text;
            //string nameCourse = txtNameCourse.Text;
            //ViewDocumentsTecherForm viewDocumentsTecherForm = new ViewDocumentsTecherForm();
            //viewDocumentsTecherForm.lblIdCourse.Text = idCourse;
            //viewDocumentsTecherForm.lblName.Text = nameCourse;

            Document document = new Document();

            main.OpenFormForOther(document);
        }
    }
}
