using System;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Domain.Models
{
    [Entity(NameInStore = "SaleOrders")]
    public class Order : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public DateTime Date { get; set; }

        [Field]
        public int ShippindAddressId { get; set; }

        [Field]
        public int ManagerId { get; set; }
    }
}
