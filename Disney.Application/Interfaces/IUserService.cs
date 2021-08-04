using Disney.Application.Auth;
using Disney.Application.Commands;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<AuthenticationResult> LoginUser(LoginUser request);
        Task<AuthenticationResult> RegisterUser(RegisterUser request);
        Task<Result> DeleteUser(DeleteUser request);
    }
}
