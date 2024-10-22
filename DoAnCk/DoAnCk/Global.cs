using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCk
{
    public static class Global
    {
        private static int globalId;
        public static int GlobalId { get => globalId; set => globalId = value; }

        public static void GetGlobalId(int id)
        {
            GlobalId = id;
        }
    }
}
