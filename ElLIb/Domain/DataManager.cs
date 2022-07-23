using ElLIb.Domain.Repositories.Abstract;

namespace ElLIb.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public ICommentRepository Comment { get; set; }
        public DataManager(ITextFieldsRepository textFields, IServiceItemsRepository serviceItems, ICommentRepository comment)
        {
            TextFields = textFields;
            ServiceItems = serviceItems;
            Comment = comment;
        }
    }
}
