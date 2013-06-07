using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Json;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using Environment = MSS.WinMobile.Application.Environment.Environment;

namespace MSS.WinMobile.Synchronizer
{
    public class SettingsSynchronization : Command<SettingsDto, SettingsDto>
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ManagerSynchronization));

        private readonly IWebServer _webServer;
        private readonly DateTime _updatedAfter;

        public SettingsSynchronization(
            IWebServer webServer) {
            _webServer = webServer;
        }

        public SettingsSynchronization(
            IWebServer webServer,
            DateTime updatedAfter)
            : this(webServer)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
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
                    var configurationManager = new ConfigurationManager(Environment.AppPath);
                    configurationManager.GetConfig("Domain")
                                        .GetSection("Statuses")
                                        .GetSetting("DefaultRoutePointStatusId")
                                        .Value =
                        settingsDto.DefaultRoutePointStatusId.ToString(CultureInfo.InvariantCulture);

                    configurationManager.GetConfig("Domain")
                                        .GetSection("Statuses")
                                        .GetSetting("DefaultRoutePointAttendedStatusId")
                                        .Value =
                        settingsDto.DefaultRoutePointAttendedStatusId.ToString(
                            CultureInfo.InvariantCulture);

                    configurationManager.GetConfig("Domain").Save();
                }
            }
            catch (Exception exception) {
                Log.Error(exception);
                throw;
            }
        }
    }
}
