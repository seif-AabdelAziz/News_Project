using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News.BL;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace News.MVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        Uri baseAddress = new Uri("http://localhost:5041/api/News");
        Uri authorAddress = new Uri("http://localhost:5041/api/Authors");

        public NewsController(IHttpContextAccessor _httpContextAccessor)
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
        public IActionResult Index()
        {
            List<NewsReadDTO>? list = new List<NewsReadDTO>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Published").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<NewsReadDTO>>(data);
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            NewsReadDetailsDTO? news = new NewsReadDetailsDTO();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + $"/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                news = JsonConvert.DeserializeObject<NewsReadDetailsDTO>(data);
            }
            return View(news);
        }


        [HttpGet]
        public IActionResult GetNews()
        {
            List<NewsReadDetailsDTO>? list = new List<NewsReadDetailsDTO>();

            GetToken();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/All").Result;

            if (response.IsSuccessStatusCode)
            {

                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<NewsReadDetailsDTO>>(data);
                return View(list);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Add()
        {
            List<AuthorReadDTO>? list = new List<AuthorReadDTO>();

            GetToken();
            HttpResponseMessage response = httpClient.GetAsync(authorAddress + "/All").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<AuthorReadDTO>>(data);
            }
            ViewData["Authors"] = list.Select(a => new SelectListItem(a.Name, a.ID.ToString())).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewsAddDTO newsAddDTO)
        {
            GetToken();
            var response = httpClient.PostAsJsonAsync(httpClient.BaseAddress + "/Add", newsAddDTO).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetNews));
            }
            ModelState.AddModelError("", "Publication Date must be within one week");
            return RedirectToAction(nameof(Add));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            NewsEditDTO? news = new NewsEditDTO();

            GetToken();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + $"/update/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                news = JsonConvert.DeserializeObject<NewsEditDTO>(data);
            }
            List<AuthorReadDTO>? list = new List<AuthorReadDTO>();
            HttpResponseMessage authorsResponse = httpClient.GetAsync(authorAddress + "/All").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = authorsResponse.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<AuthorReadDTO>>(data);
            }
            ViewData["Authors"] = list.Select(a => new SelectListItem(a.Name, a.ID.ToString())).ToList();

            return View(news);
        }

        [HttpPost]
        public IActionResult Edit(NewsEditDTO newsEditDTO)
        {
            GetToken();
            var response = httpClient.PutAsJsonAsync(httpClient.BaseAddress + "/Update", newsEditDTO).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetNews));
            }

            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        public IActionResult Del(Guid id)
        {
            GetToken();
            var response = httpClient.DeleteAsync(httpClient.BaseAddress + "/Delete/" + id).Result;

            return RedirectToAction(nameof(GetNews));

        }
    }
}


