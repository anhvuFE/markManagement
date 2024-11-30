using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System.Reflection;
using System.Text.Json;
using WebClient.DTO.SessionStudent;
using WebClient.DTO.StudentGrade;
using WebClient.DTO.User;
using WebClient.Services;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Table;
using WebClient.DTO.Session;

namespace WebClient.Pages.student
{
    public class ViewGradeModel : PageModel
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ViewGradeModel()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public StudentViewGradeDTO ViewGrade { get; set; }
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }

        public decimal Avg { get; set; }

        public GetStatusDTO Status { get; set; }
        public List<GetSessionDTO> ListSession { get; set; }

        public IActionResult OnGet()
        {
            string userJson = _httpContextAccessor.HttpContext.Session.GetString("currentUser");

            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToPage("/guest/Login");
            }
            GetUserDTO u = JsonSerializer.Deserialize<GetUserDTO>(userJson);
            u = UserService.GetStudent(u.Username);

            userJson = JsonSerializer.Serialize(u);
            _httpContextAccessor.HttpContext.Session.SetString("currentUser", userJson);

            try
            {
                ListSession = SessionService.GetSessionByStudent(u.Id);
            }
            catch (Exception)
            {
                return RedirectToPage("/SeverError");
            }
            return Page();
        }
        public IActionResult OnGetGrade(int sessionId, int courseId, string courseName, string className, string teacherName)
        {
            string userJson = _httpContextAccessor.HttpContext.Session.GetString("currentUser");

            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToPage("/Login");
            }
            GetUserDTO u = JsonSerializer.Deserialize<GetUserDTO>(userJson);

            try
            {
                u = UserService.GetStudent(u.Username);
            }
            catch
            {
                return RedirectToPage("/SeverError");
            }

            userJson = JsonSerializer.Serialize(u);
            _httpContextAccessor.HttpContext.Session.SetString("currentUser", userJson);

            SessionId = sessionId;
            CourseId = courseId;
            CourseName = courseName;
            ClassName = className;
            TeacherName = teacherName;
            try
            {
                ViewGrade = StudentGradeService.StudentViewGrade(u.Id, courseId);
                Avg = SessionStudentService.GetAvgGrade(courseId, u.Id);
                Status = SessionStudentService.GetStatus(courseId, u.Id);
            }
            catch 
            {
                return RedirectToPage("/SeverError");
            }
            OnGet();
            return Page();
        }


        public IActionResult OnGetExportExcel(int courseId, string courseName)
        {
            // Load lại dữ liệu cần thiết
            string userJson = _httpContextAccessor.HttpContext.Session.GetString("currentUser");

            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToPage("/Login");
            }

            GetUserDTO u = JsonSerializer.Deserialize<GetUserDTO>(userJson);

            try
            {
                u = UserService.GetStudent(u.Username);
                ViewGrade = StudentGradeService.StudentViewGrade(u.Id, courseId);
                Avg = SessionStudentService.GetAvgGrade(courseId, u.Id);
                Status = SessionStudentService.GetStatus(courseId, u.Id);
            }
            catch
            {
                return RedirectToPage("/SeverError");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Hoặc LicenseContext.Commercial nếu bạn có giấy phép thương mại

            // Tạo file Excel
            using (var stream = new MemoryStream())
            {
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Grades");

                    // Headers
                    worksheet.Cells["A1"].Value = $"View Grade of {u.Username} - {courseName} ";
                    worksheet.Cells["A2"].Value = "Grade category";
                    worksheet.Cells["B2"].Value = "Grade item";
                    worksheet.Cells["C2"].Value = "Weight";
                    worksheet.Cells["D2"].Value = "Value";

                    int row = 3;

                    foreach (var gradeType in ViewGrade.GradeTypes)
                    {
                        foreach (var grade in gradeType.Grades)
                        {
                            worksheet.Cells["A" + row].Value = gradeType.GradeTypeName;
                            worksheet.Cells["B" + row].Value = grade.GradeName;
                            worksheet.Cells["C" + row].Value = grade.Weight + " %";
                            worksheet.Cells["D" + row].Value = grade.Value;
                            row++;
                        }
                    }

                    // Footer
                    worksheet.Cells["A" + row].Value = "Course total";
                    worksheet.Cells["B" + row].Value = "Average";
                    worksheet.Cells["C" + row].Value = Avg;
                    row++;
                    worksheet.Cells["A" + row].Value = "";
                    worksheet.Cells["B" + row].Value = "Status";
                    worksheet.Cells["C" + row].Value = Status.isPass ? "PASSED" : "NOT PASSED";

                    // Format as table
                    var tableRange = worksheet.Cells[2, 1, row - 1, 4];
                    var table = worksheet.Tables.Add(tableRange, "GradesTable");
                    table.TableStyle = TableStyles.Medium9;

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    package.Save();
                }

                stream.Position = 0;
                string excelName = $"{u.Username}_{courseName}_GradeDetail.xlsx";
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }
    }
}
