using System;
using System.Collections.Generic;
using System.Linq;
using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Models.Author;
using ElLIb.Models.Book;
using ElLIb.Models.Comment;
using ElLIb.Models.Genre;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ElLIb.Controllers
{
    public class BooksShowController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly DataManager dataManager;
        public BooksShowController(DataManager dataManager, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dataManager = dataManager;
        }
        public IActionResult Index(BookViewModel model)
        {
            if (model.Id != default)
            {
                Book book = dataManager.Books.GetBookById(model.Id);
                string userId = default;
                if (User.Identity.IsAuthenticated)
                {
                    userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                
                List<AddCommentModel> comments = new();
                foreach (var i in book.Comments)
                {
                    AddCommentModel comment = new()
                    {
                        UserId = i.UserId,
                        BookId = book.Id,
                        CommentText = i.Text,
                        UserEmail = i.UserEmail,
                        Id = i.Id,
                        UserName = i.UserName,
                        CreatedDate = i.CreateOn
                    };
                    comments.Add(comment);
                }
                IQueryable<AddCommentModel> qComments = comments.AsQueryable();
                return View("Show", new BookViewModel { Text = book.Text, SubTitle = book.SubTitle, Title = book.Title, Id = book.Id, TitleImagePath = book.TitleImagePath, Comments = qComments, IsBooking = book.IsBooking, Author = book.AuthorName, Genre = book.GenreName, DateAdded = book.DateAdded, CurentUserId =  userId});
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            var books = dataManager.Books.GetBooks();
            var sortBooks = from b in books orderby b.DateAdded select b;
            List<BookViewModel> booksViewModel = new();
            foreach (var item in sortBooks)
            {
                BookViewModel book = new() 
                { 
                    Author = item.AuthorName,
                    Genre = item.GenreName,
                    Id = item.Id,
                    IsBooking = item.IsBooking,
                    SubTitle = item.SubTitle,
                    Text = item.Text,
                    Title = item.Title,
                    TitleImagePath = item.TitleImagePath,
                    DateAdded = item.DateAdded
                };
                booksViewModel.Add(book);
            }
            IQueryable<BookViewModel> qBooks = booksViewModel.AsQueryable();
            return View(new BooksListViewModel {Books = qBooks});
        }
        public IActionResult SearchByAuthor(Guid id)
        {
            if (id != default)
            {
                Author author = dataManager.Author.GetAuthorById(id);
                var books = dataManager.Books.GetBooks();
                var booksByAuthor = from b in books where b.AuthorId == author.Id orderby b.Title select b;
                List<BookViewModel> booksViewModels = new();
                foreach (var book in booksByAuthor)
                {
                    BookViewModel bookViewModel = new()
                    { 
                        IsBooking = book.IsBooking,
                        Author = book.AuthorName,
                        Genre = book.GenreName,
                        Id = book.Id,
                        Title = book.Title,
                        Text = book.Text,
                        TitleImagePath = book.TitleImagePath,
                        SubTitle = book.SubTitle
                    };
                    booksViewModels.Add(bookViewModel);
                }
                IQueryable<BookViewModel> qBooks = booksViewModels.AsQueryable();
                if (qBooks.Any())
                {
                    return View("ShowBooksSort", new BooksListViewModel { Books = qBooks });
                }
                return View("NullPage");
            }
            var authors = dataManager.Author.GetAuthors();
            var sortAuthorsByName = from author in authors orderby author.Name select author;
            List<AuthorViewModel> authorsViewModels = new();
            foreach (var item in sortAuthorsByName)
            {
                AuthorViewModel author = new()
                { 
                    Id = item.Id,
                    Name = item.Name
                };
                authorsViewModels.Add(author);
            }
            IQueryable<AuthorViewModel> qAuthors = authorsViewModels.AsQueryable();
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(new AuthorListViewModel{Authors = qAuthors });
        }
        public IActionResult SearchByGenre(Guid id)
        {
            if (id != default)
            {
                Genre genre = dataManager.Genres.GetGenreById(id);
                var books = dataManager.Books.GetBooks();
                var booksByGenre = from b in books where b.GenreId == genre.Id orderby b.Title select b;
                List<BookViewModel> booksViewModels = new();
                foreach (var book in booksByGenre)
                {
                    BookViewModel bookViewModel = new()
                    {
                        IsBooking = book.IsBooking,
                        Author = book.AuthorName,
                        Genre = book.GenreName,
                        Id = book.Id,
                        Title = book.Title,
                        Text = book.Text,
                        TitleImagePath = book.TitleImagePath,
                        SubTitle = book.SubTitle
                    };
                    booksViewModels.Add(bookViewModel);
                }
                IQueryable<BookViewModel> qBooks = booksViewModels.AsQueryable();
                if (qBooks.Any())
                {
                    return View("ShowBooksSort", new BooksListViewModel { Books = qBooks });
                }
                return View("NullPage");
            }
            var genres = dataManager.Genres.GetGenres();
            var sortGenresByName = from genre in genres orderby genre.Name select genre;
            List<GenreViewModel> genresViewModels = new();
            foreach (var item in sortGenresByName)
            {
                GenreViewModel genre = new()
                { 
                    Id = item.Id,
                    Name = item.Name
                };
                genresViewModels.Add(genre);
            }
            IQueryable<GenreViewModel> qGenre = genresViewModels.AsQueryable();
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(new GenresListViewModel { Genres = qGenre });
        }
    }
}
