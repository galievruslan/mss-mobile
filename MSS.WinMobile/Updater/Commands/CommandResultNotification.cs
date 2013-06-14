using MSS.WinMobile.Common.Observable;

namespace Updater.Commands {
    public class CommandResultNotification : INotification {
        public CommandResultNotification(string result) {
            Result = result;
        }

        public string Result { get; private set; }
    }
}
