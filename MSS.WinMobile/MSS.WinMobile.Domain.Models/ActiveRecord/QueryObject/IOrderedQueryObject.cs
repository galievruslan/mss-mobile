namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public interface IOrderedQueryObject<T> : IQueryObject<T> where T : ActiveRecordBase
    {
        string OrderByField { get; }
        OrderDirection OrderDirection { get; }
    }
}