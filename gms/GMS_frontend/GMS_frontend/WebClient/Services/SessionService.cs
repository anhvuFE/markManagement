using BussinessObject.DTO.Session;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using WebClient.DTO.Session;
using WebClient.DTO.User;

namespace WebClient.Services
{
    public class SessionService
    {
        private static readonly HttpClient client = new HttpClient();

        public static List<GetSessionDTO> GetSessionByTeacher(int? teacherId)
        {
            List<GetSessionDTO> ListSs = new List<GetSessionDTO>();
            string url = $"http://localhost:5100/api/Session/GetSessionByTeacher/{teacherId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ListSs = response.Content.ReadFromJsonAsync<List<GetSessionDTO>>().Result;
            }

            return ListSs;
        }

        public static List<GetSessionDTO> GetSessionByStudent(int? studentId)
        {
            List<GetSessionDTO> ListSs = new List<GetSessionDTO>();
            string url = $"http://localhost:5100/api/Session/GetSessionByStudent/{studentId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ListSs = response.Content.ReadFromJsonAsync<List<GetSessionDTO>>().Result;
            }

            return ListSs;
        }

        public static List<GetSessionDTO> GetAllSessions()
        {
            List<GetSessionDTO> ListSs = new List<GetSessionDTO>();
            string url = "http://localhost:5100/api/Session/GetAllSessions";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ListSs = response.Content.ReadFromJsonAsync<List<GetSessionDTO>>().Result;
            }

            return ListSs;
        }

        public static bool CreateSession(SessionDTO newSession)
        {
            try
            {
                var url = "http://localhost:5100/api/Session/AddSession";
                var response = client.PostAsJsonAsync(url, newSession).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to create session. Status Code: {response.StatusCode}");
                    var error = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Error: {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return false;
            }
        }

    }
}
