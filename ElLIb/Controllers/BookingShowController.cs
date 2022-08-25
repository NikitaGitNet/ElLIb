﻿using ElLIb.Domain;
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
            ApplicationUser user = dataManager.ApplicationUserRepository.GetApplicationUserById(userId);
            if (user.Bookings.Count != 0)
            {
                List<AddBookingModel> bookings = new List<AddBookingModel>();
                foreach (var i in user.Bookings)
                {
                    AddBookingModel booking = new AddBookingModel();
                    booking.IssueBooking = i.IssueBooking;
                    booking.UserEmail = i.UserEmail;
                    booking.UserId = user.Id;
                    booking.CreateOn = i.CreateOn;
                    booking.FinishedOn = i.FinishedOn;
                    booking.BookId = i.BookId;
                    booking.BooksTitle = i.BooksTitle;
                    booking.Id = i.Id;
                    bookings.Add(booking);
                }
                IQueryable<AddBookingModel> qBookings = bookings.AsQueryable();
                return View("~/Views/BookingShow/Show.cshtml", new UserModel { Id = user.Id, UserName = user.UserName, Bookings = qBookings, UserEmail = user.Email });
            }
            return View("~/Views/BookingShow/NullPage.cshtml");
        }
    }
}
