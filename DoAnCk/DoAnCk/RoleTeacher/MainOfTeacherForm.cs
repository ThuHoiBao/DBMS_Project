using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk.RoleTeacher
{
    public partial class MainOfTeacherForm : Form
    {
        Form currentForm = null;
        public MainOfTeacherForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CourseTeacherForm courseTeacherForm = new CourseTeacherForm(this);
            OpenForm(courseTeacherForm);
        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }
        public void OpenForm(Form f)
        {
            // Xóa tất cả các controls hiện tại trên panelHome để tránh chồng chéo

            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = f;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill; // Đảm bảo form mới sẽ chiếm toàn bộ không gian của panel
            panelHome.Controls.Add(f);
            f.BringToFront(); // Đưa form mới lên trên cùng
            f.Size = panelHome.Size;
            f.Show();
        }
        public void OpenFormForOther(Form f)
        {
            if (currentForm != null)
            {
                currentForm.Hide();
            }
            currentForm = f;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelHome.Controls.Add(f);
            f.BringToFront();
            f.Size = panelHome.Size;
            f.Show();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picImage_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TeacherSalary teacherSalary = new TeacherSalary();
            OpenForm(teacherSalary);
        }
    }
}
