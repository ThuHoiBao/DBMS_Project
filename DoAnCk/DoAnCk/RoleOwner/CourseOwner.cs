﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk.RoleOwner
{
    public partial class CourseOwner : Form
    {
        MainOwner owner;
        public CourseOwner(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void CourseOwner_Load(object sender, EventArgs e)
        {
            LoadCourseFull();
            LoadTeacherNamesToComboBox();

        }
        public void LoadCourseFull()
        {

            string query = "SELECT * FROM Course";

            // Tạo danh sách tham số
            //SqlParameter[] parameters = new SqlParameter[1];
            //parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
            //parameters[0].Value = 7;

            // Truyền tham số vào ExecuteQuery
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
        private void CourseClick(object sender, EventArgs e)
        {
            CourseUserControl1 ucCourse = sender as CourseUserControl1;
            if (ucCourse != null)
            {
                // Cập nhật thông tin từ ucCourse mà người dùng đã click
                txtIdCourse.Text = ucCourse.lblCourseId.Text;

                // Thực thi truy vấn lấy chi tiết khóa học
                string query = "EXEC procedureCourseInfoByIdTeacher @idCourse";

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
                parameters[0].Value = txtIdCourse.Text;

                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Cập nhật thông tin chi tiết khóa học vào các textbox
                    txtIdCourse.Text = dt.Rows[0]["CourseId"].ToString();
                    txtTotalLesson.Text = dt.Rows[0]["totalLession"].ToString();
                    txtNameCourse.Text = dt.Rows[0]["CourseName"].ToString();
                    txtDes.Text = dt.Rows[0]["CourseDescription"].ToString();
                    txtNumber.Text = dt.Rows[0]["timeLession"].ToString();
                    txtPrice.Text = dt.Rows[0]["price"].ToString();
                    txtTotalStudents.Text = dt.Rows[0]["totalStudent"].ToString();

                    // Hiển thị tên giảng viên vào combobox với id làm ValueMember
                    DataTable teacherTable = new DataTable();
                    teacherTable.Columns.Add("TeacherId", typeof(int));
                    teacherTable.Columns.Add("TeacherName", typeof(string));

                    // Thêm tên và id của giảng viên vào DataTable
                    int teacherId = Convert.ToInt32(dt.Rows[0]["IdTeacher"]); // Giả sử `IdTeacher` là tên cột chứa id
                    string teacherName = dt.Rows[0]["TeacherName"].ToString();
                    teacherTable.Rows.Add(teacherId, teacherName);

                    // Cập nhật ComboBox
                    cbTeacherName.DataSource = teacherTable;
                    cbTeacherName.DisplayMember = "TeacherName";
                    cbTeacherName.ValueMember = "TeacherId"; // Sử dụng "TeacherId" thay vì "IdTeacher"
                    cbTeacherName.SelectedIndex = 0; // Chọn mục đầu tiên
                }
            }
        }




        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string courseId = txtSearch.Text.Trim(); // Lấy giá trị tìm kiếm từ textbox

            if (string.IsNullOrEmpty(courseId))
            {
                MessageBox.Show("Vui lòng nhập ID khóa học để tìm kiếm!");
                return;
            }

            // Tạo truy vấn để gọi stored procedure tìm kiếm khóa học theo ID
            string query = "EXEC findCourseById @id";

            // Tạo danh sách tham số cho stored procedure
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            parameters[0].Value = courseId;

            try
            {
                // Thực thi truy vấn và lấy kết quả
                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                // Hiển thị kết quả tìm kiếm
                if (dt.Rows.Count > 0)
                {
                    ShowCourse(dt); // Gọi hàm hiển thị khóa học
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khóa học với ID này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            RefreshCourseInfo();
            LoadTeacherNamesToComboBox();
        }
        public void LoadTeacherNamesToComboBox()
        {
            string query = "SELECT Id, fullName FROM Teacher";  // Thêm TeacherId để có SelectedValue hợp lệ

            DataTable dt = Dataprovider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                // Đặt lại DataSource thay vì sử dụng Items.Clear()
                cbTeacherName.DataSource = null; // Đặt DataSource thành null trước khi gán dữ liệu mới
                cbTeacherName.DisplayMember = "fullName";
                cbTeacherName.ValueMember = "Id";
                cbTeacherName.DataSource = dt;

                cbTeacherName.SelectedIndex = 0;  // Chọn giảng viên đầu tiên
            }
            else
            {
                cbTeacherName.DataSource = null;
                cbTeacherName.Items.Add("No teachers found");
                cbTeacherName.SelectedIndex = 0;
            }
        }



        public void RefreshCourseInfo()
        {
            // Làm trống tất cả các TextBox
            txtIdCourse.Text = "";
            txtTotalLesson.Text = "";
            txtNameCourse.Text = "";
            txtDes.Text = "";
            txtNumber.Text = "";
            txtPrice.Text = "";
            txtIdTeacher.Text = "";
            txtTotalStudents.Text = "";
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem cbTeacherName đã có giá trị hợp lệ hay chưa
            if (cbTeacherName.SelectedValue != null)
            {
                // Chuyển đổi giá trị SelectedValue thành int (ID giảng viên)
                int selectedTeacherId;
                if (int.TryParse(cbTeacherName.SelectedValue.ToString(), out selectedTeacherId))
                {
                    txtIdTeacher.Text = selectedTeacherId.ToString();
                    AddCourse();
                }
                else
                {
                    MessageBox.Show("Không thể lấy ID giảng viên từ lựa chọn.");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn giảng viên hợp lệ.");
            }
        }

        private void AddCourse()
        {
            // Lấy dữ liệu từ các TextBox
            string idCourse = txtIdCourse.Text;
            string nameCourse = txtNameCourse.Text;
            string description = txtDes.Text;
            string timeLession = txtNumber.Text;
            int price = int.Parse(txtPrice.Text);
            int totalLession = int.Parse(txtTotalLesson.Text);
            int totalStudent = int.Parse(txtTotalStudents.Text);
            int idTeacher = int.Parse(txtIdTeacher.Text);

            // Chuỗi truy vấn cho thủ tục addCourse
            string query = "EXEC addCourse @id, @name, @description, @timeLession, @price, @totalLession, @totalStudent, @idTeacher";

            // Tạo danh sách các tham số
            SqlParameter[] parameters = new SqlParameter[8];

            // Thêm các tham số vào mảng `parameters`
            parameters[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            parameters[0].Value = idCourse;

            parameters[1] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[1].Value = nameCourse;

            parameters[2] = new SqlParameter("@description", SqlDbType.NVarChar);
            parameters[2].Value = description;

            parameters[3] = new SqlParameter("@timeLession", SqlDbType.NVarChar);
            parameters[3].Value = timeLession;

            parameters[4] = new SqlParameter("@price", SqlDbType.Int);
            parameters[4].Value = price;

            parameters[5] = new SqlParameter("@totalLession", SqlDbType.Int);
            parameters[5].Value = totalLession;

            parameters[6] = new SqlParameter("@totalStudent", SqlDbType.Int);
            parameters[6].Value = totalStudent;

            parameters[7] = new SqlParameter("@idTeacher", SqlDbType.Int);
            parameters[7].Value = idTeacher;

            // Thực thi câu truy vấn
            int result = Dataprovider.Instance.ExecuteNonQuery(query, parameters);

            // Kiểm tra kết quả và đưa ra thông báo
            if (result > 0)
            {
                MessageBox.Show("Khóa học đã được thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm khóa học thất bại!");
            }
        }


        private void btnRemoveDocument_Click(object sender, EventArgs e)
        {
            string courseId = txtIdCourse.Text.Trim();

            // Gọi hàm xóa khóa học
            DeleteCourse(courseId);
        }
        private void DeleteCourse(string courseId)
        {
            // Kiểm tra nếu ID khóa học không trống
            if (string.IsNullOrEmpty(courseId))
            {
                MessageBox.Show("Vui lòng nhập ID của khóa học cần xóa!");
                return;
            }

            // Câu truy vấn gọi stored procedure
            string query = "EXEC DeleteCourseAndDependencies @id";

            // Tạo tham số cho stored procedure
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            parameters[0].Value = courseId;

            try
            {
                // Thực thi stored procedure
                int rowsAffected = Dataprovider.Instance.ExecuteNonQuery(query, parameters);

                // Kiểm tra nếu có bản ghi nào bị xóa
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa khóa học thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khóa học với ID này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {
            UpdateCourse();
        }
        private void UpdateCourse()
        {
            // Lấy dữ liệu từ các textbox trên giao diện
            string courseId = txtIdCourse.Text.Trim();
            string courseName = txtNameCourse.Text.Trim();
            string description = txtDes.Text.Trim();
            string timeLession = txtNumber.Text.Trim();
            int price = int.Parse(txtPrice.Text.Trim());
            int totalLession = int.Parse(txtTotalLesson.Text.Trim());
            int totalStudent = int.Parse(txtTotalStudents.Text.Trim());

            // Kiểm tra nếu courseId không rỗng
            if (string.IsNullOrEmpty(courseId))
            {
                MessageBox.Show("Vui lòng nhập ID khóa học để cập nhật!");
                return;
            }

            // Câu truy vấn gọi stored procedure
            string query = "EXEC updateCourse @id, @name, @description, @timeLession, @price, @totalLession, @totalStudent";

            // Tạo danh sách tham số cho stored procedure
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            parameters[0].Value = courseId;

            parameters[1] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[1].Value = courseName;

            parameters[2] = new SqlParameter("@description", SqlDbType.NVarChar);
            parameters[2].Value = description;

            parameters[3] = new SqlParameter("@timeLession", SqlDbType.NVarChar);
            parameters[3].Value = timeLession;

            parameters[4] = new SqlParameter("@price", SqlDbType.Int);
            parameters[4].Value = price;

            parameters[5] = new SqlParameter("@totalLession", SqlDbType.Int);
            parameters[5].Value = totalLession;

            parameters[6] = new SqlParameter("@totalStudent", SqlDbType.Int);
            parameters[6].Value = totalStudent;

            try
            {
                // Thực thi stored procedure
                int rowsAffected = Dataprovider.Instance.ExecuteNonQuery(query, parameters);

                // Kiểm tra nếu có bản ghi nào được cập nhật
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật khóa học thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khóa học với ID này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            LoadCourseFull();
        }
       
    }
}
