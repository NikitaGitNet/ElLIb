using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFGenresRepository : IGenresRepository
    {
        private readonly AppDbContext context;
        public EFGenresRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Genre> GetGenres()
        {
            return context.Genres;
        }
        public Genre GetGenreById(Guid id)
        {
            return context.Genres.FirstOrDefault(x => x.Id == id);
        }
        public void SaveGenre(Genre entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteGenre(Guid id)
        {
            context.Genres.Remove(new Genre() { Id = id });
            context.SaveChanges();
        }
    }
}
