namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class WarehouseBinder : QueryBinder<Warehouse>
    {
        public override string SaveBinder(string template, Warehouse @object)
        {
            return string.Format(template, @object.Id, @object.Address.Replace("'", "''"));
        }
    }
}
