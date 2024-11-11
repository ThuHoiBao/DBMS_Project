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

namespace DoAnCk.RoleStudent
{
    public partial class Rigister : Form
    {
        Main Main;
        
        public Rigister(Main main)
        {
            InitializeComponent();
            Main = main;
        }

        private void Rigister_Load(object sender, EventArgs e)
        {
            LoadCourseFull();
        }
        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                CourseUserControl1 ucCourse = new CourseUserControl1();
                ucCourse.lblSTT.Text = i.ToString();
                ucCourse.lblCourseId.Text = row["CourseId"].ToString();
                ucCourse.lblCourseName.Text = row["name"].ToString();


                // Gắn sự kiện DoubleClick
                ucCourse.DoubleClick += new EventHandler(CourseClick);  // Gắn sự kiện trực tiếp

                panelListCourse.Controls.Add(ucCourse);
                i++;
            }
        }


        public void LoadCourseFull()
        {

            string query = " GetAvailableCoursesForStudent @StudentId";

            // Tạo danh sách tham số
            int studentId= Convert.ToInt32(lblSudentId.Text);
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@StudentId", SqlDbType.Int);
            parameters[0].Value = studentId;

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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sinh viên và khóa học từ các trường thông tin
             // Bạn cần thay đổi giá trị này dựa trên ID thực tế của sinh viên
            string courseId = txtIdCourse.Text; // ID khóa học từ textbox
            int studentId= Convert.ToInt32(lblSudentId.Text);
            // Thực hiện gọi stored procedure để đăng ký khóa học
            string query = "EXEC RegisterCourse @StudentId, @CourseId, @Status";

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@StudentId", SqlDbType.Int);
            parameters[0].Value = studentId;

            parameters[1] = new SqlParameter("@CourseId", SqlDbType.NVarChar);
            parameters[1].Value = courseId;

            parameters[2] = new SqlParameter("@Status", SqlDbType.VarChar);
            parameters[2].Value = "0"; // Trạng thái đăng ký là "0"

            try
            {
                // Gọi phương thức thực thi truy vấn
                Dataprovider.Instance.ExecuteNonQuery(query, parameters);

                // Thông báo thành công
                MessageBox.Show("Đăng ký khóa học thành công!");
                LoadCourseFull();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
