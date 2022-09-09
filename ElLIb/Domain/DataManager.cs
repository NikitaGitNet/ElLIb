using ElLIb.Domain.Repositories.Abstract;

namespace ElLIb.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IBooksRepository Books { get; set; }
        public ICommentRepository Comment { get; set; }
        public IBookingRepository Booking { get; set; }
        public IApplicationUserRepository ApplicationUser { get; set; }
        public IGenresRepository Genres { get; set; }
        public IAuthorRepository Author { get; set; }
        public DataManager(ITextFieldsRepository textFields, IBooksRepository books, ICommentRepository comment, IBookingRepository booking, IApplicationUserRepository applicationUser, IGenresRepository genres, IAuthorRepository author)
        {
            TextFields = textFields;
            Books = books;
            Comment = comment;
            Booking = booking;
            ApplicationUser = applicationUser;
            Genres = genres;
            Author = author;
        }
    }
}
