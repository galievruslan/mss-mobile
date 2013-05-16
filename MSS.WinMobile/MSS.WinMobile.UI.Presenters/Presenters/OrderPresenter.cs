using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class OrderPresenter : IPresenter<OrderViewModel>, IListPresenter<OrderItemViewModel> {
        private static readonly ILog Log = LogManager.GetLogger(typeof (OrderPresenter));

        private readonly IOrderView _view;

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigator _navigator;
        private readonly ILookUpService _lookUpService;
        private readonly OrderViewModel _orderViewModel;
        private readonly RoutePointViewModel _routePointViewModel;
        private readonly IList<OrderItemViewModel> _orderItemViewModels;

        private OrderPresenter(IOrderView view, IUnitOfWorkFactory unitOfWorkFactory,
                               IRepositoryFactory repositoryFactory, INavigator navigator,
                               ILookUpService lookUpService) {
            _view = view;
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
            _navigator = navigator;
            _lookUpService = lookUpService;
        }

        public OrderPresenter(IOrderView view, IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory,
                              INavigator navigator,
                              ILookUpService lookUpService,
                              RoutePointViewModel routePointViewModel) 
            :this(view, unitOfWorkFactory, repositoryFactory, navigator, lookUpService)
        {
            var routePointsRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointsRepository.GetById(routePointViewModel.Id);

            var shippingAddressRepository = _repositoryFactory.CreateRepository<ShippingAddress>();
            var shippingAddress = shippingAddressRepository.GetById(routePoint.ShippingAddressId);

            var customersRepository = _repositoryFactory.CreateRepository<Customer>();
            var customer = customersRepository.GetById(shippingAddress.CustomerId);

            _routePointViewModel = routePointViewModel;
            _orderViewModel = new OrderViewModel {
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                RoutePointId = routePoint.Id,
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                ShippingAddressId = shippingAddress.Id,
                ShippingAddressName = shippingAddress.Address
            };

            _orderItemViewModels = new List<OrderItemViewModel>();
        }

        public OrderPresenter(IOrderView view, IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory,
                              INavigator navigator,
                              ILookUpService lookUpService,
                              RoutePointViewModel routePointViewModel,
                              OrderViewModel orderViewModel)
            : this(view, unitOfWorkFactory, repositoryFactory, navigator, lookUpService) {

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
                    Price = orderItem.Price
                });
            }
        }

        public void Save() {
            if (_orderViewModel.Validate()) {
                var orderRepository = _repositoryFactory.CreateRepository<Order>();
                var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
                var routePoint = routePointRepository.GetById(_orderViewModel.RoutePointId);

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
                order.Note = _orderViewModel.Note;
                order.OrderStatus = OrderStatus.New;

                var productRepository = _repositoryFactory.CreateRepository<Product>();
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
                        orderItem.Price = orderItemViewModel.Price;
                        orderItem.Quantity = orderItemViewModel.Quantity;
                        orderItemRepository.Save(orderItem);
                    }

                    unitOfWork.Commit();
                }
                _navigator.GoToRoutePointsOrderList(_routePointViewModel);
            }
            else {
                _view.ShowError(_orderViewModel.Errors);
            }
        }

        public void Cancel() {
            _navigator.GoToRoutePointsOrderList(_routePointViewModel);
        }

        public void PickUpProducts() {
            IEnumerable<PickUpProductViewModel> pickedUpProducts = _lookUpService.PickUpProducts(
                new PriceListViewModel {
                    Id = _orderViewModel.PriceListId,
                    Name = _orderViewModel.PriceListName
                }, _orderItemViewModels);

            _orderItemViewModels.Clear();
            foreach (var pickUpProductViewModel in pickedUpProducts) {
                _orderItemViewModels.Add(new OrderItemViewModel {
                    Id = pickUpProductViewModel.OrderItemId,
                    ProductId = pickUpProductViewModel.ProductId,
                    ProductName = pickUpProductViewModel.ProductName,
                    Quantity = pickUpProductViewModel.Quantity,
                    Price = pickUpProductViewModel.Price
                });
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
            PriceListViewModel selectedPriceList = _lookUpService.LookUpPriceList();
            if (selectedPriceList != null) {
                _orderViewModel.PriceListId = selectedPriceList.Id;
                _orderViewModel.PriceListName = selectedPriceList.Name;
            }
        }

        public void ResetPriceList() {
            _orderViewModel.PriceListId = 0;
            _orderViewModel.PriceListName = string.Empty;
        }

        public void LookUpWarehouse() {
            WarehouseViewModel selectedWarehouse = _lookUpService.LookUpWarehouse();
            if (selectedWarehouse != null) {
                _orderViewModel.WarehouseId = selectedWarehouse.Id;
                _orderViewModel.WarehouseAddress = selectedWarehouse.Address;
            }
        }

        public void ResetWarehouse() {
            _orderViewModel.WarehouseId = 0;
            _orderViewModel.WarehouseAddress = string.Empty;
        }
    }
}
