using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class ProductsPriceProxy : ProductsPrice
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int PriceListId
        {
            get { return base.PriceListId; }
            set { base.PriceListId = value; }
        }

        new public int ProductId
        {
            get { return base.ProductId; }
            set { base.ProductId = value; }
        }

        new public string ProductName
        {
            get { return base.ProductName; }
            set { base.ProductName = value; }
        }

        public new int ProductCategoryId {
            get { return base.ProductCategoryId; }
            set { base.ProductCategoryId = value; }
        }

        new public decimal Price
        {
            get { return base.Price; }
            set { base.Price = value; }
        }
    }
}