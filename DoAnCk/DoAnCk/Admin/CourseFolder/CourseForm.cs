using DoAnCk.Admin.CourseFolder;
using System;
using System.Collections;
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
using System.Windows.Input;

namespace DoAnCk
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }
        Courses courses = new Courses();
        private void CourseForm_Load(object sender, EventArgs e)
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
        bool check = true;
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            string cId = txtIdCourse.Text;

            string des = txtDes.Text;
            string cName = txtNameCourse.Text;
            string day = txtDay.Text;
            string number = txtNumber.Text;
            check = true;


            Check();
            if (!int.TryParse(txtSemester.Text, out int sem))
            {
                errorProvider1.SetError(txtSemester, "Semester không chứa chữ cái hoặc các kí tự đặc biệt hoặc dấu cách ?");
                check = false;
            }

            if (!int.TryParse(txtCredit.Text, out int crdit))
            {
                errorProvider1.SetError(txtCredit, "Credit không chứa chữ số hoặc các kí tự đặc biệt hoặc dấu cách ?");
                check = false;
            }
            if (check == true)
            {
                try
                {
                    if (courses.InsertCourse(cId,  sem, crdit, des, cName, day, number))
                    {
                        MessageBox.Show("New Course Added", "Add course successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;  // Di chuyển biến i ra ngoài vòng lặp
            foreach (DataRow row in dt.Rows)  // Sửa 'for' thành 'foreach' để duyệt qua từng hàng
            {
                
                CourseUserControl1 ucCourse=new CourseUserControl1();
                ucCourse.DoubleClick += CourseClick;
                ucCourse.lblSTT.Text=i.ToString();
                ucCourse.lblCourseId.Text=row["course_id"].ToString();
                ucCourse.lblCourseName.Text = row["course_name"].ToString() ;
               
                panelListCourse.Controls.Add(ucCourse);
                i++;
            }
        }
        public void LoadCourseFull()
        {

            if (ComboBoxAccountType.SelectedItem != null && int.TryParse(ComboBoxAccountType.Text, out int semester))
            {
                // Nếu chuyển đổi thành công và ComboBox có giá trị hợp lệ
                DataTable dt = courses.SelectSemester(semester);
                ShowCourse(dt);
            }
            else
            {
                // Nếu ComboBox không chứa giá trị hợp lệ hoặc là null, hiển thị tất cả khóa học
                DataTable dt = courses.SelectSemesterCourse();
                ShowCourse(dt);
            }
        }
        private void CourseClick(object sender, EventArgs e)
        {
            CourseUserControl1 ucCourse = sender as CourseUserControl1;
            if (ucCourse != null)
            {
                txtIdCourse.Text = ucCourse.lblCourseId.Text;
                DataTable dt = courses.SelectFullCourse(txtIdCourse.Text);
                txtNameCourse.Text = ucCourse.lblCourseName.Text;
                if (dt.Rows.Count > 0)
                {
                    txtCredit.Text = dt.Rows[0]["credit"].ToString();
                    txtSemester.Text = dt.Rows[0]["semester"].ToString();
                    txtDes.Text = dt.Rows[0]["desciption"].ToString();
                    txtDay.Text = dt.Rows[0]["day"].ToString();
                    txtNumber.Text = dt.Rows[0]["number"].ToString();
                }
            }
        }

        private void panelAccount_Paint(object sender, PaintEventArgs e)
        {
            // Thiết lập độ dày của viền và màu sắc
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ một hình chữ nhật xung quanh cạnh trong của panel
                e.Graphics.DrawRectangle(pen, 0, 0, panelAccount.Width - borderWidth, panelAccount.Height - borderWidth);
            }
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            txtIdCourse.Text = "";
            txtCredit.Text = "";
            txtNameCourse.Text = "";
            txtSemester.Text = "";
            txtDes.Text = "";
            txtDay.Text = "";
            txtNumber.Text = "";
        }
        public bool CheckStringName(string st)
        {
            for (int i = 0; i < st.Length; i++)
            {
                if (!char.IsLetter(st[i]) && st[i] != ' ')
                {
                    return false;
                }

            }
            return true;

        }
        public bool CheckStringPhone(string st)
        {
            for (int i = 0; i < st.Length; i++)
            {
                if (!char.IsDigit(st[i]))
                {
                    return false;
                }

            }
            return true;

        }
        public bool CheckStringNumber(string st)
        {
            for (int i = 0; i < st.Length; i++)
            {
                if (!char.IsDigit(st[i]) && st[i] != ',')
                {
                    return false;
                }

            }
            return true;

        }
        
        public void Check()
        {
           

            errorProvider1.Clear();
            if (txtIdCourse.Text == "")
            {
                errorProvider1.SetError(txtIdCourse, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtCredit.Text == "")
            {
                errorProvider1.SetError(txtCredit, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtNameCourse.Text == "")
            {
                errorProvider1.SetError(txtNameCourse, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtSemester.Text == "")
            {
                errorProvider1.SetError(txtSemester, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtDes.Text == "")
            {
                errorProvider1.SetError(txtDes, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtDay.Text == "")
            {
                errorProvider1.SetError(txtDay, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtNumber.Text == "")
            {
                errorProvider1.SetError(txtNumber, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (!CheckStringName(txtNameCourse.Text))
            {
                errorProvider1.SetError(txtNameCourse, "Course Name không chứa chữ số hoặc các kí tự đặc biệt");
                check = false;
            }
            if (!CheckStringName(txtDay.Text))
            {
                errorProvider1.SetError(txtDay, "Thứ không chứa chữ số hoặc các kí tự đặc biệt");
                check = false;
            }
           
            if (!CheckStringNumber(txtNumber.Text))
            {
                errorProvider1.SetError(txtNumber, " Number of per day không chứa chữ cái hoặc các kí tự đặc biệt hoặc dấu cách ?");
                check = false;
            }
        }
        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            string cId = txtIdCourse.Text;
           
            string des = txtDes.Text;
            string cName = txtNameCourse.Text;
            string day = txtDay.Text;
            string number = txtNumber.Text;
            check = true;
           
           
            Check();
            if (!int.TryParse(txtSemester.Text, out int sem))
            {
                errorProvider1.SetError(txtSemester, "Semester không chứa chữ cái hoặc các kí tự đặc biệt hoặc dấu cách ?");
                check = false;
            }

            if (!int.TryParse(txtCredit.Text, out int crdit))
            {
                errorProvider1.SetError(txtCredit, "Credit không chứa chữ số hoặc các kí tự đặc biệt hoặc dấu cách ?");
                check = false;
            }
            if (check == true)
            {
                if (courses.UpdateCourse(cId, sem, crdit, des, cName, day, number))
                {
                    MessageBox.Show("Update Course Added", "Update course successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           


        }

        private void ComboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxAccountType.SelectedItem != null && int.TryParse(ComboBoxAccountType.Text, out int semester))
            {
                // Nếu chuyển đổi thành công và ComboBox có giá trị hợp lệ
                DataTable dt = courses.SelectSemester(semester);
                ShowCourse(dt);
            }
            else
            {
                // Nếu ComboBox không chứa giá trị hợp lệ hoặc là null, hiển thị tất cả khóa học
                DataTable dt = Dataprovider.Instance.ExecuteQuery("select * from Courses ");
                ShowCourse(dt);
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
        Assigns assigns = new Assigns();
        Enrollments enrollments = new Enrollments();
        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            if (txtIdCourse.Text == "")
            {
                MessageBox.Show("Chưa chọn môn học? ", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra xem môn học có bản ghi liên quan trong bảng Enrollments không
                bool hasEnrollments = enrollments.HasEnrollments(txtIdCourse.Text);
                bool hasAssigns = assigns.HasAssign(txtIdCourse.Text);
               
                if (hasEnrollments&&!hasAssigns)
                {
                    DialogResult dialogResult = MessageBox.Show("Môn học đã được sinh viên đăng ký! Bạn có chắc muốn xóa không?", "Delete Course", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    
                    if (dialogResult == DialogResult.OK)
                    {
                        if (enrollments.RemoveCourse(txtIdCourse.Text))
                        {
                            if (courses.DeleteCourse(txtIdCourse.Text))
                            {
                                MessageBox.Show("Môn học đã được xóa thành công!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CourseForm_Load(sender, e); 
                            }
                        }
                    }
                }
                else if(!hasEnrollments && hasAssigns)
                {
                    DialogResult dialogResult = MessageBox.Show("Môn học đã được giáo viên đăng ký! Bạn có chắc muốn xóa không?", "Delete Course", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                    if (dialogResult == DialogResult.OK)
                    {
                        if (assigns.RemoveCourse(txtIdCourse.Text))
                        {
                            if (courses.DeleteCourse(txtIdCourse.Text))
                            {
                                MessageBox.Show("Môn học đã được xóa thành công!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CourseForm_Load(sender, e);
                            }
                        }
                    }
                }
                if (hasEnrollments && hasAssigns)
                {
                    DialogResult dialogResult = MessageBox.Show("Môn học đã được sinh viên và giáo viên  đăng ký! Bạn có chắc muốn xóa không?", "Delete Course", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                    if (dialogResult == DialogResult.OK)
                    {
                        if (enrollments.RemoveCourse(txtIdCourse.Text)&& assigns.RemoveCourse(txtIdCourse.Text))
                        {
                            if (courses.DeleteCourse(txtIdCourse.Text))
                            {
                                MessageBox.Show("Môn học đã được xóa thành công!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CourseForm_Load(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    if (courses.DeleteCourse(txtIdCourse.Text))
                    {
                        MessageBox.Show("Môn học đã được xóa thành công!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CourseForm_Load(sender, e); 
                    }
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
