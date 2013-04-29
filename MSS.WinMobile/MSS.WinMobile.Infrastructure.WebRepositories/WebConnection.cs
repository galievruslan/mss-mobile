using System;
using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.WebRepositories.Utilites;
using log4net;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebConnection : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebConnection));

        public WebServer WebServer { get; private set; }
        private readonly string _username;
        private readonly string _password;

        public CsrfTokenContainer CsrfTokenContainer { get; private set; }
        public CookieContainer CookieContainer { get; private set; }

        public const string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string ContentType = "application/json; charset=utf-8";
        public const string CsrfTokenParamName = "authenticity_token";

        public WebConnection(WebServer webServer, string username, string password)
        {
            WebServer = webServer;
            _username = username;
            _password = password;

            CsrfTokenContainer = new CsrfTokenContainer();
            CookieContainer = new CookieContainer();
            State = ConnectionState.Closed;
        }

        public ConnectionState State { get; private set; }

        public void Open()
        {
            const string logonPath = "users/sign_in";
            const string userParamName = "user";
            const string usernameParamName = "username";
            const string passwordParamName = "password";

            if (State != ConnectionState.Open)
            {
                try
                {
                    CsrfTokenContainer = new CsrfTokenContainer();
                    CookieContainer = new CookieContainer();

                    // Only for get CSRF token
                    Get(RequestFactory.CreateGetRequest(this, logonPath,
                                                        new Dictionary<string, object>()));


                    Post(RequestFactory.CreatePostRequest(this, logonPath,
                                                         new Dictionary<string, object>
                                                             {
                                                                 {
                                                                     userParamName, new Dictionary<string, object>
                                                                         {
                                                                             {usernameParamName, _username},
                                                                             {passwordParamName, _password}
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

        public DateTime ServerTime()
        {
            const string serverTimePath = "synchronization/datetime.json";
            string json = RequestDispatcher.Dispatch(this, RequestFactory.CreateGetRequest(this, serverTimePath));
            return DateTime.Parse(json.Replace("{\"datetime\":\"", string.Empty).Replace("\"}", string.Empty));
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
            const string logoutPath = "users/sign_out";
            RequestDispatcher.Dispatch(this, RequestFactory.CreateGetRequest(this, logoutPath));
        }
    }

    public enum ConnectionState
    {
        Open,
        Closed,
        Corrupted
    }
}
