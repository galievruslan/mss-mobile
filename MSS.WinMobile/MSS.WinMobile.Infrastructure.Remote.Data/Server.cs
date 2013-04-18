using System;
using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Server
{
    public class Server : IDisposable
    {
        private const string LogonPath = "users/sign_in";
        private const string LogoutPath = "users/sign_out";
        private const string UserParamName = "user";
        private const string UsernameParamName = "username";
        private const string PasswordParamName = "password";

        private readonly Session _session;

        protected Server(Session session)
        {
            _session = session;
        }

        public static Server Logon(Uri uri, string username, string password)
        {
            var server = new Server(new Session(uri, username, password));

            // Only for get CSRF token
            server.Get(LogonPath, new Dictionary<string, object>());
            server.Post(LogonPath, new Dictionary<string, object>
                {
                    {
                        UserParamName, new Dictionary<string, object>
                            {
                                {UsernameParamName, username},
                                {PasswordParamName, password}
                            }
                    }
                });

            return server;
        }

        public string Get(string url, Dictionary<string, object> parameters)
        {
            return RequestDispatcher.Dispatch(_session, RequestFactory.CreateGetRequest(_session, url, parameters));
        }

        public string Post(string url, Dictionary<string, object> parameters)
        {
            return RequestDispatcher.Dispatch(_session, RequestFactory.CreatePostRequest(_session, url, parameters));
        }

        public void Dispose()
        {
            RequestDispatcher.Dispatch(_session, RequestFactory.CreateGetRequest(_session, LogoutPath));
        }
    }
}
