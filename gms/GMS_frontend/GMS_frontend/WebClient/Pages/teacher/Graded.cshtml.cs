using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using TimetableSystem.Services;
using WebClient.DTO.StudentGrade;
using WebClient.DTO.User;
using WebClient.Services;
using Newtonsoft.Json;
using ClosedXML.Excel;
namespace WebClient.Pages.teacher
{
    public class GradedModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GradedModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            ListStudentGradeFromJson = new List<StudentGradeFromJson>();
        }
        public List<GetUserDTO> ListUserDTO { get; set; }

        public List<StudentGradeFromJson> ListStudentGradeFromJson { get; set; }

        public int SessionId { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Msg { get; set; }

        public void GetData(int sessionId, string className, string courseName, int gradeId, string gradeName)
        {
            SessionId = sessionId;
            CourseName = courseName;
            ClassName = className;
            GradeId = gradeId;
            GradeName = gradeName;


            ListUserDTO = UserService.GetStudentInSession(sessionId);
        }
        public IActionResult OnGet(int sessionId, string className, string courseName, int gradeId, string gradeName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsTeacher(user))
            {
                return Redirect("/AccessDenied");
            }

            try
            {
                GetData(sessionId, className, courseName, gradeId, gradeName);

            }
            catch (Exception)
            {

                return RedirectToPage("/SeverError");
            }
            return Page();
        }

        public IActionResult OnPostGraded(List<int> studentIds, List<decimal> grades, int sessionId, string className, string courseName, int gradeId, string gradeName)
        {
            GetUserDTO user = AuthenticationHelper.GetAuthenticatedUser(_httpContextAccessor.HttpContext);

            if (user == null || !AuthenticationHelper.IsTeacher(user))
            {
                return Redirect("/AccessDenied");
            }

            bool semesterOnGoing = SemesterService.IsSemeterOnGoing();
            if (!semesterOnGoing)
            {
                Msg = "Graded Fail. Semester is not started";
                try
                {
                    GetData(sessionId, className, courseName, gradeId, gradeName);

                }
                catch (Exception)
                {
                    return RedirectToPage("/SeverError");
                }

                return Page();
            }

            int countFalse = 0;
            for (int i = 0; i < studentIds.Count; i++)
            {
                bool success;
                try
                {
                    success = StudentGradeService.GradedForStudent(gradeId, studentIds[i], grades[i]);
                }
                catch (Exception)
                {
                    return RedirectToPage("/SeverError");
                }
                 ;
                if (!success)
                {
                    countFalse++;
                }
            }
            if (countFalse > 0)
            {
                Msg = $"Graded fail. The {gradeName} of {courseName} - {className} has been graded before";
            }
            else
            {
                Msg = "Graded success";
            }


            try
            {
                GetData(sessionId, className, courseName, gradeId, gradeName);

            }
            catch (Exception)
            {
                return RedirectToPage("/SeverError");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostImport(IFormFile file, int sessionId, string className, string courseName, int gradeId, string gradeName)
        {
            try
            {
                GetData(sessionId, className, courseName, gradeId, gradeName);
            }
            catch
            {
                return RedirectToPage("/SeverError");
            }

            // neu file null
            if (file == null || file.Length == 0)
            {
                Msg = "No input file";
                return Page();
            }
            else
            {
                try
                {
                    var filePath = Path.Combine("wwwroot", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    using (var workbook = new XLWorkbook(filePath))
                    {
                        // doc sheet1
                        var worksheet = workbook.Worksheet(1);

                        bool invalidGradeData = false;
                        bool invalidStudentData = false;
                        foreach (var row in worksheet.RowsUsed().Skip(1)) // Skip header row
                        {
                            StudentGradeFromJson studentGradeFromJson = new StudentGradeFromJson();

                            //doc data theo row
                            try
                            {
                                studentGradeFromJson.studentName = row.Cell(1).GetValue<string>(); // Cột 1 là "StudentName"
                                studentGradeFromJson.gradeValue = row.Cell(2).GetValue<int>();
                            }
                            catch
                            {
                                Msg = "File data is not in the correct format";
                                return Page();
                            }

                            // check grade
                            if (studentGradeFromJson.gradeValue < 0 || studentGradeFromJson.gradeValue > 10)
                            {
                                invalidGradeData = true;
                            }
                            ListStudentGradeFromJson.Add(studentGradeFromJson);
                        }

                        //check student
                        for (int i = 0; i < ListStudentGradeFromJson.Count; i++)
                        {
                            if (!ListStudentGradeFromJson[i].studentName.ToLower().Equals(ListUserDTO[i].Username.ToLower()))
                            {
                                invalidStudentData = true;
                                break;
                            }
                        }
                        if (invalidStudentData && invalidGradeData)
                        {
                            ListStudentGradeFromJson = null;
                            Msg = "Invalid Student & Grade data";
                        }
                        else if (invalidStudentData)
                        {
                            ListStudentGradeFromJson = null;
                            Msg = "Invalid Student data";
                        }
                        else if (invalidGradeData)
                        {
                            ListStudentGradeFromJson = null;
                            Msg = "Invalid Grade data";
                        }
                        return Page();
                    }
                }
                catch
                {
                    Msg = "The process cannot access the file because it is being used by another process";
                    return Page();
                }

            }
        }
    }
}



    //public IActionResult OnPostImportFile(IFormFile file, int sessionId, string className, string courseName, int gradeId, string gradeName)
    //{
    //    GetData(sessionId, className, courseName, gradeId, gradeName);
    //    if (file == null)
    //    {
    //        Msg = "No input file";
    //        return Page();
    //    }

    //    using (var r = new StreamReader(file.OpenReadStream()))
    //    {
    //        string json = r.ReadToEnd();

    //        try
    //        {
    //            ListStudentGradeFromJson = System.Text.Json.JsonSerializer.Deserialize<List<StudentGradeFromJson>>(json);
    //        }
    //        catch
    //        {
    //            Msg = "File data is not in the correct format";
    //            return Page();
    //        }
    //        for (int i = 0; i < ListStudentGradeFromJson.Count; i++)
    //        {
    //            if ((!ListStudentGradeFromJson[i].studentName.ToLower().Equals(ListUserDTO[i].Username.ToLower()))
    //                || (ListStudentGradeFromJson[i].gradeValue > 10)
    //                || (ListStudentGradeFromJson[i].gradeValue < 0)
    //                )
    //            {
    //                ListStudentGradeFromJson = null;
    //                Msg = "Invalid file data";
    //                return Page();
    //            }
    //        }
    //    }
    //    return Page();
    //}
