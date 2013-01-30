using System.IO;
using System.Reflection;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.UI.Presenters
{
    public class SynchronizationPresenter : Presenter
    {
        private readonly ISynchronizationView _view;
        private readonly Infrastructure.Remote.Data.Session _remoteSession;
        private readonly Infrastructure.Local.Data.Session _localSession;

        public SynchronizationPresenter(ISynchronizationView view)
        {
            _view = view;
            _remoteSession = new Infrastructure.Remote.Data.Session("192.168.0.102",
                                         3000, "admin", "423200");
            _localSession = new Infrastructure.Local.Data.Session(Path.GetDirectoryName (Assembly.GetExecutingAssembly ().GetName ().CodeBase) + @"/Storage.sdf");
        }

        public void Synchronize()
        {
            var rManagerRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<Manager>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lManagerRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<Manager>(
                    _localSession.GetConnection());

            Manager[] managers = rManagerRepository.Find();
            foreach (var manager in managers)
            {
                lManagerRepository.Add(manager);
            }

            var rCustomerRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<Customer>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lCustomerRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<Customer>(
                    _localSession.GetConnection());
            Customer[] customers = rCustomerRepository.Find();
            foreach (var customer in customers)
            {
                lCustomerRepository.Add(customer);
            }

            var rWarehouseRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<Warehouse>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lWarehouseRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<Warehouse>(
                    _localSession.GetConnection());
            Warehouse[] warehouses = rWarehouseRepository.Find();
            foreach (var warehouse in warehouses)
            {
                lWarehouseRepository.Add(warehouse);
            }

            var rProductRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<Product>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lProductRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<Product>(
                    _localSession.GetConnection());
            Product[] products = rProductRepository.Find();
            foreach (var product in products)
            {
                lProductRepository.Add(product);
            }

            var rStatusRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<Status>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lStatusRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<Status>(
                    _localSession.GetConnection());
            Status[] statuss = rStatusRepository.Find();
            foreach (var status in statuss)
            {
                lStatusRepository.Add(status);
            }

            var rRouteRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<Route>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lRouteRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<Route>(
                    _localSession.GetConnection());
            Route[] routes = rRouteRepository.Find();
            foreach (var route in routes)
            {
                lRouteRepository.Add(route);
            }

            var rUnitOfMeasureRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<UnitOfMeasure>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lUnitOfMeasureRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<UnitOfMeasure>(
                    _localSession.GetConnection());
            UnitOfMeasure[] unitOfMeasures = rUnitOfMeasureRepository.Find();
            foreach (var unitOfMeasure in unitOfMeasures)
            {
                lUnitOfMeasureRepository.Add(unitOfMeasure);
            }

            var rPriceListRepository = new Infrastructure.Remote.Data.Repositories.GenericRepository<PriceList>(
                new Infrastructure.Remote.Data.RequestDispatcher(_remoteSession));

            var lPriceListRepository =
                new Infrastructure.Local.Data.Repositories.GenericRepository<PriceList>(
                    _localSession.GetConnection());
            PriceList[] priceLists = rPriceListRepository.Find();
            foreach (var priceList in priceLists)
            {
                lPriceListRepository.Add(priceList);
            }

            _view.NavigateTo<IMenuView>();
        }

        public void Cancel()
        {
            _view.Exit();
        }
    }
}
