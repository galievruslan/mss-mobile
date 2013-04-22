using System;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebServer
    {
        public WebServer(string address)
        {
            Address = new Uri(address);
        }

        public Uri Address { get; private set; }
    }
}
