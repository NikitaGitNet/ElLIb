using System.Collections.Generic;
using System.Linq;
using ElLIb.Domain.Entities;
using ElLIb.Models.Booking;
using System;
using ElLIb.Models.Comment;

namespace ElLIb.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public DateTime CreateOn { get; set; }
        public IQueryable<BookingViewModel> Bookings { get; set; }
        public IQueryable<AddCommentModel> Comments { get; set; }
    }
}
