namespace Disney.Application.Auth
{
    public static class AuthValidationErrorResponses
    {
        public const string UserAlreadyExist = "User with this email address already exists";
        public const string UserOrPasswordAreIncorrect = "User or passwords are incorrect";
        public const string UserDoesNotExist = "User does not exist";
    }
}
