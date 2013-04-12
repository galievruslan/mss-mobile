using System.Data;
using System.Linq;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public class CategoryMap : ObjectMap<Category>
    {
        public CategoryMap()
        {
            Table = new Table("Categories")
                .AddColumn(new KeyColumn("Id"))
                .AddColumn(new Column("Name"))
                .AddColumn(new Column("Parent_Id"));
        }

        private string _saveFor;
        public override string SaveFor(Category @object)
        {
            if (string.IsNullOrEmpty(_saveFor))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("INSERT OR REPLACE INTO [{0}] (", Table.Name));
                for (int i = 0; i < Table.Columns.Length; i++)
                {
                    stringBuilder.Append(i != 0 ? ", " : ") ");
                    stringBuilder.Append(string.Format("[{0}]", Table.Columns[i].Name));
                }
                stringBuilder.Append("VALUES ({0}, '{1}', {2})");
                _saveFor = stringBuilder.ToString();
            }

            return string.Format(_saveFor, @object.Id, @object.Name.Replace("'", "''"), @object.ParentId);
        }

        private string _deleteFor;
        public override string DeleteFor(Category @object)
        {
            if (string.IsNullOrEmpty(_deleteFor))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("DELETE FROM [{0}] ", Table.Name));
                stringBuilder.Append(string.Format("DELETE FROM [{0}] = ",
                                                   Table.Columns.FirstOrDefault(column => column is KeyColumn).Name));

                stringBuilder.Append("{0}");
                _deleteFor = stringBuilder.ToString();
            }

            return string.Format(_deleteFor, @object.Id);
        }

        public override Category InstanceFrom(IDataRecord record, string fieldPrefix)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.IsDBNull(i))
                    continue;

                string fieldName = record.GetName(i);
                if (fieldPrefix != string.Empty)
                    fieldName = fieldName.Replace(fieldPrefix, string.Empty);

                switch (fieldName)
                {
                    case Table.Fields.ID:
                        {
                            Id = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.NAME:
                        {
                            Name = record.GetString(i);
                            break;
                        }
                    case Table.Fields.PARENT_ID:
                        {
                            ParentId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }
    }
}
