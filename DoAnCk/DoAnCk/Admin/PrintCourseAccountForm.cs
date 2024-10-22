using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingFont = System.Drawing.Font;
using ITextSharpFont = iTextSharp.text.Font;

namespace DoAnCk
{
    public partial class PrintCourseAccountForm : Form
    {
        DataTable dt1=new DataTable();
        
        int id;

        public PrintCourseAccountForm( DataTable dt, int id)
        {
            InitializeComponent();
            dt1 = dt;
            this.id = id;
            
        }
        Courses courses = new Courses();
        User user = new User();
        private void PrintCourseAccountForm_Load(object sender, EventArgs e)
        {
            LoadInfo();
            DataTable semesters = courses.SelectSemesterCourse();

            // Kiểm tra nếu danh sách không trống
           
            string userAccount = lblUserAccount.Text;
            DataTable dt = user.SelectIdAcount(userAccount);
            int idTecher = Convert.ToInt32(dt.Rows[0]["user_id"]);
            // Đảm bảo rằng DataGridView không bị che khuất bởi các controls khác



            DataGridView1.DataSource = dt1;
            AdjustDataGridViewColumns();
            
        }
        public void LoadInfo()
        {

            DataTable dt1 = user.GetIdCourse(id);

            lblUserAccount.Text = dt1.Rows[0]["account"].ToString();
            lblUserName.Text = dt1.Rows[0]["user_name"].ToString();
            byte[] pic = (byte[])dt1.Rows[0]["avartar"];
            MemoryStream picture = new MemoryStream(pic);
            System.Drawing.Image.FromStream(picture);
        }
        private void AdjustDataGridViewColumns()
        {
            // Đảm bảo các cột đã được tạo
            DataGridView1.AutoGenerateColumns = true;

            // Thay đổi tên cột
            DataGridView1.Columns["course_id"].HeaderText = "Mã Khóa Học";
            DataGridView1.Columns["course_name"].HeaderText = "Tên Khóa Học";
            DataGridView1.Columns["day"].HeaderText = "Thứ";
            DataGridView1.Columns["Number"].HeaderText = "Tiết Học";

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "courseList";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                            PdfWriter.GetInstance(document, fileStream);
                            document.Open();

                            // Thêm logo và tiêu đề trường học
                            PdfPTable table = new PdfPTable(2);
                            table.WidthPercentage = 100;

                            float[] columnWidth = { 1f, 3f };
                            table.SetWidths(columnWidth);

                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(@"D:\a.1WinformThayThinh\tải xuống.jpg");
                            logo.ScaleAbsolute(100f, 100f);

                            PdfPCell imageCell = new PdfPCell(logo);
                            imageCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            table.AddCell(imageCell);

                            ITextSharpFont font2 = new ITextSharpFont(ITextSharpFont.FontFamily.HELVETICA, 30f, ITextSharpFont.BOLD, BaseColor.RED);
                            Paragraph title1 = new Paragraph(new Phrase("Ho Chi Minh University of Technology and Education", font2));
                            PdfPCell textCell = new PdfPCell(title1);
                            textCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            textCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            table.AddCell(textCell);

                            title1.SpacingBefore = 10f;
                            title1.SpacingAfter = 20;

                            document.Add(table);

                            // Tiếp tục thêm phần danh sách các khóa học
                            BaseFont robotoBaseFont = BaseFont.CreateFont(@"D:\a.1WinformThayThinh\Roboto (1)\Roboto-Regular.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            ITextSharpFont font = new ITextSharpFont(robotoBaseFont, 10f, ITextSharpFont.NORMAL, BaseColor.BLACK);
                            ITextSharpFont font1 = new ITextSharpFont(robotoBaseFont, 20f, ITextSharpFont.BOLD, BaseColor.BLUE);
                            ITextSharpFont fontLblUseName = new ITextSharpFont(robotoBaseFont, 15f, ITextSharpFont.BOLD, BaseColor.BLACK);
                            Paragraph hoTen2 = new Paragraph("Mã số: " + lblUserAccount.Text, fontLblUseName);
                            hoTen2.Alignment = Element.ALIGN_LEFT;
                            hoTen2.SpacingBefore = 30f;
                            hoTen2.SpacingAfter = 10f;
                            document.Add(hoTen2);
                            Paragraph hoTen1 = new Paragraph("Họ và tên: " + lblUserName.Text, fontLblUseName);
                            hoTen1.Alignment = Element.ALIGN_LEFT;
                            hoTen1.SpacingBefore = 0f;
                            hoTen1.SpacingAfter = 10f;
                            document.Add(hoTen1);
                            Paragraph hoTen3 = new Paragraph("Học kỳ: " + lblSemester.Text, fontLblUseName);
                            hoTen3.Alignment = Element.ALIGN_LEFT;
                            hoTen3.SpacingBefore = 0f;
                            hoTen3.SpacingAfter = 10f;
                            document.Add(hoTen3);


                            Paragraph title = new Paragraph("DANH SÁCH CÁC KHÓA HỌC", font1);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.SpacingBefore = 20f;
                            title.SpacingAfter = 40f;
                            document.Add(title);
                            //Ma va ten tai khoan duoi title va ben goc phai
                            //Paragraph sign1 = new Paragraph("        ", font);
                            //sign1.Alignment = Element.ALIGN_LEFT;
                            //sign1.SpacingBefore = 20f;
                            //sign1.SpacingAfter = 40f;
                            //document.Add(sign1);
                            //lblUserName
                            
                            
                            PdfPTable pTable = new PdfPTable(DataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 80;
                            pTable.HorizontalAlignment = Element.ALIGN_CENTER;

                            float[] columnWidths = new float[DataGridView1.Columns.Count];
                            float equalWidth = 100f / DataGridView1.Columns.Count;
                            for (int i = 0; i < DataGridView1.Columns.Count; i++)
                            {
                                columnWidths[i] = equalWidth;
                            }
                            pTable.SetWidths(columnWidths);

                            foreach (DataGridViewColumn col in DataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, font));
                                pCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
                                pCell.Padding = 5;
                                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow viewRow in DataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in viewRow.Cells)
                                {
                                    PdfPCell contentCell = new PdfPCell(new Phrase(cell.Value?.ToString(), font));
                                    contentCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    pTable.AddCell(contentCell);
                                }
                            }

