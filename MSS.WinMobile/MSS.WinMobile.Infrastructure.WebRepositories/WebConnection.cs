using System;
using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using log4net;

namespace MSS.WinMobile.Infrastructure.Web.Repositories
{
    public class WebConnection : IWebConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebConnection));

        public string Address { get; private set; }
        private readonly string _username;
        private readonly string _password;

        public CsrfTokenContainer CsrfTokenContainer { get; private set; }
        public CookieContainer CookieContainer { get; private set; }

        public const string USER_AGENT = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string CONTENT_TYPE = "application/json; charset=utf-8";
        public const string CSRF_TOKEN_PARAM_NAME = "authenticity_token";

        public WebConnection(string address, string username, string password) {
            Address = address;
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


                    using (HttpWebResponse response = RequestDispatcher.Dispatch(this, RequestFactory.CreatePostRequest(this, logonPath,
                                                         new Dictionary<string, object>
                                                             {
                                                                 {
                                                                     userParamName, new Dictionary<string, object>
                                                                         {
                                                                             {usernameParamName, _username},
                                                                             {passwordParamName, _password}
                                                                         }
                                                                 }
                                                             }))) {
                        RequestDispatcher.ProcessResponse(this, response);
                        if (response.StatusCode != HttpStatusCode.Found)
                            throw new NeedLogonException();
                    }

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
            string json;
            using (HttpWebResponse response = RequestDispatcher.Dispatch(this, RequestFactory.CreateGetRequest(this, serverTimePath))) {
                json = RequestDispatcher.ProcessResponse(this, response);
            }
            return DateTime.Parse(json.Replace("{\"datetime\":\"", string.Empty).Replace("\"}", string.Empty));
        }

        public string Get(HttpWebRequest httpWebRequest)
        {
            using (HttpWebResponse response = RequestDispatcher.Dispatch(this, httpWebRequest)) {
                return RequestDispatcher.ProcessResponse(this, response);
            }
        }

        public string Post(HttpWebRequest httpWebRequest)
        {
            using (HttpWebResponse response = RequestDispatcher.Dispatch(this, httpWebRequest)) {
                return RequestDispatcher.ProcessResponse(this, response);
            }
        }

        public void Dispose()
        {
            try {
                const string logoutPath = "users/sign_out";
                RequestDispatcher.Dispatch(this, RequestFactory.CreateGetRequest(this, logoutPath));
                State = ConnectionState.Closed;
            }
            catch (Exception exception) {
                Log.Error(exception);
            }
        }
    }
}
