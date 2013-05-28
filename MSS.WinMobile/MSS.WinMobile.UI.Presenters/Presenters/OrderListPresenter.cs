using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class OrderListPresenter : IListPresenter<OrderViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IOrderListView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigator _navigator;

        private IDataPageRetriever<Order> _ordersRetriever;
        private Cache<Order> _cache;

        public OrderListPresenter(IOrderListView view, 
                              IRepositoryFactory repositoryFactory, 
                              INavigator navigator) {
            _repositoryFactory = repositoryFactory;
            _navigator = navigator;
            _view = view;
        }

        public int InitializeListSize() {
            return _ordersRetriever.Count;
        }

        public OrderViewModel GetItem(int index) {
            Order order = _cache.RetrieveElement(index);

            return new OrderViewModel
            {
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
                WarehouseName = order.WarehouseName,
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

        public OrderViewModel SelectedModel
        {
            get {
                return _selectedOrder != null
                           ? new OrderViewModel
                           {
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
                               WarehouseName = _selectedOrder.WarehouseName,
                               Amount = _selectedOrder.Amount,
                               Note = _selectedOrder.Note,
                               RoutePointId = _selectedOrder.RoutePointId,
                               Synchronized = _selectedOrder.Synchronized
                           }
                           : null;
            }
        }
        public void EditOrder() {
            if (SelectedModel != null) {
                if (SelectedModel.Synchronized)
                    _navigator.GoToViewOrder(SelectedModel);
                else
                    _navigator.GoToEditOrder(SelectedModel);
            }
        }

        public void GetOrdersOnDate(DateTime date) {
            _ordersRetriever = new OrderRetriever(_repositoryFactory.CreateRepository<Order>(), date);
            _cache = new Cache<Order>(_ordersRetriever, 10);
        }

        public void GoToMenuView() {
            _navigator.GoToMenu();
        }
    }
}
