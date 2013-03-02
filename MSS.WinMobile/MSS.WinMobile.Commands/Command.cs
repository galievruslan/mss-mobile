using System;
using System.Collections.Generic;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Commands
{
    public abstract class Command<T> : IObservable {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Command<T>));

        protected virtual void PreExecute() {
            Log.InfoFormat("Command {0} pre execution", typeof(Command<T>));
        }

        protected virtual void PostExecute() {
            Log.InfoFormat("Command {0} post execution", typeof(Command<T>));
        }

        protected abstract T Execute();

        public T Do() {
            PreExecute();
            T result = Execute();
            PostExecute();

            return result;
        }

        public void Dispose() {
            while (_observers.Count > 0) {
                Unsubscribe(_observers[0]);
            }
        }

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
    }
}
