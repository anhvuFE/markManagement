using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableSystem.Services;
using WebClient.DTO.Grade;
using WebClient.DTO.Session;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.khaothi
{
    public class UpdateGradeModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateGradeModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int UserId { get; set; }
        public string Username { get; set; }

        public int CurrentSessonId {  get; set; }
        public int CurrentGradeId {  get; set; }

        public List<GetSessionDTO> ListSession { get; set; }
        public List<GetGradeDTO> ListGrade { get; set; }

        public string Msg { get; set; }
        public IActionResult OnGet()
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsKhaoThi(user))
            {
                return Redirect("/AccessDenied");
            }

            return Page();
        }

        public IActionResult OnPost(string username, int? sessionId, int? gradeId, int? newGradeValue)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsKhaoThi(user))
            {
                return Redirect("/AccessDenied");
            }



            try
            {
                GetUserDTO u = UserService.GetStudent(username);

                if (u.Username == null)
                {
                    Username = username;
                    Msg = "No Student Found";
                    return Page();
                }

                Username = u.Username;
                ListSession = SessionService.GetSessionByStudent(u.Id);

                if (sessionId == null)
                {
                    ListGrade = GradeService.GetGradesBySessionGradedByTeacher(ListSession[0].Id);
                }
                else
                {
                    ListGrade = GradeService.GetGradesBySessionGradedByTeacher((int)sessionId);
                    CurrentSessonId = (int)sessionId;

                    if (gradeId != null)
                    {
                        CurrentGradeId = (int)gradeId;
                        if (newGradeValue != null)
                        {
                            bool semesterOnGoing = SemesterService.IsSemeterOnGoing();
                            if (!semesterOnGoing)
                            {
                                Msg = "Graded Fail. Semester is not started";
                                return Page();
                            }

                            bool exist = StudentGradeService.CheckStudentGradeExist((int)gradeId, u.Id);
                            if (!exist)
                            {
                                Msg = "Update fail. Student Grade is not exist";
                                return Page();
                            }

                            bool updateSuccess = StudentGradeService.UpdateGradeForStudent((int)gradeId, u.Id, (decimal)newGradeValue);

                            if (updateSuccess)
                            {
                                Msg = "Update success";

                            }
                            else
                            {
                                Msg = "Update fail";
                            }
                        }
                    }
                }
                return Page();

            }
            catch
            {
                return Redirect("/SeverError");
            }
        }
    }
}
