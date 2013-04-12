namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class CategoryBinder : QueryBinder<Category>
    {
        public override string SaveBinder(string template, Category @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"), @object.ParentId);
        }
    }
}
