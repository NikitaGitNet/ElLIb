using ElLIb.Domain.Entities;
using System.Linq;
using System;
namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IRatingRepository
    {
        IQueryable<Rating> GetRatings();
        Rating GetRatingById(Guid id);
        void SaveRating(Rating entity);
        void DeleteRating(Guid id);
    }
}
