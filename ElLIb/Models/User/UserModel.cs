using System.Collections.Generic;
using System.Linq;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;

namespace ElLIb.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public IQueryable<AddBookingModel> Bookings { get; set; }
    }
}
