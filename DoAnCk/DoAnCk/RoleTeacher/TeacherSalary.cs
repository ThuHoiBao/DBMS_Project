using DoAnCk.RoleOwner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk.RoleTeacher
{
    public partial class TeacherSalary : Form
    {
        MainOwner owner;
        public TeacherSalary(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }
        public TeacherSalary()
        {
            InitializeComponent();
        }

        private void TeacherSalary_Load(object sender, EventArgs e)
        {
            int idTeacher = Convert.ToInt32(lblSudentId.Text);

            LoadCoursesByTeacher(idTeacher);
            LoadTotalSalary(idTeacher);
        }
        public void LoadCoursesByTeacher(int teacherId)
        {
            string query = "EXEC GetCoursesByTeacherId @idTeacher";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
            parameters[0].Value = teacherId;

            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            ShowCourseByTeacher(dt);
        }

        public void ShowCourseByTeacher(DataTable dt)
        {
            panelListCourse.Controls.Clear(); // Xóa dữ liệu cũ nếu có
            int i = 1;

            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                ucTeacherSalary ucTeacherSalary = new ucTeacherSalary();

                // Hiển thị số thứ tự và thông tin khóa học
                ucTeacherSalary.lblSTT.Text = i.ToString(); // Số thứ tự
                ucTeacherSalary.lblCourseId.Text = row["CourseId"].ToString(); // Mã khóa học
                ucTeacherSalary.lblCourseName.Text = row["CourseName"].ToString(); // Tên khóa học
                ucTeacherSalary.lblCoursePrice.Text = row["Price"].ToString(); // Giá khóa học
                ucTeacherSalary.lblTotalStudent.Text = row["TotalStudents"].ToString(); // Tổng số sinh viên


                // Thêm UserControl vào panel
                panelListCourse.Controls.Add(ucTeacherSalary);
                i++;
            }
        }
        public void LoadTotalSalary(int teacherId)
        {
            string query = "SELECT dbo.functionCalculateTeacherSalary(@teacherId) AS TotalSalary";

            // Tạo danh sách tham số truyền vào truy vấn
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TeacherId", SqlDbType.Int);
            parameters[0].Value = teacherId;

            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                decimal totalSalary = Convert.ToDecimal(dt.Rows[0]["TotalSalary"]);

                txtTotalSalary.Text = totalSalary.ToString("C"); 
            }
            else
            {
                txtTotalSalary.Text = "0";
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
