using System;

namespace MSS.WinMobile.UI.Views.Views {
    public sealed class DesignMode {
        public static bool IsTrue {

            get {
                return AppDomain.
                    CurrentDomain.
                    FriendlyName.
                    IndexOf("DefaultDomain", StringComparison.Ordinal) >= 0;
            }
        }
    }
}