using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MSS.WinMobile.Infrastructure.WebRepositories.Utilites;
using log4net;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebConnection : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebConnection));

        private const string LogonPath = "users/sign_in";
        private const string LogoutPath = "users/sign_out";
        private const string UserParamName = "user";
        private const string UsernameParamName = "username";
        private const string PasswordParamName = "password";

        public WebServer WebServer { get; private set; }
        private readonly string _username;
        private readonly string _password;

        public CsrfTokenContainer CsrfTokenContainer { get; private set; }
        public CookieContainer CookieContainer { get; private set; }

        public const string USER_AGENT = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string CONTENT_TYPE = "application/json; charset=utf-8";
        public const string CSRF_TOKEN_PARAM_NAME = "authenticity_token";

        public WebConnection(WebServer webServer, string username, string password)
        {
            WebServer = webServer;
            _username = username;
            _password = password;
            State = ConnectionState.Closed;
        }

        public ConnectionState State { get; private set; }

        public void Open()
        {
            if (State != ConnectionState.Open)
            {
                try
                {
                    CsrfTokenContainer = new CsrfTokenContainer();
                    CookieContainer = new CookieContainer();

                    // Only for get CSRF token
                    Get(RequestFactory.CreateGetRequest(this, LogonPath,
                                                        new Dictionary<string, object>()));


                    Post(RequestFactory.CreateGetRequest(this, LogonPath,
                                                         new Dictionary<string, object>
                                                             {
                                                                 {
                                                                     UserParamName, new Dictionary<string, object>
                                                                         {
                                                                             {UsernameParamName, _username},
                                                                             {PasswordParamName, _password}
                                                                         }
                                                                 }
                                                             }));

                    State = ConnectionState.Open;
                }
                catch (Exception exception)
                {
                    Log.Error(exception);
                    State = ConnectionState.Corrupted;
                    throw;
                }
            }
        }

        public string Get(HttpWebRequest httpWebRequest)
        {
            return RequestDispatcher.Dispatch(this, httpWebRequest);
        }

        public string Post(HttpWebRequest httpWebRequest)
        {
            return RequestDispatcher.Dispatch(this, httpWebRequest);
        }

        public void Dispose()
        {
            RequestDispatcher.Dispatch(this, RequestFactory.CreateGetRequest(this, LogoutPath));
        }
    }

    public enum ConnectionState
    {
        Open,
        Closed,
        Corrupted
    }
}
