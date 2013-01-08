using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
{
    [Entity]
    public class RoutePoint : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public int RouteId { get; set; }

        [Field]
        public int CustomerId { get; set; }

        [Field]
        public int StatusId { get; set; }
    }
}
