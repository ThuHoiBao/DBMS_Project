using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCk.Login
{
    public static class Config
    {
        private static string username;
        private static string password;

        public static void SetCredentials(string user, string pass)
        {
            username = user;
            password = pass;
        }

        public static string getUsername()
        {
            return username;
        }

        public static string getPassword()
        {
            return password;
        }
    }

}
