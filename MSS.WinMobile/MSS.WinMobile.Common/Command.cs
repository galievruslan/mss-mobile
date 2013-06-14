using System;
using System.Collections.Generic;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Common
{
    public abstract class Command<TReturn> : IObservable, IObserver {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Command<TReturn>));

        public abstract TReturn Execute();

        public void Dispose() {
            while (_observers.Count > 0) {
                Unsubscribe(_observers[0]);
            }
        }

        #region IObservable
        readonly List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer) {
            if (!_observers.Contains(observer)) {
                lock (_observers) {
                    _observers.Add(observer);
                }
            }
        }

        public void Unsubscribe(IObserver observer) {
            if (_observers.Contains(observer)) {
                lock (_observers) {
                    _observers.Remove(observer);   
                }
            }
        }

        protected void Notificate(INotification notification) {
            foreach (var observer in _observers) {
                try {
                    observer.Notify(notification);
                }
                catch (Exception exception) {
                    Log.Error(string.Format("Notify observer {0} failed!", observer), exception);
                }
            }
        }

        public virtual void Notify(INotification notification)
        {
            Log.DebugFormat("notification received {0}", notification);
        }
        #endregion
    }
}
