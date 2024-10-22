using DoAnCk.RoleTeacher;
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
    public partial class Course : Form
    {
        int studentId = 1;
        Main main;
        public Course(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Course_Load(object sender, EventArgs e)
        {
            LoadCourseFull();
        }

        private void btnViewDecument_Click(object sender, EventArgs e)
        {
            string idCourse = txtIdCourse.Text;
            string nameCourse = txtNameCourse.Text;
            Document viewDocumentsTecherForm = new Document();
            viewDocumentsTecherForm.lblIdCourse.Text = idCourse;
            viewDocumentsTecherForm.lblName.Text = nameCourse;
            main.OpenFormForOther(viewDocumentsTecherForm);
        }
        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                UserControlCourseStudent ucCourse = new UserControlCourseStudent();
                ucCourse.lblSTT.Text = i.ToString();
                ucCourse.lblCourseId.Text = row["CourseId"].ToString();
                ucCourse.lblCourseName.Text = row["name"].ToString();
                ucCourse.lblIdRegister.Text = row["RegisterId"].ToString();
                if (row["status"].ToString() == "1")
                {
                    ucCourse.checkAccept.Checked = true;
                }
                else
                {
                    ucCourse.checkAccept.Checked = false;
                }

                // Gắn sự kiện DoubleClick
                ucCourse.DoubleClick += new EventHandler(CourseClick);  // Gắn sự kiện trực tiếp

                panelListCourse.Controls.Add(ucCourse);
                i++;
            }
        }


        public void LoadCourseFull()
        {

            string query = " EXEC GetRegisteredCoursesForStudent @StudentId ";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@StudentId", SqlDbType.Int);
            parameters[0].Value = studentId;

            // Truyền tham số vào ExecuteQuery
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);
            ShowCourse(dt);
        }
        private void CourseClick(object sender, EventArgs e)
        {
            UserControlCourseStudent ucCourse = sender as UserControlCourseStudent;
            if (ucCourse != null)
            {
                // Cập nhật thông tin từ ucCourse mà người dùng đã click
                txtIdCourse.Text = ucCourse.lblCourseId.Text;
                txtIdRegister.Text = ucCourse.lblIdRegister.Text; // Đảm bảo gán giá trị RegisterId

                // Kiểm tra giá trị txtIdRegister trước khi chuyển đổi
                int idRegister;
                if (int.TryParse(txtIdRegister.Text, out idRegister))
                {
                    // Thực thi truy vấn lấy chi tiết khóa học
                    string query = "EXEC procedureInfomationCourse @idRegister";

                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = new SqlParameter("@idRegister", SqlDbType.Int);
                    parameters[0].Value = idRegister;

                    DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                    if (dt.Rows.Count > 0)
                    {
                        txtIdCourse.Text = dt.Rows[0]["CourseId"].ToString();
                        txtTotalLesson.Text = dt.Rows[0]["totalLession"].ToString();
                        txtNameCourse.Text = dt.Rows[0]["name"].ToString();
                        txtDes.Text = dt.Rows[0]["description"].ToString();
                        txtNumber.Text = dt.Rows[0]["timeLession"].ToString();
                        txtPrice.Text = dt.Rows[0]["price"].ToString();
                        txtTotalStudents.Text = dt.Rows[0]["totalStudent"].ToString();

                        if (dt.Rows[0]["status"].ToString() == "1")
                        {
                            txtStatus.Text = "Đã Xác Nhận";
                        }
                        else
                        {
                            txtStatus.Text = "Chưa Xác Nhận";
                        }
                    }
                }
                else
                {
                    // Hiển thị thông báo lỗi nếu giá trị không hợp lệ
                    MessageBox.Show("Giá trị ID đăng ký không hợp lệ. Vui lòng nhập một số nguyên hợp lệ.");
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
