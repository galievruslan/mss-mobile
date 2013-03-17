namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public interface IOrderedQueryObject<T> : IQueryObject<T>
    {
        string OrderByField { get; }
        OrderDirection OrderDirection { get; }
    }
}