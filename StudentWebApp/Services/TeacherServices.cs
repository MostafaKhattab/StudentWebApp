using Newtonsoft.Json;
using StudentWebApp.ExamTempalte;
using StudentWebApp.UserTemplate;
using System.Data.SqlClient;
using System;
using Dapper;

namespace StudentWebApp.Services
{
    public class TeacherServices
    {
        public Teacher teach;

        public TeacherServices() { 
                teach = new Teacher();
        }    
        public int AddExam(int teachid, string examname)
        {
            int x = 0;
           // var sql = "INSERT INTO Exams (TeacherId, ExamName) VALUES (@teachId, @Examname)";

            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                x = connection.QuerySingle<int>(@"
                    INSERT INTO Exams (TeacherId, ExamName) 
                    OUTPUT INSERTED.ExamId
                    VALUES (@teachId, @Examname);", new { teachId = teachid, Examname = examname });
            }
            return x;
        }

        public int AddQuestion(string Question, int id)
        {

                var sql = "INSERT INTO Questions (question, questiontype,  ExamId) VALUES (@quest, @questtype, @examid)";
            int x = 0;
            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                 x = connection.Execute(sql, new { quest = Question, questtype = "essay", examid = id });
            }
            return x;
        }

        public int GetTeacherID(int id)
        {
            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                var sql = "SELECT TeacherId FROM Exams WHERE TeacherId = @examid";
                var s = connection.Query(sql, new { examid = id }).FirstOrDefault();
                return s;
            }
        }

        public List<Exam> GetExams(int userid)
        {

            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                var sql = "SELECT * FROM Exams WHERE TeacherId = @teachid";
                var s = connection.Query<Exam>(sql, new { teachid = userid }).ToList();
                return s;
            }
            

        }

        public List<Grade> GetAnswers(int examid)
        {
            int x = 0;
            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                
                    var sql = "SELECT * FROM Grades WHERE ExamId = @ex";

                    var s = connection.Query<Grade>(sql, new { ex = examid }).ToList();
                return s;
                
            }
        }

        public Grade GetGrade(int gradeid)
        {
            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                var sql = "SELECT * FROM Grades WHERE GradeId = @graid";

                var s = connection.Query<Grade>(sql, new { graid = gradeid }).FirstOrDefault();
                return s;
            }

        }

        public void PostGrades(int gradeId, string OAG)
        {
            var sql = "Update Grades SET OAG = @oag WHERE GradeId = @GID";
            int x = 0;
            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                x = connection.Execute(sql, new { oag = OAG, GID = gradeId});
            }
        }

        public int Signin(string email, string password)
        {
            using (var connection = new SqlConnection("postgresql://postgres:e6LRa*%Gbb_Xqay@db.pofymtwwmjfurydaqnhg.supabase.co:5432/postgres"))
            {
                var sql = "SELECT * FROM Teachers WHERE Email = @Email and password = @Password";
                object[] parameters = { new { Password = password, Email = email } };
                var s = connection.Query<Teacher>(sql, new { Password = password, Email = email }).FirstOrDefault<Teacher>();
                if (s != null)
                {
                    teach = s;
                    return teach.userId;
                }

            }

            return 0;
        }



    }
}