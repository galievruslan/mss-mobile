using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class OrderListPresenter : IListPresenter<OrderViewModel> {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderListPresenter));

        private readonly IOrderListView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly INavigator _navigator;
        private readonly RoutePointViewModel _routePointViewModel;

        private readonly OrderRetriever _retriever;
        private readonly Cache<Order> _cache;

        public OrderListPresenter(IOrderListView view, 
            IRepositoryFactory repositoryFactory,
            IUnitOfWorkFactory unitOfWorkFactory,
            INavigator navigator,
            RoutePointViewModel routePointViewModel)
        {
            _view = view;
            _repositoryFactory = repositoryFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            _navigator = navigator;
            _routePointViewModel = routePointViewModel;

            var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointRepository.GetById(routePointViewModel.Id);
            _retriever = new OrderRetriever(routePoint);
            _cache = new Cache<Order>(_retriever, 10);
        }

        public int InitializeListSize() {
            return _retriever.Count;
        }

        public OrderViewModel GetItem(int index) {
            Order order = _cache.RetrieveElement(index);
            return new OrderViewModel {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                ShippingDate = order.ShippingDate,
                ShippingAddressId = order.ShippingAddressId,
                ShippingAddressName = order.ShippingAddressName,
                PriceListId = order.PriceListId,
                PriceListName = order.PriceListName,
                WarehouseId = order.WarehouseId,
                WarehouseAddress = order.WarehouseAddress,
                Amount = order.Amount,
                Note = order.Note,
                RoutePointId = order.RoutePointId,
                Synchronized = order.Synchronized
            };
        }

        private Order _selectedOrder;
        public void Select(int index) {
            _selectedOrder = _cache.RetrieveElement(index);
        }

        public OrderViewModel SelectedModel {
            get {
                return _selectedOrder != null
                           ? new OrderViewModel {
                               OrderId = _selectedOrder.Id,
                               CustomerId = _selectedOrder.CustomerId,
                               CustomerName = _selectedOrder.CustomerName,
                               OrderDate = _selectedOrder.OrderDate,
                               ShippingDate = _selectedOrder.ShippingDate,
                               ShippingAddressId = _selectedOrder.ShippingAddressId,
                               ShippingAddressName = _selectedOrder.ShippingAddressName,
                               PriceListId = _selectedOrder.PriceListId,
                               PriceListName = _selectedOrder.PriceListName,
                               WarehouseId = _selectedOrder.WarehouseId,
                               WarehouseAddress = _selectedOrder.WarehouseAddress,
                               Amount = _selectedOrder.Amount,
                               Note = _selectedOrder.Note,
                               RoutePointId = _selectedOrder.RoutePointId,
                               Synchronized = _selectedOrder.Synchronized
                           }
                           : null;
            }
        }

        public void CreateOrder() {
            _navigator.GoToCreateOrderForRoutePoint(_routePointViewModel);
        }

        public void EditOrder() {
            if (SelectedModel != null) {
                if (SelectedModel.Synchronized)
                    _navigator.GoViewRoutePointsOrder(_routePointViewModel, SelectedModel);
                else
                    _navigator.GoToEditRoutePointsOrder(_routePointViewModel, SelectedModel);
            }
        }

        public void DeleteOrder() {
            if (_selectedOrder != null) {
                var orderRepository = _repositoryFactory.CreateRepository<Order>();
                var order = orderRepository.GetById(_selectedOrder.Id);
                if (order.Synchronized) {
                    _view.ShowError("You can't delete synchronized order");
                    return;
                }

                if (_view.ShowConfirmation("Are you shure, you want to delete the order?")) {
                    var orderItemRepository = _repositoryFactory.CreateRepository<OrderItem>();
                    using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                        try {
                            unitOfWork.BeginTransaction();
                            foreach (var orderItem in order.Items.ToArray()) {
                                orderItemRepository.Delete(orderItem);
                            }
                            orderRepository.Delete(order);
                            unitOfWork.Commit();
                            _selectedOrder = null;
                        }
                        catch (Exception exception) {
                            Log.Error(exception);
                            unitOfWork.Rollback();
                        }
                    }
                }
            }
        }

        public void GoToRoute() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route = routeRepository.GetById(_routePointViewModel.RouteId);
            _navigator.GoToRoute(new RouteViewModel {Id = route.Id, Date = route.Date});
        }
    }
}
