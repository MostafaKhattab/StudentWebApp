using StudentWebApp.ExamTempalte;

namespace StudentWebApp.UserTemplate
{
    public class Teacher : User
    {
        public Exam[] exams {  get; set; }

        public Teacher() { 
        }
        public Teacher(string email, string password, string username, string usertype, int userId) : base(email, password, username, usertype, userId)
        {
        }
    }
}
