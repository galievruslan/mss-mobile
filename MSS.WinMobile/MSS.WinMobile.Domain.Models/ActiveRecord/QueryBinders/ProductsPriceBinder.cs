namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class ProductsPriceBinder : QueryBinder<ProductsPrice>
    {
        public override string SaveBinder(string template, ProductsPrice @object)
        {
            return string.Format(template, @object.Id,
                                 @object.Product != null ? string.Format("{0}, ", @object.Product.Id) : "NULL, ",
                                 @object.PriceListId,
                                 @object.Price);
        }
    }
}