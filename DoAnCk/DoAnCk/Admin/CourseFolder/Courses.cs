
﻿using Guna.UI2.WinForms.Suite;
﻿using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DoAnCk
{
    public class Courses
    {
        public bool InsertCourse(string courseId,int semester,
            int credit,string description,string courseName,string day, string number)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@cId",courseId),
                
                new SqlParameter("@sem",semester),
                new SqlParameter("@cred",credit),
                new SqlParameter("@des",description),
                new SqlParameter("@cName",courseName),
                new SqlParameter("@days",day),
                new SqlParameter("@num",number)
            };
            int result = Dataprovider.Instance.ExecuteNonQuery("INSERT INTO Courses (course_id,semester,credit,desciption,course_name,day,number)" +
                    " VALUES (@cId,@sem,@cred,@des,@cName,@days,@num)", parameters);
            return result > 0;

        }
        public bool UpdateCourse(string courseId,  int semester,
           int credit, string description, string courseName,string day,string number)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@cId",courseId),
             
                new SqlParameter("@sem",semester),
                new SqlParameter("@cred",credit),
                new SqlParameter("@des",description),
                new SqlParameter("@cName",courseName),
                 new SqlParameter("@days",day),
                new SqlParameter("@num",number)
            };
            int result = Dataprovider.Instance.ExecuteNonQuery("UPDATE Courses " +
                    "SET  semester=@sem,credit=@cred,desciption=@des,course_name=@cName," +
                    " day=@days,number=@num WHERE course_id = @cId", parameters);

            return result > 0;

        }
        public bool DeleteCourse(string id)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@cId",id),

               
            };
            string querry = "DELETE FROM Courses WHERE course_id = @cId ";

            int check = Dataprovider.Instance.ExecuteNonQuery("DELETE FROM Courses WHERE course_id = @cId ",parameters);
            return check > 0;


        }
        public DataTable SelectFullCourse(string CourseId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cId", CourseId),
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT * FROM Courses WHERE course_id=@cId", parameters);
            return dt;
        }
        
        public bool UpdateTeacherCourse( string courseId,string teacherId)
        {
           
            SqlParameter[] parameters =
            {
               
               new SqlParameter("@cid",courseId),
               new SqlParameter("@tid",teacherId)
            };
            int result = Dataprovider.Instance.ExecuteNonQuery("Update Courses " +
                " Set teacher_id = @tid where course_id=@tid ", parameters);
            return result > 0;
        }
        public DataTable SelectSemesterCourse()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT DISTINCT semester FROM Courses ORDER BY semester ASC", parameters);
            return dt;
        }
        public DataTable SelectSemester(int semester)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sem",semester)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("select * from Assigns a,Courses c where  a.course_id=c.course_id and C.semester=@sem", parameters);
            return dt;
        }

        public DataTable GetSemesterAndSelect(int semester, int idTecher)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sem",semester),
                new SqlParameter("@uac",idTecher)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Assigns.teacher_id, Users.user_id,Users.account,Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                   "FROM  Users " +
                                   "INNER JOIN Assigns ON Users.user_id = Assigns.teacher_id " +
                                   "INNER JOIN Courses ON Assigns.course_id = Courses.course_id " +
                                   "WHERE Assigns.teacher_id = @uac AND Courses.semester = @sem"
                                    , parameters);
            return dt;
        }
        public DataTable GetSemesterAndSelectStudent(int semester, int idStudent)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@sid",idStudent),
                new SqlParameter("@sem",semester)
               
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Enrollments.student_id, Users.user_id,Users.account,Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                   "FROM  Users " +
                                   "INNER JOIN Enrollments ON Users.user_id = Enrollments.student_id " +
                                   "INNER JOIN Courses ON Enrollments.course_id = Courses.course_id " +
                                   "WHERE Enrollments.student_id = @sid AND Courses.semester = @sem"
                                    , parameters);
            return dt;
        }
        public DataTable GetSelect(int idteacher)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                
                new SqlParameter("@uac",idteacher)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Assigns.teacher_id, Users.user_id,Users.account,Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                   "FROM  Users " +
                                   "INNER JOIN Assigns ON Users.user_id = Assigns.teacher_id " +
                                   "INNER JOIN Courses ON Assigns.course_id = Courses.course_id " +
                                   "WHERE Assigns.teacher_id = @uac"
                                    , parameters);
            return dt;
        }
        public DataTable GetSelectStudent(int idStudent)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@sid",idStudent)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Enrollments.student_id, Users.user_id,Users.account,Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                     "FROM  Users " +
                                     "INNER JOIN Enrollments ON Users.user_id = Enrollments.student_id " +
                                     "INNER JOIN Courses ON Enrollments.course_id = Courses.course_id " +
                                     "WHERE Enrollments.student_id = @sid"
                                      , parameters);
            return dt;
        }
        public DataTable GetFindCourse( string text)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@txt",text)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery(
                "select * From  Courses where CONCAT(course_id, course_name, day) LIKE '%' + @txt + '%'", parameters);
            return dt;
        }
        public DataTable GetSelectPrintf(int idteacher)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@id",idteacher)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT DISTINCT c.course_id ,c.course_name , u.user_name,c.day,c.number " +
                " FROM Users u,Courses c,Enrollments e,Assigns a Where a.teacher_id = @id  and e.course_id = c.course_id and u.user_id = a.teacher_id and a.course_id = c.course_id"
                                    , parameters);
            return dt;
        }
        public DataTable GetSelectPrintfStudent(int idStudent)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@id",idStudent),
               
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT DISTINCT c.course_id ,c.course_name , u.user_name,c.day,c.number " +
                " FROM Users u,Courses c,Enrollments e,Assigns a Where e.student_id = @id  and e.course_id = c.course_id and u.user_id = a.teacher_id and a.course_id = c.course_id"
                                      , parameters);
            return dt;
        }
        public DataTable GetSelectPrintfSemester(int idteacher,int semester)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@uac",idteacher),
                new SqlParameter("@sem",semester)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                   "FROM  Users " +
                                   "INNER JOIN Assigns ON Users.user_id = Assigns.teacher_id " +
                                   "INNER JOIN Courses ON Assigns.course_id = Courses.course_id " +
                                   "WHERE Assigns.teacher_id = @uac AND semester=@sem"
                                    , parameters);
            return dt;
        }
        public DataTable GetSelectPrintfSemesterStudent(int idStudent,int semester)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@sid",idStudent),
                new SqlParameter("@sem",semester)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                     "FROM  Users " +
                                     "INNER JOIN Enrollments ON Users.user_id = Enrollments.student_id " +
                                     "INNER JOIN Courses ON Enrollments.course_id = Courses.course_id " +
                                     "WHERE Enrollments.student_id = @sid AND semester=@sem "
                                      , parameters);
            return dt;
        }
        public DataTable GetTimetable(int idStudent, int semester)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@sid",idStudent),
                new SqlParameter("@sem",semester)
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT Users.user_name,Courses.course_id,Courses.course_name,Courses.day,Courses.Number  " +
                                     "FROM  Users " +
                                     "INNER JOIN Enrollments ON Users.user_id = Enrollments.student_id " +
                                     "INNER JOIN Courses ON Enrollments.course_id = Courses.course_id " +
                                   
                                     "WHERE Enrollments.student_id = @sid AND semester=@sem "
                                      , parameters);
            return dt;
        }
        public DataTable GetNameTeacherCourse(int idTe)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@sid",idTe),
               
            };
            DataTable dt = Dataprovider.Instance.ExecuteQuery("SELECT User.user_name " +
                                     "FROM  Users " +
                                     "INNER JOIN  ON Users.user_id = Enrollments.student_id " +
                                     "INNER JOIN Courses ON Enrollments.course_id = Courses.course_id " +
                                     "WHERE Enrollments.student_id = @sid AND semester=@sem "
                                      , parameters);
            return dt;
        }

        public DataTable ResultByCourse(string Cid)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cid",Cid)
            };
            string query = "SELECT U.user_id AS Id, U.user_name AS Name, AVG(CAST(ISNULL(SC.score, 0) AS float)) AS AVG  FROM Users U JOIN Enrollments E ON U.user_id = E.student_id AND E.course_id = @cid LEFT JOIN Documents D ON E.course_id = D.course_id LEFT JOIN Scores SC ON U.user_id = SC.student_id AND D.document_id = SC.document_id GROUP BY U.user_id, U.user_name, D.course_id";
            return Dataprovider.Instance.ExecuteQuery(query, parameters);
        }

        public DataTable DetailResultByCourse(string cid, int stid)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", stid),
                new SqlParameter("@courseId", cid)
            };
            string query = "SELECT DISTINCT D.document_name, Sc.score AS score FROM Documents D LEFT JOIN Submissions S ON S.document_id = D.document_id LEFT JOIN Scores Sc ON Sc.document_id = D.document_id AND Sc.student_id = @userId WHERE D.course_id = @courseId";
            return Dataprovider.Instance.ExecuteQuery(query, parameters);
        }

        public DataTable LoadCourseForTeacher()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tid",Global.GlobalId)
            };
            string query = "SELECT c.course_id,c.course_name FROM Courses c,Assigns a WHERE a.teacher_id = @tid AND a.course_id = c.course_id";
            return Dataprovider.Instance.ExecuteQuery(query, parameters);
        }


    }
}
