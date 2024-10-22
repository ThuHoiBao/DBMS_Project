using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    public class Assigns
    {
        public bool InsertAssign(int idTecher, string idCourse)
        {
            SqlParameter[] parameters =
            {

                new SqlParameter("@cid",idCourse),
                new SqlParameter("@tid",idTecher),

            };
            try
            {
            int result = Dataprovider.Instance.ExecuteNonQuery("INSERT INTO Assigns (course_id,teacher_id)" +
                    " VALUES (@cid,@tid)", parameters);
                 return result > 0;
            }
             catch (Exception ex)
            {
                    return false;
            }
        }
        public DataTable GetCheckCourse(string courseId, int teacherId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@cid",courseId),
                new SqlParameter("@tid",teacherId)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery(
               "select * from Assigns Where course_id=@cid AND teacher_id=@tid", parameters);
            return dt;
        }
        public bool RemoveCourseRigister(string courseId, int teacherId)
        {
            SqlParameter[] parameters =
            {

                new SqlParameter("@cid",courseId),
                new SqlParameter("@tid",teacherId),

            };
            //try
            //{
                int result = Dataprovider.Instance.ExecuteNonQuery("DELETE From Assigns" +
                    " where course_id=@cid AND teacher_id=@tid ", parameters);
                return result > 0;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public bool RemoveCourse(string courseId)
        {
            SqlParameter[] parameters =
            {

                new SqlParameter("@cid",courseId),
               

            };
            //try
            //{
            int result = Dataprovider.Instance.ExecuteNonQuery("DELETE From Assigns" +
                " where course_id=@cid ", parameters);
            return result > 0;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public bool HasAssign(string courseId)
        {
            SqlParameter[] parameters =
            {
                  new SqlParameter("@cid", courseId)
            };

            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT COUNT(*) FROM Assigns WHERE course_id = @cid", parameters);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            return count > 0;
        }

    }

}
