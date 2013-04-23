using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebConnectionFactory : IConnectionFactory<WebConnection>
    {
        private readonly WebServer _webServer;
        private readonly string _username;
        private readonly string _password;
        public WebConnectionFactory(WebServer webServer, string username, string password)
        {
            _webServer = webServer;
            _username = username;
            _password = password;
        }

        private WebConnection _webConnection;
        public WebConnection GetConnection()
        {
            if (_webConnection == null || _webConnection.State == ConnectionState.Corrupted)
            {
                _webConnection = new WebConnection(_webServer, _username, _password);
                _webConnection.Open();
            }

            return _webConnection;
        }
    }
}
