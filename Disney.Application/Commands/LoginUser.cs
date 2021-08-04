using System.ComponentModel.DataAnnotations;

namespace Disney.Application.Commands
{
    public class LoginUser
    {
        public LoginUser(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [EmailAddress]
        public string Email { get; init; }

        public string Password { get; init; }
    }
}
