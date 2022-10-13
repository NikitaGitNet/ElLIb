using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Author;
using ElLIb.Models.Book;
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
                    if (sortAuthors.Any())
                    {
                        model.AuthorName = sortAuthors.First().Name;
                        model.AuthorId = sortAuthors.First().Id;
                    }
                    else
                    {
                        Author author = new(){Name = model.AuthorName, Id = new Guid()};
                        dataManager.Author.SaveAuthor(author);
                        model.AuthorName = author.Name;
                        model.AuthorId = author.Id;
                    }
                }
                else
                {
                    model.AuthorName = UnknownAuthor.Name;
                    model.AuthorId = new Guid(UnknownAuthor.Id);
                }
                if (model.GenreName != null)
                {
                    var genres = dataManager.Genres.GetGenres();
                    var sortGenres = from g in genres where model.GenreName == g.Name select g;
                    if (sortGenres.Any())
                    {
                        model.GenreId = sortGenres.First().Id;
                        model.GenreName = sortGenres.First().Name;
                    }
                    else
                    {
                        Genre genre = new() { Name = model.GenreName, Id = new Guid() };
                        dataManager.Genres.SaveGenre(genre);
                        model.GenreName = genre.Name;
                        model.GenreId = genre.Id;
                    }
                }
                else
                {
                    model.GenreName = UnknownGenre.Name;
                    model.GenreId = new Guid(UnknownGenre.Id);
                }
                model.DateAdded = DateTime.Now;
                dataManager.Books.SaveBook(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        public IActionResult SearchByName(BookViewModel model)
        {
            if (model.Title != null)
            {
                IEnumerable<Book> books = dataManager.Books.GetBooks();
                var sortBooks = from book in books where book.Title.ToUpper().Contains(model.Title.ToUpper()) select book;
                List<BookViewModel> bookViewModels = new();
                foreach (var book in sortBooks)
                {
                    BookViewModel bookViewModel = new()
                    {
                        Title = book.Title,
                        Id = book.Id,
                        Author = book.AuthorName,
                        Genre = book.GenreName,
                        IsBooking = book.IsBooking,
                        TitleImagePath = book.TitleImagePath
                    };
                    bookViewModels.Add(bookViewModel);
                }
                return View("BooksShow", new BooksListViewModel { Books = bookViewModels});
            }
            return RedirectToAction(nameof(BooksController.BooksShow), nameof(BooksController).CutController());
        }
        public IActionResult BooksShow()
        {
            IEnumerable<Book> books = dataManager.Books.GetBooks();
            var sortBooks = from book in books orderby book.Title select book;
            List<BookViewModel> booksViewModels = new();
            foreach (Book book in sortBooks)
            {
                BookViewModel bookViewModel = new()
                {
                    Author = book.AuthorName,
                    Genre = book.GenreName,
                    Id = book.Id,
                    IsBooking = book.IsBooking,
                    Title = book.Title,
                    TitleImagePath = book.TitleImagePath,
                };
                booksViewModels.Add(bookViewModel);
            }
            return View(new BooksListViewModel{Books = booksViewModels});
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Books.DeleteBook(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
