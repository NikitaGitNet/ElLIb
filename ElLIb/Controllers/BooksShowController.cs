using System;
using ElLIb.Domain;
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
                return View("Show", dataManager.Books.GetBookById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBooks");
            return View(dataManager.Books.GetBooks());
        }
    }
}
