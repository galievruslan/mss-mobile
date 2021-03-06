﻿using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;
using AppCache = MSS.WinMobile.Application.Cache.Cache;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class OrderPresenter : IPresenter<OrderViewModel>, IListPresenter<OrderItemViewModel> {
        private static readonly ILog Log = LogManager.GetLogger(typeof (OrderPresenter));

        private readonly IOrderView _view;

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IConfigurationManager _configurationManager;
        private readonly INavigator _navigator;
        private readonly ILookUpService _lookUpService;
        private readonly OrderViewModel _orderViewModel;
        private readonly RoutePointViewModel _routePointViewModel;
        private readonly IList<OrderItemViewModel> _orderItemViewModels;

        private OrderPresenter(IOrderView view, 
                               IUnitOfWorkFactory unitOfWorkFactory,
                               IRepositoryFactory repositoryFactory,
                               IConfigurationManager configurationManager,
                               INavigator navigator,
                               ILookUpService lookUpService) {
            _view = view;
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
            _configurationManager = configurationManager;
            _navigator = navigator;
            _lookUpService = lookUpService;
        }

        public OrderPresenter(IOrderView view, IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory,
                              IConfigurationManager configurationManager,
                              INavigator navigator,
                              ILookUpService lookUpService,
                              RoutePointViewModel routePointViewModel) 
            :this(view, unitOfWorkFactory, repositoryFactory, configurationManager, navigator, lookUpService)
        {
            var routePointsRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointsRepository.GetById(routePointViewModel.Id);

            string routeCacheKey = string.Format("Route Id={0}", routePoint.RouteId);

            Route route;
            if (AppCache.Contains(routeCacheKey))
                route = AppCache.Get<Route>(routeCacheKey);
            else {
                var routeRepository = _repositoryFactory.CreateRepository<Route>();
                route = routeRepository.GetById(routePoint.RouteId);
                AppCache.Add(routeCacheKey, route);
            }

            string shippingAddressCacheKey = string.Format("ShippingAddress Id={0}", routePoint.ShippingAddressId);

            ShippingAddress shippingAddress;
            if (AppCache.Contains(shippingAddressCacheKey))
                shippingAddress = AppCache.Get<ShippingAddress>(shippingAddressCacheKey);
            else {
                var shippingAddressRepository = _repositoryFactory.CreateRepository<ShippingAddress>();
                shippingAddress = shippingAddressRepository.GetById(routePoint.ShippingAddressId);
                AppCache.Add(shippingAddressCacheKey, shippingAddress);
            }

            string customerCacheKey = string.Format("Customer Id={0}", shippingAddress.CustomerId);

            Customer customer;
            if (AppCache.Contains(customerCacheKey))
                customer = AppCache.Get<Customer>(customerCacheKey);
            else {
                var customersRepository = _repositoryFactory.CreateRepository<Customer>();
                customer = customersRepository.GetById(shippingAddress.CustomerId);
                AppCache.Add(customerCacheKey, customer);
            }

            const string warehouseCacheKey = "Default Warehouse";

            Warehouse defaultWarehouse;
            if (AppCache.Contains(warehouseCacheKey))
                defaultWarehouse = AppCache.Get<Warehouse>(warehouseCacheKey);
            else {
                var warehouseRepository = _repositoryFactory.CreateRepository<Warehouse>();
                defaultWarehouse =
                    warehouseRepository.Find().Where(new DefaultWarehouseSpec()).FirstOrDefault();
                AppCache.Add(warehouseCacheKey, defaultWarehouse);
            }

            _routePointViewModel = routePointViewModel;
            _orderViewModel = new OrderViewModel {
                OrderDate = route.Date.Date,
                ShippingDate = route.Date.Date,
                RoutePointId = routePoint.Id,
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                ShippingAddressId = shippingAddress.Id,
                ShippingAddressName = shippingAddress.Address,                
            };

            if (defaultWarehouse != null) {
                _orderViewModel.WarehouseId = defaultWarehouse.Id;
                _orderViewModel.WarehouseName = defaultWarehouse.Name;
            }

            const string priceListCacheKey = "Default Price List";

            PriceList defaultPriceList;
            if (AppCache.Contains(priceListCacheKey))
                defaultPriceList = AppCache.Get<PriceList>(priceListCacheKey);
            else {
                var defaultPriceListId = _configurationManager.GetConfig("Domain")
                                                              .GetSection("PriceLists")
                                                              .GetSetting("DefaultPriceListId")
                                                              .As<int>();
                var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
                defaultPriceList = priceListRepository.GetById(defaultPriceListId);
            }

            if (defaultPriceList != null) {
                _orderViewModel.PriceListId = defaultPriceList.Id;
                _orderViewModel.PriceListName = defaultPriceList.Name;
            }

            _orderItemViewModels = new List<OrderItemViewModel>();
        }

        public OrderPresenter(IOrderView view, IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory,
                              IConfigurationManager configurationManager,
                              INavigator navigator,
                              ILookUpService lookUpService,
                              RoutePointViewModel routePointViewModel,
                              OrderViewModel orderViewModel)
            : this(view, unitOfWorkFactory, repositoryFactory, configurationManager, navigator, lookUpService) {

            _routePointViewModel = routePointViewModel;
            _orderViewModel = orderViewModel;

            var orderRepository = _repositoryFactory.CreateRepository<Order>();
            var order = orderRepository.GetById(_orderViewModel.OrderId);

            _orderItemViewModels = new List<OrderItemViewModel>();
            foreach (var orderItem in order.Items.ToArray()) {
                _orderItemViewModels.Add(new OrderItemViewModel {
                    Id = orderItem.Id,
                    ProductId = orderItem.ProductId,
                    ProductName = orderItem.ProductName,
                    Quantity = orderItem.Quantity,
                    Price = orderItem.Price,
                    Amount = orderItem.Amount,
                    UnitOfMeasureId = orderItem.UnitOfMeasureId,
                    UnitOfMeasureName = orderItem.UnitOfMeasureName,
                    CountInUnitOfMeasure = orderItem.CountInBaseUnitOfMeasure
                });
            }
        }

        public OrderPresenter(IOrderView view, IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory,
                              IConfigurationManager configurationManager,
                              INavigator navigator,
                              ILookUpService lookUpService,
                              OrderViewModel orderViewModel)
            : this(view, unitOfWorkFactory, repositoryFactory, configurationManager, navigator, lookUpService)
        {

            _orderViewModel = orderViewModel;

            var orderRepository = _repositoryFactory.CreateRepository<Order>();
            var order = orderRepository.GetById(_orderViewModel.OrderId);

            _orderItemViewModels = new List<OrderItemViewModel>();
            foreach (var orderItem in order.Items.ToArray()) {
                _orderItemViewModels.Add(new OrderItemViewModel {
                    Id = orderItem.Id,
                    ProductId = orderItem.ProductId,
                    ProductName = orderItem.ProductName,
                    Quantity = orderItem.Quantity,
                    Price = orderItem.Price,
                    Amount = orderItem.Amount,
                    UnitOfMeasureId = orderItem.UnitOfMeasureId,
                    UnitOfMeasureName = orderItem.UnitOfMeasureName,
                    CountInUnitOfMeasure = orderItem.CountInBaseUnitOfMeasure
                });
            }
        }

        public void Save() {
            if (_orderViewModel.Validate()) {
                var orderRepository = _repositoryFactory.CreateRepository<Order>();
                var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
                var routePoint = routePointRepository.GetById(_orderViewModel.RoutePointId);

                var defaultStatusId = _configurationManager.GetConfig("Domain")
                                                          .GetSection("Statuses")
                                                          .GetSetting("DefaultRoutePointStatusId")
                                                          .As<int>();

                var attendedStatusId = _configurationManager.GetConfig("Domain")
                                                          .GetSection("Statuses")
                                                          .GetSetting("DefaultRoutePointAttendedStatusId")
                                                          .As<int>();
                if (attendedStatusId == 0 || defaultStatusId == 0) {
                    _view.ShowError(new[] {"Configuration error, please, do full synchronization."});
                    return;
                }

                var statusRepository = _repositoryFactory.CreateRepository<Status>();
                var attendedStatus = statusRepository.GetById(attendedStatusId);
                
                Order order = _orderViewModel.OrderId != 0
                                  ? orderRepository.GetById(_orderViewModel.OrderId)
                                  : routePoint.CreateOrder();

                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();
                var shippingAddress =
                    shippingAddressRepository.GetById(_orderViewModel.ShippingAddressId);

                var customersRepository = _repositoryFactory.CreateRepository<Customer>();
                var customer = customersRepository.GetById(_orderViewModel.CustomerId);

                var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
                var priceList = priceListRepository.GetById(_orderViewModel.PriceListId);

                var warehouseRepository = _repositoryFactory.CreateRepository<Warehouse>();
                var warehouse = warehouseRepository.GetById(_orderViewModel.WarehouseId);

                order.SetOrderDate(_orderViewModel.OrderDate);
                order.SetShippingDate(_orderViewModel.ShippingDate);
                order.SetCustomer(customer);
                order.SetShippingAddress(shippingAddress);
                order.SetPriceList(priceList);
                order.SetWarehouse(warehouse);
                order.Amount = _orderItemViewModels.Sum(model => model.Amount);
                order.Note = _orderViewModel.Note;
                order.OrderStatus = OrderStatus.New;

                var productRepository = _repositoryFactory.CreateRepository<Product>();
                var unitOfMeasureRepository = _repositoryFactory.CreateRepository<UnitOfMeasure>();
                var orderItemRepository = _repositoryFactory.CreateRepository<OrderItem>();
                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    unitOfWork.BeginTransaction();
                    order = orderRepository.Save(order);

                    // Delete not actual rows
                    foreach (var orderItem in order.Items.ToArray()) {
                        OrderItem item = orderItem;
                        if (_orderItemViewModels.All(model => model.Id != item.Id)) {
                            orderItemRepository.Delete(item);
                        }
                    }

                    foreach (var orderItemViewModel in _orderItemViewModels) {
                        OrderItem orderItem = orderItemViewModel.Id == 0
                                                  ? order.CreateItem()
                                                  : orderItemRepository.GetById(
                                                      orderItemViewModel.Id);

                        var product = productRepository.GetById(orderItemViewModel.ProductId);
                        orderItem.SetProduct(product);
                        var unitOfMeasure =
                            unitOfMeasureRepository.GetById(orderItemViewModel.UnitOfMeasureId);
                        orderItem.SetUnitOfMeasure(unitOfMeasure);
                        orderItem.Quantity = orderItemViewModel.Quantity;
                        orderItem.Price = orderItemViewModel.Price;
                        orderItem.CountInBaseUnitOfMeasure = orderItemViewModel.CountInUnitOfMeasure;
                        orderItem.Amount = orderItemViewModel.Amount;
                        orderItemRepository.Save(orderItem);
                    }

                    if (routePoint.StatusId == defaultStatusId) {
                        routePoint.SetStatus(attendedStatus);
                        routePointRepository.Save(routePoint);
                    }

                    unitOfWork.Commit();
                }

                if (_routePointViewModel != null)
                    _navigator.GoToRoutePointsOrderList(_routePointViewModel);
                else
                {
                    if (_orderViewModel != null)
                        _navigator.GoToOrderList(_orderViewModel.OrderDate);
                    else
                    {
                        _navigator.GoToMenu();
                    }
                }
            }
            else {
                _view.ShowError(_orderViewModel.Errors);
            }
        }

        public void Cancel() {
            if (_routePointViewModel != null)
                _navigator.GoToRoutePointsOrderList(_routePointViewModel);
            else {
                if (_orderViewModel != null)
                    _navigator.GoToOrderList(_orderViewModel.OrderDate);
                else {
                    _navigator.GoToMenu();
                }
            }
        }

        public void PickUpProducts() {
            IEnumerable<PickUpProductViewModel> pickedUpProducts = _lookUpService.PickUpProducts(
                new PriceListViewModel {
                    Id = _orderViewModel.PriceListId,
                    Name = _orderViewModel.PriceListName
                }, _orderItemViewModels);

            if (pickedUpProducts != null) {
                _orderItemViewModels.Clear();
                foreach (var pickUpProductViewModel in pickedUpProducts) {
                    _orderItemViewModels.Add(new OrderItemViewModel {
                        Id = pickUpProductViewModel.OrderItemId,
                        ProductId = pickUpProductViewModel.ProductId,
                        ProductName = pickUpProductViewModel.ProductName,
                        Quantity = pickUpProductViewModel.Quantity,
                        Price = pickUpProductViewModel.Price,
                        Amount = pickUpProductViewModel.Amount,
                        UnitOfMeasureId = pickUpProductViewModel.UnitOfMeasureId,
                        UnitOfMeasureName = pickUpProductViewModel.UnitOfMeasureName,
                        CountInUnitOfMeasure = pickUpProductViewModel.CountInUnitOfMeasure
                    });
                }
                _orderViewModel.Amount = _orderItemViewModels.Sum(model => model.Amount);
            }
        }

        public OrderViewModel Initialize() {
            return _orderViewModel;
        }

        public int InitializeListSize() {
            return _orderItemViewModels.Count;
        }

        public OrderItemViewModel GetItem(int index) {
            return _orderItemViewModels[index];
        }

        private OrderItemViewModel _selectedOrderItemViewModel;

        public void Select(int index) {
            _selectedOrderItemViewModel = _orderItemViewModels[index];
        }

        public OrderItemViewModel SelectedModel {
            get { return _selectedOrderItemViewModel; }
        }

        public void LookUpPriceList() {

            var selectedPriceList = _lookUpService.LookUpPriceList();
            if (selectedPriceList == null) return;
            if (_orderViewModel.PriceListId == selectedPriceList.Id) return;

            if (_orderItemViewModels.Count > 0) {
                if (_view.ShowConfirmation("All items will be deleted, are you sure?")) {
                    _orderItemViewModels.Clear();
                    _selectedOrderItemViewModel = null;
                    _orderViewModel.PriceListId = selectedPriceList.Id;
                    _orderViewModel.PriceListName = selectedPriceList.Name;
                }
            }
            else {
                _orderViewModel.PriceListId = selectedPriceList.Id;
                _orderViewModel.PriceListName = selectedPriceList.Name;
            }
        }

        public void ResetPriceList() {
            if (_orderItemViewModels.Count > 0) {
                if (_view.ShowConfirmation("All items will be deleted, are you sure?")) {
                    _orderItemViewModels.Clear();
                    _selectedOrderItemViewModel = null;
                    _orderViewModel.PriceListId = 0;
                    _orderViewModel.PriceListName = string.Empty;
                }
            }
            else {
                _orderViewModel.PriceListId = 0;
                _orderViewModel.PriceListName = string.Empty;
            }
        }

        public void LookUpWarehouse() {
            WarehouseViewModel selectedWarehouse = _lookUpService.LookUpWarehouse();
            if (selectedWarehouse != null) {
                _orderViewModel.WarehouseId = selectedWarehouse.Id;
                _orderViewModel.WarehouseName = selectedWarehouse.Name;
            }
        }

        public void ResetWarehouse() {
            _orderViewModel.WarehouseId = 0;
            _orderViewModel.WarehouseName = string.Empty;
        }

        public void DeleteItem() {
            if (SelectedModel != null) {
                _orderItemViewModels.Remove(
                    _orderItemViewModels.FirstOrDefault(model => model.ProductId == SelectedModel.ProductId));
                _selectedOrderItemViewModel = null;
                _orderViewModel.Amount = _orderItemViewModels.Sum(model => model.Amount);
            }
        }
    }
}
