using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class RoutePoint : Model
    {
        protected RoutePoint() {
            
        }

        protected RoutePoint(Route route) {
            RouteId = route.Id;
        }

        public int RouteId { get; protected set; }

        public int ShippingAddressId { get; protected set; }
        public string ShippingAddressName { get; protected set; }

        public int StatusId { get; protected set; }

        public void SetShippingAddress(ShippingAddress shippingAddress) {
            ShippingAddressId = shippingAddress.Id;
            ShippingAddressName = shippingAddress.Name;
        }

        public void SetStatus(Status status) {
            StatusId = status.Id;
        }

        public abstract IQueryObject<Order> Orders { get; }
    }
}
