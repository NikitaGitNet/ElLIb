using ElLIb.Domain;
using ElLIb.Models.Book;
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
                    Author = book.Author,
                    Genre = book.Genre,
                    Id = book.Id,
                    IsBooking = book.IsBooking,
                    SubTitle = book.SubTitle,
                    Title = book.Title,
                    Text = book.Text,
                    TitleImagePath = book.TitleImagePath,
                };
                booksViewModels.Add(bookViewModel);
            }
            IQueryable<BookViewModel> qBooks = booksViewModels.AsQueryable();
            return View(new BooksListViewModel { Books = qBooks });
        }
        public IActionResult BookingShow()
        {
            return View(dataManager.Booking.GetBookings());
        }
    }
}
