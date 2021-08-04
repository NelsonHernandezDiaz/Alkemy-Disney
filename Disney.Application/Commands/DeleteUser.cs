using Disney.Application.Auth;
using System.ComponentModel.DataAnnotations;

namespace Disney.Application.Commands
{
    public class DeleteUser: LoggedRequest
    {
        public DeleteUser(string email)
        {
            Email = email;
        }

        [EmailAddress]
        public string Email { get; init; }
    }
}
