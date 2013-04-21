using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.Domain.Models
{
    public partial class PriceList
    {
        public PriceList(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public QueryObject<ProductsPrice> GetProductsPrices()
        {
            return ProductsPrice.GetByPriceList(this);
        }
    }
}
