using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.Application {
    public class PresentersFactory : IPresentersFactory {
        private readonly IStorageManager _storageManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IModelsFactory _modelsFactory;
        private readonly ILookUpService _lookUpService;

        public PresentersFactory(IStorageManager storageManager,
                                 IRepositoryFactory repositoryFactory,
                                 IModelsFactory modelsFactory) {
            _storageManager = storageManager;
            _unitOfWorkFactory = new SqLiteUnitOfWorkFactory(_storageManager);
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _lookUpService = new LookUpService(this);
        }

        public LogonPresenter CreateLogonPresenter(ILogonView logonView) {
            return new LogonPresenter(logonView);
        }

        public MenuPresenter CreateMenuPresenter(IMenuView logonView) {
            return new MenuPresenter(logonView);
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
            INewRoutePointView newRoutePointView, RouteViewModel routeViewModel) {
            return new NewRoutePointPresenter(newRoutePointView, _unitOfWorkFactory,
                                              _repositoryFactory, _lookUpService, routeViewModel);
        }

        public CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView) {
            return new CustomerLookUpPresenter(customerLookUpView, _repositoryFactory);
        }

        public ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, CustomerViewModel customerViewModel) {
            return new ShippingAddressLookUpPresenter(shippingAddressLookUpView, _repositoryFactory,
                                                      customerViewModel);
        }

        public OrderListPresenter CreateOrderListPresenter(IOrderListView orderListView, RoutePointViewModel routePointViewModel) {
            return new OrderListPresenter(orderListView, _repositoryFactory, routePointViewModel);
        }

        public OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel) {
            return new OrderPresenter(orderView, _unitOfWorkFactory, _repositoryFactory, routePointViewModel);
        }

        public OrderPresenter CreateOrderPresenter(IOrderView orderView, OrderViewModel orderViewModel) {
            return new OrderPresenter(orderView, _unitOfWorkFactory, _repositoryFactory, orderViewModel);
        }

        public PriceListLookUpPresenter CreatePriceListLookUpPresenter(IPriceListLookUpView priceListLookUpView) {
            return new PriceListLookUpPresenter(priceListLookUpView, _repositoryFactory);
        }

        public WarehouseLookUpPresenter CreateWarehouseLookUpPresenter(IWarehouseLookUpView warehouseLookUpView) {
            return new WarehouseLookUpPresenter(warehouseLookUpView, _repositoryFactory);
        }

        public PickUpProductPresenter CreatePickUpProductPresenter(IPickUpProductView pickUpProductView, OrderViewModel orderViewModel,
                                                                   IList<OrderItemViewModel> orderItemViewModels) {
            return new PickUpProductPresenter(pickUpProductView, _repositoryFactory, orderViewModel, orderItemViewModels);
        }
    }
}
