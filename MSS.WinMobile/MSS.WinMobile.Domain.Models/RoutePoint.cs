using OpenNETCF.ORM;

namespace MSS.WinMobile.Domain.Models
{
    [Entity]
    public class RoutePoint : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public int RouteId { get; set; }

        [Field]
        public int ShippingAddressId { get; set; }

        [Field]
        public int StatusId { get; set; }
    }
}
