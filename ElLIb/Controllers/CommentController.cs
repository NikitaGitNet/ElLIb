using ElLIb.Controllers;
using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
using ElLIb.Models.Book;
using ElLIb.Models.Comment;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElLIb.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IRepository<Book> bookRepository;
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<ApplicationUser> signInManager;
        public CommentController(IWebHostEnvironment hostingEnviroment, IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager, IRepository<Comment> commentRepository, IRepository<ApplicationUser> userRepository, IRepository<Book> bookRepository)
        {
            this.commentRepository = commentRepository;
            this.hostingEnviroment = hostingEnviroment;
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Write(AddCommentModel model)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = userRepository.GetById(new Guid(userId));
            Book book = bookRepository.GetById(model.Id);
            if (user == null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            if (book == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Comment comment = new();
            if (ModelState.IsValid && model.CommentText != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    comment.UserId = userId;
                    comment.BookId = model.Id;
                    comment.Text = model.CommentText;
                    comment.UserName = user.UserName;
                    comment.UserId = user.Id;
                    comment.CreateOn = DateTime.Now;
                    commentRepository.Save(comment);
                    return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController(), new BookViewModel { Id = model.Id });
                } 
            }
            return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController(), new BookViewModel { Id = model.Id, CommentText = model.CommentText });
        }
        [HttpPost]
        public IActionResult Delete(AddCommentModel model)
        {
            commentRepository.Delete(model.Id);
            return RedirectToAction(nameof(BooksShowController.Index), nameof(BooksShowController).CutController(), new BookViewModel { Id = model.BookId });
        }
    }
}
