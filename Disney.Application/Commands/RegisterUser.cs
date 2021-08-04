using System.ComponentModel.DataAnnotations;

namespace Disney.Application.Commands
{
    public class RegisterUser
    {
        public string UserName { get; init; }
        [EmailAddress] 
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
