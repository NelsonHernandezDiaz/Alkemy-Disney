using Disney.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllUsers();
        Task CreateUser(User entity);
        Task UpdateUser(User entity);
        bool UserExists(string Email);
    }
}
