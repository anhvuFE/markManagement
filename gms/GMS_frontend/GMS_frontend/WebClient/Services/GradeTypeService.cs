using Newtonsoft.Json;
using System.Text;
using WebClient.DTO.Course;
using WebClient.DTO.GradeType;
using WebClient.DTO.Session;
using WebClient.DTO.StudentGrade;

namespace WebClient.Services
{
    public class GradeTypeService
    {
        public static List<GetGradeTypeDTO> GetALlGradeType()
        {
            List<GetGradeTypeDTO> List = new List<GetGradeTypeDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/GradeType/GetAllGradeType\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List = response.Content.ReadFromJsonAsync<List<GetGradeTypeDTO>>().Result;
            }

            return List;
        }

        public static bool CreateGradeType(CreateGradeTypeDTO gtDTO)
        {
            var url = "http://localhost:5100/api/GradeType/CreateGradeType\r\n"; 

            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(gtDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =  client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var result =  response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateGradeType(int gradeTypeId, int gradedByRole, string newCcomparisonType, int newGradeValue)
        {
            bool result = false;
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/GradeType/UpdateGradeType/{gradeTypeId}/{gradedByRole}/{newCcomparisonType}/{newGradeValue}";

            // Tạo nội dung trống vì PatchAsync yêu cầu một HttpContent
            var content = new StringContent("", Encoding.UTF8, "application/json");

            // Sử dụng phương thức PatchAsync để gọi API PATCH
            HttpResponseMessage response = client.PatchAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadFromJsonAsync<bool>().Result;
            }

            return result;
        }



        public static bool DeleteGradeType(int gradeTypeId)
        {
            bool result = false;
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/GradeType/DeleteGradeType/{gradeTypeId}\r\n";

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadFromJsonAsync<bool>().Result;
            }

            return result;
        }

        public static GradeDistributionDTO GetGradeDistribution(int gradeTypeId, int courseId)
        {
            GradeDistributionDTO gd = new GradeDistributionDTO();
             HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/GradeType/GetDistribution/{gradeTypeId}/{courseId}\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                gd = response.Content.ReadFromJsonAsync<GradeDistributionDTO>().Result;
            }

            return gd;
        }
    }
}
