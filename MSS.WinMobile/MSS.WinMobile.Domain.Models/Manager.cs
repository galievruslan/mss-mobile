namespace MSS.WinMobile.Domain.Models
{
    public partial class Manager
    {
        public Manager(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public Order NewOrder(RoutePoint routePoint)
        {
            return new Order(routePoint);
        }

        public Order NewOrder(ShippingAddress shippingAddress)
        {
            return new Order(this, shippingAddress);
        }
    }
}
