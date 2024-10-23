using DoAnCk.RoleTeacher;
using Org.BouncyCastle.Tls.Crypto;
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

namespace DoAnCk.RoleOwner
{
    public partial class TeacherOwner : Form
    {
        MainOwner owner;
        public TeacherOwner(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void TeacherOwner_Load(object sender, EventArgs e)
        {
            LoadTeacherFull();
        }

        public void ShowTeacher(DataTable dt)
        {
            panelListAccount.Controls.Clear();
            int i = 1;  // Biến i để đánh số thứ tự giáo viên
            foreach (DataRow row in dt.Rows)  // Duyệt qua từng hàng dữ liệu
            {
                UserControlTeacher userControlTeacher = new UserControlTeacher();
                userControlTeacher.lblSTT.Text = row["id"].ToString();
                userControlTeacher.lblFullName.Text = row["fullName"].ToString();
                userControlTeacher.lblPhone.Text = row["email"].ToString();
                userControlTeacher.lblCertificate.Text = row["certificate"].ToString(); // Hiển thị chứng chỉ

                // Thêm sự kiện click đôi
                userControlTeacher.DoubleClick += TeacherClick;

                // Đánh số thứ tự cho giáo viên
                userControlTeacher.lblSTT.Text = i.ToString();

                // Thêm điều khiển vào panel
                panelListAccount.Controls.Add(userControlTeacher);
                i++;
            }
        }

        private void TeacherClick(object sender, EventArgs e)
        {
            // Kiểm tra nếu sự kiện được gán cho UserControlTeacher
            UserControlTeacher ucTeacher = sender as UserControlTeacher;
            if (ucTeacher != null)
            {
                // Lấy ID giáo viên từ UserControl
                string teacherId = ucTeacher.lblSTT.Text;

                // Gán ID giáo viên vào txtIdRegister
                txtIdRegister.Text = teacherId;

                // Thực thi truy vấn để lấy chi tiết giáo viên
                string query = "EXEC procedureTeacherInfoById @idTeacher";

                // Tạo danh sách tham số
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
                parameters[0].Value = int.Parse(teacherId);

                // Thực thi truy vấn và lấy kết quả
                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Gán dữ liệu từ DataTable vào các TextBox hoặc label để hiển thị thông tin giáo viên
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    txtName.Text = dt.Rows[0]["fullName"].ToString();
                    txtCertificate.Text = dt.Rows[0]["certificate"].ToString();
                    txtExperience.Text = dt.Rows[0]["experience"].ToString();

                    // Gọi hàm để lấy danh sách các lớp học của giáo viên và hiển thị vào txtCourse
                    LoadCoursesByTeacher(int.Parse(teacherId));
                }
            }
        }


        public void LoadCoursesByTeacher(int teacherId)
        {
            // Chuỗi truy vấn SQL gọi stored procedure lấy danh sách lớp học
            string query = "EXEC getCoursesByTeacher @idTeacher";

            // Tạo tham số cho truy vấn
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
            parameters[0].Value = teacherId;

            // Thực thi truy vấn và lấy kết quả vào DataTable
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            // Kiểm tra nếu có dữ liệu trả về
            if (dt.Rows.Count > 0)
            {
                // Duyệt qua các hàng dữ liệu và ghép tên lớp học vào một chuỗi
                List<string> courseNames = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    courseNames.Add(row["name"].ToString());
                }

                // Nếu số lớp học > 2, ghép tên lớp học lại với dấu phẩy ","
                txtCourse.Text = string.Join(", ", courseNames);
            }
            else
            {
                // Nếu không có lớp học nào, đặt chuỗi trống
                txtCourse.Text = "No courses found";
            }
        }


