using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("PriceListsLines")]
    public class PriceListLine : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [Reference("PriceList_Id", typeof(PriceList))]
        public int PriceListId { get; set; }

        [Reference("Product_Id", typeof(Product))]
        public int ProductId { get; set; }

        [DecimalColumn("Price", 8, 2)]
        public decimal Price { get; set; }
    }
}
