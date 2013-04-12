namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public abstract class QueryBinder<T> where T : ActiveRecordBase
    {
        public abstract string SaveBinder(string template, T @object);

        public virtual string DeleteBinder(string template, T @object)
        {
            return string.Format(template, @object.Id);
        }
    }
}
