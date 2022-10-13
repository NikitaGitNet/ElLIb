using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Book;
using ElLIb.Models.Booking;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElLIb.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<ApplicationUser> signInManager;
        public BookingController(DataManager dataManager, IWebHostEnvironment hostingEnviroment, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Booking(BookViewModel model)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(userId);
            if (user == null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            Book book = dataManager.Books.GetBookById(model.Id);
            if (book == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (user.Bookings.Count < 5)
            {
                book.IsBooking = true;
                Booking booking = new()
                {
                    BooksTitle = book.Title,
                    BookId = model.Id,
                    UserEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                    CreateOn = DateTime.Now,
                    FinishedOn = DateTime.Now.AddDays(3),
                    UserId = userId,
                };
                dataManager.Booking.SaveBooking(booking);
                dataManager.Books.SaveBook(book);
                return View(new BookingViewModel { BookId = booking.BookId, CreateOn = booking.CreateOn, FinishedOn = booking.FinishedOn, Id = booking.Id, UserEmail = booking.UserEmail, UserId = booking.UserId, BooksTitle = booking.BooksTitle });
            }
            return View("LimitBooking");
        }
        [HttpPost]
        public IActionResult Delete(Booking booking)
        {
            Book book = dataManager.Books.GetBookById(booking.BookId);
            dataManager.Booking.DeleteBooking(booking.Id);
            book.IsBooking = false;
            dataManager.Books.SaveBook(book);
            return RedirectToAction(nameof(BookingShowController.Index), nameof(BookingShowController).CutController());
        }
        
    }
}
