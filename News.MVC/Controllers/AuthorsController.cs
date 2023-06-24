using Microsoft.AspNetCore.Mvc;
using News.BL;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace News.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        Uri baseAddress = new Uri("http://localhost:5041/api/Authors");
        public AuthorsController(IHttpContextAccessor _httpContextAccessor)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAddress;
            httpContextAccessor = _httpContextAccessor;

        }
        private void GetToken()
        {
            var token = httpContextAccessor.HttpContext.Request.Cookies["Token"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<AuthorReadDTO>? authors = new List<AuthorReadDTO>();

            GetToken();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/All").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                authors = JsonConvert.DeserializeObject<List<AuthorReadDTO>>(data);
                return View(authors);
            }
            return RedirectToAction(nameof(Index), "News");
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorAddDTO author)
        {
            if (author == null)
            {
                return View();
            }

            GetToken();
            var response = httpClient.PostAsJsonAsync(httpClient.BaseAddress + "/Add", author).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAll));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            AuthorEditDTO? author = new AuthorEditDTO();

            GetToken();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + $"/GetAuthor/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                author = JsonConvert.DeserializeObject<AuthorEditDTO>(data);
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(AuthorEditDTO authorEdit)
        {
            GetToken();
            HttpResponseMessage response = httpClient.PutAsJsonAsync(httpClient.BaseAddress + $"/Update", authorEdit).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAll));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Del(Guid id)
        {
            GetToken();
            HttpResponseMessage response = httpClient.DeleteAsync(httpClient.BaseAddress + $"/Delete/{id}").Result;
            return RedirectToAction(nameof(GetAll));
        }
    }
}
