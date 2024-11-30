using WebClient.DTO.ComparisonType;

namespace WebClient.Services
{
    public class ComparisionTypeService
    {
        public static List<ComparisonTypeDTO> GetAll()
        {
            List<ComparisonTypeDTO> List = new List<ComparisonTypeDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/ComparisonType/GetComparisonTypes\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List = response.Content.ReadFromJsonAsync<List<ComparisonTypeDTO>>().Result;
            }

            return List;
        }
    }
}
