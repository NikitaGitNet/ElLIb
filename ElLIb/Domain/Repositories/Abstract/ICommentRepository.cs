using ElLIb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(Guid id);
        void SaveComment(Comment entity);
        void DeleteComment(Guid id);
        void DeleteCommentRange(string id);
    }
}
