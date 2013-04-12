using System;
using System.Collections.Generic;
using System.Globalization;
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

        private readonly IDataPageRetriever<OrderItem> _orderItemRetriever;
        private readonly Cache<OrderItem> _cache;

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
            _view.SetNumber(_order.Id.ToString());
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

            _view.SetPriceList(_order.PriceList != null ? _order.PriceList.Name : string.Empty);
        }

        public void SetWarehouse(int warehouseId)
        {
            Warehouse warehouse = Warehouse.GetById(warehouseId);
            _order.SetWarehouse(warehouse);

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
    }

    public class PriceListEmptyException : Exception
    {
    }
}
