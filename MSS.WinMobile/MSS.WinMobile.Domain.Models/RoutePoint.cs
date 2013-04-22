namespace MSS.WinMobile.Domain.Models
{
    public class RoutePoint : Model
    {
        public RoutePoint(int id, int routeId, int shippinAddressId, string shippingAddressName, int statusId)
            :base(id)
        {
            RouteId = routeId;
            ShippingAddressId = shippinAddressId;
            ShippingAddressName = shippingAddressName;
            StatusId = statusId;
        }

        public int RouteId { get; private set; }

        public int ShippingAddressId { get; private set; }
        public string ShippingAddressName { get; private set; }

        public int StatusId { get; private set; }
    }
}
