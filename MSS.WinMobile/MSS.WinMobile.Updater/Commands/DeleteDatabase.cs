using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Updater.Commands {
    public class DeleteDatabase : Command<bool> {
        private readonly TargetConfig _targetConfig;
        private readonly IConfigurationManager _configurationManager;

        public DeleteDatabase(TargetConfig targetConfig, IConfigurationManager configurationManager) {
            _targetConfig = targetConfig;
            _configurationManager = configurationManager;
        }

        public override bool Execute() {
            try {
                Notificate(new TextNotification("Delete old database..."));
                var fileInfo = new FileInfo(_targetConfig.Target);

                string database = _configurationManager.GetConfig("Common")
                                                       .GetSection("Database")
                                                       .GetSetting("FileName")
                                                       .Value;

                if (fileInfo.Directory != null) {
                    string databaseFullPath = Path.Combine(fileInfo.Directory.FullName, database);
                    File.Delete(databaseFullPath);
                }
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
