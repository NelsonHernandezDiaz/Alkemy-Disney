using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Context and Constructor
        private readonly DataContext context;
        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        #endregion

        public async Task<IQueryable<User>> GetAllUsers()
        {
            var result = await context.Users
                .Where(x => x.Status == false)
                .OrderBy(x => x.Email)
                .ToListAsync();
            return (IQueryable<User>)result;
        }
        public async Task CreateUser(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateUser(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
        public bool UserExists(string Email)
        {
            return context.Users.Any(x => x.Email == Email);
        }        
    }
}
