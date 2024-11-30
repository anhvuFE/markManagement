using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TimetableSystem.Services;
using WebClient.DTO.Session;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.teacher
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<GetSessionDTO> ListSession { get; set; }

        public IndexModel()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public IActionResult OnGet()
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsTeacher (user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                ListSession = SessionService.GetSessionByTeacher(user.Id);
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/SeverError");
            }
        }
    }
}
