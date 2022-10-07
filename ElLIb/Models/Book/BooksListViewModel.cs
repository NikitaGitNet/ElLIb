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
        public IEnumerable<BookViewModel> Books { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
