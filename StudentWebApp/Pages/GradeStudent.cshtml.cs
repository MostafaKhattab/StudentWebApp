using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class GradeStudentModel : PageModel
    {

        public Grade grade;
        [BindProperty]
        public double OAG { get; set; } 
        public string[] answers {get; set;}
        [BindProperty]
        public int GradeId { get; set;}
        [BindProperty]
        public int ExamId { get; set; }
        public void OnGet(int id)
        {
            TeacherServices  ts=  new TeacherServices();
            grade = ts.GetGrade(id);
            answers = grade.Answers.Split(new char[] { '=' });
        }

        public IActionResult OnPost()
        {
            string lettergrade = "";
            if (OAG > 90)
            {
                lettergrade = "A";
            }
            else if (OAG > 80)
            {
                lettergrade = "B";
            }
            else if (OAG > 70)
            {
                lettergrade = "C";
            }
            else if (OAG > 50)
            {
                lettergrade = "D";
            }
            else
            {
                lettergrade = "F";
            }
            TeacherServices teacherServices = new TeacherServices();
            teacherServices.PostGrades(GradeId,lettergrade);
            return Redirect("/GradeExam/" + ExamId);
        }
    }
}
