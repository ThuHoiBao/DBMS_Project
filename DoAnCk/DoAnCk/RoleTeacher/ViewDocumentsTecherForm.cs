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

namespace DoAnCk.RoleTeacher
{
    public partial class ViewDocumentsTecherForm : Form
    {
        public ViewDocumentsTecherForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            txtContent.Text = "";
            txtTitle.Text = "";
            txtIdDocument.Text = "";
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
                    txtTitle.Text=dt.Rows[0]["name"].ToString();
                    txtContent.Text=dt.Rows[0]["content"].ToString();
                }
            }
        }
        private void ViewDocumentsTecherForm_Load(object sender, EventArgs e)
        {
            LoadCourseFull();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            LoadCourseFull();
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            string query = "EXEC procedureInsertDocument @idCourse, @name, @content";

            // Tạo danh sách tham số để truyền vào truy vấn
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            parameters[0].Value = lblIdCourse.Text;  
            parameters[1] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[1].Value = txtTitle.Text;  
            parameters[2] = new SqlParameter("@content", SqlDbType.NVarChar);
            parameters[2].Value = txtContent.Text;  

            try
            {
                
                Dataprovider.Instance.ExecuteQuery(query, parameters);

                // Thông báo khi thêm thành công
                MessageBox.Show("Thêm tài liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách tài liệu sau khi thêm
                LoadCourseFull();
            }
            catch (SqlException ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtIdDocument.Text) || !int.TryParse(txtIdDocument.Text, out int documentId))
            {
                MessageBox.Show("Vui lòng chọn một tài liệu hợp lệ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string query = "EXEC procedureUpdateDocument @id, @idCourse, @name, @content";

            // Tạo danh sách tham số để truyền vào truy vấn
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@id", SqlDbType.Int);
            parameters[0].Value = int.Parse(txtIdDocument.Text);  // Lấy ID tài liệu
            parameters[1] = new SqlParameter("@idCourse", SqlDbType.NVarChar);
            parameters[1].Value = lblIdCourse.Text;  // Mã khóa học
            parameters[2] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[2].Value = txtTitle.Text;  // Tiêu đề tài liệu
            parameters[3] = new SqlParameter("@content", SqlDbType.NVarChar);
            parameters[3].Value = txtContent.Text;  // Nội dung tài liệu

            try
            {
                // Thực thi câu lệnh truy vấn
                Dataprovider.Instance.ExecuteQuery(query, parameters);

                // Thông báo khi cập nhật thành công
                MessageBox.Show("Sửa tài liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách tài liệu sau khi sửa
                LoadCourseFull();
            }
            catch (SqlException ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveDocument_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng chưa chọn tài liệu để xóa
            if (string.IsNullOrEmpty(txtIdDocument.Text) || !int.TryParse(txtIdDocument.Text, out int documentId))
            {
                MessageBox.Show("Vui lòng chọn một tài liệu hợp lệ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thông báo xác nhận trước khi xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài liệu này?",
                                                 "Xác nhận xóa tài liệu",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, thực hiện xóa tài liệu
                string query = "EXEC procedureDeleteDocument @id";

                // Tạo danh sách tham số để truyền vào truy vấn
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@id", SqlDbType.Int);
                parameters[0].Value = documentId;  // ID của tài liệu cần xóa

                try
                {
                    // Thực thi câu lệnh truy vấn
                    Dataprovider.Instance.ExecuteQuery(query, parameters);

                    // Thông báo khi xóa thành công
                    MessageBox.Show("Xóa tài liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách tài liệu sau khi xóa
                    LoadCourseFull();
                }
                catch (SqlException ex)
                {
                    // Hiển thị thông báo lỗi nếu có
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
