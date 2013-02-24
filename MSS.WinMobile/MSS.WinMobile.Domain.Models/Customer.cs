using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("Customers")]
    public class Customer : IEntity
    {
        public Customer()
        {
            ShippingAddresses = new ShippingAddress[0];
        }

        [Key("Id")]
        public int Id { get; set; }

        [StringColumn("Name", 255)]
        public string Name { get; set; }

        public ShippingAddress[] ShippingAddresses { get; private set; }
    }
}
