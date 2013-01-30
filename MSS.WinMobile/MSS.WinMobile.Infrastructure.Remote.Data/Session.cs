using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class Session : ISession
    {
        public const string CONTENT_TYPE = "application/json; charset=utf-8";
        
        public Session(string address, int port, string username, string password)
        {
            BaseUri = string.Format(@"http://{0}:{1}/", address, port);
            Username = username;
            Password = password;
        }

        public string BaseUri { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public string Cookie { get; set; }
        public string CsrfToken { get; set; }

        public ITransaction BeginTransaction()
        {
            var dispatcher = new RequestDispatcher(this);
            return new Transaction(dispatcher);
        }
    }
}
