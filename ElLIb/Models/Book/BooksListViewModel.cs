using ElLIb.Domain.Entities;
using ElLIb.Models.Author;
using ElLIb.Models.Genre;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Models.Book
{
    public class BooksListViewModel
    {
        public IQueryable<BookViewModel> Books { get; set; }
        public IQueryable<GenreViewModel> Genres { get; set; }
        public IQueryable<AuthorViewModel> Authors { get; set; }
    }
}
