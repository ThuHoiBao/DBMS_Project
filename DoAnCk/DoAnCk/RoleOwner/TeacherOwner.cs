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
    public partial class TeacherOwner : Form
    {
        MainOwner owner;
        public TeacherOwner(MainOwner owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void TeacherOwner_Load(object sender, EventArgs e)
        {

        }
    }
}
