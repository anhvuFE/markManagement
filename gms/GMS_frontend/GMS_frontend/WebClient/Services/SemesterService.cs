using WebClient.DTO.Session;

namespace WebClient.Services
{
    public class SemesterService
    {
        public static bool IsSemeterOnGoing()
        {
            bool result = false;
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Semester/IsSemesterOnGoing\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content.ReadFromJsonAsync<bool>().Result;
            }

            return result;
        }
    }
}
