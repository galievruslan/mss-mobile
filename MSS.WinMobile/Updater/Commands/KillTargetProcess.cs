using System;
using System.IO;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;
using OpenNETCF.Win32;

namespace Updater.Commands {
    public class KillTargetProcess : Command<bool> {
        private readonly TargetConfig _targetConfig;
        public KillTargetProcess(TargetConfig targetConfig) {
            _targetConfig = targetConfig;
        }

        public override bool Execute() {

            try {
                Notificate(new TextNotification("Close updatable application..."));
                var fileInfo = new FileInfo(_targetConfig.Target);
                // TODO get window name from targetConfig 
                const string windowName = "MSS";

                Win32Window theWindow = Win32Window.FindWindow("#NETCF_AGL_BASE_", windowName);
                if (theWindow != null)
                    Win32Window.SendMessage(theWindow.Handle, (int) WM.CLOSE, 0, 0);
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
