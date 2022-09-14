using System.Linq;
namespace ElLIb.Models.Booking
{
    public class BookingListViewModel
    {
        public IQueryable<BookingViewModel> Bookings { get; set; }
    }
}
