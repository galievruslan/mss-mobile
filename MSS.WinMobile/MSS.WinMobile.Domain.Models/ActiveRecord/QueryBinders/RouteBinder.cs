namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class RouteBinder : QueryBinder<Route>
    {
        public override string SaveBinder(string template, Route @object)
        {
            return string.Format(template, @object.Id,
                                 @object.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                                 @object.Manager != null ? string.Format("{0}, ", @object.Manager.Id) : "NULL, ");
        }
    }
}