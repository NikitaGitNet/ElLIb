using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

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
            // исправить дрочь с айди
            var entity = new Booking
            {
                BooksTitle = model.BookTitle,
                BookId = model.BookId,
                UserEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                CreateOn = DateTime.Now,
                FinishedOn = DateTime.Now.AddDays(3),
                UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            };
            entity.BooksCount++;
            // Сделать вывод ошибки, если книгу нельзя забронировать
            if (ModelState.IsValid)
            {
                dataManager.Booking.SaveBooking(entity);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(dataManager.Books.GetBooks());
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Booking.DeleteBooking(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
