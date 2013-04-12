namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class OrderBinder : QueryBinder<Order>
    {
        public override string SaveBinder(string template, Order @object)
        {
            return string.Format(template,
                                 @object.Id,
                                 @object.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                                 @object.ShippingAddress != null
                                     ? string.Format("{0}, ", @object.ShippingAddress.Id)
                                     : "NULL, ",
                                 @object.Manager != null ? string.Format("{0}, ", @object.Manager.Id) : "NULL, ",
                                 @object.PriceList != null ? string.Format("{0}, ", @object.PriceList.Id) : "NULL, ",
                                 @object.Warehouse != null ? string.Format("{0}, ", @object.Warehouse.Id) : "NULL, ",
                                 @object.Note.Replace("'", "''"));
        }
    }
}
