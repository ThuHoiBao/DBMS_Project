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
using DoAnCk.Login;
using Emgu.CV.CvEnum;

namespace DoAnCk
{
    public partial class SignUpForm : Form
    {
        MainLoginForm loginForm;
        public SignUpForm(MainLoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                picImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public bool InsertStudent(string userName, string password, string fullName, string email, string phoneNumber, DateTime dateOfBirth, string target, string address, byte[] avatar, string type)
        {
            int userType = 1;
            Config.SetCredentials(txtUserName.Text, txtPassWord.Text);
            Dataprovider.Instance.SetConnectionStringByRole(userType);
            // Câu lệnh EXEC SQL với stored procedure
            string query = "EXEC InsertStudent @userName, @password, @fullName, @email, @phoneNumber, @dateOfBirth, @target, @address, @avatar, @type";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName", SqlDbType.NVarChar) { Value = userName },
                new SqlParameter("@password", SqlDbType.NVarChar) { Value = password },
                new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                new SqlParameter("@email", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@phoneNumber", SqlDbType.NVarChar) { Value = phoneNumber },
                new SqlParameter("@dateOfBirth", SqlDbType.DateTime) { Value = dateOfBirth },
                new SqlParameter("@target", SqlDbType.NVarChar) { Value = target },
                new SqlParameter("@address", SqlDbType.NVarChar) { Value = address },
                new SqlParameter("@avatar", SqlDbType.VarBinary) { Value = avatar },
                new SqlParameter("@type", SqlDbType.NVarChar) { Value = type }
            };

            // Thực hiện câu lệnh và kiểm tra kết quả
            int result = Dataprovider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0; // Trả về true nếu chèn thành công
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            DateTime bdate = datepicBd.Value;
            string fullName = txtFullName.Text;
            string pass = txtPassWord.Text;
            string adrs = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string target = txtTarget.Text;
            string userType = "3";

            // Chuyển ảnh thành mảng byte để lưu trữ
            MemoryStream pic = new MemoryStream();
            picImage.Image.Save(pic, picImage.Image.RawFormat);
            byte[] avatar = pic.ToArray();

            try
            {
                // Gọi phương thức InsertStudent để thêm sinh viên mới vào cơ sở dữ liệu
                bool isInserted = InsertStudent(userName, pass, fullName, email, phone, bdate, target, adrs, avatar, userType);

                if (isInserted)
                {
                    MessageBox.Show("New Account Added, Please wait for admin to confirm", "New Account Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add new account. Please check the information provided.", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                // Kiểm tra lỗi từ SQL Server nếu có lỗi trùng lặp
                if (ex.Number == 2627 || ex.Number == 2601) // Lỗi trùng khóa
                {
                    if (ex.Message.Contains("username")) // Kiểm tra xem lỗi có liên quan đến username
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ex.Message.Contains("phone")) // Kiểm tra xem lỗi có liên quan đến phone
                    {
                        MessageBox.Show("Phone number already exists. Please use a different phone number.", "Duplicate Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Thông báo lỗi khác từ SQL
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            //MainLoginForm mainLoginForm = new MainLoginForm();
            LoginForm login = new LoginForm(loginForm);
          
            //this.Hide();
            loginForm.OpenForm(login);
            loginForm.Show();
        }
    }
}
