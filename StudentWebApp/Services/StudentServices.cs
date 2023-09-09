using Dapper;
using StudentWebApp.ExamTempalte;
using StudentWebApp.UserTemplate;
using System.Data.SqlClient;

namespace StudentWebApp.Services
{
    public class StudentServices
    {
        public Student stud;

        public StudentServices() { 
        stud = new Student();
        }

        public bool Signin(string email, string password)
        {
            using (var connection = new SqlConnection("UserId=postgres;Password=e6LRa*%Gbb_Xqay;Server=db.pofymtwwmjfurydaqnhg.supabase.co;Port=5432;Database=postgres"))
            {
                var sql = "SELECT * FROM Students WHERE Email = @Email and password = @Password" ;
                object[] parameters = { new { Password = password, Email = email } };
                var s = connection.Query<Student>(sql,new { Password = password, Email = email } ).FirstOrDefault<Student>();
                if(s != null)
                {
                    stud = s;
                    return true;
                }
                
            }

            return false;
        }

        public List<Exam> GetExams()
        {
            /*string temp = "(";
            for(int i = 0; i < examtaken.Length; i++) { 
                temp += examtaken[i];
                if(i++ != examtaken.Length)
                {
                    temp += ",";
                }
            }
            temp += ")";*/
            using (var connection = new SqlConnection("UserId=postgres;Password=e6LRa*%Gbb_Xqay;Server=db.pofymtwwmjfurydaqnhg.supabase.co;Port=5432;Database=postgres"))
            {
                var sql = "SELECT * FROM Exams";
                var s = connection.Query<Exam>(sql).ToList();
                return s;
            }
            

        }

        public List<Question> GetQuestions(int examid)
        {
            /*string temp = "(";
            for(int i = 0; i < examtaken.Length; i++) { 
                temp += examtaken[i];
                if(i++ != examtaken.Length)
                {
                    temp += ",";
                }
            }
            temp += ")";*/
            using (var connection = new SqlConnection("UserId=postgres;Password=e6LRa*%Gbb_Xqay;Server=db.pofymtwwmjfurydaqnhg.supabase.co;Port=5432;Database=postgres"))
            {
                var sql = "SELECT * FROM Questions WHERE ExamId = @examid ";
                var s = connection.Query<Question>(sql, new { examid = examid }).ToList();
                return s;
            }


        }


        public List<Grade> GetGrades(int userid)
        {
            using (var connection = new SqlConnection("UserId=postgres;Password=e6LRa*%Gbb_Xqay;Server=db.pofymtwwmjfurydaqnhg.supabase.co;Port=5432;Database=postgres"))
            {
                var sql = "SELECT * FROM Grades WHERE StudentId = @studentid";

                var s = connection.Query<Grade>(sql, new { studentid = userid}).ToList();
                return s;
            }

        }




        public bool PostAnswers(List<string> answers, int testid, int stuid )
        {
            string Ans = "";
            int x=0;
            foreach(string ans in answers)
            {
                Ans += ans+ "=";
            }
            var sql = "INSERT INTO Grades (ExamId, StudentId,Answers) VALUES (@examid,@studid,@answ)";

            using (var connection = new SqlConnection("UserId=postgres;Password=e6LRa*%Gbb_Xqay;Server=db.pofymtwwmjfurydaqnhg.supabase.co;Port=5432;Database=postgres"))
            {
               x = connection.Execute(sql, new { examid = testid, studid = stuid, answ = Ans });
            }

            if (x != 0)
            {
                return true;
            }
            return false;


        }


    }
}
