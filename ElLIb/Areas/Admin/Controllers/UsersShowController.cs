using ElLIb.Areas.Admin.Models;
using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using ElLIb.Models.Comment;
using ElLIb.Models.User;
using ElLIb.Service;
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

        public IActionResult UsersShow()
        {
            var users = dataManager.ApplicationUser.GetApplicationUsers();
            var sortUsers = from u in users orderby u.UserName select u;
            List<UserViewModel> usersViewModel = new();
            foreach (var user in sortUsers)
            {
                UserViewModel userViewModel = new() 
                {
                    Email = user.Email,
                    CreateOn = user.CreateOn,
                    Id = user.Id,
                    UserName = user.UserName,
                    Bookings = user.Bookings,
                    Comments = user.Comments
                };
                usersViewModel.Add(userViewModel);
            }
            IQueryable<UserViewModel> qUsers = usersViewModel.AsQueryable();
            return View(new UsersListViewModel {Users = qUsers });
        }
        public IActionResult ShowCurentUser(UserModel model)
        {
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(model.Id);
            if (user.Bookings != null)
            {
                if (user.Bookings.Count != 0)
                {
                    List<BookingViewModel> bookings = new();
                    if (user.Bookings.Count != 0)
                    {
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
                    }

                    IQueryable<BookingViewModel> qBookings = bookings.AsQueryable();
                    return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = qBookings, CreateOn = user.CreateOn });
                }
            }
            return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = null, CreateOn = user.CreateOn, Comments = null});

        }
        [HttpPost]
        public IActionResult SearchByEmail(UserModel model)
        {
            if (model.UserEmail != null)
            {
                IQueryable<ApplicationUser> users = dataManager.ApplicationUser.GetApplicationUsers();
                var sortUsers = from u in users where model.UserEmail.ToUpper() == u.Email.ToUpper() select u;
                ApplicationUser applicationUser = new();
                foreach (var user in sortUsers)
                {
                    applicationUser = user;
                }
                return RedirectToAction(nameof(UsersShowController.ShowCurentUser), nameof(UsersShowController).CutController(), new UserModel {Id = applicationUser.Id });
            }
            return RedirectToAction(nameof(UsersShowController.UsersShow), nameof(UsersShowController).CutController());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserModel model)
        {
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(model.Id);
            if (user.Bookings != null)
            {
                foreach (var booking in user.Bookings)
                {
                    Guid bookId = booking.BookId;
                    Book book = dataManager.Books.GetBookById(bookId);
                    book.IsBooking = false;
                    dataManager.Books.SaveBook(book);
                }
                dataManager.Booking.DeleteBookingRange(model.Id);
            }
            if (user.Comments != null)
            {
                dataManager.Comment.DeleteCommentRange(model.Id);
            }
            await userManager.FindByIdAsync(model.Id);
            await userManager.DeleteAsync(user);

            return View("Delete");
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserModel model)
        {
            ApplicationUser user = await userManager.FindByIdAsync(model.Id);
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await userManager.UpdateAsync(user);
            return View(new UserModel {Password = model.Password });
        }
    }
}
