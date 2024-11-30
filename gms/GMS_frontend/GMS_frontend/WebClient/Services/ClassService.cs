using BussinessObject.DTO.Class;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WebClient.Services
{
    public class ClassService
    {
        private static readonly HttpClient client = new HttpClient();

        public static List<ClassDTO> GetClasses()
        {
            var url = "http://localhost:5100/api/Class/GetAllClasses";
            var response = client.GetAsync(url).Result;
            return response.IsSuccessStatusCode
                ? response.Content.ReadFromJsonAsync<List<ClassDTO>>().Result
                : new List<ClassDTO>();
        }

        public static async Task<bool> ClassExists(string className)
        {
            var classes = await client.GetFromJsonAsync<List<ClassDTO>>("http://localhost:5100/api/Class/GetAllClasses");
            return classes.Any(c => c.Name.Equals(className, StringComparison.OrdinalIgnoreCase));
        }

        public static async Task<bool> CreateClass(ClassDTO newClass)
        {
            // Kiểm tra tồn tại
            if (await ClassExists(newClass.Name))
            {
                return false; // Lớp đã tồn tại
            }

            var url = "http://localhost:5100/api/Class/AddClass";
            var response = await client.PostAsJsonAsync(url, newClass);
            return response.IsSuccessStatusCode;
        }
    }
}
