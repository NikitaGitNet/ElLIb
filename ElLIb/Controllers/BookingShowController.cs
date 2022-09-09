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
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        public BookingShowController(DataManager dataManager, IWebHostEnvironment hostingEnviroment, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(userId);
            if (user.Bookings.Count != 0)
            {
                List<AddBookingModel> bookings = new();
                foreach (var i in user.Bookings)
                {
                    AddBookingModel booking = new()
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
                IQueryable<AddBookingModel> qBookings = bookings.AsQueryable();
                return View("~/Views/BookingShow/Show.cshtml", new UserModel { Id = user.Id, UserName = user.UserName, Bookings = qBookings, UserEmail = user.Email });
            }
            return View("~/Views/BookingShow/NullPage.cshtml");
        }
    }
}
