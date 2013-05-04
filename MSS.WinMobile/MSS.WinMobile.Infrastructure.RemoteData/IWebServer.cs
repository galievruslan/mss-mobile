using System;

namespace MSS.WinMobile.Infrastructure.Web {
    public interface IWebServer : IDisposable {
        string Address { get;}
        IWebConnection Connect();
    }
}
