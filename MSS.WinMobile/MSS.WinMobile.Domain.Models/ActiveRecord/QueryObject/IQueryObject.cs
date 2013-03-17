using System.Collections.Generic;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public interface IQueryObject<T> where T : ActiveRecordBase
    {
        string TableName { get; }
        string[] FieldsNames { get; }

        IEnumerator<T> GetEnumerator();
    }
}