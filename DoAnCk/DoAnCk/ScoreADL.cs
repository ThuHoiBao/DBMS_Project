using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCk
{
    public class ScoreADL
    {
        public bool insert(int student_id, string subid, int score ,string decript)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@stid", student_id),
                new SqlParameter("@subid", subid),
                new SqlParameter("@sc",score),
                new SqlParameter("@decript",decript),
            };
            string query = "INSERT INTO Scores VALUES(@stid,@subid,@sc,@decript)";
            try
            {
                int result = Dataprovider.Instance.ExecuteNonQuery(query, sqlParameters);
                return result > 0;
            }
            catch
            {
                return false;
            }

        }

        public bool Update(int student_id, string subid, int score, string decript)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@stid", student_id),
                new SqlParameter("@subid", subid),
                new SqlParameter("@sc",score),
                new SqlParameter("@decript",decript),
            };
            string query = "UPDATE Scores SET score = @sc, decription = @decript where student_id = @stid and document_id = @subid";
            try
            {
                int result = Dataprovider.Instance.ExecuteNonQuery(query, sqlParameters);
                return result > 0;
            }
            catch
            {
                return false;
            
            }
        }

        public DataTable GetScore(int studentId, string  documentid)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@stid", studentId),
                new SqlParameter("@did", documentid)
            };
            return Dataprovider.Instance.ExecuteQuery("SELECT score from scores where student_id = @stid and document_id = @did", sqlParameters);
        }
    }
}
