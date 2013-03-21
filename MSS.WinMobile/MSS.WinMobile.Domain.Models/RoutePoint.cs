namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePoint
    {
        public RoutePoint(int id, int routeId, int shippingAddressId, int statusId)
        {
            Id = id;
            RouteId = routeId;
            ShippingAddressId = shippingAddressId;
            StatusId = statusId;
        }

        public RoutePoint(int id, int routeId, int shippingAddressId, int statusId, int orderId)
        {
            Id = id;
            RouteId = routeId;
            ShippingAddressId = shippingAddressId;
            StatusId = statusId;
            OrderId = orderId;
        }

        public int RouteId { get; private set; }

        public int ShippingAddressId { get; private set; }

        public int StatusId { get; private set; }

        public int? OrderId { get; private set; }

        private Order _order;
        public Order Order
        {
            get
            {
                if (_order == null && OrderId != null)
                    _order = Order.GetById((int)OrderId);

                return _order;
            }
        }

        private ShippingAddress _shippingAddress;
        public ShippingAddress ShippingAddress
        {
            get { return _shippingAddress ?? (_shippingAddress = ShippingAddress.GetById(ShippingAddressId)); }
            private set { _shippingAddress = value; }
        }

        private Route _route;
        public Route Route {
            get { return _route ?? (_route = Route.GetById(RouteId)); }
            private set { _route = value; }
        }
    }
}
