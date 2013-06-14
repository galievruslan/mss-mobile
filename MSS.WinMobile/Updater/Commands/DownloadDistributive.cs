using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using Environment = MSS.WinMobile.Application.Environment.Environment;

namespace Updater.Commands {
    public class DownloadDistributive : Command<string> {
        private readonly IWebServer _webServer;
        private readonly UpdateInfo _updateInfo;
        private readonly string _destination;

        public DownloadDistributive(IWebServer webServer, UpdateInfo updateInfo, string destination) {
            _webServer = webServer;
            _updateInfo = updateInfo;
            _destination = destination;
        }

        public override string Execute() {
            try {
                Notificate(new TextNotification("Downloading..."));
                var downloader = new Downloader(_webServer);
                string distributive = Path.Combine(_destination, "distributive.zip");
                downloader.DownloadFile(_updateInfo.File, distributive);
                Notificate(new CommandResultNotification("OK"));
                return Path.Combine(_destination, distributive);
            }
            catch (Exception) {
                Notificate(new CommandResultNotification("failed"));
                throw;
            }
        }
    }
}
