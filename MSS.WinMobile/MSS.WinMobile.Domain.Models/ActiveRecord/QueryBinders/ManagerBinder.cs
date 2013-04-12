namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class ManagerBinder : QueryBinder<Manager>
    {
        public override string SaveBinder(string template, Manager @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"));
        }
    }
}
