using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Author;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class AuthorsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public AuthorsController(DataManager dataManager, IWebHostEnvironment hostingEnviroment)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
        }
        public IActionResult AddAuthor(Guid id)
        {
            var entity = id == default ? new Author() : dataManager.Author.GetAuthorById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult AddAuthor(Author model)
        {
            if (model.Id != default)
            {
                dataManager.Author.SaveAuthor(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            if (ModelState.IsValid)
            {
                IEnumerable<Author> authors = dataManager.Author.GetAuthors();
                foreach (var author in authors)
                {
                    if (model.Name == author.Name)
                    {
                        return View("ErrorAuthor");
                    }
                }
                dataManager.Author.SaveAuthor(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        public IActionResult WarningDeleteAuthor(Guid id)
        {
            Author author = dataManager.Author.GetAuthorById(id);
            IEnumerable<Book> books = dataManager.Books.GetBooks();
            var sortBooks = from book in books where book.AuthorId == author.Id select book;
            if (sortBooks.Any())
            {
                return View(new AuthorViewModel { Id = id, Name = author.Name });
            }
            return RedirectToAction(nameof(AuthorsController.DeleteAuthor), nameof(AuthorsController).CutController(), new AuthorViewModel { Id = id });
        }
        public IActionResult DeleteAuthor(AuthorViewModel model)
        {
            dataManager.Author.DeleteAuthor(model.Id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
        
    }
}
