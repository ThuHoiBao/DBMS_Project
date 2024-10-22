using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    public partial class MainAdminForm : Form
    {
        Form currentForm = null;
        public MainAdminForm()
        {
            InitializeComponent();
        }
        
        public void MainFormAdmin_Load(object sender, EventArgs e)
        {
            SqlParameter[] sqlParameters =
             {
                new SqlParameter("@uid",Global.GlobalId)
            };
            DataTable table = Dataprovider.Instance.ExecuteQuery("select * from Users Where user_id =@uid", sqlParameters);

            if (table.Rows.Count > 0)
            {
                if (!(table.Rows[0]["avartar"] is DBNull))
                {
                    byte[] pic = (byte[])table.Rows[0]["avartar"];
                    MemoryStream picture = new MemoryStream(pic);
                    picImage.Image = Image.FromStream(picture);
                }
                else
                {
                    picImage.Image = null;
                }
                lblUserName.Text = table.Rows[0]["user_name"].ToString();
            }
        }
        
        public void GetImageAndUserName()
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@uid",Global.GlobalId)
            };
            DataTable table = Dataprovider.Instance.ExecuteQuery("select * from Users Where user_id =@uid",sqlParameters);
          
            if (table.Rows.Count > 0)
            {
                if (!(table.Rows[0]["avartar"] is DBNull)){
                    byte[] pic = (byte[])table.Rows[0]["avartar"];
                    MemoryStream picture = new MemoryStream(pic);
                    picImage.Image = Image.FromStream(picture);
                }
                else
                {
                    picImage.Image = null;
                }
                lblUserName.Text = table.Rows[0]["user_name"].ToString();
            }
        }
      
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public void OpenFormForOther(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = form;
            form.TopLevel = false;

            panelHome.Controls.Add(form);
            form.Show();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm(this);
            OpenForm(teacherForm);
        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();
            OpenForm(courseForm);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            //AccountForm accountForm = new AccountForm(this);
            //OpenForm(accountForm);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
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

        private void picImage_Click(object sender, EventArgs e)
        {

        }
    }
}
