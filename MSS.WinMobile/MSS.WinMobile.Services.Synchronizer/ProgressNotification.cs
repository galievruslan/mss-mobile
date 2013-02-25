namespace MSS.WinMobile.Services
{
    public class ProgressNotification : INotification
    {
        public ProgressNotification(int progress)
        {
            Progress = progress;
        }

        public int Progress { get; private set; }
    }
}
