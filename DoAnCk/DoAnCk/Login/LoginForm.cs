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
            
            MainLoginForm mainLoginForm = new MainLoginForm();
            SignUpForm signUpForm = new SignUpForm();
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
            if(comboboxAccount.Text == "Administrator")
            {
                userType = 1;
            }
            else if (comboboxAccount.Text == "Teacher")
            {
                userType = 2;
            }
            else
            {
                userType = 3;
            }
            int accep = 1;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc", txtNameAccount.Text),
                new SqlParameter("@pwd", txtPassword.Text),
                new SqlParameter("@ust",userType),
                new SqlParameter("@acep",accep)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT * FROM Users WHERE account = @acc AND password = @pwd " +
                " And user_type =@ust AND accept = @acep",parameters);
            check = true;
            Check();
            if (check == true && dt.Rows.Count>0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["user_id"].ToString());
                Global.GetGlobalId(userId);
                if (dt.Rows.Count > 0 && comboboxAccount.Text == "Administrator")
                {

                    MessageBox.Show("Đăng Nhập Thành Công !!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainAdminForm mainAdminForm = new MainAdminForm();
                    this.Hide();
                    mainLoginForm.Hide();
                    mainAdminForm.Show();
                   

                }
      //          else if(dt.Rows.Count>0 && comboboxAccount.Text == "Teacher")
      //          {
      //              MessageBox.Show("Đăng Nhập Thành Công !!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //              MainTeacherForm main = new MainTeacherForm(userId);
      //              this.Hide();
      //              mainLoginForm.Hide();
      //main.Show();
                    
      //          }
      //          else if(dt.Rows.Count > 0 && comboboxAccount.Text == "Student")
      //          {
      //              MessageBox.Show("Đăng Nhập Thành Công !!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //              FormMain formMain =new FormMain(userId);
      //             mainLoginForm.Hide();
      //              this.Hide();
      //              formMain.Show();
                   
      //          }
                else
                {
                    MessageBox.Show("Incorrect Pass Word or User Account or Type Account");
                }
            }
            else if(dt.Rows.Count == 0 && check==true)
            {
                MessageBox.Show("Incorrect Pass Word or User Account or Type Account","Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnSeenPass.Visible = true;
        }
    }
}
