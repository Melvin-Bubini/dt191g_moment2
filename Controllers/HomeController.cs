using Microsoft.AspNetCore.Mvc;

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
    }
}
