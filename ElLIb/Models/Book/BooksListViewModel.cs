using ElLIb.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Models.Book
{
    public class BooksListViewModel
    {
        public IQueryable<BookViewModel> Books { get; set; }
        public IQueryable<Author> Authors { get; set; }
        public IQueryable<Genre> Genres { get; set; }
    }
}
