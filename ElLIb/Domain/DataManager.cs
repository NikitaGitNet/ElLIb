using ElLIb.Domain.Repositories.Abstract;

namespace ElLIb.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IBooksRepository Books { get; set; }
        public ICommentRepository Comment { get; set; }
        public IBookingRepository Booking { get; set; }
        public IApplicationUserRepository ApplicationUserRepository { get; set; }
        public DataManager(ITextFieldsRepository textFields, IBooksRepository books, ICommentRepository comment, IBookingRepository booking, IApplicationUserRepository applicationUserRepository)
        {
            TextFields = textFields;
            Books = books;
            Comment = comment;
            Booking = booking;
            ApplicationUserRepository = applicationUserRepository;
        }
    }
}
