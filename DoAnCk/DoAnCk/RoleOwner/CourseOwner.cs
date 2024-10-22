using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
