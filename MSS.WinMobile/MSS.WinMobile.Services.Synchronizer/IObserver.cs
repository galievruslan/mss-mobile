namespace MSS.WinMobile.Services
{
    public interface IObserver
    {
        void Notify(INotification notification);
    }
}
