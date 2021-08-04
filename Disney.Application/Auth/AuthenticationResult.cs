using Disney.Domain.Common;
using System.Collections.Generic;

namespace Disney.Application.Auth
{
    public class AuthenticationResult : Result
    {
        public string Token { get; init; }
        public IEnumerable<string> ErrorMessages { get; init; }
    }
}
