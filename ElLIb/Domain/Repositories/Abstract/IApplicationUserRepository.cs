using ElLIb.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(string id);
        void SaveApplicationUser(ApplicationUser entity);
        void DeleteApplicationUser(string id);
    }
}
