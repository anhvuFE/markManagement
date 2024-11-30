using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.Services;
using WebClient.DTO.Course;
using WebClient.DTO.User;
using System.Collections.Generic;
using TimetableSystem.Services;

namespace WebClient.Pages.admin
{
    public class CourseModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<CourseDTO> Courses { get; set; }

        [BindProperty]
        public CourseDTO NewCourse { get; set; } = new CourseDTO();

        public CourseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private GetUserDTO GetAuthenticatedUser()
        {
            return AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);
        }

        public IActionResult OnGet()
        {
            GetUserDTO user = GetAuthenticatedUser();
            if (user == null || !AuthenticationHelper.IsAdmin(user))
            {
                return Redirect("/AccessDenied");
            }

            Courses = CourseService.GetCourses();
            return Page();
        }

        public IActionResult OnPost()
        {
            GetUserDTO user = GetAuthenticatedUser();
            if (user == null || !AuthenticationHelper.IsAdmin(user))
            {
                return Redirect("/AccessDenied");
            }

            if (!ModelState.IsValid)
            {
                Courses = CourseService.GetCourses();
                return Page();
            }

            CourseService.AddCourse(NewCourse);
            return RedirectToPage();
        }
    }
}
