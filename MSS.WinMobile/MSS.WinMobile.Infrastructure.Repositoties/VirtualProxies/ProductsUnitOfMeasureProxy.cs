using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class ProductsUnitOfMeasureProxy : ProductsUnitOfMeasure
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int UnitOfMeasureId
        {
            get { return base.UnitOfMeasureId; }
            set { base.UnitOfMeasureId = value; }
        }

        new public int ProductId
        {
            get { return base.ProductId; }
            set { base.ProductId = value; }
        }

        new public bool Base
        {
            get { return base.Base; }
            set { base.Base = value; }
        }
    }
}