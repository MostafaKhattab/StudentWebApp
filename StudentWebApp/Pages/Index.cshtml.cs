using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentWebApp.Services;

namespace StudentWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password{ get; set; }
        [BindProperty]
        public bool isteacher { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(isteacher + Email);
            
            if (isteacher)
            {
                TeacherServices SS = new TeacherServices();
                if (SS.Signin(Email, Password) != 0)
                {
                    return Redirect("TeacherHomePage/"+SS.teach.userId);
                }
            }
            else
            {
                StudentServices SS = new StudentServices();
                if (await SS.SigninAsync(Email, Password) == true)
                {
                    return Redirect("StudentHomePage/"+SS.stud.userId);
                }
            }
            return Page();
        }


    }
}