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

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View("Booking", booking);
            }

            // Hämta tidigare bokningar från session
            var sessionBookings = HttpContext.Session.GetString("Bookings");

            // Om sessionen innehåller bokningar, deserialisera dem, annars skapa en ny lista
            var bookings = string.IsNullOrEmpty(sessionBookings)
                ? new List<Booking>()
                : JsonConvert.DeserializeObject<List<Booking>>(sessionBookings) ?? new List<Booking>();

            // Sätt ID genom att ta det högsta befintliga ID:t + 1
            booking.Id = bookings.Any() ? bookings.Max(b => b.Id) + 1 : 1;

            // Lägg till den nya bokningen
            bookings.Add(booking);

            // Spara tillbaka i sessionen i JSON-format
            HttpContext.Session.SetString("Bookings", JsonConvert.SerializeObject(bookings));
            
            // Rensa formuläret
            ModelState.Clear();

            // TempData används för att skicka en framgångsmeddelande
            TempData["SuccessMessage"] = "Bokningen har registrerats";

            return RedirectToAction("Booking");
        }


        [Route("/Mina-sidor")]
        public IActionResult MyPages()
        {
            var sessionBookings = HttpContext.Session.GetString("Bookings");

            var bookings = string.IsNullOrEmpty(sessionBookings)
                ? new List<Booking>()
                : JsonConvert.DeserializeObject<List<Booking>>(sessionBookings) ?? new List<Booking>();

            ViewBag.TotalBookings = bookings.Count;
            ViewData["LatestBooking"] = bookings.LastOrDefault()?.Name;

            return View(bookings);
        }
    }
}
