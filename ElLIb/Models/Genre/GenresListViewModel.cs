using System.Linq;
namespace ElLIb.Models.Genre
{
    public class GenresListViewModel
    {
        public IQueryable<GenreViewModel> Genres { get; set; }
    }
}
