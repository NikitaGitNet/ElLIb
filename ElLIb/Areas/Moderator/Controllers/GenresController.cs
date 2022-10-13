using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Genre;
using ElLIb.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class GenresController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public GenresController(DataManager dataManager, IWebHostEnvironment hostingEnviroment)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
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
                IEnumerable<Genre> genres = dataManager.Genres.GetGenres();
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
            Genre genre = dataManager.Genres.GetGenreById(id);
            IEnumerable<Book> books = dataManager.Books.GetBooks();
            var sortBooks = from book in books where book.GenreId == genre.Id select book;
            if (sortBooks.Any())
            {
                return View(new GenreViewModel { Id = id, Name = genre.Name });
            }
            return RedirectToAction(nameof(GenresController.DeleteGenre), nameof(GenresController).CutController(), new GenreViewModel { Id = id });
        }
        public IActionResult DeleteGenre(GenreViewModel model)
        {
            dataManager.Genres.DeleteGenre(model.Id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
