using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class OrderPresenter : IPresenter<OrderViewModel>, IListPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderPresenter));

        private readonly IOrderView _view;
        private readonly SqLiteUnitOfWork _unitOfWork;
        private readonly Order _order;
         
        private IDataPageRetriever<OrderItem> _orderItemRetriever;
        private Cache<OrderItem> _cache;

        public OrderPresenter(IOrderView view, SqLiteUnitOfWork unitOfWork, int routePointId)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            var orderRepository = new OrderRepository(_unitOfWork);
            _order = orderRepository.Find().Where("RoutePoint_Id", new Equals(routePointId)).FirstOrDefault();
            if (_order == null)
            {
                _order = new Order();
                _order = orderRepository.Save(_order);
            }

            _orderItemRetriever = new OrderItemRetriever(new OrderItemRepository(_unitOfWork),
                                                         _order);
            _cache = new Cache<OrderItem>(_orderItemRetriever, 10);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            OrderItem item = _cache.RetrieveElement(index);
            return new Dictionary<string, string>
                {
                    //{"Name", item.Product.Name},
                    {"GetCount", item.Quantity.ToString(CultureInfo.InvariantCulture)}
                };
        }

        public void Save()
        {
            if (_viewModel.Validate()) {
                throw new NotImplementedException();
            }
            else {
                _view.DisplayErrors(_viewModel.Errors);
            }
        }

        public void Cancel()
        {
            _view.CloseView();
        }

        public void PickUpProducts()
        {
            //using (
            //    var pickUpProductView =
            //        NavigationContext.NavigateTo<IPickUpProductView>(new Dictionary<string, object>
            //            {
            //                {"OrderId", _order.Id}
            //            }))
            //{
            //    if (DialogViewResult.Ok == pickUpProductView.ShowDialogView())
            //    {
            //        IDictionary<int, int> collectedValues = pickUpProductView.GetValues();
            //        IList<OrderItem> orderItems = _order.Items().ToArray();
            //        foreach (var collectedValue in collectedValues)
            //        {
            //            KeyValuePair<int, int> value = collectedValue;
            //            OrderItem orderItem = orderItems.FirstOrDefault(item => item.Product.Id == value.Key);
            //            if (orderItem != null)
            //            {
            //                if (orderItem.Quantity != value.Value)
            //                {
            //                    orderItem.Quantity = value.Value;
            //                    orderItem.Save();
            //                }
            //            }
            //            else
            //            {
            //                _order.AddItem(Product.GetById(value.Key), value.Value);
            //            }
            //        }

            //        foreach (var orderItem in _order.Items())
            //        {
            //            OrderItem item = orderItem;
            //            if (collectedValues.All(pair => pair.Key != item.Product.Id))
            //                _order.RemoveItem(orderItem);
            //        }

            //        _orderItemRetriever = new OrderItemRetriever(_order);
            //        _cache = new Cache<OrderItem>(_orderItemRetriever, 10);
            //        _view.SetItemCount(_orderItemRetriever.Count);
            //    }
            //}
        }

        private OrderViewModel _viewModel;
        public OrderViewModel Initialize() {
            _viewModel = new OrderViewModel
            {
                CustomerId = _order.CustomerId,
                CustomerName = _order.CustomerName,
                ShippingAddressId = _order.ShippingAddressId,
                ShippingAddressName = _order.ShippingAddressName,
                PriceListId = _order.PriceListId,
                PriceListName = _order.PriceListName,
                WarehouseId = _order.WarehouseId,
                WarehouseName = _order.WarehouseAddress
            };
            return _viewModel;
        }

        public int InitializeList() {
            return _orderItemRetriever.Count;
        }
    }

    public class PriceListEmptyException : Exception
    {
    }
}
