using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElLIb.Controllers
{
    public class BookingController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BookingController(DataManager dataManager, IWebHostEnvironment hostingEnviroment, IHttpContextAccessor httpContextAccessor)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult Booking(AddBookingModel model)
        {
            var book = new Book();
            book = dataManager.Books.GetBookById(model.BookId);
            book.IsBooking = true;
            var entity = new Booking
            {
                BooksTitle = book.Title,
                BookId = model.BookId,
                UserEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                CreateOn = DateTime.Now,
                FinishedOn = DateTime.Now.AddDays(3),
                UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            if (ModelState.IsValid)
            {
                dataManager.Booking.SaveBooking(entity);
                dataManager.Books.SaveBook(book);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(dataManager.Books.GetBooks());
            // Сделать вывод ошибки, если книгу нельзя забронировать
        }
        [HttpPost]
        public IActionResult Delete(Booking booking)
        {
            var book = dataManager.Books.GetBookById(booking.BookId);
            dataManager.Booking.DeleteBooking(booking.Id);
            book.IsBooking = false;
            dataManager.Books.SaveBook(book);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
        public IActionResult IssueBooking(Guid id)
        {
            var booking = dataManager.Booking.GetBookingById(id);
            booking.IssueBooking = true;
            booking.FinishedOn = DateTime.Now.AddDays(7);
            dataManager.Booking.SaveBooking(booking);
            return View("~/Areas/Moderator/Views/Home/CurentBookingShow.cshtml", dataManager.Booking.GetBookingById(id));
        }
    }
}
