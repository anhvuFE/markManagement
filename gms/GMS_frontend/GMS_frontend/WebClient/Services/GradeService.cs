using WebClient.DTO.Grade;
using WebClient.DTO.Session;

namespace WebClient.Services
{
    public class GradeService
    {
        public static List<GetGradeDTO> GetGradesBySessionGradedByTeacher(int sessionId)
        {
            List<GetGradeDTO> ListGrade = new List<GetGradeDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Grade/GetGradesBySessionGradedByTeacher/{sessionId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ListGrade = response.Content.ReadFromJsonAsync<List<GetGradeDTO>>().Result;
            }

            return ListGrade;
        }

        public static List<GetGradeDTO> GetGradesBySessionGradedByKhaoThi(int sessionId)
        {
            List<GetGradeDTO> ListGrade = new List<GetGradeDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Grade/GetGradesBySessionGradedByKhaoThi/{sessionId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ListGrade = response.Content.ReadFromJsonAsync<List<GetGradeDTO>>().Result;
            }

            return ListGrade;
        }


        public static List<GetGradeDTO> GetGradesGradedByKhaoThi()
        {
            List<GetGradeDTO> ListGrade = new List<GetGradeDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Grade/GetAllGradeGradedByKhaoThi\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ListGrade = response.Content.ReadFromJsonAsync<List<GetGradeDTO>>().Result;
            }

            return ListGrade;
        }
        public static ResultForCreateGradeDTO CreateGrade(int courseId, List<CreateGradeDTO> ListGDTO)
        {
            ResultForCreateGradeDTO result = new ResultForCreateGradeDTO();

            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Grade/CreateGrade/{courseId}";

            HttpResponseMessage response = client.PostAsJsonAsync(url, ListGDTO).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadFromJsonAsync<ResultForCreateGradeDTO>().Result;

                return result;
            }
            return result;
        }
    }
}
