namespace MSS.WinMobile.Common.Observable
{
    public interface IObserver
    {
        void Notify(INotification notification);
    }
}
