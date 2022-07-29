using ElLIb.Domain.Entities;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IBooksRepository
    {
        IQueryable<Book> GetBooks();
        Book GetBookById(Guid id);
        void SaveBook(Book entity);
        void DeleteBook(Guid id);
    }
}
