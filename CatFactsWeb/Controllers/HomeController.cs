using CatFactsWeb.Classes;
using CatFactsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatFactsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://catfact.ninja");
            _httpClient.Timeout = TimeSpan.FromSeconds(2);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ButtonClick()
        {
            var response = _httpClient.GetAsync("fact").Result;
            response.EnsureSuccessStatusCode();
            CatFact fact = response.Content.ReadFromJsonAsync<CatFact>().Result!;
            TempData["CatFactValue"] = fact.ToString();
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
