using ElLIb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Books.GetBooks());
        }
        public IActionResult BookingShow()
        {
            return View(dataManager.Booking.GetBookings());
        }
    }
}
