using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiSettings apiSettings;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiSettings> apiSettings)
        {
            this.logger = logger;
            this.apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
        {
            SearchViewModel searchViewModel = new SearchViewModel(apiSettings);
            return View(searchViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}