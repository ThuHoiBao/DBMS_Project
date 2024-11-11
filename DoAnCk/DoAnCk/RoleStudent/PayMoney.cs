using DoAnCk.RoleStudent;
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
    public partial class PayMoney : Form
    {
        MainOwner owner;
        public PayMoney(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }
        public PayMoney()
        {
            InitializeComponent();
        }
        private void PayMoney_Load(object sender, EventArgs e)
        {
            LoadCourseFull(1);
            LoadTotalDebt(1);
        }

        public void LoadCourseFull(int studentId)
        {
            string query = "EXEC GetCoursesByStudentId @idStudent";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idStudent", SqlDbType.Int);
            parameters[0].Value = studentId;

            // Thực thi truy vấn và nhận DataTable
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            // Hiển thị danh sách khóa học
            ShowCourse(dt);
        }
        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;

            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                Payment ucpayment = new Payment();

                // Hiển thị số thứ tự và thông tin khóa học
                ucpayment.lblSTT.Text = i.ToString(); // Số thứ tự
                ucpayment.lblCourseId.Text = row["CourseId"].ToString(); // Mã khóa học
                ucpayment.lblCourseName.Text = row["CourseName"].ToString(); // Tên khóa học
                ucpayment.lblCoursePrice.Text = row["price"].ToString(); // Giá khóa học


                // Thêm UserControl vào panel
                panelListCourse.Controls.Add(ucpayment);
                i++;
            }
        }
        public void LoadTotalDebt(int studentId)
        {
            // Tạo chuỗi truy vấn để gọi hàm SQL functionCalculateDebt
            string query = "SELECT dbo.functionCalculateDebt(@studentId) AS TotalDebt";

            // Tạo danh sách tham số truyền vào truy vấn
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@studentId", SqlDbType.Int);
            parameters[0].Value = studentId;

            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                // Lấy tổng số tiền từ cột TotalDebt trong kết quả
                decimal totalDebt = Convert.ToDecimal(dt.Rows[0]["TotalDebt"]);

                // Hiển thị tổng số tiền nợ ra TextBox
                txtTotalDebt.Text = totalDebt.ToString("C"); // Định dạng tiền tệ
            }
            else
            {
                // Nếu không có kết quả, hiển thị thông báo
                txtTotalDebt.Text = "0";
            }
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            LoadTotalDebt(1);
        }
    }
}
