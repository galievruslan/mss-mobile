using System.Linq;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public class RouteTemplateMap : ObjectMap<RouteTemplate>
    {
        public RouteTemplateMap()
        {
            Table = new Table("RouteTemplates")
                .AddColumn(new KeyColumn("Id"))
                .AddColumn(new Column("DayOfWeek"))
                .AddColumn(new Column("Manager_Id"));
        }

        private string _saveFor;
        public override string SaveFor(RouteTemplate @object)
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
                stringBuilder.Append("VALUES ({0}, {1}, {2})");
                _saveFor = stringBuilder.ToString();
            }

            return string.Format(_saveFor, @object.Id, (int)@object.DayOfWeek, @object.ManagerId);
        }

        private string _deleteFor;
        public override string DeleteFor(RouteTemplate @object)
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
    }
}
