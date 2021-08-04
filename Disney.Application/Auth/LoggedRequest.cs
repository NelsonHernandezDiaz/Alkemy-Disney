namespace Disney.Application.Auth
{
    public class LoggedRequest
    {
        private string userId;
        public string GetUser() => userId;
        public void SetUser(string userId) => this.userId = userId;
    }
}
