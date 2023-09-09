using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class TeacherHomePageModel : PageModel
    {
        public List<Exam> exams { get; set; }
        private readonly ILogger<TeacherHomePageModel> _logger;
        public int teacherid { get; set; }

        public TeacherHomePageModel(ILogger<TeacherHomePageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id)
        {
            teacherid = id;
            TeacherServices teacherServices = new TeacherServices();
            exams = teacherServices.GetExams(id);
            Console.WriteLine(exams);
        }
    }
}