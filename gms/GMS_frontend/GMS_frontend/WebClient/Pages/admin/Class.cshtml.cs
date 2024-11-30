using BussinessObject.DTO.Class;
using BussinessObject.DTO.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.DTO.Course;
using WebClient.DTO.Session;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.admin
{
    public class ClassModel : PageModel
    {
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public List<GetUserDTO> Teachers { get; set; } = new List<GetUserDTO>();
        public List<ClassDTO> Classes { get; set; } = new List<ClassDTO>();
        public Dictionary<string, List<GetSessionDTO>> SessionsByCourse { get; set; } = new Dictionary<string, List<GetSessionDTO>>();

        [BindProperty]
        public int SelectedCourseId { get; set; }

        [BindProperty]
        public int SelectedClassId { get; set; }

        [BindProperty]
        public int SelectedTeacherId { get; set; }

        [BindProperty]
        public string NewClassName { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPostCreateClass()
        {

            var newSession = new SessionDTO
            {
                CourseId = SelectedCourseId,
                TeacherId = SelectedTeacherId,
                ClassId = SelectedClassId
            };

            bool isCreated = SessionService.CreateSession(newSession);
            if (isCreated)
            {
                ViewData["Message"] = "Tạo session thành công.";
                return RedirectToPage();
            }
            else
            {
                ViewData["Message"] = "Không thể tạo session. Vui lòng kiểm tra lại thông tin hoặc thử lại sau.";
                LoadData();
                return Page();
            }
        }


        public async Task<IActionResult> OnPostCreateNewClass()
        {
            if (string.IsNullOrEmpty(NewClassName))
            {
                ModelState.AddModelError(string.Empty, "Class name is required.");
                ViewData["Message"] = "Tên lớp không được để trống.";
                LoadData();
                return Page();
            }

            var newClass = new ClassDTO { Name = NewClassName };

            // Gọi CreateClass để kiểm tra và thêm lớp
            bool isClassCreated = await ClassService.CreateClass(newClass);
            if (isClassCreated)
            {
                ViewData["Message"] = "Tạo lớp thành công.";
                return RedirectToPage();
            }

            ModelState.AddModelError(string.Empty, "Class name already exists or failed to create class.");
            ViewData["Message"] = "Tên lớp đã tồn tại hoặc không thể tạo lớp.";
            LoadData();
            return Page();
        }

        private void LoadData()
        {
            Courses = CourseService.GetCourses();
            Teachers = UserService.GetUsersByRole(3);
            Classes = ClassService.GetClasses();

            var allSessions = SessionService.GetAllSessions();
            SessionsByCourse = allSessions
                .GroupBy(s => s.CourseName)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
