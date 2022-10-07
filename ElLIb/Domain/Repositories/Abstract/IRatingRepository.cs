using ElLIb.Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetRatings();
        Rating GetRatingById(Guid id);
        void SaveRating(Rating entity);
        void DeleteRating(Guid id);
    }
}
