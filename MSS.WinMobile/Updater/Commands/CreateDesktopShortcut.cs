using System;

using System.Collections.Generic;
using System.Text;
using MSS.WinMobile.Common;

namespace Updater.Commands {
    public class CreateDesktopShortcut : Command<bool> {
        private TargetConfig _targetConfig;
        public CreateDesktopShortcut(TargetConfig targetConfig) {
            
        }

        public override bool Execute() {
            throw new NotImplementedException();
        }
    }
}
