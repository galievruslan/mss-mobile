using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class OrderListPresenter : IListPresenter<OrderViewModel> {
        private IOrderListView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly RoutePointViewModel _routePointViewModel;

        private OrderRetriever _retriever;
        private Cache<Order> _cache;

        public OrderListPresenter(IOrderListView view, IRepositoryFactory repositoryFactory, RoutePointViewModel routePointViewModel)
        {
            _view = view;
            _repositoryFactory = repositoryFactory;
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
                Note = order.Note,
                RoutePointId = order.RoutePointId
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
                               Note = _selectedOrder.Note,
                               RoutePointId = _selectedOrder.RoutePointId
                           }
                           : null;
            }
        }

        public void CreateOrder() {
            var newOrderView = NavigationContext.NavigateTo<IOrderView>(new Dictionary<string, object> { { "route_point", _routePointViewModel } });
            newOrderView.ShowView();

            var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointRepository.GetById(_routePointViewModel.Id);
            _retriever = new OrderRetriever(routePoint);
            _cache = new Cache<Order>(_retriever, 10);
        }

        public void EditOrder() {
            if (SelectedModel != null) {
                var editOrderView =
                    NavigationContext.NavigateTo<IOrderView>(new Dictionary<string, object> {
                        {"order", SelectedModel}
                    });
                editOrderView.ShowView();
            }
        }

        public void PrepareOrderForSending() {
            //var newOrderView = NavigationContext.NavigateTo<IOrderView>(new Dictionary<string, object> { { "route_point", _routePointViewModel } });
            //newOrderView.ShowView();
        }
    }
}
