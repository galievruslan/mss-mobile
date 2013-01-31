using System;
using MSS.WinMobile.Domain.Models;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fullFilePath = string.Format(@"{0}\{1}",
            //                                    Path.GetDirectoryName(
            //                                        Assembly.GetExecutingAssembly()
            //                                              .GetName()
            //                                              .CodeBase),
            //                                    storageName);

            //var session = new Session("testStorage.sdf");
            //var repository = new GenericRepository<Customer>(session.GetConnection());
            ////var c = new Customer
            ////    {
            ////        Id = 2,
            ////        Name = "Second"
            ////    };
            ////repository.Add(c);


            //var c = repository.GetById(1);
            //repository.Delete(c);

            //var ca = repository.Find();
            //foreach (var customer in ca)
            //{
            //    Console.WriteLine("{0}\t{1}", customer.Id, customer.Name);    
            //}

            //var remoteSession = new MSS.WinMobile.Infrastructure.Remote.Data.Session("192.168.0.102", 3000, "admin", "423200");
            //var rManagerRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<Manager>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var localSession = new MSS.WinMobile.Infrastructure.Local.Data.Session("Storage.sdf");
            //var lManagerRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<Manager>(
            //        localSession.GetConnection());

            //Manager[] managers = rManagerRepository.Find();
            //foreach (var manager in managers)
            //{
            //    lManagerRepository.Add(manager);
            //}

            //var rCustomerRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<Customer>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lCustomerRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<Customer>(
            //        localSession.GetConnection());
            //Customer[] customers = rCustomerRepository.Find();
            //foreach (var customer in customers)
            //{
            //    lCustomerRepository.Add(customer);
            //}

            //var rWarehouseRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<Warehouse>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lWarehouseRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<Warehouse>(
            //        localSession.GetConnection());
            //Warehouse[] warehouses = rWarehouseRepository.Find();
            //foreach (var warehouse in warehouses)
            //{
            //    lWarehouseRepository.Add(warehouse);
            //}

            //var rProductRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<Product>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lProductRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<Product>(
            //        localSession.GetConnection());
            //Product[] products = rProductRepository.Find();
            //foreach (var product in products)
            //{
            //    lProductRepository.Add(product);
            //}

            //var rStatusRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<Status>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lStatusRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<Status>(
            //        localSession.GetConnection());
            //Status[] statuss = rStatusRepository.Find();
            //foreach (var status in statuss)
            //{
            //    lStatusRepository.Add(status);
            //}

            //var rRouteRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<Route>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lRouteRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<Route>(
            //        localSession.GetConnection());
            //Route[] routes = rRouteRepository.Find();
            //foreach (var route in routes)
            //{
            //    lRouteRepository.Add(route);
            //}

            //var rUnitOfMeasureRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<UnitOfMeasure>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lUnitOfMeasureRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<UnitOfMeasure>(
            //        localSession.GetConnection());
            //UnitOfMeasure[] unitOfMeasures = rUnitOfMeasureRepository.Find();
            //foreach (var unitOfMeasure in unitOfMeasures)
            //{
            //    lUnitOfMeasureRepository.Add(unitOfMeasure);
            //}

            //var rPriceListRepository = new MSS.WinMobile.Infrastructure.Remote.Data.Repositories.GenericRepository<PriceList>(
            //    new MSS.WinMobile.Infrastructure.Remote.Data.RequestDispatcher(remoteSession));

            //var lPriceListRepository =
            //    new MSS.WinMobile.Infrastructure.Local.Data.Repositories.GenericRepository<PriceList>(
            //        localSession.GetConnection());
            //PriceList[] priceLists = rPriceListRepository.Find();
            //foreach (var priceList in priceLists)
            //{
            //    lPriceListRepository.Add(priceList);
            //}
            
            Console.Read();
        }
    }
}
