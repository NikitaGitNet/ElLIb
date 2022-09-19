using ElLIb.Domain;
using ElLIb.Models.Booking;
using ElLIb.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class ModeratorBookingShowController : Controller
    {
        private readonly DataManager dataManager;
        public ModeratorBookingShowController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        [HttpPost]
        public IActionResult Delete(BookingViewModel booking)
        {
            var book = dataManager.Books.GetBookById(booking.BookId);
            dataManager.Booking.DeleteBooking(booking.Id);
            book.IsBooking = false;
            dataManager.Books.SaveBook(book);

            return RedirectToAction(nameof(BookingController.Show), nameof(BookingController).CutController());
        }
    }
}
