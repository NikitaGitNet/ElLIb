using ElLIb.Controllers;
using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Book;
using ElLIb.Models.Comment;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;

namespace ElLIb.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CommentController(DataManager dataManager, IWebHostEnvironment hostingEnviroment, IHttpContextAccessor httpContextAccessor)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
            this.httpContextAccessor = httpContextAccessor;
        }
     
        [HttpPost]
        public IActionResult Write(AddCommentModel model)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(userId);
            Comment comment = new();
            if (ModelState.IsValid && model.CommentText != null)
            {
                comment.BookId = model.Id;
                comment.Text = model.CommentText;
                comment.UserName = user.UserName;
                comment.UserId = user.Id;
                comment.CreateOn = DateTime.Now;
                dataManager.Comment.SaveComment(comment);
                return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController(), new BookViewModel {Id = model.Id });
            }
            return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController(), new BookViewModel { Id = model.Id, CommentText = model.CommentText });
        }
        [HttpPost]
        public IActionResult Estimate(AddCommentModel model)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(userId);
            Rating rating = new() 
            { 
                BookId = model.Id,
                RatingValue = model.Rating,
                UserId = userId,
            };
            dataManager.Rating.SaveRating(rating);
            return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController());
        }
        [HttpPost]
        public IActionResult Delete(AddCommentModel model)
        {
            dataManager.Comment.DeleteComment(model.Id);
            return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController(), new BookViewModel { Id = model.BookId });
        }
    }
}
