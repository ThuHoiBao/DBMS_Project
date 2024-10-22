using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '\0';
            txtConfirmPass.PasswordChar = '\0';
            btnSeenPass.Visible =false ;
            
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
        bool check = true;
        public void Check()
        {
            int born = datepicBd.Value.Year;
            int thisYear = DateTime.Now.Year;


            errorProvider1.Clear();
            if (txtNameAccount.Text== "")
            {
                errorProvider1.SetError(txtNameAccount, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtUserName.Text == "")
            {
                errorProvider1.SetError(txtUserName, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtPassWord.Text == "")
            {
                errorProvider1.SetError(txtPassWord, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtConfirmPass.Text == "")
            {
                errorProvider1.SetError(txtConfirmPass, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtAddress.Text == "")
            {
                errorProvider1.SetError(txtAddress, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (radStdent == null && radTeacher == null)
            {
                errorProvider1.SetError(radTeacher, "Bạn Chưa Chọn gì?");
                check = false;
            }
            if (picImage.Image == null)
            {
                errorProvider1.SetError(picImage, "Bạn Chưa Chọn gì?");
                check = false;
            }
            if ((thisYear - born) < 10 || (thisYear - born > 100))
            {
                errorProvider1.SetError(datepicBd, "Tuổi bạn phải lớn hơn 10 và nhỏ hơn 100?");
                check = false;
            }
            if (!CheckStringName(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "UserName không chứa chữ số hoặc các kí tự đặc biệt");
                check = false;
            }

        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            User user = new User();
            string userName = txtUserName.Text;
            DateTime bdate = datepicBd.Value;
            string userAccount = txtNameAccount.Text;
            string pass = txtPassWord.Text;
            string adrs = txtAddress.Text;
            int accept = 0;

            int userType = 1;
            string gmail = "";
            if (radStdent.Checked)
            {
                userType = 3;
                gmail=txtNameAccount.Text+"@student.hcmute.edu.vn";
            }
            else if (radTeacher.Checked)
            {
                userType = 2;
                gmail = txtNameAccount.Text + "@teacher.hcmute.edu.vn";
            }


            MemoryStream pic = new MemoryStream();
            int born = datepicBd.Value.Year;
            int thisYear = DateTime.Now.Year;
            check = true;
            Check();
            if (check == true)
            {
                try
                {
                    picImage.Image.Save(pic, picImage.Image.RawFormat);
                    if (txtPassWord.Text == txtConfirmPass.Text)
                    {
                        if (user.InsertAccount(accept, userName, bdate, pic, userAccount, pass, gmail, adrs, userType))
                        {
                            MessageBox.Show("New Account Added, Please, wait for admin to confirm", "New Account Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Confirm Pass Word is not the same as Pass Word", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnUnSeenPass_Click(object sender, EventArgs e)
        {
            txtConfirmPass.PasswordChar = '*';
            txtPassWord.PasswordChar = '*';
            btnSeenPass.Visible = true;
        }
    }
}
