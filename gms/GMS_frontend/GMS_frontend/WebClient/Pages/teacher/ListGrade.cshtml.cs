using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableSystem.Services;
using WebClient.DTO.Grade;
using WebClient.DTO.Session;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.teacher
{
    public class ListGradeModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListGradeModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public List<GetGradeDTO> ListGrade { get; set; }
        public int SessionId { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public IActionResult OnGet(int sessionId,  string className, string courseName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsTeacher(user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                ListGrade = GradeService.GetGradesBySessionGradedByTeacher(sessionId); ;
            }
            catch (Exception)
            {

                return RedirectToPage("/SeverError");
            }

            SessionId = sessionId;
            ClassName = className;
            CourseName = courseName;

            return Page();
        }
    }
}
