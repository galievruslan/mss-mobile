using System;

using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class CookieContainer
    {
        public const string REQUESTHEADER_SESSIONCOOKIE = "Cookie";
        public const string RESPONSEHEADER_SESSIONCOOKIE = "Set-Cookie";

        public string Cookie { get; private set; }

        public void SetCookie(string cookie)
        {
            Cookie = cookie;
        }
    }
}
