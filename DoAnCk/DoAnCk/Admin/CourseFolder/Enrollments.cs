using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCk.Admin.CourseFolder
{
    public class Enrollments
    {
        public bool InsertErollments(int idStudent, string idCourse)
        {
            SqlParameter[] parameters =
            {

                new SqlParameter("@cid",idCourse),
                new SqlParameter("@sid",idStudent),

            };
            try
            {
                int result = Dataprovider.Instance.ExecuteNonQuery("INSERT INTO Enrollments (course_id,student_id)" +
                        " VALUES (@cid,@sid)", parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable GetCheckCourse(string courseId, int studentId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@cid",courseId),
                new SqlParameter("@sid",studentId)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery(
               "select * from Enrollments Where course_id=@cid AND student_id=@sid", parameters);
            return dt;
        }
        public bool RemoveCourseRigister(string courseId, int studentId)
        {
            SqlParameter[] parameters =
            {

                new SqlParameter("@cid",courseId),
                new SqlParameter("@sid",studentId),

            };
            //try
            //{
            int result = Dataprovider.Instance.ExecuteNonQuery("DELETE From Enrollments " +
                " where course_id=@cid AND student_id=@sid ", parameters);
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
            int result = Dataprovider.Instance.ExecuteNonQuery("DELETE From Enrollments " +
                " where course_id=@cid  ", parameters);
            return result > 0;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public bool HasEnrollments(string courseId)
        {
            SqlParameter[] parameters =
            {
                  new SqlParameter("@cid", courseId)
            };

            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT COUNT(*) FROM Enrollments WHERE course_id = @cid", parameters);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            return count > 0;
        }
        //select * from Assigns a,Courses c where  a.course_id=c.course_id
    }
}
