using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.DTO.SessionStudent;
using WebClient.DTO.User;
using WebClient.Services;
using System.Collections.Generic;

namespace WebClient.Pages.admin
{
    public class AddStudentModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int SessionId { get; set; }

        public List<GetStudentBySession> CurrentStudents { get; set; }
        public List<GetUserDTO> AllStudents { get; set; } 

        [BindProperty]
        public int SelectedStudentId { get; set; }

        public void OnGet()
        {

            System.Diagnostics.Debug.WriteLine($"OnGet - SessionId: {SessionId}");

            CurrentStudents = SessionStudentService.GetSessionStudentsBySessionId(SessionId);

            AllStudents = UserService.GetUsersByRole(4);
        }

        public IActionResult OnPostAddStudent()
        {
            System.Diagnostics.Debug.WriteLine($"OnPostAddStudent - SessionId: {SessionId}");
            System.Diagnostics.Debug.WriteLine($"OnPostAddStudent - SelectedStudentId: {SelectedStudentId}");

            if (SelectedStudentId > 0)
            {
                var newStudent = new SessionStudentDTO
                {
                    SessionId = SessionId,
                    StudentId = SelectedStudentId
                };

                bool isAdded = SessionStudentService.AddStudentToSession(newStudent);

                if (isAdded)
                {
                    return RedirectToPage(new { SessionId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Student is already in this session.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please select a student to add.");
            }

            CurrentStudents = SessionStudentService.GetSessionStudentsBySessionId(SessionId);
            AllStudents = UserService.GetUsersByRole(4);

            return Page();
        }

    }
}
