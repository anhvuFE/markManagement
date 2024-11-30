using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebClient.DTO.Course;

namespace WebClient.Pages.Shared.Components.CourseDropdown
{
    public class CourseDropdownViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CourseDropdownViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5100/");

            var response = await client.GetAsync("api/Course/GetAllCourse");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                courses = JsonConvert.DeserializeObject<List<CourseDTO>>(json);
            }

            return View(courses);  // Trả về Razor View với danh sách các môn học
        }
    }
}
