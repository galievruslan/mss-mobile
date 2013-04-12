namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class ProductBinder : QueryBinder<Product>
    {
        public override string SaveBinder(string template, Product @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"), @object.CategoryId);
        }
    }
}

