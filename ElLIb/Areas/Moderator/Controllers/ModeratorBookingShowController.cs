using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
using ElLIb.Models.Booking;
using ElLIb.Service;
using Microsoft.AspNetCore.Mvc;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class ModeratorBookingShowController : Controller
    {
        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<Booking> bookingRepository;
        public ModeratorBookingShowController(IRepository<Book> bookRepository, IRepository<Booking> bookingRepository)
        {
            this.bookRepository = bookRepository;
            this.bookingRepository = bookingRepository;
        }
        [HttpPost]
        public IActionResult Delete(BookingViewModel booking)
        {
            Book book = bookRepository.GetById(booking.BookId);
            bookingRepository.Delete(booking.Id);
            book.IsBooking = false;
            bookRepository.Save(book);
            return RedirectToAction(nameof(BookingController.Show), nameof(BookingController).CutController());
        }
    }
}
