using System;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Web;

namespace MSS.WinMobile.Updater.Commands {
    public class ConnectToUpdateServer : Command<IWebConnection> {
        private readonly IWebServer _webServer;
        public ConnectToUpdateServer(IWebServer webServer) {
            _webServer = webServer;
        }

        public override IWebConnection Execute() {
            try {
                Notificate(new TextNotification("Connecting to the server..."));
                IWebConnection webConnection = _webServer.Connect();
                Notificate(new CommandResultNotification("OK"));
                return webConnection;
            }
            catch (Exception) {
                Notificate(new CommandResultNotification("failed"));
                throw;
            }
        }
    }
}
