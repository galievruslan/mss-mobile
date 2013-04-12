namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class ShippingAddressBinder : QueryBinder<ShippingAddress>
    {
        public override string SaveBinder(string template, ShippingAddress @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"));
        }
    }
}
