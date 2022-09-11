using System.Linq;

namespace ElLIb.Models.Author
{
    public class AuthorListViewModel
    {
        public IQueryable<AuthorViewModel> Authors { get; set; }
    }
}
