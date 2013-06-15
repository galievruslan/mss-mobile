using System;
using MSS.WinMobile.Common;

namespace MSS.WinMobile.Updater.Commands {
    public class CreateDesktopShortcut : Command<bool> {
        private TargetConfig _targetConfig;
        public CreateDesktopShortcut(TargetConfig targetConfig) {
            
        }

        public override bool Execute() {
            throw new NotImplementedException();
        }
    }
}
