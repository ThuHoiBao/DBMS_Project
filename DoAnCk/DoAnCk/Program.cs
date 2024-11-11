using DoAnCk.RoleOwner;
using DoAnCk.RoleStudent;
using DoAnCk.RoleTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    internal static class Program
    {
        /// <summary>https://github.com/xdung04/QuanLiSinhVien/pull/19/conflict?name=DoAnCk%252FProgram.cs&ancestor_oid=b19ace2f379293cedcba19b39984ee2f216bab49&base_oid=119acfadda39e6c6f5765b75224abb7a6d1d5207&head_oid=35843ac9f64ea8a5a6543850a7fbd76888a4896c
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PayMoney());

        }
    }
}
