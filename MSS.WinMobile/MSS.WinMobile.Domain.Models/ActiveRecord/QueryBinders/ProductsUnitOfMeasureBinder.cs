namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class ProductsUnitOfMeasureBinder : QueryBinder<ProductsUnitOfMeasure>
    {
        public override string SaveBinder(string template, ProductsUnitOfMeasure @object)
        {
            return string.Format(template, @object.Id,
                                 @object.Product != null ? string.Format("{0}, ", @object.Product.Id) : "NULL, ",
                                 @object.UnitOfMeasureId,
                                 @object.Base ? 1 : 0);
        }
    }
}