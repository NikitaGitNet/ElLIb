using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ElLIb.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
