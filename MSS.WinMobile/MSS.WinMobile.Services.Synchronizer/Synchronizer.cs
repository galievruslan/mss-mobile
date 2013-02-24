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
                #region Customers synchronization
                var customers = new List<Customer>();
                var shippingAddresses = new List<ShippingAddress>();

                var customersDtos = server.CustomerService.GetCustomers();
                foreach (var customerDto in customersDtos)
                {
                    var customer  = new Customer
                        {
                            Id = customerDto.Id,
                            Name = customerDto.Name
                        };
                    customers.Add(customer);

                    foreach (var shippingAddressDto in customerDto.ShippingAddresses)
                    {
                        var shippingAddress = new ShippingAddress
                            {
                                Id = shippingAddressDto.Id,
                                Name = shippingAddressDto.Name,
                                Address = shippingAddressDto.Address,
                                CustomerId = customerDto.Id
                            };
                        shippingAddresses.Add(shippingAddress);
                    }
                }

                SynchronizeEntity(customers);
                SynchronizeEntity(shippingAddresses);
                customers.Clear();
                shippingAddresses.Clear();
                #endregion

                #region Managers synchronization
                var managers = new List<Manager>();

                var managersDtos = server.ManagerService.GetManagers();
                foreach (var managerDto in managersDtos)
                {
                    var manager = new Manager
                        {
                            Id = managerDto.Id,
                            Name = managerDto.Name
                        };
                    managers.Add(manager);
                }
                SynchronizeEntity(managers);
                managers.Clear();
                #endregion

                #region Statuses synchronization
                var statuses = new List<Status>();

                var statusesDtos = server.StatusService.GetStatuses();
                foreach (var statusDto in statusesDtos)
                {
                    var status = new Status
                    {
                        Id = statusDto.Id,
                        Name = statusDto.Name
                    };
                    statuses.Add(status);
                }
                SynchronizeEntity(statuses);
                statuses.Clear();
                #endregion

                #region Warehouses synchronization
                var warehouses = new List<Warehouse>();

                var warehousesDtos = server.WarehouseService.GetWarehouses();
                foreach (var warehouseDto in warehousesDtos)
                {
                    var warehouse = new Warehouse
                    {
                        Id = warehouseDto.Id,
                        Address = warehouseDto.Address
                    };
                    warehouses.Add(warehouse);
                }
                SynchronizeEntity(warehouses);
                warehouses.Clear();
                #endregion

                #region UnitOfMeasures synchronization
                var uoms = new List<UnitOfMeasure>();

                var uomsDtos = server.UnitOfMeasureService.GetUnitsOfMeasures();
                foreach (var uomDto in uomsDtos)
                {
                    var uom = new UnitOfMeasure
                        {
                            Id = uomDto.Id,
                            Name = uomDto.Name
                        };
                    uoms.Add(uom);
                }
                SynchronizeEntity(uoms);
                uoms.Clear();
                #endregion

                #region Products synchronization
                var products = new List<Product>();
                var productsUoms = new List<ProductsUnitOfMeasure>();

                var productsDtos = server.ProductService.GetProducts();
                foreach (var productDto in productsDtos)
                {
                    var product = new Product
                        {
                            Id = productDto.Id,
                            Name = productDto.Name,
                        };
                    products.Add(product);

                    foreach (var productUomDto in productDto.ProductUnitOfMeasures)
                    {
                        var productUom = new ProductsUnitOfMeasure
                            {
                                Id = productUomDto.Id,
                                ProductId = productDto.Id,
                                UnitOfMeasureId = productUomDto.Id
                            };
                        productsUoms.Add(productUom);
                    }
                }

                SynchronizeEntity(products);
                SynchronizeEntity(productsUoms);
                products.Clear();
                productsUoms.Clear();
                #endregion

                #region PriceLists synchronization
                var priceLists = new List<PriceList>();
                var priceListsLines = new List<PriceListLine>();

                var priceListsDtos = server.PriceListService.GetPriceLists();
                foreach (var priceListDto in priceListsDtos)
                {
                    var priceList = new PriceList
                        {
                            Id = priceListDto.Id,
                            Name = priceListDto.Name
                        };
                    priceLists.Add(priceList);

                    foreach (var priceListLineDto in priceListDto.PriceListLines)
                    {
                        var priceListLine = new PriceListLine
                        {
                            Id = priceListLineDto.Id,
                            ProductId = priceListLineDto.Id,
                            PriceListId = priceListDto.Id,
                            Price = priceListLineDto.Price
                        };
                        priceListsLines.Add(priceListLine);
                    }
                }

                SynchronizeEntity(priceLists);
                SynchronizeEntity(priceListsLines);
                priceLists.Clear();
                priceListsLines.Clear();
                #endregion

                #region Routes synchronization
                var routes = new List<Route>();
                var routesPoints = new List<RoutePoint>();

                var routeDto = server.RouteService.GetToday();
                var route = new Route()
                    {
                        Id = routeDto.Id,
                        Date = routeDto.Date,
                        ManagerId = routeDto.ManagerId
                    };
                routes.Add(route);

                foreach (var routePointDto in routeDto.RoutePoints)
                {
                    var routePoint = new RoutePoint
                        {
                            Id = routePointDto.Id,
                            RouteId = routeDto.Id,
                            ShippingAddressId = routePointDto.ShippingAddressId,
                            StatusId = routePointDto.StatusId
                        };
                    routesPoints.Add(routePoint);
                }

                SynchronizeEntity(routes);
                SynchronizeEntity(routesPoints);
                routes.Clear();
                routesPoints.Clear();
                #endregion
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
                        if (repository.GetById(entity.Id).Id == 0)
                            repository.Add(entity);
                        else
                            repository.Update(entity);
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
