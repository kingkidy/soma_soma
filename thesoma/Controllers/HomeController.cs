using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using thesoma.Models;

namespace thesoma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return RedirectToPage("/Account/Login", new { area = "Identity"});
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
