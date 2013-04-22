using System;
using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.WebRepositories.Utilites;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebConnection : IDisposable
    {
        private const string LogonPath = "users/sign_in";
        private const string LogoutPath = "users/sign_out";
        private const string UserParamName = "user";
        private const string UsernameParamName = "username";
        private const string PasswordParamName = "password";

        private readonly WebServer _webServer;
        private readonly string _username;
        private readonly string _password;

        private CsrfTokenContainer _csrfTokenContainer;
        private CookieContainer _cookieContainer;

        public const string USER_AGENT = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string CONTENT_TYPE = "application/json; charset=utf-8";
        public const string CSRF_TOKEN_PARAM_NAME = "authenticity_token";

        public WebConnection(WebServer webServer, string username, string password)
        {
            _webServer = webServer;
            _username = username;
            _password = password;
            _state = ConnectionState.Closed;
        }

        private ConnectionState _state;
        public void Open()
        {
            if (_state != ConnectionState.Open)
            {
                _csrfTokenContainer = new CsrfTokenContainer();
                _cookieContainer = new CookieContainer();

                // Only for get CSRF token
                Get(LogonPath, new Dictionary<string, object>());
                Post(LogonPath, new Dictionary<string, object>
                {
                    {
                        UserParamName, new Dictionary<string, object>
                            {
                                {UsernameParamName, _username},
                                {PasswordParamName, _password}
                            }
                    }
                });

                _state = ConnectionState.Open;
            }
        }

        public string Get(string url, Dictionary<string, object> parameters)
        {
            return RequestDispatcher.Dispatch(_csrfTokenContainer, _cookieContainer,
                                              RequestFactory.CreateGetRequest(_csrfTokenContainer, _cookieContainer, _webServer.Address + url,
                                                                              parameters));
        }

        public string Post(string url, Dictionary<string, object> parameters)
        {
            return RequestDispatcher.Dispatch(_csrfTokenContainer, _cookieContainer, RequestFactory.CreatePostRequest(_csrfTokenContainer, _cookieContainer, _webServer.Address + url, parameters));
        }

        public void Dispose()
        {
            RequestDispatcher.Dispatch(_csrfTokenContainer, _cookieContainer, RequestFactory.CreateGetRequest(_csrfTokenContainer, _cookieContainer, LogoutPath));
        }
    }

    public enum ConnectionState
    {
        Open,
        Closed,
        Corrupted
    }
}
