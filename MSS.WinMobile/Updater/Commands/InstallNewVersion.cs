using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;

namespace Updater.Commands {
    public class InstallNewVersion : Command<bool> {
        private string _distributive;
        public InstallNewVersion(string distributive) {
            _distributive = distributive;
        }

        public override bool Execute() {
            try {
                Notificate(new TextNotification("Installation..."));
                var processStartInfo = new ProcessStartInfo(@"\Windows\wceload.exe",
                                                            "/noui \"" + _distributive +
                                                            "\"");
                var process = new Process {StartInfo = processStartInfo};
                process.Start();

                while (!process.HasExited) {
                    process.WaitForExit(500);
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
