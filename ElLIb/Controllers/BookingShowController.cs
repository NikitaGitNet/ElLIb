using ElLIb.Domain;
using ElLIb.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ElLIb.Controllers
{
    public class BookingShowController : Controller
    {
        private readonly DataManager dataManager;
        public BookingShowController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                var entity = dataManager.Booking.GetBookingById(id);
                return View("Show", new AddBookingModel { BookId = entity.BookId, BooksCount = entity.BooksCount, CreateOn = entity.CreateOn, FinishedOn = entity.FinishedOn, Id = entity.Id, UserEmail = entity.UserEmail, UserId = entity.UserId, BooksTitle = entity.BooksTitle });
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }
        public IActionResult BookingShow(Guid id)
        {
            if (id != default)
            {
                return View("~/Areas/Moderator/Views/Home/CurentBookingShow.cshtml", dataManager.Booking.GetBookingById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }
    }
}