                            document.Add(pTable);
                            DateTime date = DateTime.Now;
                            Paragraph ending = new Paragraph($"Tp.HCM, ngày {date.ToString("dd")} tháng {date.ToString("MM")} năm {date.ToString("yyyy")}", font);

                            ending.Alignment = Element.ALIGN_RIGHT;
                            ending.SpacingBefore = 20f;
                            document.Add(ending);

                            Paragraph sign = new Paragraph("        ", font);
                            sign.Alignment = Element.ALIGN_RIGHT;
                            sign.SpacingBefore = 7f;
                            document.Add(sign);
                            //lblUserName

                            Paragraph hoTen = new Paragraph(lblUserName.Text, fontLblUseName);
                            hoTen.Alignment = Element.ALIGN_RIGHT;
                            document.Add(hoTen);

                            document.Close();
                        }
                        MessageBox.Show("Data Printed Successfully", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error While Exporting Data: " + ex.Message, "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }


        }

        private void ComboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string userAccount = lblUserAccount.Text;
            //DataTable dta = user.SelectIdAcount(userAccount);
            //int idTecher = Convert.ToInt32(dta.Rows[0]["user_id"]);
           
            
            //if (ComboBoxAccountType.SelectedItem != null && int.TryParse(ComboBoxAccountType.Text, out int semester))
            //{
            //    // Nếu chuyển đổi thành công và ComboBox có giá trị hợp lệ
            //    DataTable dt1 = new DataTable();
            //    dt1 = courses.GetSelectPrintfSemester( idTecher,semester);
            //    DataGridView1.DataSource = dt1;
            //}
            //else
            //{
            //    // Nếu ComboBox không chứa giá trị hợp lệ hoặc là null, hiển thị tất cả khóa học
            //    DataTable dt2 = new DataTable();
            //    dt2 = courses.GetSelectPrintf(idTecher);
            //    DataGridView1.DataSource= dt2;
            //}
        }

        
    }
}
    

