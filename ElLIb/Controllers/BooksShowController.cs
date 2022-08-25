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
                List<AddCommentModel> comments = new List<AddCommentModel>();
                foreach (var i in book.Comments)
                {
                    AddCommentModel comment = new AddCommentModel();
                    comment.BookId = book.Id;
                    comment.Text = i.Text;
                    comment.UserEmail = i.UserEmail;
                    comment.Id = i.Id;
                    comments.Add(comment);
                }
                IQueryable<AddCommentModel> qComments = comments.AsQueryable();
                return View("Show", new BookViewModel { Text = book.Text, SubTitle = book.SubTitle, Title = book.Title, BookId = book.Id, TitleImagePath = book.TitleImagePath, Comments = qComments, IsBooking = book.IsBooking });
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }
    }
}
