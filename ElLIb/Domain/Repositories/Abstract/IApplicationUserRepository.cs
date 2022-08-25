using ElLIb.Domain.Entities;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IApplicationUserRepository
    {
        IQueryable<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(string id);
        void SaveApplicationUser(ApplicationUser entity);
        void DeleteApplicationUser(string id);
    }
}
