using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebClient.DTO.User;
using TimetableSystem.Services;

namespace WebClient.Pages.admin
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
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

            return Page();
        }
    }
}
