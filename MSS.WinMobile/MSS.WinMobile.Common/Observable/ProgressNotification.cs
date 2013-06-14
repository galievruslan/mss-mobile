namespace MSS.WinMobile.Common.Observable {
    public class ProgressNotification : INotification {
        public ProgressNotification(int progress) {
            Progress = progress;
        }

        public int Progress { get; private set; }
    }
}
