using ElLIb.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthorById(Guid id);
        void SaveAuthor(Author entity);
        void DeleteAuthor(Guid id);
    }
}
