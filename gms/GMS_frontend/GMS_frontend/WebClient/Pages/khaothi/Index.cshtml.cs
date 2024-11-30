using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TimetableSystem.Services;
using WebClient.DTO.Grade;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.khaothi
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<GetGradeDTO> ListGrade { get; set; }

        public IndexModel()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public IActionResult OnGet()
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsKhaoThi(user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                ListGrade = GradeService.GetGradesGradedByKhaoThi();
                return Page();
            }
            catch
            {
                return Redirect("/SeverError");
            }
        }
    }
}

