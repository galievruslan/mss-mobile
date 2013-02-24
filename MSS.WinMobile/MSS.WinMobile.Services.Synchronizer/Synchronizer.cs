using System;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Remote.Data;
using log4net;

namespace MSS.WinMobile.Services
{
    public class Synchronizer : IObservable {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Synchronizer));

        private readonly Uri _serverUri;
        private readonly string _userName;
        private readonly string _password;

        private readonly ISession _destinationSession;

        public Synchronizer()
        {
            _serverUri = new Uri(string.Format("http://{0}:{1}/",
                                               ConfigurationManager.AppSettings["ServerAddress"],
                                               ConfigurationManager.AppSettings["ServerPort"]));
            _userName = ConfigurationManager.AppSettings["ServerUsername"];
            _password = ConfigurationManager.AppSettings["ServerPassword"];

            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            _destinationSession = new Infrastructure.Local.Data.Session(databaseName);
        }

        public void Start()
        {
            using (var server = Server.Logon(_serverUri, _userName, _password))
            {
                var customers = new List<Customer>(server.CustomerService.GetCustomers());
                SynchronizeEntity(customers);
                foreach (var customer in customers)
                {
                    SynchronizeEntity(customer.);
                }

                SynchronizeEntity(server.ManagerService.GetManagers());
                SynchronizeEntity(server.UnitOfMeasureService.GetUnitsOfMeasures());
                SynchronizeEntity(server.ProductService.GetProducts());
                SynchronizeEntity(server.StatusService.GetStatuses());
                SynchronizeEntity(server.WarehouseService.GetWarehouses());
                SynchronizeEntity(new[] {server.RouteService.GetToday()});
                SynchronizeEntity(server.PriceListService.GetPriceLists());   
            }
        }

        private void SynchronizeEntity<T>(IEnumerable<T> entities) where T : IEntity {
            NotifyObservers(new Notification(string.Format("{0} syncronization started.", typeof(T))));

            try
            {
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
