using System;
using System.Net;

namespace MSS.WinMobile.Infrastructure.Web {
    public interface IWebConnection : IDisposable {
        void Open();
        ConnectionState State { get; }

        string Address { get; }
        CsrfTokenContainer CsrfTokenContainer { get; }
        CookieContainer CookieContainer { get; }

        DateTime ServerTime();
        string Get(HttpWebRequest httpWebRequest);
        string Post(HttpWebRequest httpWebRequest);
    }

    public enum ConnectionState {
        Open,
        Closed,
        Corrupted
    }
}
