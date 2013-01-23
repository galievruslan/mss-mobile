using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("ShippingAddresses")]
    public class ShippingAddress : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [StringColumn("Address", 255)]
        public string Address { get; set; }

        [StringColumn("Name", 255)]
        public string Name { get; set; }

        [Reference("Customer_Id", typeof(Customer))]
        public int CustomerId { get; set; }
    }
}
