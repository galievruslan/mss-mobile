using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("ProductsUnitOfMeasures")]
    public class ProductsUnitOfMeasure : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [Reference("Product_Id", typeof(Product))]
        public int ProductId { get; set; }

        [Reference("UnitOfMeasure_Id", typeof(UnitOfMeasure))]
        public int UnitOfMeasureId { get; set; }

        [BooleanColumn("Base")]
        public bool Base { get; set; }
    }
}
