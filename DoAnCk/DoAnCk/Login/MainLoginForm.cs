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
    public partial class MainLoginForm : Form
    {
        public MainLoginForm()
        {
            InitializeComponent();
        }
        
        Form currentForm=null;
        private void panelControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

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
            panelControl.Controls.Add(f);
            f.BringToFront(); // Đưa form mới lên trên cùng
            f.Size = panelControl.Size;
            f.Show();
        }
        public void OpenFormForOther(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = form;
            form.TopLevel = false;

            panelControl.Controls.Add(form);
            form.Show();
        }


        public void MainLoginForm_Load(object sender, EventArgs e)
        {
            OpenForm(new LoginForm(this));
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
