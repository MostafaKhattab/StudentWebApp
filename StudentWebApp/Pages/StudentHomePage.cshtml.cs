using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class StudentHomePageModel : PageModel
    {
        public List<Exam> exams { get; set; }
        private readonly ILogger<StudentHomePageModel> _logger;
        public int teacherid { get; set; }

        public StudentHomePageModel(ILogger<StudentHomePageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id)
        {
            teacherid = id;
            StudentServices st = new StudentServices();
            exams = st.GetExams();
            Console.WriteLine(exams);
        }
    }
}
