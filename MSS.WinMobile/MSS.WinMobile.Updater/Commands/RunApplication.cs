using System;
using System.Diagnostics;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Updater.Commands {
    public class RunApplication : Command<bool> {
        private readonly TargetConfig _targetConfig;
        public RunApplication(TargetConfig targetConfig) {
            _targetConfig = targetConfig;
        }

        public override bool Execute() {
            try {
                Notificate(new TextNotification("Start updated application..."));
                var process = new Process {
                    StartInfo = new ProcessStartInfo {FileName = _targetConfig.Target, UseShellExecute = true}
                };
                process.Start();
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
