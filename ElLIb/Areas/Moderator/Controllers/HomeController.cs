using ElLIb.Domain;
using ElLIb.Models.Author;
using ElLIb.Models.Book;
using ElLIb.Models.Genre;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var books = dataManager.Books.GetBooks();
            var sortBooks = from b in books orderby b.Title select b;
            List<BookViewModel> booksViewModels = new();
            foreach (var book in sortBooks)
            {
                BookViewModel bookViewModel = new()
                {
                    Author = book.AuthorName,
                    Genre = book.GenreName,
                    Id = book.Id,
                    IsBooking = book.IsBooking,
                    SubTitle = book.SubTitle,
                    Title = book.Title,
                    Text = book.Text,
                    TitleImagePath = book.TitleImagePath,
                };
                booksViewModels.Add(bookViewModel);
            }
            var genres = dataManager.Genres.GetGenres();
            var sortGenres = from g in genres orderby g.Name select g;
            List<GenreViewModel> genreViewModels = new();
            foreach (var genre in sortGenres)
            {
                GenreViewModel model = new()
                {
                    Id = genre.Id,
                    Name = genre.Name
                };
                genreViewModels.Add(model);
            }
            var authors = dataManager.Author.GetAuthors();
            var sortAuthors = from a in authors orderby a.Name select a;
            List<AuthorViewModel> authorVeiwModels = new();
            foreach (var author in sortAuthors)
            {
                AuthorViewModel model = new()
                {
                    Id = author.Id,
                    Name = author.Name
                };
                authorVeiwModels.Add(model);
            }
            IQueryable<AuthorViewModel> qAuthors = authorVeiwModels.AsQueryable();
            IQueryable<GenreViewModel> qGenres = genreViewModels.AsQueryable();
            IQueryable<BookViewModel> qBooks = booksViewModels.AsQueryable();
            return View(new BooksListViewModel { Books = qBooks, Authors = qAuthors, Genres = qGenres });
        }
    }
}
