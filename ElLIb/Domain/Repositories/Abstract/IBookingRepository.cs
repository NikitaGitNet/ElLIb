using ElLIb.Domain.Entities;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetBookings();
        Booking GetBookingById(Guid id);
        void SaveBooking(Booking entity);
        void DeleteBooking(Guid id);
    }
}
