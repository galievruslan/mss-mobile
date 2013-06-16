using System;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Updater.Commands {
    public class RestoreCredentials : Command<bool> {
        private readonly IConfigurationManager _configurationManager;
        public RestoreCredentials(IConfigurationManager configurationManager) {
            _configurationManager = configurationManager;
        }

        public override bool Execute() {
            try {
                Notificate(new TextNotification("Restore credentials..."));
                var newConfigurationManager = new ConfigurationManager(_configurationManager.Path);
                newConfigurationManager.GetConfig("Common")
                                       .GetSection("Server")
                                       .GetSetting("Address")
                                       .Value =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Address")
                                         .Value;
                newConfigurationManager.GetConfig("Common")
                                       .GetSection("Server")
                                       .GetSetting("Username")
                                       .Value =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Username")
                                         .Value;
                newConfigurationManager.GetConfig("Common")
                                       .GetSection("Server")
                                       .GetSetting("Password")
                                       .Value =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Password")
                                         .Value;
                newConfigurationManager.GetConfig("Common")
                                       .GetSection("Localization")
                                       .GetSetting("Current")
                                       .Value =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Localization")
                                         .GetSetting("Current")
                                         .Value;
                newConfigurationManager.GetConfig("Common").Save();
                Notificate(new CommandResultNotification("OK"));
                return true;
            }
            catch (Exception) {
                Notificate(new CommandResultNotification("failed"));
                throw;
            }
        }
    }
}
