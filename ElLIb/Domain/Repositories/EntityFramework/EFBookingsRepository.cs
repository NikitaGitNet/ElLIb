using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFBookingsRepository : IBookingRepository
    {
        private readonly AppDbContext context;
        public EFBookingsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Booking> GetBookings()
        {
            return context.Bookings;
        }
        public Booking GetBookingById(Guid id)
        {
            return context.Bookings.FirstOrDefault(x => x.Id == id);
        }
        public void SaveBooking(Booking entity)
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
        public void DeleteBooking(Guid id)
        {
            context.Bookings.Remove(new Booking() { Id = id });
            context.SaveChanges();
        }
        public void DeleteBookingRange(string id)
        {
            var bookings = GetBookings();
            var sortBookings = from b in bookings where b.UserId == id select b;
            context.Bookings.RemoveRange(sortBookings);
            context.SaveChanges();
        }
    }
}
