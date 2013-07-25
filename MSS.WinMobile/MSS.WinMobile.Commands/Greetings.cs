using System.Collections.Generic;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Common;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;

namespace MSS.WinMobile.Synchronizer {
    public class Greetings : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(OrdersSynchronization));

        private readonly IWebServer _webServer;
        public Greetings(IWebServer webServer) {
            _webServer = webServer;
        }

        public override bool Execute() {
            IDictionary<string, object> greetingsParams = new Dictionary<string, object>();
            greetingsParams.Add("client_type", string.Format("Win Mobile ({0})", System.Environment.OSVersion));
            greetingsParams.Add("client_version", Environment.AppVersion);

            IWebConnection webConnection = _webServer.Connect();
            var httpWebRequest = RequestFactory.CreatePostRequest(webConnection,
                                                                  "synchronization/client_information.json",
                                                                  greetingsParams);
            webConnection.Post(httpWebRequest);
            return true;
        }
    }
}
