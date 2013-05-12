using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Product : Model
    {
        public string Name { get; protected set; }

        public int CategoryId { get; protected set; }

        public abstract IQueryObject<ProductsUnitOfMeasure> UnitsOfMeasures { get; }
    }
}
