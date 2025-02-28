using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0102_Metler.Models;

namespace Mission08_Team0102_Metler.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }
        //this is a controller

        public IActionResult Index()
        {
            return View();
        }



    }
}
