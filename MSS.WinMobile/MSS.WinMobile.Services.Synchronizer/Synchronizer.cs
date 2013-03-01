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
                NotifyObservers(new ProgressNotification(0));
                SynchronizeCustomers(server);
                NotifyObservers(new ProgressNotification(10));
                SynchronizeManagers(server);
                NotifyObservers(new ProgressNotification(20));
                SynchronizeStatuses(server);
                NotifyObservers(new ProgressNotification(30));
                SynchronizeWarehouses(server);
                NotifyObservers(new ProgressNotification(40));
                SynchronizeUnitsOfMeasure(server);
                NotifyObservers(new ProgressNotification(50));
                SynchronizeCategories(server);
                NotifyObservers(new ProgressNotification(60));
                SynchronizePriceLists(server);
                NotifyObservers(new ProgressNotification(70));
                SynchronizeProducts(server);
                NotifyObservers(new ProgressNotification(90));
                SynchronizeRoutes(server);
                NotifyObservers(new ProgressNotification(100));
            }
        }

        private void SynchronizeCustomers(Server server)
        {
            var customers = new List<Customer>();
            var shippingAddresses = new List<ShippingAddress>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var customersDtos = server.CustomerService.GetCustomers(pageNumber, itemsPerPage);
            while (customersDtos.Length > 0)
            {
                foreach (var customerDto in customersDtos)
                {
                    var customer = new Customer
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

                pageNumber++;
                customersDtos = server.CustomerService.GetCustomers(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeManagers(Server server)
        {
            var managers = new List<Manager>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var managersDtos = server.ManagerService.GetManagers(pageNumber, itemsPerPage);
            while (managersDtos.Length > 0)
            {
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

                pageNumber++;
                managersDtos = server.ManagerService.GetManagers(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeStatuses(Server server)
        {
            var statuses = new List<Status>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var statusesDtos = server.StatusService.GetStatuses(pageNumber, itemsPerPage);
            while (statusesDtos.Length > 0)
            {
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

                pageNumber++;
                statusesDtos = server.StatusService.GetStatuses(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeWarehouses(Server server)
        {
            var warehouses = new List<Warehouse>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var warehousesDtos = server.WarehouseService.GetWarehouses(pageNumber, itemsPerPage);
            while (warehousesDtos.Length > 0)
            {
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

                pageNumber++;
                warehousesDtos = server.WarehouseService.GetWarehouses(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeUnitsOfMeasure(Server server)
        {
            var uoms = new List<UnitOfMeasure>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var uomsDtos = server.UnitOfMeasureService.GetUnitsOfMeasures(pageNumber, itemsPerPage);
            while (uomsDtos.Length > 0)
            {
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

                pageNumber++;
                uomsDtos = server.UnitOfMeasureService.GetUnitsOfMeasures(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeCategories(Server server)
        {
            var categories = new List<Category>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var categoriesDtos = server.CategoryServiceService.GetCategories(pageNumber, itemsPerPage);
            while (categoriesDtos.Length > 0)
            {
                foreach (var categoryDto in categoriesDtos)
                {
                    var category = new Category
                    {
                        Id = categoryDto.Id,
                        Name = categoryDto.Name,
                    };

                    if (categoryDto.CategoryId != 0)
                        category.ParentId = categoryDto.CategoryId;


                    categories.Add(category);
                }
                SynchronizeEntity(categories);
                categories.Clear();

                pageNumber++;
                categoriesDtos = server.CategoryServiceService.GetCategories(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeProducts(Server server)
        {
            var products = new List<Product>();
            var productsUoms = new List<ProductsUnitOfMeasure>();
            var productsPrices = new List<ProductsPrice>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var productsDtos = server.ProductService.GetProducts(pageNumber, itemsPerPage);
            while (productsDtos.Length > 0)
            {
                foreach (var productDto in productsDtos)
                {
                    var product = new Product
                    {
                        Id = productDto.Id,
                        Name = productDto.Name,
                    };
                    if (productDto.CategoryId != 0)
                        product.CategoryId = productDto.CategoryId;

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

                    foreach (var productPriceDto in productDto.ProductPrices)
                    {
                        var productPrice = new ProductsPrice
                        {
                            Id = productPriceDto.Id,
                            ProductId = productDto.Id,
                            PriceListId = productPriceDto.PriceListId,
                            Price = productPriceDto.Price
                        };
                        productsPrices.Add(productPrice);
                    }
                }

                SynchronizeEntity(products);
                SynchronizeEntity(productsUoms);
                SynchronizeEntity(productsPrices);
                products.Clear();
                productsUoms.Clear();
                productsPrices.Clear();

                pageNumber++;
                productsDtos = server.ProductService.GetProducts(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizePriceLists(Server server)
        {
            var priceLists = new List<PriceList>();

            int pageNumber = 1;
            const int itemsPerPage = 1;
            var priceListsDtos = server.PriceListService.GetPriceLists(pageNumber, itemsPerPage);
            while (priceListsDtos.Length > 0)
            {
                foreach (var priceListDto in priceListsDtos)
                {
                    var priceList = new PriceList
                    {
                        Id = priceListDto.Id,
                        Name = priceListDto.Name
                    };
                    priceLists.Add(priceList);
                }

                SynchronizeEntity(priceLists);
                priceLists.Clear();

                pageNumber++;
                priceListsDtos = server.PriceListService.GetPriceLists(pageNumber, itemsPerPage);
            }
        }

        private void SynchronizeRoutes(Server server)
        {
            var routes = new List<Route>();
            var routesPoints = new List<RoutePoint>();

            var routeDto = server.RouteService.GetToday();

            var route = new Route
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
        }

        private void SynchronizeEntity<T>(IEnumerable<T> entities) where T : IEntity {
            NotifyObservers(new TextNotification(string.Format("{0} syncronization started.", typeof(T))));

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

                NotifyObservers(new TextNotification(string.Format("{0} syncronization finished.", typeof(T))));
            }
            catch (Exception)
            {
                NotifyObservers(new TextNotification(string.Format("{0} syncronization failed.", typeof(T))));
            }
        }

        #region IObsevable

        readonly IList<IObserver> _observers = new List<IObserver>();

        private void NotifyObservers(INotification notification)
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
