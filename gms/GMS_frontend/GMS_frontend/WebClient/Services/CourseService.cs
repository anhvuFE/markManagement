using WebClient.DTO.Course;
using WebClient.DTO.Session;

namespace WebClient.Services
{
    public class CourseService
    {

        public static List<CourseDTO> GetCourses()
        {
            List<CourseDTO> List = new List<CourseDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Course/GetAllCourse\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List = response.Content.ReadFromJsonAsync<List<CourseDTO>>().Result;
            }

            return List;
        }
        public static bool DeleteGradeDistribution(int courseId)
        {
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Course/DeleteGradeDistribution/{courseId}";
            HttpResponseMessage response = client.DeleteAsync(url).Result;
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public static bool AddCourse(CourseDTO course)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5100/api/Course/AddCourse";
            HttpResponseMessage response = client.PostAsJsonAsync(url, course).Result;
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
