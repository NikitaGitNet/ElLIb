using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Author;
using ElLIb.Models.Genre;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                    using (FileStream stream = new FileStream(Path.Combine(hostingEnviroment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                if (model.AuthorName != null)
                {
                    IEnumerable<Author> authors = dataManager.Author.GetAuthors();
                    var sortAuthors = from author in authors where model.AuthorName.ToUpper() == author.Name.ToUpper() select author;
                    if (sortAuthors.Count() == 0)
                    {
                        Author author = new() { Name = model.AuthorName, Id = new Guid() };
                        dataManager.Author.SaveAuthor(author);
                        model.AuthorName = author.Name;
                        model.AuthorId = author.Id;
                    }
                    else
                    {
                        foreach (var author in sortAuthors)
                        {
                            model.AuthorName = author.Name;
                            model.AuthorId = author.Id;
                        }
                    }
                }
                else
                {
                    model.AuthorName = "Неизвестный автор";
                    model.AuthorId = new Guid("0bf3eaaa-107f-434e-85bc-49653b07515a");
                }
                if (model.GenreName != null)
                {
                    var genres = dataManager.Genres.GetGenres();
                    var sortGenres = from g in genres where model.GenreName == g.Name select g;
                    if (sortGenres.Count() <= 0)
                    {
                        Genre genre = new() { Name = model.GenreName, Id = new Guid() };
                        dataManager.Genres.SaveGenre(genre);
                        model.GenreName = genre.Name;
                        model.GenreId = genre.Id;
                    }
                    else
                    {
                        foreach (var genre in sortGenres)
                        {
                            model.GenreName = genre.Name;
                            model.GenreId = genre.Id;
                        }
                    }
                }
                else
                {
                    model.GenreName = "Неизвестный жанр";
                    model.GenreId = new Guid("e5372338-ee97-408b-82c2-ab7e3ca6d145");
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
        public IActionResult WarningDeleteGenre(Guid id)
        {
            var genre = dataManager.Genres.GetGenreById(id);
            IQueryable<Book> books = dataManager.Books.GetBooks();
            var sortBooks = from b in books where b.GenreId == genre.Id select b;
            if (sortBooks.Any())
            {
                return View(new GenreViewModel { Id = id, Name = genre.Name });
            }
            return RedirectToAction(nameof(BooksController.DeleteGenre), nameof(BooksController).CutController(), new GenreViewModel { Id = id });
        }
        public IActionResult DeleteGenre(GenreViewModel model)
        {
            dataManager.Genres.DeleteGenre(model.Id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
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
        public IActionResult WarningDeleteAuthor(Guid id)
        {
            var author = dataManager.Author.GetAuthorById(id);
            IQueryable<Book> books = dataManager.Books.GetBooks();
            var sortBooks = from b in books where b.AuthorId == author.Id select b;
            if (sortBooks.Any())
            {
                return View(new AuthorViewModel {Id = id, Name = author.Name });
            }
            return RedirectToAction(nameof(BooksController.DeleteAuthor), nameof(BooksController).CutController(), new AuthorViewModel {Id = id });
        }
        public IActionResult DeleteAuthor(AuthorViewModel model)
        {
            dataManager.Author.DeleteAuthor(model.Id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Books.DeleteBook(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
