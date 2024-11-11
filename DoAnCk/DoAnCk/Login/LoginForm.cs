using DoAnCk.RoleOwner;
using DoAnCk.RoleStudent;
using DoAnCk.RoleTeacher;
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

namespace DoAnCk
{
    public partial class LoginForm : Form
    {
        MainLoginForm mainLoginForm;
        public LoginForm(MainLoginForm mainLoginForm)
        {
            InitializeComponent();
            this.mainLoginForm = mainLoginForm;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            //MainLoginForm mainLoginForm = new MainLoginForm();
            SignUpForm signUpForm = new SignUpForm(mainLoginForm);
            //this.Hide();
            mainLoginForm.OpenForm(signUpForm);
            mainLoginForm.Show();
            
        }
 

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainLoginForm mainLoginForm = new MainLoginForm();
            FogetAccountForm fAccountForm = new FogetAccountForm();
            mainLoginForm.OpenForm(fAccountForm); 
            mainLoginForm.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
                txtPassword.PasswordChar = '\0';
                btnSeenPass.Visible = false;
           
        }

        private void btnUnSeenPass_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnSeenPass.Visible = true;
        }
        bool check = true;
        public void Check()
        {
            errorProvider1.Clear();
            if (txtNameAccount.Text == "")
            {
                errorProvider1.SetError(txtNameAccount, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (comboboxAccount.Text=="")
            {
                errorProvider1.SetError(comboboxAccount, "Bạn Chưa Chọn tài khoản nào ?");
                check = false;
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int userType;
            
            DataTable dt = new DataTable();

            // Xác định loại người dùng dựa trên lựa chọn của comboboxAccount
            if (comboboxAccount.Text == "Administrator")
            {
                userType = 1;
                string procedureName = "EXEC LoginOwner @userName,  @password";
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@userName", SqlDbType.NVarChar);
                parameters[0].Value = txtNameAccount.Text;
                parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
                parameters[1].Value = txtPassword.Text;
                // Truyền stored procedure vào ExecuteQuery mà không cần "EXEC"
                dt = Dataprovider.Instance.ExecuteQuery(procedureName, parameters);

            }
            else if (comboboxAccount.Text == "Teacher")
            {
                userType = 2;
               string procedureName = "EXEC LoginTeacher @userName,  @password";
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@userName", SqlDbType.NVarChar);
                parameters[0].Value = txtNameAccount.Text;
                parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
                parameters[1].Value = txtPassword.Text;

                // Truyền stored procedure vào ExecuteQuery mà không cần "EXEC"
                dt = Dataprovider.Instance.ExecuteQuery(procedureName, parameters);
            }
            else
            {
                userType = 3;
               string procedureName = "EXEC LoginStudent @userName, @password";
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@userName",SqlDbType.NVarChar);
                parameters[0].Value = txtNameAccount.Text;
                parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
                parameters[1].Value = txtPassword.Text;
                // Truyền stored procedure vào ExecuteQuery mà không cần "EXEC"
                dt = Dataprovider.Instance.ExecuteQuery(procedureName, parameters);
            }

            // Tạo danh sách tham số


            // Kiểm tra kết quả trả về
            if (dt.Rows.Count > 0)
            {
                // Đăng nhập thành công, lấy user_id từ kết quả
                int userId = Convert.ToInt32(dt.Rows[0]["id"]);
                string fullName = dt.Rows[0]["fullName"].ToString();

                MessageBox.Show("Đăng Nhập Thành Công !!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kiểm tra loại người dùng và mở form tương ứng
                if (userType == 1) // Administrator
                {
                    MainOwner mainOwner = new MainOwner();
                    mainOwner.lblUserName.Text = "Xin Chào," + fullName;
                    this.Hide();
                    mainLoginForm.Hide();
                    mainOwner.Show();
                }
                else if (userType == 2) // Teacher
                {
                    MainOfTeacherForm mainOfTeacherForm = new MainOfTeacherForm();
                    mainOfTeacherForm.lblSudentId.Text =userId.ToString();
                    mainOfTeacherForm.lblUserName.Text= "Xin Chào," + fullName;
                    this.Hide();
                    mainLoginForm.Hide();
                    mainOfTeacherForm.Show();
                }
                else if (userType == 3) // Student
                {
                    Main main = new Main();
                    main.lblIdStudent.Text = userId.ToString();
                    main.lblUserName.Text ="Xin Chào,"+ fullName;
                    this.Hide();
                    mainLoginForm.Hide();
                    main.Show();
                }
            }
            else
            {
                // Nếu không tìm thấy bản ghi phù hợp, thông báo lỗi
                MessageBox.Show("Incorrect Username, Password, or Account Type", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnSeenPass.Visible = true;
        }
    }
}
