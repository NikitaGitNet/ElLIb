using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using ElLIb.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersShowController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<ApplicationUser> userManager;
        public UsersShowController(DataManager dataManager, UserManager<ApplicationUser> userManager)
        {
            this.dataManager = dataManager;
            this.userManager = userManager;
        }

        public IActionResult UsersShow(string id)
        {
            //??? а че это снизу
            if (id != default)
            {

            }
            return View(dataManager.ApplicationUserRepository.GetApplicationUsers());
        }
        public IActionResult ShowCurentUser(string id)
        {
            ApplicationUser user = dataManager.ApplicationUserRepository.GetApplicationUserById(id);
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
                return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = qBookings, CreateOn = user.CreateOn});
            }
            return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = null, CreateOn = user.CreateOn});

        }
        [HttpPost]
        public IActionResult CancelUser(string id)
        {
            ApplicationUser user = dataManager.ApplicationUserRepository.GetApplicationUserById(id);
            foreach (var booking in user.Bookings)
            {
                var bookId = booking.BookId;
                Book book = dataManager.Books.GetBookById(bookId);
                book.IsBooking = false;
                dataManager.Books.SaveBook(book);
                booking.IssueBooking = false;
                dataManager.Booking.SaveBooking(booking);
            }
            return View("~/Areas/Admin/Views/UsersShow/UsersShow.cshtml");
        }
        // сделать удаление как с айдентити юзером
        [HttpPost]
        public IActionResult Delete(string id)
        {
            ApplicationUser user = dataManager.ApplicationUserRepository.GetApplicationUserById(id);
            if (user != null)
            {
                if (user.Bookings != null)
                {
                    foreach (var booking in user.Bookings)
                    {
                        // допилить чтобы брони становились недействительными а потом уже удалялись
                        dataManager.Booking.DeleteBooking(booking.Id);
                    }
                }
                if (user.Comments != null)
                {
                    foreach (var comment in user.Comments)
                    {
                        // допилить чтобы брони становились недействительными а потом уже удалялись
                        dataManager.Comment.DeleteComment(comment.Id);
                    }
                }
            }
            dataManager.ApplicationUserRepository.DeleteApplicationUser(id);
            return View("~/Areas/Admin/Views/UsersShow/UsersShow.cshtml");
        }
    }
}
