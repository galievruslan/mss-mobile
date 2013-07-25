using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Json;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;

namespace MSS.WinMobile.Synchronizer
{
    public class SettingsSynchronization : Command<bool>
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ManagerSynchronization));

        private readonly IWebServer _webServer;
        private readonly DateTime _updatedAfter;
        private readonly IConfigurationManager _configurationManager;

        public SettingsSynchronization(
            IWebServer webServer,
            IConfigurationManager configurationManager) {
            _webServer = webServer;
            _configurationManager = configurationManager;
        }

        public SettingsSynchronization(
            IWebServer webServer,
            IConfigurationManager configurationManager,
            DateTime updatedAfter)
            : this(webServer, configurationManager)
        {
            _updatedAfter = updatedAfter;
        }

        public override bool Execute()
        {
            try {
                string url;
                var attribute =
                    (UrlAttribute)
                    typeof (SettingsDto).GetCustomAttributes(typeof (UrlAttribute), true)[0];
                if (attribute != null)
                    url = attribute.Url;
                else
                    throw new InvalidOperationException(
                        string.Format("Can't retrieve from web object of type \"{0}\"",
                                      typeof(SettingsDto)));

                var arguments = new Dictionary<string, object>();
                if (_updatedAfter != DateTime.MinValue) {
                    arguments.Add("updated_at", _updatedAfter.ToString("s"));
                }

                HttpWebRequest webRequest = RequestFactory.CreateGetRequest(
                    _webServer.Connect(), url, arguments);
                string json = _webServer.Connect().Get(webRequest);
                var settingsDto = JsonDeserializer.Deserialize<SettingsDto>(json);

                if (settingsDto != null) {
                    _configurationManager.GetConfig("Domain")
                                        .GetSection("Statuses")
                                        .GetSetting("DefaultRoutePointStatusId")
                                        .Value =
                        settingsDto.DefaultRoutePointStatusId.ToString(CultureInfo.InvariantCulture);

                    _configurationManager.GetConfig("Domain")
                                        .GetSection("Statuses")
                                        .GetSetting("DefaultRoutePointAttendedStatusId")
                                        .Value =
                        settingsDto.DefaultRoutePointAttendedStatusId.ToString(
                            CultureInfo.InvariantCulture);

                    _configurationManager.GetConfig("Domain")
                                        .GetSection("PriceLists")
                                        .GetSetting("DefaultPriceListId")
                                        .Value =
                        settingsDto.DefaultPriceListId.ToString(
                            CultureInfo.InvariantCulture);

                    _configurationManager.GetConfig("Domain").Save();
                }
            }
            catch (Exception exception) {
                Log.Error(exception);
                throw;
            }

            return true;
        }
    }
}
