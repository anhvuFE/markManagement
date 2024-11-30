using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableSystem.Services;
using WebClient.DTO.Course;
using WebClient.DTO.GradeType;
using WebClient.DTO.StudentGrade;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.admin
{
    public class ViewDistributionModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ViewDistributionModel()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public List<GetGradeTypeDTO> ListGradeType { get; set; }
        public List<CourseDTO> ListCourse { get; set; }

        public GradeDistributionDTO[][] DistributeTable { get; set; }

        public IActionResult OnGet()
        {

            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsAdmin(user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                ListGradeType = GradeTypeService.GetALlGradeType();
                ListCourse = CourseService.GetCourses();

                DistributeTable = new GradeDistributionDTO[ListCourse.Count][];
                for (int i = 0; i < ListCourse.Count; i++)
                {
                    DistributeTable[i] = new GradeDistributionDTO[ListGradeType.Count];
                }

                for (int i = 0; i < ListCourse.Count; i++)
                {
                    for (int j = 0; j < ListGradeType.Count; j++)
                    {
                        DistributeTable[i][j] = GradeTypeService.GetGradeDistribution(ListGradeType[j].Id, ListCourse[i].Id);
                    }
                }

                return Page();

            }
            catch
            {
                return Redirect("/SeverError");
            }
        }

        public IActionResult OnPostUpdate(int courseId, string courseName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsAdmin(user))
            {
                return Redirect("/AccessDenied");
            }

            return Redirect($"/admin/UpdateDistribution?courseId={courseId}&courseName={courseName}");
        }

    }
}
