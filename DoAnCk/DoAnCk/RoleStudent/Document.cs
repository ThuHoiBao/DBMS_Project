using DoAnCk.RoleTeacher;
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

namespace DoAnCk.RoleStudent
{
    public partial class Document : Form
    {
        public Document()
        {
            InitializeComponent();
        }

        private void Document_Load(object sender, EventArgs e)
        {
            LoadCourseFull();
        }
        public void ShowDucument(DataTable dt)
        {
            panelListDocument.Controls.Clear();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                UserControlDecument userControlDecument = new UserControlDecument();
                userControlDecument.lblSTT.Text = i.ToString();
                userControlDecument.lblId.Text = row["id"].ToString();
                userControlDecument.lblDate.Text = row["Date"].ToString();
                userControlDecument.lblTitle.Text = row["name"].ToString();

                // Gắn sự kiện DoubleClick
                userControlDecument.DoubleClick += new EventHandler(DocumentClick);  // Gắn sự kiện trực tiếp

                panelListDocument.Controls.Add(userControlDecument);
                i++;
            }
        }


        public void LoadCourseFull()
        {

            string query = "EXEC procedureDocumentsByCourse @idCourse";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            parameters[0].Value = lblIdCourse.Text;

            // Truyền tham số vào ExecuteQuery
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);
            ShowDucument(dt);
        }
        private void DocumentClick(object sender, EventArgs e)
        {

            UserControlDecument ucDocument = sender as UserControlDecument;
            if (ucDocument != null)
            {
                // Cập nhật thông tin từ ucCourse mà người dùng đã click

                int idDocument = int.Parse(ucDocument.lblId.Text);

                // Thực thi truy vấn lấy chi tiết khóa học
                string query = "EXEC procedureDocument @id ";

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@id", SqlDbType.Int);
                parameters[0].Value = idDocument;

                DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtIdDocument.Text = dt.Rows[0]["id"].ToString();
                    txtTitle.Text = dt.Rows[0]["name"].ToString();
                    txtContent.Text = dt.Rows[0]["content"].ToString();
                }
            }
        }
    }
}
