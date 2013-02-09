using System;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using log4net;

namespace MSS.WinMobile.Services
{
    public class Synchronizer : IObservable {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Synchronizer));

        private readonly ISession _sourceSession;
        private readonly ISession _destinationSession;

        public Synchronizer()
        {
            string serverAddress = ConfigurationManager.AppSettings["ServerAddress"];
            int serverPort = Int32.Parse(ConfigurationManager.AppSettings["ServerPort"]);
            string userName = ConfigurationManager.AppSettings["ServerUserName"];
            string userPassword = ConfigurationManager.AppSettings["ServerUserPassword"];

            _sourceSession = new Infrastructure.Remote.Data.Session(serverAddress, serverPort,
                                                                    userName, userPassword);

            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            _destinationSession = new Infrastructure.Local.Data.Session(databaseName);
        }

        public void Start()
        {
            SynchronizeEntity<Customer>();
            SynchronizeEntity<ShippingAddress>();
            SynchronizeEntity<Manager>();
            SynchronizeEntity<Product>();
            SynchronizeEntity<UnitOfMeasure>();
            SynchronizeEntity<Status>();
            SynchronizeEntity<Warehouse>();
            SynchronizeEntity<Route>();
            SynchronizeEntity<RoutePoint>();
            SynchronizeEntity<PriceList>();
        }

        private void SynchronizeEntity<T>() where T : IEntity {
            NotifyObservers(new Notification(string.Format("{0} syncronization started.", typeof(T))));

            try
            {
                var entities = new List<T>();
                using (ITransaction sourceTransaction = _sourceSession.BeginTransaction())
                {
                    IGenericRepository<T> repository = sourceTransaction.Resolve<T>();
                    entities.AddRange(repository.Find());
                }

                using (ITransaction destinationTransaction = _destinationSession.BeginTransaction())
                {
                    IGenericRepository<T> repository = destinationTransaction.Resolve<T>();
                    foreach (var entity in entities)
                    {
                        repository.Add(entity);
                    }

                    destinationTransaction.Commit();
                }

                NotifyObservers(new Notification(string.Format("{0} syncronization finished.", typeof(T))));
            }
            catch (Exception)
            {
                NotifyObservers(new Notification(string.Format("{0} syncronization failed.", typeof(T))));
            }
        }

        #region IObsevable

        readonly IList<IObserver> _observers = new List<IObserver>();

        private void NotifyObservers(Notification notification)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.Notify(notification);
                }
                catch(Exception exception)
                {
                    Log.Error("Observer notification failed", exception);
                }
            }
        }

        public void Subscribe(IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }

        public void Dispose()
        {
            while (_observers.Count > 0)
            {
                Unsubscribe(_observers[0]);
            }
        }

        #endregion
    }
}
