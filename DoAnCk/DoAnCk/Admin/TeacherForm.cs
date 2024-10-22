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

namespace DoAnCk
{
    public partial class TeacherForm : Form
    {
        MainAdminForm adminForm;
        public TeacherForm(MainAdminForm adminForm)
        {
            InitializeComponent();
            this.adminForm = adminForm;
        }
        User user=new User();
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            btnAddCourse.Visible = false;
            ComboBoxAccountType.SelectedIndex = 0;
            LoadUserFull();

        }
        public void ShowAccount(DataTable dt)
        {
            panelListAccount.Controls.Clear();
            int i = 1;  // Di chuyển biến i ra ngoài vòng lặp
            foreach (DataRow row in dt.Rows)  // Sửa 'for' thành 'foreach' để duyệt qua từng hàng
            {

                ucAccount account = new ucAccount();
                account.DoubleClick += Account;
                account.lblSTT.Text = i.ToString();
                
                account.lblUserAccount.Text = row["userName"].ToString();
                account.lblUserName.Text = row["fullName"].ToString();
                //if (!(row["avartar"] is DBNull))
                //{
                //    byte[] pic = (byte[])row["avartar"];  // Đảm bảo tên cột đúng là 'avartar' không phải 'avatar'
                //    MemoryStream pictureStream = new MemoryStream(pic);
                //    account.picImage.Image = Image.FromStream(pictureStream);  // Đảm bảo rằng 'picImage' là accessible
                //}
                //if (row["accept"].ToString() == "1")
                //{
                //    account.checkAccept.Checked = true;
                //}
                //else
                //{
                //    account.checkAccept.Checked = false;
                //}
                panelListAccount.Controls.Add(account);
                i++;
            }
        }
        public void LoadUserFull()
        {
            string query = "SELECT * FROM TeacherUserInfo;";
            //if (ComboBoxAccountType.Text == "Teachers")
            //{
            //    query += " WHERE user_type = 2";
            //    btnAddCourse.Visible = true;
            //}
            //else if (ComboBoxAccountType.Text == "Students")
            //{
            //    query += " WHERE user_type = 3";
            //    btnAddCourse.Visible = false;
            //}
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query);
            ShowAccount(dt);
        }

        private void Account(object sender, EventArgs e)
        {

            ucAccount clickedAccount = sender as ucAccount;
            if (clickedAccount != null)
            {
                txtUserAccount.Text = clickedAccount.lblUserAccount.Text;
                txtUserName.Text = clickedAccount.lblUserName.Text;
                txtStatus.Text = clickedAccount.checkAccept.Checked ? "Đã Xác Nhận" : "Chưa Chấp Nhận";

                if (clickedAccount.picImage.Image != null)

                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Lưu hình ảnh hiện tại trong PictureBox vào MemoryStream
                        clickedAccount.picImage.Image.Save(ms, clickedAccount.picImage.Image.RawFormat);
                        byte[] imageBytes = ms.ToArray();

                        // Lưu trữ hoặc xử lý mảng byte ở đây
                        // Hiển thị lại hình ảnh từ mảng byte nếu cần
                        MemoryStream pictureStream = new MemoryStream(imageBytes);
                        picImage.Image = Image.FromStream(pictureStream);
                    }
                }
            }
        }

        private void panalAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            
            if (txtUserAccount.Text == "")
            {
                MessageBox.Show("Chưa chọn tài khoản? ", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (txtStatus.Text == "Đã Xác Nhận")
                {
                    string userAccount = txtUserAccount.Text;
                    DataTable dta = user.SelectIdAcount(userAccount);
                    int idTecher = Convert.ToInt32(dta.Rows[0]["user_id"]);
                    AddCourseTeacher addCourseTeacher = new AddCourseTeacher(adminForm,idTecher);
                       
                        adminForm.OpenFormForOther(addCourseTeacher);
                }
                
                else
                {
                    MessageBox.Show("Tài Khoản Chưa Được Xác Nhận ? ", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserFull();
        }

        private void panelAccount_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (txtUserAccount.Text == "")
            {
                MessageBox.Show("Chưa chọn tài khoản? ", "Accept Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (txtStatus.Text == "Đã Xác Nhận")
                {


                    MessageBox.Show("Tài khoản đã được xác nhận trước đó rồi!! ", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {
                    int accept = 1;
                    string userAccount = txtUserAccount.Text;
                    if (user.UpdateAccept(accept, userAccount))
                    {
                        MessageBox.Show("Accept Account", "Account accept successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    TeacherForm_Load(sender, e);
                }
            }
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            if (txtUserAccount.Text == "")
            {
                MessageBox.Show("Chưa chọn tài khoản? ", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string userAccount = txtUserAccount.Text;
                DataTable dta = user.SelectIdAcount(userAccount);
                int idTecher = Convert.ToInt32(dta.Rows[0]["user_id"]);
                if (user.DeleteAccount(idTecher))
                {
                    MessageBox.Show("Tài khoản đã được xóa!!!!", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TeacherForm_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Tài khoản chưa được xóa!!!!", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = user.GetFindUser(txtText.Text);
            ShowAccount(dt);
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            if (txtUserAccount.Text == "")
            {
                MessageBox.Show("Chưa chọn tài khoản? ", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MainLoginForm main = new MainLoginForm();
                string userAccount = txtUserAccount.Text;
                DataTable dta = user.SelectIdAcount(userAccount);
                int idTecher = Convert.ToInt32(dta.Rows[0]["user_id"]);
                int user_type = Convert.ToInt32(dta.Rows[0]["user_type"]);
                string pass = dta.Rows[0]["password"].ToString();
                MainAdminForm mainAdminForm = new MainAdminForm();
                LoginForm loginForm = new LoginForm(main);
                loginForm.txtNameAccount.Text = txtUserAccount.Text;
                loginForm.txtPassword.Text = pass;
                if (user_type == 1)
                {
                    loginForm.comboboxAccount.SelectedIndex = 0; // Chọn mục đầu tiên trong ComboBox
                }
                else if (user_type == 2)
                {
                    loginForm.comboboxAccount.SelectedIndex = 1; // Chọn mục thứ hai trong ComboBox
                }
                else
                {
                    loginForm.comboboxAccount.SelectedIndex = 2; // Chọn mục thứ ba trong ComboBox
                }


                //mainAdminForm.Show();

                adminForm.Hide();
                loginForm.Show();

            }
        }
    }
}
