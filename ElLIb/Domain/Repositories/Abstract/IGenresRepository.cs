using ElLIb.Domain.Entities;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IGenresRepository
    {
        IQueryable<Genre> GetGenres();
        Genre GetGenreById(Guid id);
        void SaveGenre(Genre entity);
        void DeleteGenre(Guid id);
    }
}
