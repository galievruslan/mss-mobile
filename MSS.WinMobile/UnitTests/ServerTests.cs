using System;
using System.Collections.Generic;
using System.Diagnostics;
using MSS.WinMobile.Infrastructure.Server;
using MSS.WinMobile.Infrastructure.Server.Services;
using UnitTests.Asserts;

namespace UnitTests
{
    public static class ServerTests
    {
        public static void ServerLogonTest()
        {
            Console.WriteLine("ServerLogonTest started.");

            Server server = Server.Logon(new Uri(@"http://mss.alkotorg.com/"), "admin", "423200");
            Assert.NotNull(server);

            server.Dispose();
            Console.WriteLine("ServerLogonTest passed.");
        }

        public static void ServerGetTest()
        {
            Console.WriteLine("ServerGetTest started.");

            Server server = Server.Logon(new Uri(@"http://mss.alkotorg.com/"), "admin", "423200");
            var parametersBuilder = new ParametersBuilder();
            string json = server.Get(@"synchronization/managers.json", parametersBuilder.Build());
            Assert.NotEquals(string.Empty, json);
            parametersBuilder.PageNumber(1).ItemsPerPage(1);
            json = server.Get(@"synchronization/managers.json", parametersBuilder.Build());
            Assert.NotEquals(string.Empty, json);
            parametersBuilder.PageNumber(1).ItemsPerPage(1).UpdatedAfter(DateTime.Now);
            json = server.Get(@"synchronization/managers.json", parametersBuilder.Build());
            Assert.NotEquals(string.Empty, json);

            server.Dispose();
            Console.WriteLine("ServerGetTest passed.");
        }
    }
}
