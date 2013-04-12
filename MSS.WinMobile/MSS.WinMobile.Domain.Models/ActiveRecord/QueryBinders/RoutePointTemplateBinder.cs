namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class RoutePointTemplateBinder : QueryBinder<RoutePointTemplate>
    {
        public override string SaveBinder(string template, RoutePointTemplate @object)
        {
            return string.Format(template, @object.Id,
                @object.RouteTemplateId,
                @object.ShippingAddress != null ? string.Format("{0}, ", @object.ShippingAddress.Id) : "NULL, ");
        }
    }
}