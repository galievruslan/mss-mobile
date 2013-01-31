namespace MSS.WinMobile.Services
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);
    }
}
