namespace MSS.WinMobile.Infrastructure.Web.Repositories
{
    public class WebServer : IWebServer {
        private readonly string _username;
        private readonly string _password;
        public WebServer(string address, string username, string password) {
            Address = address;
            _username = username;
            _password = password;
        }

        public string Address { get; private set; }

        private IWebConnection _webConnection;
        public IWebConnection Connect() {
            if (_webConnection == null || _webConnection.State == ConnectionState.Corrupted) {
                _webConnection = new WebConnection(Address, _username, _password);
                _webConnection.Open();
            }

            return _webConnection;
        }

        public void Dispose() {
            _webConnection.Dispose();
        }
    }
}
