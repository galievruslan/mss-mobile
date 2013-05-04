using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class PriceList : Model
    {
        public string Name { get; protected set; }

        public abstract IQueryObject<ProductsPrice> Lines { get; }
    }
}
