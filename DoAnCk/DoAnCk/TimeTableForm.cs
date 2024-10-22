using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    
    public partial class TimeTableForm : Form
    {
        DataTable dt=new DataTable();
      
        public TimeTableForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }
        Courses courses=new Courses();
        private void TimeTableForm_Load(object sender, EventArgs e)
        {
           
            
                string color1 = "#7AB2B2";
                string color2 = "#7469B6";
                string color3 = "#7ABA78";
                string color4 = "#ED9455";
                Panel panel1 = new Panel();
                panel1.Size = new Size(148, 30);
                Panel panel2 = new Panel();
                panel2.Size = new Size(148, 30);
                Panel panel3 = new Panel();
                panel3.Size = new Size(148, 30);

                int i = 0;
                

                foreach (DataRow row in dt.Rows)
                {
                    if (i == 0)
                    {
                        TuesdayflowLayoutPanel2.Controls.Add(panel1);
                        ThursdayflowLayoutPanel5.Controls.Add(panel2);
                        SaturdayflowLayoutPanel6.Controls.Add(panel3);
                    }

                    TimeTableUserControl1 ucTime2 = new TimeTableUserControl1();
                    TimeTableUserControl1 ucTime3 = new TimeTableUserControl1();
                    TimeTableUserControl1 ucTime4 = new TimeTableUserControl1();
                    TimeTableUserControl1 ucTime5 = new TimeTableUserControl1();
                    TimeTableUserControl1 ucTime6 = new TimeTableUserControl1();
                    TimeTableUserControl1 ucTime7 = new TimeTableUserControl1();
                    TimeTableUserControl1 ucTime8 = new TimeTableUserControl1();
                    if (i % 2 == 0)
                    {
                        ucTime2.BackColor = ColorTranslator.FromHtml(color3);
                        ucTime3.BackColor = ColorTranslator.FromHtml(color4);
                        ucTime4.BackColor = ColorTranslator.FromHtml(color1);
                    }
                    else
                    {
                        ucTime2.BackColor = ColorTranslator.FromHtml(color1);
                        ucTime3.BackColor = ColorTranslator.FromHtml(color2);
                        ucTime4.BackColor = ColorTranslator.FromHtml(color3);
                    }
                    if (row["day"].ToString() == "Hai")
                    {
                        ucTime2.lblCourseName.Text = row["course_name"].ToString();
                          ucTime2.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime2.lblNumber.Text = row["number"].ToString();
                        MondayflowLayoutPanel3.Controls.Add(ucTime2);
                    }
                    else if (row["day"].ToString() == "Ba")
                    {
                        ucTime3.lblCourseName.Text = row["course_name"].ToString();
                         ucTime3.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime3.lblNumber.Text = row["number"].ToString();
                        TuesdayflowLayoutPanel2.Controls.Add(ucTime3);
                    }
                    else if (row["day"].ToString() == "Tư")
                    {
                        ucTime4.lblCourseName.Text = row["course_name"].ToString();
                         ucTime4.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime4.lblNumber.Text = row["number"].ToString();
                        WednesdayflowLayoutPanel4.Controls.Add(ucTime4);
                    }
                    else if (row["day"].ToString() == "Năm")
                    {
                        ucTime5.lblCourseName.Text = row["course_name"].ToString();
                         ucTime5.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime5.lblNumber.Text = row["number"].ToString();
                        ThursdayflowLayoutPanel5.Controls.Add(ucTime5);
                    }
                    else if (row["day"].ToString() == "Sáu")
                    {
                        ucTime6.lblCourseName.Text = row["course_name"].ToString();
                         ucTime6.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime6.lblNumber.Text = row["number"].ToString();
                        FridayflowLayoutPanel7.Controls.Add(ucTime6);
                    }
                    else if (row["day"].ToString() == "Bảy")
                    {
                        ucTime7.lblCourseName.Text = row["course_name"].ToString();
                         ucTime7.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime7.lblNumber.Text = row["number"].ToString();
                        SaturdayflowLayoutPanel6.Controls.Add(ucTime7);
                    }
                    else if (row["day"].ToString() == "Chủ Nhật")
                    {
                        ucTime8.lblCourseName.Text = row["course_name"].ToString();
                         ucTime8.lblNameTeacher.Text = row["user_name"].ToString();
                        ucTime8.lblNumber.Text = row["number"].ToString();
                        SundayflowLayoutPanel8.Controls.Add(ucTime8);
                    }
                    i++;
                }
            

            // Kiểm tra nếu danh sách không trống


        }

        private void TimeflowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TuesdayflowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, TuesdayflowLayoutPanel2.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, TuesdayflowLayoutPanel2.Height - borderWidth, TuesdayflowLayoutPanel2.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, TuesdayflowLayoutPanel2.Height);

                //// Vẽ viền bên phải
                //e.Graphics.DrawRectangle(pen, TuesdayflowLayoutPanel2.Width - borderWidth, 0, borderWidth, TuesdayflowLayoutPanel2.Height);
            }
        }

        private void MondayflowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, MondayflowLayoutPanel3.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, MondayflowLayoutPanel3.Height - borderWidth, MondayflowLayoutPanel3.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, MondayflowLayoutPanel3.Height);

                //// Vẽ viền bên phải
                //e.Graphics.DrawRectangle(pen, TuesdayflowLayoutPanel2.Width - borderWidth, 0, borderWidth, TuesdayflowLayoutPanel2.Height);
            }
        }

        private void ThursdayflowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, ThursdayflowLayoutPanel5.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, ThursdayflowLayoutPanel5.Height - borderWidth, ThursdayflowLayoutPanel5.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, ThursdayflowLayoutPanel5.Height);

                //// Vẽ viền bên phải
                //e.Graphics.DrawRectangle(pen, TuesdayflowLayoutPanel2.Width - borderWidth, 0, borderWidth, TuesdayflowLayoutPanel2.Height);
            }
        }

        private void FridayflowLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, FridayflowLayoutPanel7.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, FridayflowLayoutPanel7.Height - borderWidth, FridayflowLayoutPanel7.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, FridayflowLayoutPanel7.Height);

                //// Vẽ viền bên phải
                //e.Graphics.DrawRectangle(pen, TuesdayflowLayoutPanel2.Width - borderWidth, 0, borderWidth, TuesdayflowLayoutPanel2.Height);
            }
        }

        private void SaturdayflowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, SaturdayflowLayoutPanel6.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, SaturdayflowLayoutPanel6.Height - borderWidth, SaturdayflowLayoutPanel6.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, SaturdayflowLayoutPanel6.Height);

                //// Vẽ viền bên phải
                //e.Graphics.DrawRectangle(pen, TuesdayflowLayoutPanel2.Width - borderWidth, 0, borderWidth, TuesdayflowLayoutPanel2.Height);
            }
        }

        private void SundayflowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, SundayflowLayoutPanel8.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, SundayflowLayoutPanel8.Height - borderWidth, SundayflowLayoutPanel8.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, SundayflowLayoutPanel8.Height);

                //// Vẽ viền bên phải
                e.Graphics.DrawRectangle(pen, SundayflowLayoutPanel8.Width - borderWidth, 0, borderWidth, SundayflowLayoutPanel8.Height);
            }
        }

        private void WednesdayflowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;
            Color borderColor = Color.Black;  // Màu đỏ cho viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền trên
                e.Graphics.DrawRectangle(pen, 0, 0, WednesdayflowLayoutPanel4.Width, borderWidth);

                // Vẽ viền dưới
                e.Graphics.DrawRectangle(pen, 0, WednesdayflowLayoutPanel4.Height - borderWidth, MondayflowLayoutPanel3.Width, borderWidth);

                // Vẽ viền bên trái
                e.Graphics.DrawRectangle(pen, 0, 0, borderWidth, WednesdayflowLayoutPanel4.Height);

                //// Vẽ viền bên phải
                //e.Graphics.DrawRectangle(pen, TuesdayflowLayoutPanel2.Width - borderWidth, 0, borderWidth, TuesdayflowLayoutPanel2.Height);
            }
        }

       
    }
}
