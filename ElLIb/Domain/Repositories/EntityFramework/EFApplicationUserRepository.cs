using ElLIb.Domain.Entities;
using ElLIb.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ElLIb.Domain.Repositories.EntityFramework
{
    public class EFApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext context;
        public EFApplicationUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ApplicationUser> GetApplicationUsers()
        {
            return context.ApplicationUsers;
        }
        public ApplicationUser GetApplicationUserById(string id)
        {
            return context.ApplicationUsers
                .Include(x => x.Bookings)
                .FirstOrDefault(x => x.Id == id);

        }
        public void SaveApplicationUser(ApplicationUser entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteApplicationUser(string id)
        {
            context.ApplicationUsers.Remove(new ApplicationUser() { Id = id });
            context.SaveChanges();
        }
    }
}
