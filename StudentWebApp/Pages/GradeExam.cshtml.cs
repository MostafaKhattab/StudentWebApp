using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class GradeExamModel : PageModel
    {   
        public List<Grade> grades { get; set; }
        public GradeExamModel() { }
        public void OnGet(int id)
        {
            TeacherServices teacherServices = new TeacherServices();
            grades =teacherServices.GetAnswers(id);

        }
    }
}
