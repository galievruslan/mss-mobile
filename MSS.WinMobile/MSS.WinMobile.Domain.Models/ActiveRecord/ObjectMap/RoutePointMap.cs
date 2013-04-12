using System.Linq;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public class RoutePointMap : ObjectMap<RoutePoint>
    {
        public RoutePointMap()
        {
            Table = new Table("RoutePoints")
                .AddColumn(new KeyColumn("Id"))
                .AddColumn(new Column("Route_Id"))
                .AddColumn(new Column("ShippingAddress_Id"))
                .AddColumn(new Column("Order_Id"))
                .AddColumn(new Column("Status_Id"));
        }

        private string _saveFor;
        public override string SaveFor(RoutePoint @object)
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
                stringBuilder.Append("VALUES ('{0}', '{1}', {2}, {3}, {4})");
                _saveFor = stringBuilder.ToString();
            }

            return string.Format(_saveFor, 
                                 @object.Id, 
                                 @object.RouteId,
                                 @object.ShippingAddress != null ? string.Format("{0}, ", @object.ShippingAddress.Id) : "NULL, ",
                                 @object.Order != null ? string.Format("{0}, ", @object.Order.Id) : "NULL, ",
                                 @object.Status != null ? string.Format("{0}, ", @object.Status.Id) : "NULL, ");
        }

        private string _deleteFor;
        public override string DeleteFor(RoutePoint @object)
        {
            if (string.IsNullOrEmpty(_deleteFor))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("DELETE FROM [{0}] ", Table.Name));
                stringBuilder.Append(string.Format("DELETE FROM [{0}] = ",
                                                   Table.Columns.FirstOrDefault(column => column is KeyColumn).Name));

                stringBuilder.Append("'{0}'");
                _deleteFor = stringBuilder.ToString();
            }

            return string.Format(_deleteFor, @object.Id);
        }
    }
}
