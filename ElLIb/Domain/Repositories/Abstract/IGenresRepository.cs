using ElLIb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IGenresRepository
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(Guid id);
        void SaveGenre(Genre entity);
        void DeleteGenre(Guid id);
    }
}
