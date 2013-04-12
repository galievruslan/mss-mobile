namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class UnitOfMeasureBinder : QueryBinder<UnitOfMeasure>
    {
        public override string SaveBinder(string template, UnitOfMeasure @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"));
        }
    }
}
