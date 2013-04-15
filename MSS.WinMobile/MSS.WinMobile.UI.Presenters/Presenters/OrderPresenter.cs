using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class OrderPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderPresenter));

        private readonly IOrderView _view;
        private readonly Order _order;

        private IDataPageRetriever<OrderItem> _orderItemRetriever;
        private Cache<OrderItem> _cache;

        public OrderPresenter(IOrderView view, int routePointId)
        {
            _view = view;
            RoutePoint routePoint = RoutePoint.GetById(routePointId);
            _order = routePoint.Order;
            if (_order == null)
            {
                _order = new Order(RoutePoint.GetById(routePointId));
                _order.Save();
            }

            _orderItemRetriever = new OrderItemRetriever(_order);
            _cache = new Cache<OrderItem>(_orderItemRetriever, 10);
        }

        public void InitializeView()
        {
            _view.SetNumber(_order.Id.ToString(CultureInfo.InvariantCulture));
            _view.SetDate(_order.Date);
            _view.SetCustomer(_order.Customer.Name);
            _view.SetShippingAddress(_order.ShippingAddress.Address);
            
            if (_order.PriceList != null)
                _view.SetPriceList(_order.PriceList.Name);

            if (_order.Warehouse != null)
                _view.SetWarehouse(_order.Warehouse.Address);

            _view.SetItemCount(_orderItemRetriever.Count);
        }

        public void SetPriceList(int priceListId)
        {
            PriceList priceList = PriceList.GetById(priceListId);
            _order.SetPriceList(priceList);
            _order.Save();

            _view.SetPriceList(_order.PriceList != null ? _order.PriceList.Name : string.Empty);
        }

        public void SetWarehouse(int warehouseId)
        {
            Warehouse warehouse = Warehouse.GetById(warehouseId);
            _order.SetWarehouse(warehouse);
            _order.Save();

            _view.SetWarehouse(_order.Warehouse != null ? _order.Warehouse.Address : string.Empty);
        }

        public int GetPriceListId()
        {
            if (_order.PriceList != null)
                return _order.PriceList.Id;

            throw new PriceListEmptyException();
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Cancel()
        {
            throw new NotImplementedException();
        }

        public void PickUpProducts()
        {
            using (
                var pickUpProductView =
                    NavigationContext.NavigateTo<IPickUpProductView>(new Dictionary<string, object>
                        {
                            {"OrderId", _order.Id}
                        }))
            {
                if (DialogViewResult.OK == pickUpProductView.ShowDialogView())
                {
                    IDictionary<int, int> collectedValues = pickUpProductView.GetValues();
                    IList<OrderItem> orderItems = _order.Items().ToArray();
                    foreach (var collectedValue in collectedValues)
                    {
                        KeyValuePair<int, int> value = collectedValue;
                        OrderItem orderItem = orderItems.FirstOrDefault(item => item.Id == value.Key);
                        if (orderItem != null)
                        {
                            if (orderItem.Quantity != value.Value)
                            {
                                orderItem.Quantity = value.Value;
                                orderItem.Save();
                            }
                        }
                        else
                        {
                            _order.AddItem(Product.GetById(value.Key), value.Value);
                        }
                    }

                    foreach (var orderItem in _order.Items())
                    {
                        OrderItem item = orderItem;
                        if (collectedValues.All(pair => pair.Key != item.Id))
                            _order.RemoveItem(orderItem);
                    }

                    _orderItemRetriever = new OrderItemRetriever(_order);
                    _cache = new Cache<OrderItem>(_orderItemRetriever, 10);
                    _view.SetItemCount(_orderItemRetriever.Count);
                }
            }
        }
    }

    public class PriceListEmptyException : Exception
    {
    }
}
