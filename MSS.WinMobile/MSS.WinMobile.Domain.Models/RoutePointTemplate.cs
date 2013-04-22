namespace MSS.WinMobile.Domain.Models
{
    public class RoutePointTemplate : Model
    {
        public RoutePointTemplate(int id, int routeTemplateId, int shippingAddressId)
            : base(id)
        {
            RouteTemplateId = routeTemplateId;
            ShippingAddressId = shippingAddressId;
        }

        public int RouteTemplateId { get; private set; }

        public int ShippingAddressId { get; private set; }
    }
}
