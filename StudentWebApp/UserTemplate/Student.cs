using StudentWebApp.ExamTempalte;
using System.Diagnostics;

namespace StudentWebApp.UserTemplate
{
    public class Student:User
    {
        public Grade[]? Grades { get; set; }
        public Student(string email, string password, string username, string usertype, int userId) : base(email, password, username, usertype, userId)
        {
            this.Email = email;
            this.password = password;
            this.username = username;
            this.usertype = usertype;
            this.userId = userId;
        }

        public Student()
        {

        }
    }
}
