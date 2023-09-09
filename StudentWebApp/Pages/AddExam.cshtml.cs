using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class AddExamModel : PageModel
    {
        [BindProperty]
        public string ExamName { get; set; }
        [BindProperty]
        public int teacherid {  get; set; }
        public void OnGet(int id)
        {
            teacherid = id;
        }
        public IActionResult OnPost()
        {
            TeacherServices teacherServices = new TeacherServices();
            int examid =teacherServices.AddExam(teacherid, ExamName);
            if(examid != 0)
            {
               return Redirect("/AddQuestion/" + examid);
            }
            return Page();
        }
    }
}
