using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFAuthorsRepository : IAuthorRepository
    {
        private readonly AppDbContext context;
        public EFAuthorsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Author> GetAuthors()
        {
            return context.Authors;
        }
        public Author GetAuthorById(Guid id)
        {
            return context.Authors.FirstOrDefault(x => x.Id == id);
        }
        public void SaveAuthor(Author entity)
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
        public void DeleteAuthor(Guid id)
        {
            context.Authors.Remove(new Author() { Id = id });
            context.SaveChanges();
        }
    }
}
