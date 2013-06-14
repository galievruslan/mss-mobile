using System;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories;

namespace Updater.Commands {
    public class SetupUpdateServer : Command<IWebServer> {
        private readonly IConfigurationManager _configurationManager;

        public SetupUpdateServer(IConfigurationManager configurationManager) {
            _configurationManager = configurationManager;
        }

        public override IWebServer Execute() {
            try {
                Notificate(new TextNotification("Setting up connection to the server..."));
                string serverAddress = _configurationManager.GetConfig("Common")
                                                            .GetSection("Server")
                                                            .GetSetting("Address")
                                                            .Value;
                string login = _configurationManager.GetConfig("Common")
                                                    .GetSection("Server")
                                                    .GetSetting("Username")
                                                    .Value;
                string password = _configurationManager.GetConfig("Common")
                                                       .GetSection("Server")
                                                       .GetSetting("Password")
                                                       .Value;

                var webServer = new WebServer(serverAddress, login, password);
                Notificate(new CommandResultNotification("OK"));
                return webServer;
            }
            catch (Exception) {
                Notificate(new CommandResultNotification("failed"));
                throw;
            }
        }
    }
}
