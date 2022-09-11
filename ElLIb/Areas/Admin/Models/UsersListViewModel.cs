using System.Linq;
namespace ElLIb.Areas.Admin.Models
{
    public class UsersListViewModel
    {
        public IQueryable<UserViewModel> Users { get; set; }
    }
}
