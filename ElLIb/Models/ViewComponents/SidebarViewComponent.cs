using ElLIb.Domain;
using ElLIb.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ElLIb.Models.ViewCompanents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;
        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var books = dataManager.Books.GetBooks();
            var sortBooks = from b in books orderby b.DateAdded descending select b;
            List<BookViewModel> booksViewModel = new();
            int count = 0;
            foreach (var item in sortBooks)
            {
                if (count < 5)
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
                        TitleImagePath = item.TitleImagePath
                    };
                    booksViewModel.Add(book);
                    count++;
                }
            }
            return Task.FromResult((IViewComponentResult)View("Default", new BooksListViewModel {Books = booksViewModel }));
        }
    }
}
