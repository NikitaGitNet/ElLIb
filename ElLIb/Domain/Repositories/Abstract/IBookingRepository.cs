using ElLIb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBookingById(Guid id);
        void SaveBooking(Booking entity);
        void DeleteBooking(Guid id);
        void DeleteBookingRange(string id);
    }
}
