using ElLIb.Domain.Entities;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAuthors();
        Author GetAuthorById(Guid id);
        void SaveAuthor(Author entity);
        void DeleteAuthor(Guid id);
    }
}
