using WebClient.DTO.Grade;
using WebClient.DTO.Session;
using WebClient.DTO.StudentGrade;

namespace WebClient.Services
{
    public class StudentGradeService
    {

        public static bool GradedForStudent(int gradeId, int studentId, decimal value)
        {
            string url = $"http://localhost:5100/api/StudentGrade/GradedForStudent/{gradeId}/{studentId}/{value}\r\n";

            // Gửi request POST
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync(url, null).Result;

            if (response.IsSuccessStatusCode)
            {
                return true; // Đã chấm điểm thành công
            }
            else
            {
                return false; // Chấm điểm không thành công
            }
        }


        public static bool UpdateGradeForStudent(int gradeId, int studentId, decimal newValue)
        {
            HttpClient client = new HttpClient();   

            string url = $"http://localhost:5100/api/StudentGrade/UpdateGradeForStudent/{gradeId}/{studentId}/{newValue}";

            var request = new HttpRequestMessage(HttpMethod.Patch, url);

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Handle the error or log it as needed
                return false;
            }

        }

        public static GetGradeForStudentDTO GetGradeForStudentByGradeId(int gradeId, int studentId)
        {
            GetGradeForStudentDTO result = new GetGradeForStudentDTO();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/StudentGrade/GetGradeForStudentByGradeId/{gradeId}/{studentId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content.ReadFromJsonAsync<GetGradeForStudentDTO>().Result;
            }

            return result;
        }

        public static bool CheckStudentGradeExist(int gradeId, int studentId)
        {
            bool result = false;
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/StudentGrade/CheckStudentGradeExist/{gradeId}/{studentId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content.ReadFromJsonAsync<bool>().Result;
            }

            return result;
        }

        public static bool DeleteStudentGrade(int gradeId, int studentId)
        {
            bool result = false;
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/StudentGrade/DeleteStudentGrade/{gradeId}/{studentId}";

            // Sử dụng phương thức DeleteAsync để gọi API DELETE
            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadFromJsonAsync<bool>().Result;
            }

            return result;
        }


        public static StudentViewGradeDTO StudentViewGrade(int studentId, int courseId)
        {
            StudentViewGradeDTO result = new StudentViewGradeDTO();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/StudentGrade/ViewGrade/{studentId}/{courseId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content.ReadFromJsonAsync<StudentViewGradeDTO>().Result;
            }

            return result;
        }
    }
}
