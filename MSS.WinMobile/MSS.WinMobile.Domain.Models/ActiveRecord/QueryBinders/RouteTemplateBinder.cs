namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class RouteTemplateBinder : QueryBinder<RouteTemplate>
    {
        public override string SaveBinder(string template, RouteTemplate @object)
        {
            return string.Format(template, @object.Id, (int)@object.DayOfWeek, @object.ManagerId);
        }
    }
}