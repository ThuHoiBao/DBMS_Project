using Google.Apis.Drive.v3.Data;
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
using System.Xml.Linq;

namespace DoAnCk.RoleTeacher
{
    public partial class CourseTeacherForm : Form
    {
        MainOfTeacherForm mainOfTeacherForm;
        public CourseTeacherForm( MainOfTeacherForm mainOfTeacherForm)
        {
            InitializeComponent();
            this.mainOfTeacherForm = mainOfTeacherForm;
        }

        private void CourseTeacherForm_Load(object sender, EventArgs e)
        {
            LoadCourseFull();
        }
        Courses courses = new Courses();

        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                CourseUserControl1 ucCourse = new CourseUserControl1();
                ucCourse.lblSTT.Text = i.ToString();
                ucCourse.lblCourseId.Text = row["id"].ToString();
                ucCourse.lblCourseName.Text = row["name"].ToString();
               

                // Gắn sự kiện DoubleClick
                ucCourse.DoubleClick += new EventHandler(CourseClick);  // Gắn sự kiện trực tiếp

                panelListCourse.Controls.Add(ucCourse);
                i++;
            }
        }


        public void LoadCourseFull()
        {

            string query = "EXEC procedureCourseListByTeacher @idTeacher";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
            parameters[0].Value = 7;

            // Truyền tham số vào ExecuteQuery
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);
            ShowCourse(dt);
        }
        private void CourseClick(object sender, EventArgs e)
        {
            CourseUserControl1 ucCourse = sender as CourseUserControl1;
            if (ucCourse != null)
            {
                // Cập nhật thông tin từ ucCourse mà người dùng đã click
                txtIdCourse.Text = ucCourse.lblCourseId.Text;

                // Thực thi truy vấn lấy chi tiết khóa học
                string query = "EXEC procedureCourse @idCourse";

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
                parameters[0].Value = txtIdCourse.Text;

                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtIdCourse.Text = dt.Rows[0]["id"].ToString();
                    txtTotalLesson.Text = dt.Rows[0]["totalLession"].ToString();
                    txtNameCourse.Text = dt.Rows[0]["name"].ToString();
                    txtDes.Text = dt.Rows[0]["description"].ToString();
                    txtNumber.Text = dt.Rows[0]["timeLession"].ToString();
                    txtPrice.Text = dt.Rows[0]["price"].ToString();
                    txtTotalStudents.Text = dt.Rows[0]["totalStudent"].ToString();
                }
            }
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            // Tạo truy vấn để gọi hàm tìm kiếm từ SQL Server
            string query = "SELECT * FROM FuntionSearchCourseByIdOrName(@idTeacher, @searchValue)";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
            parameters[0].Value = 7;  // Thay bằng id của giáo viên cần tìm kiếm
            parameters[1] = new SqlParameter("@searchValue", SqlDbType.NVarChar);
            parameters[1].Value = searchValue;

            // Thực thi truy vấn và lấy kết quả
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            // Hiển thị kết quả tìm kiếm
            ShowCourse(dt);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViewDecument_Click(object sender, EventArgs e)
        {
           

            string idCourse = txtIdCourse.Text;
            string nameCourse = txtNameCourse.Text;
            ViewDocumentsTecherForm viewDocumentsTecherForm = new ViewDocumentsTecherForm();
            viewDocumentsTecherForm.lblIdCourse.Text = idCourse;
            viewDocumentsTecherForm.lblName.Text = nameCourse;
            
            mainOfTeacherForm.OpenFormForOther(viewDocumentsTecherForm);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            string idCourse = txtIdCourse.Text;
            string nameCourse = txtNameCourse.Text;
            ViewStudentsTeacherForm viewStudentsTeacherForm = new ViewStudentsTeacherForm();
            viewStudentsTeacherForm.lblIdCourse.Text = idCourse;
            viewStudentsTeacherForm.lblName.Text = nameCourse;
            mainOfTeacherForm.OpenFormForOther(viewStudentsTeacherForm);
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
