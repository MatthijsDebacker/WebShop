using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<string> images;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            images = new List<string>();
            images.Add("images/bikes/Bike_01.jpg");
            images.Add("images/bikes/Bike_02.jpg");
            images.Add("images/bikes/Bike_03.jpg");
            images.Add("images/bikes/Bike_04.jpg");
        }

        public IActionResult Index()
        {
            var rand = new Random();
            ViewData["LandingImage"] = images[rand.Next(0, images.Count)];
            return View();
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
