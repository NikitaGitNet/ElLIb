using System;
using System.IO;
using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElLIb.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                if (model.AuthorName != null)
                {
                    var authors = dataManager.Author.GetAuthors();
                    var sortAuthors = from a in authors where model.AuthorName == a.Name select a;
                    if (sortAuthors.Count() <= 0)
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
                }
                model.DateAdded = DateTime.Now;
                dataManager.Books.SaveBook(model);
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
