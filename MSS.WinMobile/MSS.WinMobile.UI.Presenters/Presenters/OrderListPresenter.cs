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
        private readonly int _routePointId;

        private OrderRetriever _retriever;
        private Cache<Order> _cache; 

        public OrderListPresenter(IOrderListView view, IRepositoryFactory repositoryFactory, int routePointId) {
            _view = view;
            _repositoryFactory = repositoryFactory;
            _routePointId = routePointId;

            var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointRepository.GetById(_routePointId);
            _retriever = new OrderRetriever(routePoint);
            _cache = new Cache<Order>(_retriever, 10);
        }

        public int InitializeListSize() {
            return _retriever.Count;
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
                    WarehouseAddress = order.WarehouseAddress
                };
        }

        private Order _selectedOrder;
        public void Select(int index) {
            _selectedOrder = _cache.RetrieveElement(index);
        }

        public OrderViewModel SelectedModel {
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
                                   WarehouseAddress = _selectedOrder.WarehouseAddress
                               }
                           : null;
            }
        }
    }
}
