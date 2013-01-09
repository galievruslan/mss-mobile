using OpenNETCF.ORM;

namespace MSS.WinMobile.Domain.Models
{
    [Entity]
    public class ShippingAddress : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public string Address { get; set; }

        [Field]
        public string Name { get; set; }

        [Field]
        public int CustomerId { get; set; }
    }
}
