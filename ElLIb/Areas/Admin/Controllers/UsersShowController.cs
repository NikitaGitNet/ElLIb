using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using ElLIb.Models.Comment;
using ElLIb.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View(dataManager.ApplicationUser.GetApplicationUsers());
        }
        public IActionResult ShowCurentUser(string id)
        {
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(id);
            if (user.Bookings.Count != 0 || user.Comments.Count != 0)
            {
                List<AddCommentModel> comments = new();
                List<AddBookingModel> bookings = new();
                if (user.Bookings.Count != 0)
                {
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
                }
                if (user.Comments.Count != 0)
                {
                    foreach (var i in user.Comments)
                    {
                        AddCommentModel comment = new()
                        {
                            Text = i.Text,
                            UserEmail = i.UserEmail,
                            Id = i.Id,
                            BookId = i.BookId
                        };
                        comments.Add(comment);
                    }
                }
                IQueryable<AddBookingModel> qBookings = bookings.AsQueryable();
                IQueryable<AddCommentModel> qComments = comments.AsQueryable();
                return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = qBookings, CreateOn = user.CreateOn, Comments = qComments });
            }
            return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = null, CreateOn = user.CreateOn, Comments = null});

        }
        [HttpPost]
        public IActionResult CancelUser(string id)
        {
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(id);
            if (user.Bookings != null)
            {
                foreach (var booking in user.Bookings)
                {
                    Guid bookId = booking.BookId;
                    Book book = dataManager.Books.GetBookById(bookId);
                    book.IsBooking = false;
                    dataManager.Books.SaveBook(book);
                }
            }
            foreach (var comment in user.Comments)
            {
                comment.User = null;
                comment.UserId = null;
                dataManager.Comment.SaveComment(comment);
            }
            user.Comments = null;
            user.Bookings = null;
            dataManager.ApplicationUser.SaveApplicationUser(user);
            return View();
        }
        // сделать удаление как с айдентити юзером
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(id);
            await userManager.DeleteAsync(user);
            return View();
        }
    }
}
