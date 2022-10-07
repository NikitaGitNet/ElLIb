using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using ElLIb.Models.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElLIb.Controllers
{
    public class BookingShowController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<ApplicationUser> signInManager;
        public BookingShowController(DataManager dataManager, IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager)
        {
            this.dataManager = dataManager;
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(userId);
            if (user == null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            // проверить на работоспособность изменил условие ниже
            if (user.Bookings.Any())
            {
                List<BookingViewModel> bookings = new();
                foreach (var i in user.Bookings)
                {
                    BookingViewModel booking = new()
                    {
                        IssueBooking = i.IssueBooking,
                        UserEmail = i.UserEmail,
                        UserId = user.Id,
                        CreateOn = i.CreateOn,
                        FinishedOn = i.FinishedOn,
                        BookId = i.BookId,
                        BooksTitle = i.BooksTitle,
                        Id = i.Id
                    };
                    bookings.Add(booking);
                }
                return View("~/Views/BookingShow/Show.cshtml", new UserModel { Id = user.Id, UserName = user.UserName, Bookings = bookings, UserEmail = user.Email });
            }
            return View("~/Views/BookingShow/NullPage.cshtml");
        }
    }
}
