namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePoint
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int ShippingAddressId { get; set; }

        public int StatusId { get; set; }

        private ShippingAddress _shippingAddress;
        public ShippingAddress ShippingAddress
        {
            get { return _shippingAddress ?? (_shippingAddress = ShippingAddress.GetById(ShippingAddressId)); }
        }
    }
}
