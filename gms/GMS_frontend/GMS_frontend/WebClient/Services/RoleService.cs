using WebClient.DTO.Course;
using WebClient.DTO.Role;

namespace WebClient.Services
{
    public class RoleService
    {
        public static List<RoleDTO> GetRoleGraded()
        {
            List<RoleDTO> List = new List<RoleDTO>();
            HttpClient client = new HttpClient();
            string url = $"http://localhost:5100/api/Role/GetRoleGraded\r\n";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List = response.Content.ReadFromJsonAsync<List<RoleDTO>>().Result;
            }

            return List;
        }
    }
}
