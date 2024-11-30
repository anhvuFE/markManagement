using WebClient.DTO.Session;
using WebClient.DTO.User;

namespace WebClient.Services
{
    public class UserService
    {
        public static GetUserDTO login(string username, string password)
        {
            GetUserDTO u = new GetUserDTO();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/User/GetUser/{username}/{password}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                u = response.Content.ReadFromJsonAsync<GetUserDTO>().Result;
            }

            return u;
        }

        public static GetUserDTO GetStudent(string username)
        {
            GetUserDTO u = new GetUserDTO();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/User/GetStudent/{username}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                u = response.Content.ReadFromJsonAsync<GetUserDTO>().Result;
            }

            return u;
        }

        public static List<GetUserDTO> GetStudentInSession(int sessionId)
        {
            List<GetUserDTO> listU = new List<GetUserDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/User/GetStudentInSession/{sessionId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listU = response.Content.ReadFromJsonAsync<List<GetUserDTO>>().Result;
            }

            return listU;
        }

        public static List<GetUserDTO> GetStudentInCourse(int courseId)
        {
            List<GetUserDTO> listU = new List<GetUserDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/User/GetStudentByCourseId/{courseId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listU = response.Content.ReadFromJsonAsync<List<GetUserDTO>>().Result;
            }

            return listU;
        }

        public static List<GetUserDTO> GetUsersByRole(int roleId)
        {
            List<GetUserDTO> listU = new List<GetUserDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/User/GetUsersByRole/{roleId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listU = response.Content.ReadFromJsonAsync<List<GetUserDTO>>().Result;
            }
            return listU;
        }

    }
}
