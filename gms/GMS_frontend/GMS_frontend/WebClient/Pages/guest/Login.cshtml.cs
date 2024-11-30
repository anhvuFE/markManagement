using WebClient.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using WebClient.DTO.User;
using WebClient.Services;

namespace WebClient.Pages.guest
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                var authenticatedUser = UserService.login(Username, Password);

                if (authenticatedUser.RoleId != null)
                {
                    string userJson = JsonSerializer.Serialize(authenticatedUser);
                    HttpContext.Session.SetString("currentUser", userJson);

                    if (authenticatedUser.RoleId == 1)
                    {
                        return RedirectToPage("/admin/index");
                    }
                    else if (authenticatedUser.RoleId == 2)
                    {
                        return RedirectToPage("/khaothi/index");
                    }
                    else if (authenticatedUser.RoleId == 3)
                    {
                        return RedirectToPage("/teacher/index");
                    }
                    else if (authenticatedUser.RoleId == 4)
                    {
                        return RedirectToPage("/student/index");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    return Page();
                }
            }
            catch (Exception)
            {
                return RedirectToPage("/SeverError");
            }
            return Page();
        }
    }
}
