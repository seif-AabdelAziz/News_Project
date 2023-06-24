using Microsoft.AspNetCore.Mvc;
using News.BL;
using Newtonsoft.Json.Linq;

namespace News.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient httpClient;
        Uri baseAddress = new Uri("http://localhost:5041/api/Users");

        public UsersController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Log()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log(LoginDTO login)
        {
            HttpResponseMessage response = httpClient.PostAsJsonAsync(httpClient.BaseAddress + "/Login", login).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject responseJson = JObject.Parse(responseBody);
                string token = (string)responseJson["token"]!;
                Response.Cookies.Append("Token", token);

                return RedirectToAction("GetNews", "News");
            }
            ModelState.AddModelError("", "Username or Password are incorrect");
            return View();
        }
    }
}
