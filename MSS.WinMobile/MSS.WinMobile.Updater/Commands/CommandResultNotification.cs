using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Updater.Commands {
    public class CommandResultNotification : INotification {
        public CommandResultNotification(string result) {
            Result = result;
        }

        public string Result { get; private set; }
    }
}
