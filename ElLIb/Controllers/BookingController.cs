using ElLIb.Domain;
using ElLIb.Domain.Entities;
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
        public BookingController(DataManager dataManager, IWebHostEnvironment hostingEnviroment, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Booking(AddBookingModel model)
        {
            Book book = dataManager.Books.GetBookById(model.BookId);
            book.IsBooking = true;
            Booking booking = new Booking
            {
                BooksTitle = book.Title,
                BookId = model.BookId,
                UserEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                CreateOn = DateTime.Now,
                FinishedOn = DateTime.Now.AddDays(3),
                UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            dataManager.Booking.SaveBooking(booking);
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            //user.Bookings = new List<Booking>();
            user.Bookings.Add(booking);
            
            await userManager.UpdateAsync(user);

            if (ModelState.IsValid)
            {
                dataManager.Books.SaveBook(book);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(dataManager.Books.GetBooks());
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
        
    }
}
