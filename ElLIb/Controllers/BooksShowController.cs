using System;
using System.Collections.Generic;
using System.Linq;
using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Book;
using ElLIb.Models.Comment;
using Microsoft.AspNetCore.Mvc;

namespace ElLIb.Controllers
{
    public class BooksShowController : Controller
    {
        private readonly DataManager dataManager;
        public BooksShowController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                Book book = dataManager.Books.GetBookById(id);

                List<AddCommentModel> comments = new();
                foreach (var i in book.Comments)
                {
                    AddCommentModel comment = new()
                    {
                        BookId = book.Id,
                        Text = i.Text,
                        UserEmail = i.UserEmail,
                        Id = i.Id,
                        UserName = i.UserName
                    };
                    comments.Add(comment);
                }
                IQueryable<AddCommentModel> qComments = comments.AsQueryable();
                return View("Show", new BookViewModel { Text = book.Text, SubTitle = book.SubTitle, Title = book.Title, Id = book.Id, TitleImagePath = book.TitleImagePath, Comments = qComments, IsBooking = book.IsBooking });
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            var genres = dataManager.Genres.GetGenres();
            var autors = dataManager.Author.GetAuthors();
            var books = dataManager.Books.GetBooks();
            List<BookViewModel> booksViewModel = new();
            foreach (var b in books)
            {
                BookViewModel book = new()
                {
                    IsBooking = b.IsBooking,
                    Id = b.Id,
                    Title = b.Title,
                    TitleImagePath = b.TitleImagePath,
                    Text = b.Text,
                    SubTitle = b.SubTitle,
                };
                booksViewModel.Add(book);
            }
            IQueryable<BookViewModel> qBooksViewModels = booksViewModel.AsQueryable();
            return View(new BooksListViewModel {Authors = autors, Books = qBooksViewModels, Genres = genres });
        }
        public IActionResult Show(Guid genreId, Guid authorId)
        {
            Genre genre = dataManager.Genres.GetGenreById(genreId);
            Author author = dataManager.Author.GetAuthorById(authorId);
            IQueryable<Book> books = dataManager.Books.GetBooks();
            List<BookViewModel> booksViewModels = new();
            var sortBooks = from b in books where b.Genres == genre && b.Author == author orderby b.Title select b;
            foreach (var item in sortBooks)
            {
                BookViewModel book = new()
                {
                    TitleImagePath = item.TitleImagePath,
                    Text = item.Text,
                    SubTitle = item.SubTitle,
                    Title = item.Title,
                    Id = item.Id
                };
                booksViewModels.Add(book);
            }
            IQueryable<BookViewModel> qBooks = booksViewModels.AsQueryable();
            return View("~/Views/BooksShow/Show.cshtml", new BooksListViewModel {Books = qBooks});
        }
    }
}
