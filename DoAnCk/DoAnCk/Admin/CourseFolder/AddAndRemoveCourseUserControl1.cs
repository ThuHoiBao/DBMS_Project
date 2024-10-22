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
    public partial class AddAndRemoveCourseUserControl1 : UserControl
    {
        public AddAndRemoveCourseUserControl1()
        {
            InitializeComponent();
        }
       
        public event EventHandler RemoveCourse;
        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            RemoveCourse?.Invoke(this, EventArgs.Empty);
        }

        private void btnCourseAdd_Click(object sender, EventArgs e)
        {

        }
        
        private void lblCourseId_Click(object sender, EventArgs e)
        {

        }

        private void AddAndRemoveCourseUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
