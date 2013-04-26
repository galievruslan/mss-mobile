using System;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebServer
    {
        public WebServer(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}
