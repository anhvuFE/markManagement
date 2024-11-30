using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using TimetableSystem.Services;
using WebClient.DTO.Grade;
using WebClient.DTO.StudentGrade;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.teacher
{
    public class ViewGradeModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ViewGradeModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<GetUserDTO> ListStudent { get; set; }
        public List<GetGradeDTO> ListGrade { get; set; }
        public string[][] GradeTable { get; set; }
        public int SessionId { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public async Task<IActionResult>  OnGet(int sessionId, string className, string courseName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsTeacher(user))
            {
                return Redirect("/AccessDenied");
            }

            SessionId = sessionId;
            ClassName = className;
            CourseName = courseName;

            try
            {
                ListStudent = UserService.GetStudentInSession(sessionId);
                ListGrade = GradeService.GetGradesBySessionGradedByTeacher(sessionId);

            }
            catch (Exception)
            {

                return RedirectToPage("/SeverError");
            }

            GradeTable = new string[ListStudent.Count][];
            for (int i = 0; i < ListStudent.Count; i++)
            {
                GradeTable[i] = new string[ListGrade.Count];
            }

            for (int i = 0; i < ListStudent.Count; i++)
            {
                for (int j = 0; j < ListGrade.Count; j++)
                {
                    GradeTable[i][j] = StudentGradeService.GetGradeForStudentByGradeId(ListGrade[j].Id, ListStudent[i].Id).GradeValue;
                }
            }

            return Page();
        }
    }
}
