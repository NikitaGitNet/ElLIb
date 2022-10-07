﻿using System;
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
                if (book == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                string userId = default;
                if (User.Identity.IsAuthenticated)
                {
                    userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                List<AddCommentModel> comments = new();
                foreach (var comment in book.Comments)
                {
                    AddCommentModel commentModel = new()
                    {
                        UserId = comment.UserId,
                        BookId = book.Id,
                        CommentText = comment.Text,
                        UserEmail = comment.UserEmail,
                        Id = comment.Id,
                        UserName = comment.UserName,
                        CreatedDate = comment.CreateOn
                    };
                    comments.Add(commentModel);
                }
                return View("Show", new BookViewModel { Text = book.Text, SubTitle = book.SubTitle, Title = book.Title, Id = book.Id, TitleImagePath = book.TitleImagePath, Comments = comments, IsBooking = book.IsBooking, Author = book.AuthorName, Genre = book.GenreName, DateAdded = book.DateAdded, CurentUserId =  userId});
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            IEnumerable<Book> books = dataManager.Books.GetBooks();
            var sortBooks = from book in books orderby book.Title select book;
            List<BookViewModel> booksViewModels = new();
            foreach (var book in sortBooks)
            {
                BookViewModel bookModel = new() 
                { 
                    Author = book.AuthorName,
                    Genre = book.GenreName,
                    Id = book.Id,
                    IsBooking = book.IsBooking,
                    SubTitle = book.SubTitle,
                    Text = book.Text,
                    Title = book.Title,
                    TitleImagePath = book.TitleImagePath,
                    DateAdded = book.DateAdded
                };
                booksViewModels.Add(bookModel);
            }
            return View(new BooksListViewModel {Books = booksViewModels });
        }
        public IActionResult SearchByAuthor(Guid id)
        {
            if (id != default)
            {
                Author author = dataManager.Author.GetAuthorById(id);
                IEnumerable<Book> books = dataManager.Books.GetBooks();
                var sortBooksByAuthor = from book in books where book.AuthorId == author.Id orderby book.Title select book;
                if (sortBooksByAuthor.Any())
                {
                    List<BookViewModel> bookViewModels = new();
                    foreach (var book in sortBooksByAuthor)
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
                        bookViewModels.Add(bookViewModel);
                    }
                    return View("ShowBooksSort", new BooksListViewModel { Books = bookViewModels });
                }
                return View("NullPage");
            }
            IEnumerable<Author> authors = dataManager.Author.GetAuthors();
            var sortAuthorsByName = from author in authors orderby author.Name select author;
            List<AuthorViewModel> authorViewModels = new();
            foreach (var author in sortAuthorsByName)
            {
                AuthorViewModel authorModel = new()
                { 
                    Id = author.Id,
                    Name = author.Name
                };
                authorViewModels.Add(authorModel);
            }
            //Посмотреть на сколько нужна хуйня ниже
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(new AuthorListViewModel{Authors = authorViewModels});
        }
        public IActionResult SearchByGenre(Guid id)
        {
            if (id != default)
            {
                Genre genre = dataManager.Genres.GetGenreById(id);
                IEnumerable<Book> books = dataManager.Books.GetBooks();
                var sortBooksByGenre = from book in books where book.GenreId == genre.Id orderby book.Title select book;
                if (sortBooksByGenre.Any())
                {
                    List<BookViewModel> booksViewModels = new();
                    foreach (var book in sortBooksByGenre)
                    {
                        BookViewModel bookModel = new()
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
                        booksViewModels.Add(bookModel);
                    }
                    return View("ShowBooksSort", new BooksListViewModel { Books = booksViewModels });
                }
                return View("NullPage");
            }
            IEnumerable<Genre> genres = dataManager.Genres.GetGenres();
            var sortGenresByName = from genre in genres orderby genre.Name select genre;
            List<GenreViewModel> genresViewModels = new();
            foreach (var genre in sortGenresByName)
            {
                GenreViewModel genreModel = new()
                { 
                    Id = genre.Id,
                    Name = genre.Name
                };
                genresViewModels.Add(genreModel);
            }
            //посмотреть нужна ли строчка кода ниже
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(new GenresListViewModel { Genres = genresViewModels });
        }
        public IActionResult SearchByName(string name)
        {
            if (name != null)
            {
                IEnumerable<Book> books = dataManager.Books.GetBooks();
                var sortBooks = from book in books where book.Title.ToUpper().Contains(name.ToUpper()) select book;
                if (sortBooks.Any())
                {
                    List<BookViewModel> booksViewModels = new();
                    foreach (var book in sortBooks)
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
                    return View("ShowBooksSort", new BooksListViewModel { Books = booksViewModels });
                }
            }
            return View("NullPage");
        }
    }
}
