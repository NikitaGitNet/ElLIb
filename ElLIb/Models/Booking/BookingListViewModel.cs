using System.Collections.Generic;
using System.Linq;
namespace ElLIb.Models.Booking
{
    public class BookingListViewModel
    {
        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}
