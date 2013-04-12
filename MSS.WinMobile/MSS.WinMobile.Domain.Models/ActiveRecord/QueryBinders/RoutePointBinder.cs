namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class RoutePointBinder : QueryBinder<RoutePoint>
    {
        public override string SaveBinder(string template, RoutePoint @object)
        {
            return string.Format(template, @object.Id,
                                 @object.RouteId,
                                 @object.ShippingAddress != null ? string.Format("{0}, ", @object.ShippingAddress.Id) : "NULL, ",
                                 @object.Order != null ? string.Format("{0}, ", @object.Order.Id) : "NULL, ",
                                 @object.Status != null ? string.Format("{0}, ", @object.Status.Id) : "NULL, ");
        }
    }
}