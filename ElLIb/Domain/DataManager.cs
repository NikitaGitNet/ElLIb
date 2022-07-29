using ElLIb.Domain.Repositories.Abstract;

namespace ElLIb.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IBooksRepository Books { get; set; }
        public ICommentRepository Comment { get; set; }
        public DataManager(ITextFieldsRepository textFields, IBooksRepository books, ICommentRepository comment)
        {
            TextFields = textFields;
            Books = books;
            Comment = comment;
        }
    }
}
