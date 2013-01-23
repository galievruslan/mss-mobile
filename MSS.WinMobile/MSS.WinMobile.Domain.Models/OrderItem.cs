using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("OrderItems")]
    public class OrderItem : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }
        
        [Reference("OrderId", typeof(Order))]
        public int OrderId { get; set; }

        [Reference("Product_Id", typeof(Product))]
        public int ProductId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
