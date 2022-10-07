﻿using ElLIb.Areas.Admin.Models;
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
            IEnumerable<ApplicationUser> users = dataManager.ApplicationUser.GetApplicationUsers();
            var sortUsers = from user in users orderby user.UserName select user;
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
            return View(new UsersListViewModel {Users = usersViewModel });
        }
        public IActionResult ShowCurentUser(UserModel model)
        {
            //тестить на работоспособность, переделал условную конструкцию
            if (model != null)
            {
                ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(model.Id);
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
                    return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = bookings, CreateOn = user.CreateOn });
                }
                return View(new UserModel { Id = user.Id, UserEmail = user.Email, UserName = user.UserName, Bookings = null, CreateOn = user.CreateOn, Comments = null });
            }
            return RedirectToAction(nameof(UsersShowController.UsersShow), nameof(UsersShowController).CutController());
        }
        [HttpPost]
        public IActionResult SearchByEmail(UserModel model)
        {
            if (model.UserEmail != null)
            {
                IEnumerable<ApplicationUser> users = dataManager.ApplicationUser.GetApplicationUsers();
                var sortUsers = from user in users where user.Email.ToUpper().Contains(model.UserEmail.ToUpper()) select user;
                List<UserViewModel> userViewModels = new();
                foreach (var user in sortUsers)
                {
                    UserViewModel userViewModel = new()
                    { 
                        Email = user.Email,
                        UserName = user.UserName,
                        CreateOn = user.CreateOn,
                        Id = user.Id
                    };
                    userViewModels.Add(userViewModel);
                }
                //посмотреть можно ли через редирект
                //return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController(), new UsersListViewModel {Users = userViewModels });
                return View("UsersShow", new UsersListViewModel { Users = userViewModels });
            }
            return RedirectToAction(nameof(UsersShowController.UsersShow), nameof(UsersShowController).CutController());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserModel model)
        {
            //тестить на работоспособность, переделал условную конструкцию
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(model.Id);
            if (user.Bookings.Any())
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
            if (user.Comments.Any())
            {
                dataManager.Comment.DeleteCommentRange(model.Id);
            }
            await userManager.FindByIdAsync(model.Id);
            await userManager.IsLockedOutAsync(user);
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
