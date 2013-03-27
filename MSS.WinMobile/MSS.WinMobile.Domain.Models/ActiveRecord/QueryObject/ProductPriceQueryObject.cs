using System;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class ProductPriceQueryObject : QueryObject<ProductsPrice>
    {
        public ProductPriceQueryObject()
            : base(
                ProductsPrice.Table.TABLE_NAME,
                new[]
                    {
                        string.Format(@"{0}", ProductsPrice.Table.Fields.ID), 
                        string.Format(@"{0}", ProductsPrice.Table.Fields.PRICE_LIST_ID), 
                        string.Format(@"{0}", ProductsPrice.Table.Fields.PRODUCT_ID),
                        string.Format(@"{0}", ProductsPrice.Table.Fields.VALUE), 
                        string.Format(@"{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.ID),
                        string.Format(@"{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.CATEGORY_ID),
                        string.Format(@"{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.NAME)
                    })
        {
        }

        protected ProductPriceQueryObject(QueryObject<ProductsPrice> queryObject)
            : base(queryObject)
        {
            throw new NotSupportedException("ProductPriceQueryObject can't wrap another QueryObjects");
        }

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", ProductsPrice.Table.TABLE_NAME,
                                                    ProductsPrice.Table.Fields.ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", ProductsPrice.Table.TABLE_NAME,
                                                    ProductsPrice.Table.Fields.PRICE_LIST_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", ProductsPrice.Table.TABLE_NAME,
                                                    ProductsPrice.Table.Fields.PRODUCT_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", ProductsPrice.Table.TABLE_NAME,
                                                    ProductsPrice.Table.Fields.VALUE));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Product.Table.TABLE_NAME,
                                                    Product.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", Product.Table.TABLE_NAME,
                                                                  Product.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Product.Table.TABLE_NAME,
                                                    Product.Table.Fields.CATEGORY_ID,
                                                    string.Format(@"{0}_{1}", Product.Table.TABLE_NAME,
                                                                  Product.Table.Fields.CATEGORY_ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}] ", Product.Table.TABLE_NAME,
                                                    Product.Table.Fields.NAME,
                                                    string.Format(@"{0}_{1}", Product.Table.TABLE_NAME,
                                                                  Product.Table.Fields.NAME)));

            queryStringBuilder.Append(string.Format(" FROM [{0}] AS [{0}]", ProductsPrice.Table.TABLE_NAME));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]", 
                Product.Table.TABLE_NAME,
                ProductsPrice.Table.TABLE_NAME,
                ProductsPrice.Table.Fields.PRODUCT_ID,
                Product.Table.Fields.ID));

            return queryStringBuilder.ToString();
        }
    }
}
