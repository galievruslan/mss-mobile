﻿using System.Collections.Generic;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using MSS.WinMobile.UI.Views;

namespace MSS.WinMobile.Application {
    public class PresentersFactory : IPresentersFactory {
        private readonly IStorageManager _storageManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IModelsFactory _modelsFactory;
        private readonly INavigator _navigator;
        private readonly ILookUpService _lookUpService;
        private readonly IConfigurationManager _configurationManager;
        private readonly ILocalizationManager _localizationManager;

        public PresentersFactory(IStorageManager storageManager,
                                 IRepositoryFactory repositoryFactory,
                                 IModelsFactory modelsFactory,
                                 IViewContainer container,
                                 IConfigurationManager configurationManager,
                                 ILocalizationManager localizationManager) {
            _storageManager = storageManager;
            _unitOfWorkFactory = new SqLiteUnitOfWorkFactory(_storageManager);
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _configurationManager = configurationManager;
            _localizationManager = localizationManager;
            _navigator = new Navigator(container, this, _localizationManager);
            _lookUpService = new LookUpService(this, localizationManager);
        }

        public LogonPresenter CreateLogonPresenter(ILogonView logonView) {
            return new LogonPresenter(logonView, _configurationManager, _navigator);
        }

        public MenuPresenter CreateMenuPresenter(IMenuView logonView) {
            return new MenuPresenter(logonView, _repositoryFactory, _configurationManager,
                                     _navigator);
        }

        public SynchronizationPresenter CreateSynchronizationPresenter(
            ISynchronizationView synchronizationView, bool exitOnError) {
            return new SynchronizationPresenter(synchronizationView, 
                                                _storageManager,
                                                _unitOfWorkFactory,
                                                _repositoryFactory, 
                                                _configurationManager,
                                                _navigator);
        }

        public RoutePresenter CreateRoutePresenter(IRouteView routeView, RouteViewModel routeViewModel) {
            return new RoutePresenter(routeView,
                                      _unitOfWorkFactory,
                                      _repositoryFactory,
                                      _modelsFactory, 
                                      _configurationManager,
                                      _navigator,
                                      routeViewModel);
        }

        public NewRoutePointPresenter CreateNewRoutePointPresenter(
            INewRoutePointView newRoutePointView, RouteViewModel routeViewModel) {
            return new NewRoutePointPresenter(newRoutePointView, _unitOfWorkFactory,
                                              _repositoryFactory, _modelsFactory, _configurationManager, _navigator,
                                              _lookUpService, routeViewModel);
        }

        public ChangeStatusPresenter CreateChangeStatusPresenter(IChangeStatusView changeStatusView,
                                                                 RoutePointViewModel routePointViewModel) {
            return new ChangeStatusPresenter(changeStatusView, _repositoryFactory, _unitOfWorkFactory, _navigator, routePointViewModel);
        }

        public CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView) {
            return new CustomerLookUpPresenter(customerLookUpView, _repositoryFactory);
        }

        public ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, CustomerViewModel customerViewModel) {
            return new ShippingAddressLookUpPresenter(shippingAddressLookUpView, _repositoryFactory,
                                                      customerViewModel);
        }

        public RoutePointsOrderListPresenter CreateRoutePointsOrderListPresenter(IRoutePointsOrderListView orderListView, RoutePointViewModel routePointViewModel) {
            return new RoutePointsOrderListPresenter(orderListView, _repositoryFactory, _unitOfWorkFactory, _navigator, routePointViewModel);
        }

        public OrderListPresenter CreateOrderListPresenter(IOrderListView orderListView) {
            return new OrderListPresenter(orderListView, _repositoryFactory, _navigator);
        }

        public OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel) {
            return new OrderPresenter(orderView, _unitOfWorkFactory, _repositoryFactory, _configurationManager, _navigator, _lookUpService, routePointViewModel);
        }

        public OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            return new OrderPresenter(orderView, _unitOfWorkFactory, _repositoryFactory, _configurationManager, _navigator,
                                      _lookUpService, routePointViewModel, orderViewModel);
        }

        public OrderPresenter CreateOrderPresenter(IOrderView orderView, OrderViewModel orderViewModel) {
            return new OrderPresenter(orderView, _unitOfWorkFactory, _repositoryFactory, _configurationManager, _navigator, _lookUpService,
                                      orderViewModel);
        }

        public PriceListLookUpPresenter CreatePriceListLookUpPresenter(IPriceListLookUpView priceListLookUpView) {
            return new PriceListLookUpPresenter(priceListLookUpView, _repositoryFactory);
        }

        public WarehouseLookUpPresenter CreateWarehouseLookUpPresenter(IWarehouseLookUpView warehouseLookUpView) {
            return new WarehouseLookUpPresenter(warehouseLookUpView, _repositoryFactory);
        }

        public CategoryLookUpPresenter CreateCategoryLookUpPresenter(ICategoryLookUpView categoryLookUpView,
                                                                     CategoryViewModel selectedCategoryViewModel) {
            return new CategoryLookUpPresenter(categoryLookUpView, _repositoryFactory, selectedCategoryViewModel);
        }

        public PickUpProductPresenter CreatePickUpProductPresenter(IPickUpProductView pickUpProductView, PriceListViewModel priceListViewModel,
                                                                   IEnumerable<OrderItemViewModel> orderItemViewModels) {
            return new PickUpProductPresenter(pickUpProductView, _repositoryFactory, _lookUpService, priceListViewModel, orderItemViewModels);
        }

        public SettingsPresenter CreateSettingsPresenter(ISettingsView settingsView) {
            return new SettingsPresenter(settingsView, _storageManager, _repositoryFactory, _configurationManager, _navigator, _localizationManager);
        }
    }
}
