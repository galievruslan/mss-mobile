using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("RoutePoints")]
    public class RoutePoint : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [Reference("Route_Id", typeof(Route))]
        public int RouteId { get; set; }

        [Reference("ShippingAddress_Id", typeof(ShippingAddress))]
        public int ShippingAddressId { get; set; }

        [Reference("Status_Id", typeof(Status))]
        public int StatusId { get; set; }
    }
}
