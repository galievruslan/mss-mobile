using System.Collections.Generic;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public interface IQueryObject<T>
    {
        string TableName { get; }
        string[] FieldsNames { get; }
        string BuildQuery();
        IEnumerator<T> GetEnumerator();
    }
}