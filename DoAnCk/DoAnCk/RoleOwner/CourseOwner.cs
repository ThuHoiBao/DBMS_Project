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
    public partial class CourseOwner : Form
    {
        MainOwner owner;
        public CourseOwner(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void CourseOwner_Load(object sender, EventArgs e)
        {

        }
        public void ShowCourse(DataTable dt)
        {
            panelListCourse.Controls.Clear();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                // Tạo mới một đối tượng CourseUserControl1 cho mỗi hàng dữ liệu
                CourseUserControl1 ucCourse = new CourseUserControl1();
                ucCourse.lblSTT.Text = i.ToString();
                ucCourse.lblCourseId.Text = row["id"].ToString();
                ucCourse.lblCourseName.Text = row["name"].ToString();


                // Gắn sự kiện DoubleClick
              //  ucCourse.DoubleClick += new EventHandler(CourseClick);  // Gắn sự kiện trực tiếp

                panelListCourse.Controls.Add(ucCourse);
                i++;
            }
        }


        public void LoadCourseFull()
        {

            string query = "EXEC procedureCourseListByTeacher @idTeacher";

            // Tạo danh sách tham số
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@idTeacher", SqlDbType.Int);
            parameters[0].Value = 7;

            // Truyền tham số vào ExecuteQuery
            DataTable dt = Dataprovider.Instance.ExecuteQuery(query, parameters);
            ShowCourse(dt);
        }
    }
}
