using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using dt191g_moment2.Models;
namespace dt191g_moment2.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }

        [Route("/bokning")]
        public IActionResult Booking()
        {
            return View();
        }

        [Route("/Mina-sidor")]
        public IActionResult MyPages()
        {
            var jsonStr = System.IO.File.ReadAllText("booking.json");
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Booking>>(jsonStr);
            return View(JsonObj);
        }
    }
}
