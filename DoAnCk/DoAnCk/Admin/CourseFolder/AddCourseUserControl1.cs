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
    public partial class AddCourseUserControl1 : UserControl
    {
        public AddCourseUserControl1()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
        public event EventHandler CourseAdded;
        private void btnCourseAdd_Click(object sender, EventArgs e)
        {
            CourseAdded?.Invoke(this, EventArgs.Empty);
        }

        private void AddCourseUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
