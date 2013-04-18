using System;

namespace MSS.WinMobile.Infrastructure.Server
{
    public class Session
    {
        public Session(Uri uri, string username, string password)
        {
            Uri = uri;
            Username = username;
            Password = password;

            CsrfTokenContainer = new CsrfTokenContainer();
            CookieContainer = new CookieContainer();
        }

        public Uri Uri { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public CsrfTokenContainer CsrfTokenContainer { get; private set; }
        public CookieContainer CookieContainer { get; private set; }

        public const string USER_AGENT = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string CONTENT_TYPE = "application/json; charset=utf-8";
        public const string CSRF_TOKEN_PARAM_NAME = "authenticity_token";
    }
}
