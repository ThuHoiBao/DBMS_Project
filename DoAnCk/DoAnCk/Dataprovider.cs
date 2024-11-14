using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnCk.Login;


namespace DoAnCk
{
    public class Dataprovider
    {
        private string connectionString;

        private static Dataprovider instance = new Dataprovider();
        public static Dataprovider Instance
        {
            get { if (instance == null) instance = new Dataprovider(); return Dataprovider.instance; }
            private set { Dataprovider.instance = value; }
        }

        private Dataprovider() { }

        public void SetConnectionStringByRole(int userType)
        {
            if (userType == 1) // Administrator
            {
                connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=EnglishCourse_DataBase;Integrated Security=True;";
            }
            else if (userType == 2) // Teacher
            {
                connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=EnglishCourse_DataBase;User Id=" + Config.getUsername() + ";Password=" + Config.getPassword() + ";";
            }
            else if (userType == 3) // Student
            {
                connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=EnglishCourse_DataBase;User Id=" + Config.getUsername() + ";Password=" + Config.getPassword() + ";";
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("ConnectionString has not been initialized. Please call SetConnectionStringByRole first.");
            }

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }


        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Thêm tham số vào SqlCommand
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}
