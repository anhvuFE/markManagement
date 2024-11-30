using WebClient.DTO.SessionStudent;
using System.Net.Http;
using System.Net.Http.Json;

namespace WebClient.Services
{
    public class SessionStudentService
    {
        public static decimal GetAvgGrade(int courseId, int studentId)
        {
            decimal avg = 0;
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/SessionStudent/GetAvgGrade/{courseId}/{studentId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                avg = response.Content.ReadFromJsonAsync<decimal>().Result;
            }

            return avg;
        }

        public static GetStatusDTO GetStatus(int courseId, int studentId)
        {
            GetStatusDTO result = new GetStatusDTO();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/SessionStudent/GetStatus/{courseId}/{studentId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content.ReadFromJsonAsync<GetStatusDTO>().Result;
            }

            return result;
        }

        public static bool AddStudentToSession(SessionStudentDTO sessionStudentDTO)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5100/api/SessionStudent/AddStudentToSession";
            HttpResponseMessage response = client.PostAsJsonAsync(url, sessionStudentDTO).Result;
            return response.IsSuccessStatusCode;
        }

        public static List<GetStudentBySession> GetSessionStudentsBySessionId(int sessionId)
        {
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/SessionStudent/GetSessionStudents/{sessionId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            List<GetStudentBySession> students = new List<GetStudentBySession>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                students = response.Content.ReadFromJsonAsync<List<GetStudentBySession>>().Result;
            }

            return students;
        }
    }
}
