using ElLIb.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class BookingModeratorController : Controller
    {
        private readonly DataManager dataManager;
        public BookingModeratorController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Show(Guid id)
        {
            if (id != default)
            {
                return View("~/Areas/Moderator/Views/Booking/CurentBookingShow.cshtml", dataManager.Booking.GetBookingById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }
        [HttpPost]
        public IActionResult IssueBooking(Guid id)
        {
            var booking = dataManager.Booking.GetBookingById(id);
            booking.IssueBooking = true;
            booking.FinishedOn = DateTime.Now.AddDays(7);
            dataManager.Booking.SaveBooking(booking);
            return View("~/Areas/Moderator/Views/Booking/CurentBookingShow.cshtml", dataManager.Booking.GetBookingById(id));
        }
    }
}
