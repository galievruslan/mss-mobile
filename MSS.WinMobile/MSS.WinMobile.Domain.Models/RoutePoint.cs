using System;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePoint
    {
        public RoutePoint(Route route, ShippingAddress shippingAddress, Status status)
        {
            RouteId = route.Id;
            ShippingAddressId = shippingAddress.Id;
            StatusId = status.Id;
        }

        public int RouteId { get; private set; }

        public int ShippingAddressId { get; private set; }

        public int StatusId { get; private set; }

        public int OrderId { get; private set; }

        private Order _order;
        public Order Order
        {
            get { return _order ?? (_order = Order.GetById(OrderId)); }
            private set { _order = value; }
        }

        private ShippingAddress _shippingAddress;
        public ShippingAddress ShippingAddress
        {
            get { return _shippingAddress ?? (_shippingAddress = ShippingAddress.GetById(ShippingAddressId)); }
            private set { _shippingAddress = value; }
        }

        private Status _status;
        public Status Status
        {
            get { return _status ?? (_status = Status.GetById(ShippingAddressId)); }
            private set { _status = value; }
        }
    }
}
