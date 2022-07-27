using ElLIb.Domain;
using ElLIb.Domain.Entities;
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
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.ServiceItems.GetServiceItems());
        }
        // сделать эту хуйню асинхронной
        [HttpPost]
        public IActionResult Write(Comment comment)
        {
            comment.ServiceItemId = comment.Id;
            comment.Id = default;
            comment.UserEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            comment.UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            comment.CreateOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                dataManager.Comment.SaveComment(comment);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(comment);
        }
    }
}
