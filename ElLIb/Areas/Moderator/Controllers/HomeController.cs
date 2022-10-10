using ElLIb.Domain;
using ElLIb.Domain.Entities;
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
                    SubTitle = book.SubTitle,
                    Title = book.Title,
                    Text = book.Text,
                    TitleImagePath = book.TitleImagePath,
                };
                booksViewModels.Add(bookViewModel);
            }
            IEnumerable<Genre> genres = dataManager.Genres.GetGenres();
            var sortGenres = from genre in genres orderby genre.Name select genre;
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
            IEnumerable<Author> authors = dataManager.Author.GetAuthors();
            var sortAuthors = from author in authors orderby author.Name select author;
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
            return View(new BooksListViewModel { Books = booksViewModels, Authors = authorVeiwModels, Genres = genreViewModels });
        }
    }
}
