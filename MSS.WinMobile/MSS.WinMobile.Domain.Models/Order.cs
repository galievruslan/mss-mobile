using System;
using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
{
    [Entity(NameInStore = "SaleOrders")]
    public class Order : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public DateTime Date { get; set; }

        [Field]
        public int CustomerId { get; set; }

        [Field]
        public int ManagerId { get; set; }
    }
}
