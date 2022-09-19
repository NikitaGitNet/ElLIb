using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class BooksController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public BooksController(DataManager dataManager, IWebHostEnvironment hostingEnviroment)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Book() : dataManager.Books.GetBookById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Book model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnviroment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                if (model.Author != null)
                {
                    var authors = dataManager.Author.GetAuthors();
                    var sortAuthors = from a in authors where model.Author == a.Name select a;
                    if (sortAuthors.Count() <= 0)
                    {
                        Author author = new() { Name = model.Author, Id = new Guid() };
                        dataManager.Author.SaveAuthor(author);
                    }
                }
                else
                {
                    model.Author = "Неизвестный автор";
                }
                if (model.Genre != null)
                {
                    var genres = dataManager.Genres.GetGenres();
                    var sortGenres = from g in genres where model.Genre == g.Name select g;
                    if (sortGenres.Count() <= 0)
                    {
                        Genre genre = new() { Name = model.Genre, Id = new Guid() };
                        dataManager.Genres.SaveGenre(genre);
                    }
                }
                else
                {
                    model.Genre = "Неизвестный жанр";
                }
                model.DateAdded = DateTime.Now;
                dataManager.Books.SaveBook(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        public IActionResult AddGenre(Guid id)
        {
            var entity = id == default ? new Genre() : dataManager.Genres.GetGenreById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult AddGenre(Genre model)
        {
            if (model.Id != default)
            {
                dataManager.Genres.SaveGenre(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            if (ModelState.IsValid)
            {
                IQueryable<Genre> genres = dataManager.Genres.GetGenres();
                foreach (var genre in genres)
                {
                    if (model.Name == genre.Name)
                    {
                        return View("ErrorGenre");
                    }
                }
                dataManager.Genres.SaveGenre(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
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
                Author author = dataManager.Author.GetAuthorById(model.Id);
                var books = dataManager.Books.GetBooks();
                var sortBooks = from b in books where b.Author == author.Name orderby b.Title select b;
                foreach (var book in sortBooks)
                {
                    book.Author = model.Name;
                    dataManager.Books.SaveBook(book);
                }
                dataManager.Author.SaveAuthor(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            if (ModelState.IsValid)
            {
                IQueryable<Author> authors = dataManager.Author.GetAuthors();
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
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Books.DeleteBook(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
