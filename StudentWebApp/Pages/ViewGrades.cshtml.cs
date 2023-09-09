using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class ViewGradesModel : PageModel
    {
        public List<Grade> exams { get; set; }
        private readonly ILogger<ViewGradesModel> _logger;
        public int teacherid { get; set; }

        public ViewGradesModel(ILogger<ViewGradesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id)
        {
            teacherid = id;
            StudentServices st = new StudentServices();
            exams = st.GetGrades(id);
            Console.WriteLine(exams);
        }
    }
}
