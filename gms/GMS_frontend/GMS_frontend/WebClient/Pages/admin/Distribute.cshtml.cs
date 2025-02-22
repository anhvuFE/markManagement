using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableSystem.Services;
using WebClient.DTO.Grade;
using WebClient.DTO.GradeType;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.admin
{
    public class DistributeModel : PageModel
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public DistributeModel()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public List<GetGradeTypeDTO> ListGradeType { get; set; }

        public int CurrentCourseId { get; set; }
        public string CurrentCourseName { get; set; }

        public string Msg { get; set; }

        public IActionResult OnGet(int courseId, string courseName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsAdmin(user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                GetData(courseId, courseName);
                return Page();
            }
            catch
            {
                return Redirect("/SeverError");
            }
        }


        public IActionResult OnPostDistribution(int[] gradeTypeSelect, int[] numberOfGradeType, int[] weightPerGrade, int courseId, string courseName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsAdmin(user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                
                bool semesterOnGoing = SemesterService.IsSemeterOnGoing();
                if (semesterOnGoing)
                {
                    Msg = "Create Fail. Semester is on going";
                    GetData(courseId, courseName);
                    return Page();
                }

                GetData(courseId, courseName);

                int length = gradeTypeSelect.Count();
                List<CreateGradeDTO> listToCreate = new List<CreateGradeDTO>();
                for (int i = 0; i < length; i++)
                {
                    CreateGradeDTO gDTO = new CreateGradeDTO();
                    gDTO.GradeTypeId = gradeTypeSelect[i];
                    gDTO.NumberOfGrade = numberOfGradeType[i];
                    gDTO.WeightPerGrade = weightPerGrade[i];

                    listToCreate.Add(gDTO);
                }

                ResultForCreateGradeDTO result = GradeService.CreateGrade(courseId, listToCreate);
                Msg = result.Msg;
                return Page();
            }
            catch (Exception)
            {
                return Redirect("/SeverError");
            }
        }

        public void GetData(int courseId, string courseName)
        {
            ListGradeType = GradeTypeService.GetALlGradeType();
            CurrentCourseId = courseId;
            CurrentCourseName = courseName;
        }
    }
}
