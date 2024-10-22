using DoAnCk.RoleTeacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk.RoleStudent
{
    public partial class Main : Form
    {
        Form currentForm = null;
        public Main()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Course courseForm = new Course(this);
            OpenForm(courseForm);
        }
        public void OpenForm(Form f)
        {
            // Xóa tất cả các controls hiện tại trên panelHome để tránh chồng chéo

            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = f;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill; // Đảm bảo form mới sẽ chiếm toàn bộ không gian của panel
            panelHome.Controls.Add(f);
            f.BringToFront(); // Đưa form mới lên trên cùng
            f.Size = panelHome.Size;
            f.Show();
        }
        public void OpenFormForOther(Form f)
        {
            if (currentForm != null)
            {
                currentForm.Hide();
            }
            currentForm = f;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelHome.Controls.Add(f);
            f.BringToFront();
            f.Size = panelHome.Size;
            f.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
