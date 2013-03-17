using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public interface IFiltredQueryObject<T> : IQueryObject<T> where T : ActiveRecordBase
    {
        string FilterByField { get; }
        Condition Condition { get; }
    }
}