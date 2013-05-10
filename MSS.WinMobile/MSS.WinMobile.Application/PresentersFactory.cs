using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.Application {
    public class PresentersFactory : IPresentersFactory {
        private readonly IStorageManager _storageManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IModelsFactory _modelsFactory;

        public PresentersFactory(IStorageManager storageManager,
                                 IRepositoryFactory repositoryFactory,
                                 IModelsFactory modelsFactory) {
            _storageManager = storageManager;
            _unitOfWorkFactory = new SqLiteUnitOfWorkFactory(_storageManager);
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
        }

        public LogonPresenter CreateLogonPresenter(ILogonView logonView) {
            return new LogonPresenter(logonView);
        }

        public SynchronizationPresenter CreateSynchronizationPresenter(
            ISynchronizationView synchronizationView) {
            return new SynchronizationPresenter(synchronizationView, _storageManager,
                                                _unitOfWorkFactory,
                                                _repositoryFactory);
        }

        public RoutePresenter CreateRoutePresenter(IRouteView routeView) {
            return new RoutePresenter(routeView,
                                      _unitOfWorkFactory,
                                      _repositoryFactory, _modelsFactory);
        }

        public NewRoutePointPresenter CreateNewRoutePointPresenter(
            INewRoutePointView newRoutePointView, int routeId) {
            return new NewRoutePointPresenter(newRoutePointView, _unitOfWorkFactory,
                                              _repositoryFactory, routeId);
        }

        public CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView) {
            return new CustomerLookUpPresenter(customerLookUpView, _repositoryFactory);
        }

        public ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, int customerId) {
            return new ShippingAddressLookUpPresenter(shippingAddressLookUpView, _repositoryFactory,
                                                      customerId);
        }
    }
}
