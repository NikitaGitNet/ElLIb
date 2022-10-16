using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
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
        private readonly IRepository<Booking> bookingRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<ApplicationUser> signInManager;
        public BookingShowController(IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager, IRepository<Booking> bookingRepository, IRepository<ApplicationUser> userRepository)
        {
            this.bookingRepository = bookingRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = userRepository.GetById(new Guid(userId));
            if (user == null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
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
                return View("Show", new UserModel { Id = user.Id, UserName = user.UserName, Bookings = bookings, UserEmail = user.Email });
            }
            return View("NullPage");
        }
    }
}
