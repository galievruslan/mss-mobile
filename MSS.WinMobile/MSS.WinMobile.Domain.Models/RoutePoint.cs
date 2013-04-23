namespace MSS.WinMobile.Domain.Models
{
    public class RoutePoint : Model
    {
        public int RouteId { get; protected set; }

        public int ShippingAddressId { get; protected set; }
        public string ShippingAddressName { get; protected set; }

        public int StatusId { get; protected set; }
    }
}
