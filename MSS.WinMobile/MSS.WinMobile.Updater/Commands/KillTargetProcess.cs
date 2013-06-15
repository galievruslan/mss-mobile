using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MSS.WinMobile.Common;
using MSS.WinMobile.Common.Observable;
using OpenNETCF.Win32;

namespace MSS.WinMobile.Updater.Commands {
    public class KillTargetProcess : Command<bool> {
        private readonly TargetConfig _targetConfig;
        public KillTargetProcess(TargetConfig targetConfig) {
            _targetConfig = targetConfig;
        }

        public override bool Execute() {

            try {
                Notificate(new TextNotification("Close updatable application..."));

                // Send close message
                Win32Window theWindow = Win32Window.FindWindow("#NETCF_AGL_BASE_", _targetConfig.TargetWindow);
                if (theWindow != null)
                    Win32Window.SendMessage(theWindow.Handle, (int) WM.CLOSE, 0, 0);

                // Sleep for 3 seconds
                Thread.Sleep(3000);

                // Kill all processes
                var processes = OpenNETCF.ToolHelp.ProcessEntry.GetProcesses();
                foreach (OpenNETCF.ToolHelp.ProcessEntry process in processes)
                {
                    if (process.ExeFile == _targetConfig.Target)
                        process.Kill();
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
