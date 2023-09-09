using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.ExamTempalte;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class AnswerQuestionModel : PageModel
    {
        public List<Question> questions {  get; set; }
        [BindProperty]
        public int examid { get; set; }
        private readonly ILogger<AnswerQuestionModel> _logger;
        [BindProperty]
        public List<string> answer { get; set; }
        [BindProperty]
        public int studentid { get; set; }

        public AnswerQuestionModel(ILogger<AnswerQuestionModel> logger)
        {
            _logger = logger;
        }





        public void OnGet(int id,int userid)
        {
       
            examid = id;
            studentid = userid;
            StudentServices studentServices = new StudentServices();
            questions = studentServices.GetQuestions(examid);
        }

        public IActionResult OnPost() {

            StudentServices studentServices = new StudentServices();
            studentServices.PostAnswers(answer,examid, studentid);
            return Redirect("/StudentHomePage/" + studentid);
        }
    }
}
