using System;
using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;

namespace MSS.WinMobile.Updater.Commands {
    public class GetUpdateInfo : Command<UpdateInfo> {
        private readonly IWebConnection _webConnection;
        private readonly IConfigurationManager _configurationManager;
        public GetUpdateInfo(IWebConnection webConnection,
                             IConfigurationManager configurationManager) {
            _webConnection = webConnection;
            _configurationManager = configurationManager;
        }

        public override UpdateInfo Execute() {
            try {
                Notificate(new TextNotification("Get updates info..."));
                string updatePath = _configurationManager.GetConfig("Common")
                                                         .GetSection("Updates")
                                                         .GetSetting("Source")
                                                         .Value;

                HttpWebRequest request = RequestFactory.CreateGetRequest(_webConnection,
                                                                         updatePath,
                                                                         new Dictionary
                                                                             <string, object>());
                HttpWebResponse response = RequestDispatcher.Dispatch(_webConnection, request);

                string jsonUpdateInfo = RequestDispatcher.ProcessResponse(_webConnection, response);
                var updateInfo = Json.JsonDeserializer.Deserialize<UpdateInfo>(jsonUpdateInfo);
                Notificate(new CommandResultNotification("OK"));
                return updateInfo;
            }
            catch (Exception) {
                Notificate(new CommandResultNotification("failed"));
                throw;
            }
        }
    }
}
