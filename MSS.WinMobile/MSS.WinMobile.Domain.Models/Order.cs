using System;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order
    {
        public Order(Manager manager)
        {
            ManagerId = manager.Id;
            Date = DateTime.Now;
        }

        public Order(RoutePoint routePoint)
            :this(routePoint.Route.Manager)
        {
            ShippindAddressId = routePoint.ShippingAddressId;
        }

        public Order(Manager manager, ShippingAddress shippingAddress)
            : this(manager)
        {
            ShippindAddressId = shippingAddress.Id;
        }

        public DateTime Date { get; private set; }

        public int ShippindAddressId { get; private set; }

        public int ManagerId { get; private set; }

        public string Note { get; set; }
    }
}
