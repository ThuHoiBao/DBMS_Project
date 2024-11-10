using DoAnCk.RoleStudent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnCk.RoleOwner
{
    public partial class Stats : Form
    {
        MainOwner owner;
        public Stats(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }
        private void Stats_Load(object sender, EventArgs e)
        {
            LoadStudentRegistrationStats();
            LoadCourseFull();
        }
        private void LoadStudentRegistrationStats()
        {
            chart1.Series.Clear();
            Series series = new Series
            {
                Name = "Số lượng sinh viên",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Int32
            };
            chart1.Series.Add(series);

            chart1.Titles.Clear();
            chart1.Titles.Add("Thống kê số lượng sinh viên đăng ký từ tháng 6 đến tháng 11");

            for (int month = 6; month <= 11; month++)
            {
                string query = "SELECT COUNT(*) AS TotalStudents FROM GetStudentInfoByMonth(@month)";

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@month", SqlDbType.Int);
                parameters[0].Value = month;

                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    int totalStudents = Convert.ToInt32(dt.Rows[0]["TotalStudents"]);

                    series.Points.AddXY(month, totalStudents);
                }
            }
        }
        public void LoadCourseFull()
        {

            string query = "SELECT * FROM GetCourseInfo()";

            DataTable dt = Dataprovider.Instance.ExecuteQuery(query);

            ShowCourse(dt);
        }
        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;

            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                CourseStats ucstatsCourse = new CourseStats();

                // Hiển thị số thứ tự và thông tin khóa học
                ucstatsCourse.lblSTT.Text = i.ToString(); // Số thứ tự
                ucstatsCourse.lblCourseId.Text = row["CourseId"].ToString(); // Mã khóa học
                ucstatsCourse.lblCourseName.Text = row["CourseName"].ToString(); // Tên khóa học

                // Nếu cần, có thể thêm thông tin số lượng sinh viên đã đăng ký
                ucstatsCourse.lblTotalStudent.Text = row["TotalStudent"].ToString(); // Số lượng sinh viên
               
                ucstatsCourse.DoubleClick += new EventHandler(CourseClick);  // Gắn sự kiện trực tiếp

                // Thêm UserControl vào panel
                panelListCourse.Controls.Add(ucstatsCourse);
                i++;
            }
        }
        private void CourseClick(object sender, EventArgs e)
        {
            CourseStats ucstatsCourse = sender as CourseStats;
            if (ucstatsCourse != null)
            {
                // Cập nhật thông tin từ ucCourse mà người dùng đã click
                string txtIdCourse = ucstatsCourse.lblCourseId.Text;

                
                // Hiển thị thống kê sinh viên trên biểu đồ chart1
                LoadStudentStatsForCourse(txtIdCourse);
            }
        }

        private void LoadStudentStatsForCourse(string courseId)
        {
            // Thực thi stored procedure để lấy thống kê sinh viên theo tháng
            string query = "EXEC GetStudentInfoByCourse @idCourse";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            parameters[0].Value = courseId;

            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            // Thiết lập biểu đồ
            chart1.Series.Clear();
            Series series = new Series
            {
                Name = "Số lượng sinh viên",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Int32
            };
            chart1.Series.Add(series);

            // Xóa các điểm dữ liệu cũ
            chart1.Series[0].Points.Clear();

            // Duyệt qua dữ liệu và thêm vào biểu đồ
            foreach (DataRow row in dt.Rows)
            {
                int month = Convert.ToInt32(row["Month"]);
                int totalStudents = Convert.ToInt32(row["TotalStudents"]);
                // Thêm dữ liệu vào biểu đồ
                chart1.Series[0].Points.AddXY(month, totalStudents);
            }

            // Thêm tiêu đề cho biểu đồ
            chart1.Titles.Clear();
            chart1.Titles.Add("Thống kê số lượng sinh viên của môn" + courseId);
            titleChar.Visible = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            titleChar.Visible = true;
            LoadStudentRegistrationStats();
        }
    }
}
