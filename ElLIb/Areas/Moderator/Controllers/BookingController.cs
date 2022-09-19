using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class BookingController : Controller
    {
        private readonly DataManager dataManager;
        public BookingController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Show(Guid id)
        {
            if (id != default)
            {
                try
                {
                    Booking booking = dataManager.Booking.GetBookingById(id);
                    return View("~/Areas/Moderator/Views/Booking/CurentBookingShow.cshtml", new BookingViewModel { BookId = booking.BookId, BooksTitle = booking.BooksTitle, FinishedOn = booking.FinishedOn, CreateOn = booking.CreateOn, Id = booking.Id, IssueBooking = booking.IssueBooking, UserEmail = booking.UserEmail, UserId = booking.UserId });
                }
                catch
                {
                    return View("ErrorPage");
                }
                
            }
            var bookings = dataManager.Booking.GetBookings();
            var sortBooks = from b in bookings orderby b.CreateOn select b;
            List<BookingViewModel> bookingViewModels = new List<BookingViewModel>();
            foreach (var item in sortBooks)
            {
                BookingViewModel booking = new()
                { 
                    FinishedOn = item.FinishedOn,
                    BookId = item.BookId,
                    BooksTitle = item.BooksTitle,
                    CreateOn = item.CreateOn,
                    Id = item.Id,
                    IssueBooking = item.IssueBooking,
                    UserEmail = item.UserEmail,
                    UserId = item.UserId
                };
                bookingViewModels.Add(booking);
            }
            IQueryable<BookingViewModel> qBookings = bookingViewModels.AsQueryable();
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View("BookingShow", new BookingListViewModel {Bookings = qBookings});
        }
        [HttpPost]
        public IActionResult IssueBooking(Guid id)
        {
            var booking = dataManager.Booking.GetBookingById(id);
            booking.IssueBooking = true;
            booking.FinishedOn = DateTime.Now.AddDays(7);
            dataManager.Booking.SaveBooking(booking);
            return View(new BookingViewModel {FinishedOn=booking.FinishedOn, Id = booking.Id,  BooksTitle = booking.BooksTitle, CreateOn = booking.CreateOn, BookId = booking.BookId, IssueBooking = booking.IssueBooking, UserEmail = booking.UserEmail, UserId = booking.UserId });
        }
    }
}
