using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0102_Metler.Models;

namespace Mission08_Team0102_Metler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //this is a controller

        public IActionResult Index()
        {
            return View();
        }
    }
}
