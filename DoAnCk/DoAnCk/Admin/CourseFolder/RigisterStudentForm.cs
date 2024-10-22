using DoAnCk.Admin.CourseFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    public partial class RigisterStudentForm : Form
    {
        
        public RigisterStudentForm()
        {
            InitializeComponent();
            
        }
        Courses courses = new Courses();
        User user = new User();
        Assigns assigns = new Assigns();
        int idStudent = Global.GlobalId;
        Enrollments enrollments = new Enrollments();
        private void RigisterStudentForm_Load(object sender, EventArgs e)
        {
            DataTable semesters = courses.SelectSemesterCourse();

            // Kiểm tra nếu danh sách không trống
            if (semesters.Rows.Count > 0)
            {
                // Thiết lập DataSource cho comboBoxSemester và chọn phần tử đầu tiên
                ComboBoxAccountType.DataSource = semesters;
                ComboBoxAccountType.DisplayMember = "semester";
                ComboBoxAccountType.ValueMember = "semester";
                ComboBoxAccountType.SelectedItem = null; // Đặt giá trị mặc định

                // Gọi sự kiện SelectedIndexChanged để cập nhật listBoxAvaiable

            }
            ComboBoxAccountType_SelectedIndexChanged(sender, e);

        }
        public void ShowCourse()
        {
            AvaiableflowLayoutPanel.Controls.Clear();
            SelectflowLayoutPanel1.Controls.Clear();
            // Di chuyển biến i ra ngoài vòng lặp
            for (int i = 0; i < 20; i++)  // Sửa 'for' thành 'foreach' để duyệt qua từng hàng
            {

                AddCourseUserControl1 ucCourse = new AddCourseUserControl1();
                AddAndRemoveCourseUserControl1 ucCourse1 = new AddAndRemoveCourseUserControl1();
                AvaiableflowLayoutPanel.Controls.Add(ucCourse);
                SelectflowLayoutPanel1.Controls.Add(ucCourse1);

            }
        }
        public void AvaiableShowCourse(DataTable dt)
        {
            AvaiableflowLayoutPanel.Controls.Clear();
            // Di chuyển biến i ra ngoài vòng lặp
            foreach (DataRow row in dt.Rows)  // Sửa 'for' thành 'foreach' để duyệt qua từng hàng
            {


                AddCourseUserControl1 ucCourse = new AddCourseUserControl1();
                ucCourse.CourseAdded += btnAddCourse;
                ucCourse.lblCourseId.Text = row["course_id"].ToString();
                ucCourse.lblCourseName.Text = row["course_name"].ToString();
                ucCourse.lblNumber.Text = row["number"].ToString();
                ucCourse.lblDay.Text = row["day"].ToString();

                AvaiableflowLayoutPanel.Controls.Add(ucCourse);

            }
        }
        public void SelectShowCourse(DataTable dt)
        {
            SelectflowLayoutPanel1.Controls.Clear();
            // Di chuyển biến i ra ngoài vòng lặp
            foreach (DataRow row in dt.Rows)  // Sửa 'for' thành 'foreach' để duyệt qua từng hàng
            {


                AddAndRemoveCourseUserControl1 ucCourse = new AddAndRemoveCourseUserControl1();
                // ucCourse.CourseAdded += btnAddCourse;
                ucCourse.RemoveCourse += btnRemoveCourse;
                ucCourse.lblCourseId.Text = row["course_id"].ToString();
                ucCourse.lblCourseName.Text = row["course_name"].ToString();
                ucCourse.lblNumber.Text = row["number"].ToString();
                ucCourse.lblDay.Text = row["day"].ToString();

                SelectflowLayoutPanel1.Controls.Add(ucCourse);

            }
        }
        public static bool CheckOverlap(string str1, string str2)
        {
            // Chuyển chuỗi thành tập hợp các số nguyên
            HashSet<int> set1 = new HashSet<int>(Array.ConvertAll(str1.Split(','), int.Parse));
            int[] numbers2 = Array.ConvertAll(str2.Split(','), int.Parse);

            // Duyệt qua mảng thứ hai và kiểm tra xem có số nào trong set1 không
            foreach (int number in numbers2)
            {
                if (set1.Contains(number))
                {
                    return false; // Nếu tìm thấy số trùng, trả về False
                }
            }

            return true; // Nếu không tìm thấy số nào trùng, trả về True
        }
        public void btnAddCourse(object sender, EventArgs e)
        {
            StringBuilder successCourses = new StringBuilder("Những Môn Học Trùng Lịch:\n");
            AddCourseUserControl1 ucCourseAvai = sender as AddCourseUserControl1;
            if (ucCourseAvai != null)
            {
                // Kiểm tra xem khóa học đã tồn tại trong SelectflowLayoutPanel1 hay chưa
                bool courseExists = false;
                int tmp = 0;
                foreach (AddAndRemoveCourseUserControl1 existingCourse in SelectflowLayoutPanel1.Controls)
                {
                    if (existingCourse.lblCourseId.Text == ucCourseAvai.lblCourseId.Text)
                    {
                        courseExists = true;
                        tmp = 1;
                        break;
                    }
                    else if (!CheckOverlap(existingCourse.lblNumber.Text, ucCourseAvai.lblNumber.Text)
                        && existingCourse.lblDay.Text == ucCourseAvai.lblDay.Text)
                    {
                        courseExists = true;
                        tmp = 2;
                        successCourses.AppendLine(existingCourse.lblCourseId.Text + " " + existingCourse.lblCourseName.Text);

                    }
                }

                if (!courseExists)
                {
                    // Tạo một phiên bản mới của AddAndRemoveCourseUserControl1 nếu khóa học chưa tồn tại
                    AddAndRemoveCourseUserControl1 ucCourseSelect = new AddAndRemoveCourseUserControl1();
                    ucCourseSelect.lblCourseId.Text = ucCourseAvai.lblCourseId.Text;
                    ucCourseSelect.lblCourseName.Text = ucCourseAvai.lblCourseName.Text;
                    ucCourseSelect.lblDay.Text = ucCourseAvai.lblDay.Text;
                    ucCourseSelect.lblNumber.Text = ucCourseAvai.lblNumber.Text;
                    ucCourseSelect.RemoveCourse += btnRemoveCourse;


                    // Thêm vào SelectflowLayoutPanel1 nếu không trùng khóa học
                    SelectflowLayoutPanel1.Controls.Add(ucCourseSelect);
                }
                else
                {
                    if (tmp == 1)
                    {
                        MessageBox.Show("Môn Học Đã Được Chọn Trước Rồi  !!!", "Select Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (tmp == 2)
                    {
                        string message = "";
                        message += successCourses.ToString();
                        MessageBox.Show(message, "Select Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        public void btnRemoveCourse(object sender, EventArgs e)
        {
            AddAndRemoveCourseUserControl1 ucCourseselect = sender as AddAndRemoveCourseUserControl1;
            string courseId = ucCourseselect.lblCourseId.Text;
            

            
            DataTable dt = new DataTable();

            dt = enrollments.GetCheckCourse(courseId, idStudent);
            if (dt.Rows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Môn Này Đã Được Đăng Kí Bạn có Chắc Muốn Xóa Không?",
                 "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (enrollments.RemoveCourseRigister(courseId, idStudent))
                    {
                        MessageBox.Show("Môn Học Đã Được Hủy!!!", " Delete Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                SelectflowLayoutPanel1.Controls.Remove(ucCourseselect);
                MessageBox.Show("Đã Bỏ Chọn Môn Học Đó !!!", " Delete Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void ComboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            if (ComboBoxAccountType.SelectedItem != null && int.TryParse(ComboBoxAccountType.Text, out int semester))
            {
                // Nếu chuyển đổi thành công và ComboBox có giá trị hợp lệ
                DataTable dt1 = courses.GetSemesterAndSelectStudent(semester, idStudent);
                DataTable dt = courses.SelectSemester(semester);
                AvaiableShowCourse(dt);
                SelectShowCourse(dt1);
            }
            else
            {
                // Nếu ComboBox không chứa giá trị hợp lệ hoặc là null, hiển thị tất cả khóa học
                DataTable dt = Dataprovider.Instance.ExecuteQuery("select * from Assigns a,Courses c where  a.course_id=c.course_id");
                DataTable dt1 = courses.GetSelectStudent(idStudent);
                AvaiableShowCourse(dt);
                SelectShowCourse(dt1);
            }
        }

        private void lblSemesters_Click(object sender, EventArgs e)
        {
            DataTable semesters = courses.SelectSemesterCourse();

            // Kiểm tra nếu danh sách không trống
            if (semesters.Rows.Count > 0)
            {
                // Thiết lập DataSource cho comboBoxSemester và chọn phần tử đầu tiên
                ComboBoxAccountType.DataSource = semesters;
                ComboBoxAccountType.DisplayMember = "semester";
                ComboBoxAccountType.ValueMember = "semester";
                ComboBoxAccountType.SelectedItem = null; // Đặt giá trị mặc định

                // Gọi sự kiện SelectedIndexChanged để cập nhật listBoxAvaiable

            }
        }

        private void btnRigister_Click(object sender, EventArgs e)
        {

            StringBuilder successCourses = new StringBuilder("Các Môn Học Mới Đăng Kí:\n");
            StringBuilder failedCourses = new StringBuilder("Các Môn Học Đã Đăng Kí Trước Đó:\n");
            ;
            
            bool anySuccess = false;
            bool anyFailure = false;
            foreach (AddAndRemoveCourseUserControl1 ucCourse in SelectflowLayoutPanel1.Controls)
            {
                string courseid = ucCourse.lblCourseId.Text;
                if (enrollments.InsertErollments(idStudent, courseid))
                {
                    successCourses.AppendLine(courseid + " " + ucCourse.lblCourseName.Text);
                    anySuccess = true;
                }
                else
                {
                    failedCourses.AppendLine(courseid + " " + ucCourse.lblCourseName.Text);
                    anyFailure = true;
                }
            }
            string message = "";
            if (anySuccess)
            {
                message += successCourses.ToString();
            }
            if (anyFailure)
            {
                message += "\n" + failedCourses.ToString();
            }

            MessageBox.Show(message, "Kết Quả Đăng Kí", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

           
                DataTable dta = user.GetIdCourse(idStudent);

                string userAC = dta.Rows[0]["account"].ToString();
                string userN = dta.Rows[0]["user_name"].ToString();
                

                DataTable dt1 = new DataTable();
                if (ComboBoxAccountType.SelectedItem != null && int.TryParse(ComboBoxAccountType.Text, out int semester))
                {
                    // Nếu chuyển đổi thành công và ComboBox có giá trị hợp lệ
                    dt1 = courses.GetSelectPrintfSemesterStudent(idStudent, semester);
                }
                else
                {
                    // Nếu ComboBox không chứa giá trị hợp lệ hoặc là null, hiển thị tất cả khóa học
                    dt1 = courses.GetSelectPrintfStudent(idStudent);

                }

                PrintCourseAccountForm pAccount = new PrintCourseAccountForm(dt1,idStudent);
               
                    pAccount.lblUserAccount.Text = userAC;
                    pAccount.lblUserName.Text = userN;
                    pAccount.lblSemester.Text = ComboBoxAccountType.Text;
                    if (!(dta.Rows[0]["avartar"] is DBNull))
                    {
                        byte[] pic = (byte[])dta.Rows[0]["avartar"];  // Đảm bảo tên cột đúng là 'avartar' không phải 'avatar'
                        MemoryStream pictureStream = new MemoryStream(pic);
                        pAccount.picImage.Image = Image.FromStream(pictureStream);  // Đảm bảo rằng 'picImage' là accessible
                    }
                    pAccount.Show();
           
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt= courses.GetFindCourse(txtText.Text);
            AvaiableShowCourse(dt);

        }
    }
}
