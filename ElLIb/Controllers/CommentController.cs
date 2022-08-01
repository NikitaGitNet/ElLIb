﻿using ElLIb.Domain;
using ElLIb.Domain.Entities;
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
        // сделать эту хуйню асинхронной
        [HttpPost]
        public IActionResult Write(AddCommentModel model)
        {
            var entity = new Comment
            {
                BookId = model.BookId,
                Text = model.Text,
                UserEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                CreateOn = DateTime.Now
            };
            if (ModelState.IsValid)
            {
                dataManager.Comment.SaveComment(entity);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(entity);
        }
    }
}
