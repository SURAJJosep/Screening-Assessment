using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
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
            int count = HttpContext.Session.GetInt32("count") ?? 0;
            ViewBag.Count = count;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Increment()
        {
            int count = HttpContext.Session.GetInt32("count") ?? 0;
            count++;
            HttpContext.Session.SetInt32("count", count);
            return RedirectToAction("Index");
        }

        public IActionResult Clicks()
        {
           int count = HttpContext.Session.GetInt32("count") ?? 0;
           ViewBag.Count = count;
           return View();
        }

        [HttpPost]
        public IActionResult ReverseString(string input)
        {
           ViewBag.Input = input;
           ViewBag.Reversed = new string(input.Reverse().ToArray());
           ViewBag.WordsReversed = string.Join(" ", input.Split(' ').Reverse());
           return View("Reverse");
        }

 
        public IActionResult Reverse()
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
