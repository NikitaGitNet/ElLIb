using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
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
        private readonly IRepository<Booking> bookingRepository;
        private readonly IRepository<TextField> textFieldRepository;
        public BookingController(IRepository<Booking> bookingRepository, IRepository<TextField> textFieldRepository)
        {
            this.bookingRepository = bookingRepository;
            this.textFieldRepository = textFieldRepository;
        }

        public IActionResult Show(Guid id)
        {
            if (id != default)
            {
                try
                {
                    Booking booking = bookingRepository.GetById(id);
                    return View("~/Areas/Moderator/Views/Booking/CurentBookingShow.cshtml", new BookingViewModel { BookId = booking.BookId, BooksTitle = booking.BooksTitle, FinishedOn = booking.FinishedOn, CreateOn = booking.CreateOn, Id = booking.Id, IssueBooking = booking.IssueBooking, UserEmail = booking.UserEmail, UserId = booking.UserId });
                }
                catch
                {
                    return View("ErrorPage");
                }
                
            }
            var bookings = bookingRepository.GetAll();
            var sortBooks = from booking in bookings orderby booking.CreateOn select booking;
            List<BookingViewModel> bookingViewModels = new();
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
            ViewBag.TextField = textFieldRepository.GetByCodeWord("PageBooks");
            return View("BookingShow", new BookingListViewModel {Bookings = bookingViewModels });
        }
        [HttpPost]
        public IActionResult IssueBooking(Guid id)
        {
            var booking = bookingRepository.GetById(id);
            booking.IssueBooking = true;
            booking.FinishedOn = DateTime.Now.AddDays(7);
            bookingRepository.Save(booking);
            return View(new BookingViewModel {FinishedOn=booking.FinishedOn, Id = booking.Id,  BooksTitle = booking.BooksTitle, CreateOn = booking.CreateOn, BookId = booking.BookId, IssueBooking = booking.IssueBooking, UserEmail = booking.UserEmail, UserId = booking.UserId });
        }
    }
}
