using System;
using System.Collections.Generic;
using System.Linq;
using ElLIb.Domain;
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
                var entity = dataManager.Books.GetBookById(id);
                var comments = new List<AddCommentModel>();
                foreach (var i in entity.Comments)
                {
                    AddCommentModel comment = new AddCommentModel();
                    comment.BookId = entity.Id;
                    comment.Text = i.Text;
                    comment.UserEmail = i.UserEmail;
                    comments.Add(comment);
                }
                IQueryable<AddCommentModel> qComments = comments.AsQueryable();
                return View("Show", new BookViewModel { BooksCount = entity.BooksCount, Text = entity.Text, SubTitle = entity.SubTitle, Title = entity.Title, BookId = entity.Id, TitleImagePath = entity.TitleImagePath, Comments = qComments });
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }
    }
}
