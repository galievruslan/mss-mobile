using System;

namespace MSS.WinMobile.Common.Observable
{
    public interface IObservable : IDisposable
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);
    }
}
