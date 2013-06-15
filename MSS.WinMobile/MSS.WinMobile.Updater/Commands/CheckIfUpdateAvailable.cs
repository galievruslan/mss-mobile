using System;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Updater.Commands {
    public class CheckIfUpdateAvailable : Command<bool> {
        private readonly TargetConfig _targetConfig;
        private readonly UpdateInfo _updateInfo;
        public CheckIfUpdateAvailable(TargetConfig targetConfig,
                                   UpdateInfo updateInfo) {
            _targetConfig = targetConfig;
            _updateInfo = updateInfo;
        }

        public override bool Execute() {
            Notificate(new TextNotification("Current version..."));
            var targetVersion = new Version(_targetConfig.TargetVersion);
            Notificate(new CommandResultNotification(targetVersion.ToString()));

            Notificate(new TextNotification("Available version..."));
            var versionToUpdate = new Version(_updateInfo.Version);
            Notificate(new CommandResultNotification(versionToUpdate.ToString()));
            if (versionToUpdate > targetVersion) {
                Notificate(new TextNotification("New version is available."));
                return true;
            }

            Notificate(new TextNotification("Lastest version is installed."));
            return false;
        }
    }
}
