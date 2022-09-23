using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFBooksRepository : IBooksRepository
    {
        private readonly AppDbContext context;
        public EFBooksRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Book> GetBooks()
        {
            return context.Books;
        }
        public Book GetBookById(Guid id)
        {
            return context.Books
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == id);
        }
        public void SaveBook(Book entity)
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
        public void DeleteBook(Guid id)
        {
            context.Books.Remove(new Book() { Id = id });
            context.SaveChanges();
        }
    }
}
