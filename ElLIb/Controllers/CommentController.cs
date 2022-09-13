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
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Comment.GetCommentById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }

        [HttpPost]
        public IActionResult Write(AddCommentModel model)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = dataManager.ApplicationUser.GetApplicationUserById(userId);
            Comment comment = new();
            if (ModelState.IsValid)
            {
                comment.BookId = model.Id;
                comment.Text = model.CommentText;
                comment.UserName = user.UserName;
                comment.UserId = user.Id;
                comment.CreateOn = DateTime.Now;
                dataManager.Comment.SaveComment(comment);
                return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController());
            }
            return View(comment);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Comment.DeleteComment(id);
            return RedirectToAction(nameof(BooksShowController.Index), nameof(HomeController).CutController());
        }
    }
}
