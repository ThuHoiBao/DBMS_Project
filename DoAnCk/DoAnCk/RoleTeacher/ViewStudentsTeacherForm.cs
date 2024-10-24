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
using System.Windows.Controls;
using System.Windows.Forms;

namespace DoAnCk.RoleTeacher
{
    public partial class ViewStudentsTeacherForm : Form
    {
        public ViewStudentsTeacherForm()
        {
            InitializeComponent();
        }

        private void ViewStudentsTeacherForm_Load(object sender, EventArgs e)
        {
            LoadStudentFull();
        }
        public void ShowStudent(DataTable dt)
        {
            panelListAccount.Controls.Clear();
            int i = 1;  // Di chuyển biến i ra ngoài vòng lặp
            foreach (DataRow row in dt.Rows)  // Sửa 'for' thành 'foreach' để duyệt qua từng hàng
            {

                
                UserControlStuent userControlStuent = new UserControlStuent();
                userControlStuent.lblIdRegister.Text = row["id"].ToString();
                userControlStuent.lblFullName.Text=row["fullName"].ToString();
                userControlStuent.lblPhone.Text= row["phoneNumber"].ToString();
                userControlStuent.DoubleClick += Account;
                userControlStuent.lblSTT.Text = i.ToString();

                //if (!(row["avatar"] is DBNull))
                //{
                //    byte[] pic = (byte[])row["avatar"];  // Đảm bảo tên cột đúng là 'avartar' không phải 'avatar'
                //    MemoryStream pictureStream = new MemoryStream(pic);
                //    userControlStuent.picImage.Image = Image.FromStream(pictureStream);  // Đảm bảo rằng 'picImage' là accessible
                //}
                if (row["status"].ToString() == "1")
                {
                    userControlStuent.checkAccept.Checked = true;
                }
                else
                {
                    userControlStuent.checkAccept.Checked = false;
                }
                panelListAccount.Controls.Add(userControlStuent);
                i++;
            }
        }
        public void LoadStudentFull()
        {
            string query = "EXEC procedureStudentsByCourse @idCourse";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            parameters[0].Value = lblIdCourse.Text;

            // Truyền tham số vào ExecuteQuery
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);
            ShowStudent(dt);
        }

        private void Account(object sender, EventArgs e)
        {
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
                    txtIdRegister.Text= dt.Rows[0]["id"].ToString();
                    txtName.Text= dt.Rows[0]["fullName"].ToString();
                    txtPhone.Text= dt.Rows[0]["phoneNumber"].ToString();
                    txtEmail.Text= dt.Rows[0]["email"].ToString();
                    txtAddress.Text= dt.Rows[0]["address"].ToString();
                    if (dt.Rows[0]["status"].ToString() == "1")
                    {
                        txtStatus.Text = "Đã Xác Nhận";
                    }
                    else
                    {
                        txtStatus.Text = "Chưa Xác Nhận";
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng chưa chọn tài khoản
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa chọn tài khoản!", "Accept Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if (txtStatus.Text == "Đã Xác Nhận")
                {
                    MessageBox.Show("Tài khoản đã được xác nhận trước đó rồi!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Xác nhận và cập nhật trạng thái tài khoản
                    string newStatus = "1";  // Giá trị cho trạng thái "Đã Xác Nhận"
                    int idRegister = int.Parse(txtIdRegister.Text);  // Lấy ID tài khoản từ TextBox

                    string query = "EXEC procedureUpdateStudentStatus @id, @newStatus";

                    // Tạo danh sách tham số để truyền vào truy vấn
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = new SqlParameter("@id", SqlDbType.Int);
                    parameters[0].Value = idRegister;  
                    parameters[1] = new SqlParameter("@newStatus", SqlDbType.NVarChar);
                    parameters[1].Value = newStatus;  

                    try
                    {
                        // Thực thi câu lệnh truy vấn
                        Dataprovider.Instance.ExecuteQuery(query, parameters);

                        // Cập nhật giao diện sau khi xác nhận thành công
                        txtStatus.Text = "Đã Xác Nhận";

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Xác nhận tài khoản thành công!", "Accept Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách sinh viên sau khi cập nhật
                        LoadStudentFull();
                    }
                    catch (SqlException ex)
                    {
                        // Hiển thị thông báo lỗi nếu có
                        MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng chưa chọn tài khoản
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa chọn tài khoản để xóa!", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này khỏi khóa học?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                int idRegister = int.Parse(txtIdRegister.Text);  // Lấy ID tài khoản từ TextBox

                string query = "EXEC procedureRemoveStudentFromCourse @id";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@id", SqlDbType.Int);
                parameters[0].Value = idRegister;

                try
                {
                    // Thực thi câu lệnh truy vấn
                    Dataprovider.Instance.ExecuteQuery(query, parameters);

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Xóa sinh viên khỏi khóa học thành công!", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa các trường thông tin trên giao diện
                    txtIdRegister.Clear();
                    txtName.Clear();
                    txtPhone.Clear();
                    txtEmail.Clear();
                    txtAddress.Clear();
                    txtStatus.Clear();

                    // Tải lại danh sách sinh viên sau khi xóa
                    LoadStudentFull();
                }
                catch (SqlException ex)
                {
                    // Hiển thị thông báo lỗi nếu có
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            // Tạo truy vấn để gọi hàm tìm kiếm từ SQL Server
            string query = "SELECT * FROM funtionSearchStudentsByCourse(@idCourse, @searchValue)";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            parameters[0].Value = lblIdCourse.Text; 
            parameters[1] = new SqlParameter("@searchValue", SqlDbType.NVarChar);
            parameters[1].Value = searchValue;

            // Thực thi truy vấn và lấy kết quả
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            // Hiển thị kết quả tìm kiếm
            ShowStudent(dt);

        }
    }
}
