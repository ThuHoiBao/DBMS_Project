using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    public class User
    {
        public bool InsertAccount( int accept,string userName, DateTime bdate, MemoryStream pictute, 
            string account, string pass, string email,string address, int userType)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@acept",accept),
                new SqlParameter("@usn", userName),
                new SqlParameter("@bd", bdate),
                new SqlParameter("@pic", pictute.ToArray()),
                new SqlParameter("@ac", account),
                new SqlParameter("@pas", pass),
                new SqlParameter ("@em", email),
                new SqlParameter("@adr", address),
                new SqlParameter("@ust",userType)
            };
            int result = Dataprovider.Instance.ExecuteNonQuery("INSERT INTO Users (accept,user_name,birth_date,avartar,account,password,email,address,user_type)" +
                    " VALUES (@acept,@usn, @bd, @pic, @ac, @pas,@em, @adr, @ust)", parameters);
                return result > 0;         
        }
        public bool UpdateAccount(int id, int accept, string userName, DateTime bdate, MemoryStream pictute,
         string account, string pass, string email, string address)
        {
                SqlParameter[] parameters =
                {
             new SqlParameter ( "@id", id ),
             new SqlParameter("@acept",accept),
             new SqlParameter("@usn", userName),
             new SqlParameter("@bd", bdate),
             new SqlParameter("@pic", pictute.ToArray()),
             new SqlParameter("@ac", account),
             new SqlParameter("@pas", pass),
             new SqlParameter ("@em", email),
             new SqlParameter("@adr", address),
         };
            int result = Dataprovider.Instance.ExecuteNonQuery("Update Users " +
                " Set accept = @acept,birth_date=@bd,avartar=@pic,account=@ac,password=@pas,email=@em,address=@adr,user_name=@usn where user_id=@id ", parameters);
            return result > 0;
        }
        
        public bool UpdateAccept(int accept,string user_account)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@acept",accept),
               new SqlParameter("@ac",user_account)
            };
            int result = Dataprovider.Instance.ExecuteNonQuery("Update Users " +
                " Set accept = @acept where account=@ac ", parameters);
            return result > 0;
        }
        public bool UpdatePassWord(string passWord,string user_account)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@pw",passWord),
               new SqlParameter("@ac",user_account)
            };
            int result = Dataprovider.Instance.ExecuteNonQuery("Update Users " +
                " Set password = @pw where account=@ac ", parameters);
            return result > 0;
        }
        public DataTable SelectIdAcount(string userAccount)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@uac", userAccount),
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT * FROM Users WHERE account=@uac", parameters);
            return dt;
        }
        public DataTable GetIdCourse(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@uid", id),
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT * FROM Users WHERE user_id=@uid", parameters);
            return dt;
        }
        public bool RemoveAccount(int id)
        {
            string querry = "DELETE FROM std WHERE Id =" + id;
            try
            {
                int check = Dataprovider.Instance.ExecuteNonQuery(querry);
                if (check > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thông Báo!", MessageBoxButtons.OK);
                    return true;
                }
                else
                {
                    MessageBox.Show("Id không hợp lệ", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool DeleteAccount(int id)
        {
            string querry = "DELETE FROM Users WHERE user_id =" + id;
            
                int check = Dataprovider.Instance.ExecuteNonQuery(querry);
                return check > 0;

            
        }
        public DataTable GetFindUser(string text)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@txt",text)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery(
                "select * From  Users where CONCAT(account, user_name) LIKE '%' + @txt + '%'", parameters);
            return dt;
        }

    }
}
