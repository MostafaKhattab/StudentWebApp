using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class AddQuestionModel : PageModel
    {
        [BindProperty]
        public int Examid {  get; set; }
        [BindProperty]
        public string question { get; set; }

        public int teacherid { get; set; }
        public void OnGet(int id)
        {
            Examid = id;
            TeacherServices teacherServices = new TeacherServices();
            teacherid = teacherServices.GetTeacherID(Examid);
        }
        public IActionResult OnPost()
        {
            TeacherServices teacherServices = new TeacherServices();
            teacherServices.AddQuestion(question, Examid);
            return Redirect("/AddQuestion/" + Examid);

        }
    }
}
