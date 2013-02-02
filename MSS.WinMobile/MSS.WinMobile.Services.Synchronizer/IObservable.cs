using System;

namespace MSS.WinMobile.Services
{
    public interface IObservable : IDisposable
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);
    }
}