    public void LoadTeacherFull()
        {
            string query = "SELECT * FROM getTeachers"; // Gọi view để lấy toàn bộ giáo viên

            // Thực thi truy vấn
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query);
            ShowTeacher(dt); // Hiển thị danh sách giáo viên
        }


        private void Account(object sender, EventArgs e)
        {


            //UserControlStuent userControlStuent = sender as UserControlStuent;
            //if (userControlStuent != null)
            //{
            //    txtn
            //    txtStatus.Text = userControlStuent.checkAccept.Checked ? "Đã Xác Nhận" : "Chưa Chấp Nhận";

            //    if (userControlStuent.picImage.Image != null)

            //    {
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            // Lưu hình ảnh hiện tại trong PictureBox vào MemoryStream
            //            clickedAccount.picImage.Image.Save(ms, clickedAccount.picImage.Image.RawFormat);
            //            byte[] imageBytes = ms.ToArray();

            //            // Lưu trữ hoặc xử lý mảng byte ở đây
            //            // Hiển thị lại hình ảnh từ mảng byte nếu cần
            //            MemoryStream pictureStream = new MemoryStream(imageBytes);
            //            picImage.Image = Image.FromStream(pictureStream);
            //        }
            //    }
            //}


            UserControlStuent userControlStuent = sender as UserControlStuent;
            if (userControlStuent != null)
            {
                // Cập nhật thông tin từ ucCourse mà người dùng đã click

                int idRegister = int.Parse(userControlStuent.lblIdRegister.Text);

                // Thực thi truy vấn lấy chi tiết khóa học
                string query = "EXEC procedureStudent @id ";

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@id", SqlDbType.Int);
                parameters[0].Value = idRegister;

                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtIdRegister.Text = dt.Rows[0]["id"].ToString();
                    txtName.Text = dt.Rows[0]["fullName"].ToString();
                    txtCertificate.Text = dt.Rows[0]["phoneNumber"].ToString();
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    if (dt.Rows[0]["status"].ToString() == "1")
                    {
                        txtCourse.Text = "Đã Xác Nhận";
                    }
                    else
                    {
                        txtCourse.Text = "Chưa Xác Nhận";
                    }

                    //if (!(dt.Rows[0]["avatar"] is DBNull))
                    //{
                    //    byte[] pic = (byte[])row["avatar"];  // Đảm bảo tên cột đúng là 'avartar' không phải 'avatar'
                    //    MemoryStream pictureStream = new MemoryStream(pic);
                    //    userControlStuent.picImage.Image = Image.FromStream(pictureStream);  // Đảm bảo rằng 'picImage' là accessible
                    //}

                }
            }
        }

        

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //string searchValue = txtSearch.Text;

            //// Tạo truy vấn để gọi hàm tìm kiếm từ SQL Server
            //string query = "SELECT * FROM funtionSearchStudentsByCourse(@idCourse, @searchValue)";

            //// Tạo danh sách tham số
            //SqlParameter[] parameters = new SqlParameter[2];
            //parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            //parameters[0].Value = lblIdCourse.Text;
            //parameters[1] = new SqlParameter("@searchValue", SqlDbType.NVarChar);
            //parameters[1].Value = searchValue;

            //// Thực thi truy vấn và lấy kết quả
            //DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            //// Hiển thị kết quả tìm kiếm
            //ShowTeacher(dt);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panelAccount_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTeacher();
        }
        private void AddTeacher()
        {
            // Lấy dữ liệu từ các TextBox hoặc các control nhập liệu
            string fullName = txtName.Text;
            string email = txtEmail.Text;
            string certificate = txtCertificate.Text;

            // Chuyển đổi chuỗi experience sang số nguyên
            int experience = int.Parse(txtExperience.Text);

            // Các trường không có dữ liệu sẽ được gán giá trị mặc định
            string userName = "defaultUser";  // Gán giá trị mặc định cho userName
            string password = "defaultPassword";  // Gán giá trị mặc định cho password
            string avatar = "defaultAvatar.png";  // Gán giá trị mặc định cho avatar
            string type = "defaultType";  // Gán giá trị mặc định cho type

            // Khởi tạo câu truy vấn SQL để gọi stored procedure addTeacher
            string query = "EXEC addTeacher @idOwner, @userName, @password, @email, @fullName, @certificate, @experience, @avatar, @type";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = new SqlParameter("@idOwner", SqlDbType.Int);
            parameters[0].Value = 1; // Gán idOwner = 1

            parameters[1] = new SqlParameter("@userName", SqlDbType.NVarChar);
            parameters[1].Value = userName;

            parameters[2] = new SqlParameter("@password", SqlDbType.NVarChar);
            parameters[2].Value = password;

            parameters[3] = new SqlParameter("@email", SqlDbType.NVarChar);
            parameters[3].Value = email;

            parameters[4] = new SqlParameter("@fullName", SqlDbType.NVarChar);
            parameters[4].Value = fullName;

            parameters[5] = new SqlParameter("@certificate", SqlDbType.NVarChar);
            parameters[5].Value = certificate;

            parameters[6] = new SqlParameter("@experience", SqlDbType.Int);
            parameters[6].Value = experience;

            parameters[7] = new SqlParameter("@avatar", SqlDbType.NVarChar);
            parameters[7].Value = avatar;

            parameters[8] = new SqlParameter("@type", SqlDbType.NVarChar);
            parameters[8].Value = type;

            // Thực thi truy vấn thêm giáo viên
            int result = Dataprovider.Instance.ExecuteNonQuery(query, parameters);

            // Kiểm tra kết quả
            if (result > 0)
            {
                MessageBox.Show("Giáo viên đã được thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm giáo viên thất bại!");
            }
        }

        private void txtIdRegister_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string teacherId = txtIdRegister.Text.Trim(); // Giả sử txtIdRegister chứa ID của giáo viên

            // Gọi hàm xóa giáo viên
            DeleteTeacher(teacherId);
        }
        private void DeleteTeacher(string teacherId)
        {
            // Kiểm tra nếu ID giáo viên không trống
            if (string.IsNullOrEmpty(teacherId))
            {
                MessageBox.Show("Vui lòng nhập ID của giáo viên cần xóa!");
                return;
            }

            // Câu truy vấn gọi stored procedure
            string query = "EXEC deleteTeacher @id";

            // Tạo tham số cho stored procedure
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", SqlDbType.Int);
            parameters[0].Value = int.Parse(teacherId); // Chuyển đổi ID thành số nguyên

            try
            {
                // Thực thi stored procedure
                int rowsAffected = Dataprovider.Instance.ExecuteNonQuery(query, parameters);

                // Kiểm tra nếu có bản ghi nào bị xóa
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa giáo viên thành công!");
                    LoadTeacherFull(); // Tải lại danh sách giáo viên sau khi xóa thành công
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên với ID này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            string teacherId = txtSearch.Text.Trim(); // Lấy ID giáo viên từ textbox

            if (string.IsNullOrEmpty(teacherId))
            {
                MessageBox.Show("Vui lòng nhập ID giáo viên để tìm kiếm!");
                return;
            }

            // Tạo truy vấn gọi stored procedure để tìm giáo viên theo ID
            string query = "EXEC findTeacherById @id";

            // Tạo danh sách tham số cho stored procedure
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", SqlDbType.Int);
            parameters[0].Value = int.Parse(teacherId); // Chuyển đổi ID sang số nguyên

            try
            {
                // Thực thi truy vấn và lấy kết quả
                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                // Hiển thị kết quả tìm kiếm
                if (dt.Rows.Count > 0)
                {
                    ShowTeacher(dt); // Gọi hàm hiển thị danh sách giáo viên
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên với ID này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
