using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFCommentsRepository : ICommentRepository
    {
        private readonly AppDbContext context;
        public EFCommentsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments;
        }
        public Comment GetCommentById(Guid id)
        {
            return context.Comments.FirstOrDefault(x => x.Id == id);
        }
        public void SaveComment(Comment entity)
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
        public void DeleteComment(Guid id)
        {
            context.Comments.Remove(new Comment() { Id = id });
            context.SaveChanges();
        }
        public void DeleteCommentRange(string id)
        {
            IEnumerable<Comment> cooments = GetComments();
            var sortCooments = from comment in cooments where comment.UserId == id select comment;
            context.Comments.RemoveRange(sortCooments);
            context.SaveChanges();
        }
    }
}
