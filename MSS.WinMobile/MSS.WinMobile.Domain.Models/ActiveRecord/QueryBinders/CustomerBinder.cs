namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class CustomerBinder : QueryBinder<Customer>
    {
        public override string SaveBinder(string template, Customer @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"));
        }
    }
}
