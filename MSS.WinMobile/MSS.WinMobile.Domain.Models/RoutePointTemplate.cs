namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePointTemplate
    {
        public RoutePointTemplate(int id, int routeTemplateId, int shippingAddressId)
        {
            Id = id;
            RouteTemplateId = routeTemplateId;
            ShippingAddressId = shippingAddressId;
        }

        public int RouteTemplateId { get; private set; }

        public int ShippingAddressId { get; private set; }

        private ShippingAddress _shippingAddress;
        public ShippingAddress ShippingAddress
        {
            get { return _shippingAddress ?? (_shippingAddress = ShippingAddress.GetById(ShippingAddressId)); }
            private set { _shippingAddress = value; }
        }
    }
}
