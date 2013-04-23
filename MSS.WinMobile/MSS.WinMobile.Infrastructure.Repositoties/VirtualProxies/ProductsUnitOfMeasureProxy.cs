using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class ProductsUnitOfMeasureProxy : ProductsUnitOfMeasure
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetUnitOfMeasureId(int unitOfMeasureId)
        {
            UnitOfMeasureId = unitOfMeasureId;
        }

        internal void SetProductId(int productId)
        {
            ProductId = productId;
        }

        internal void SetBase(bool @base)
        {
            Base = @base;
        }
    }
}