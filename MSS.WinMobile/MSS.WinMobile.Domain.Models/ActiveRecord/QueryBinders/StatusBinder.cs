namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class StatusBinder : QueryBinder<Status>
    {
        public override string SaveBinder(string template, Status @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"));
        }
    }
}
