using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
{
    [Entity(NameInStore = "SaleOrderItems")]
    public class OrderItem : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }
        
        [Field]
        public int OrderId { get; set; }

        [Field]
        public int ProductId { get; set; }

        [Field]
        public int Quantity { get; set; }
    }
}
