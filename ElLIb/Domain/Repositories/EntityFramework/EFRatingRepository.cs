using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFRatingRepository : IRatingRepository
    {
        private readonly AppDbContext context;
        public EFRatingRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Rating> GetRatings()
        {
            return context.Ratings;
        }
        public Rating GetRatingById(Guid id)
        {
            return context.Ratings.FirstOrDefault(x => x.Id == id);
        }
        public void SaveRating(Rating entity)
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
        public void DeleteRating(Guid id)
        {
            context.Ratings.Remove(new Rating() { Id = id });
            context.SaveChanges();
        }
    }
}
