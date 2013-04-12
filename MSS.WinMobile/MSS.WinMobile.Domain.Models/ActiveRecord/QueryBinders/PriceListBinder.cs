namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class PriceListBinder : QueryBinder<PriceList>
    {
        public override string SaveBinder(string template, PriceList @object)
        {
            return string.Format(template, @object.Id, @object.Name.Replace("'", "''"));
        }
    }
}

