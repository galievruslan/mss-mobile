using System.Collections.Generic;
using System.Data;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public abstract class ObjectMap<T> where T : ActiveRecordBase<T>
    {
        public Table Table { get; protected set; }

        public abstract string SaveFor(T @object);

        public abstract string DeleteFor(T @object);

        public abstract T InstanceFrom(IDataRecord record, string fieldPrefix);
    }

    public class Table
    {
        public Table(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
        public Column[] Columns {
            get { return _columns.ToArray(); }
        }

        readonly List<Column> _columns = new List<Column>();
        public Table AddColumn(Column column)
        {
            _columns.Add(column);
            return this;
        }
    }

    public class Column
    {
        public Column(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
    }

    public class KeyColumn : Column
    {
        public KeyColumn(string name) : base(name)
        {
        }
    }
}
