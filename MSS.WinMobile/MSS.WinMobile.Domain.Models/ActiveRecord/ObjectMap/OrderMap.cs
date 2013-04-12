using System.Linq;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public class OrderMap : ObjectMap<Order>
    {
        public OrderMap()
        {
            Table = new Table("Orders")
                .AddColumn(new KeyColumn("Id"))
                .AddColumn(new Column("Date"))
                .AddColumn(new Column("ShippingAddress_Id"))
                .AddColumn(new Column("Manager_Id"))
                .AddColumn(new Column("PriceList_Id"))
                .AddColumn(new Column("Warehouse_Id"))
                .AddColumn(new Column("Note"));
        }

        private string _saveFor;
        public override string SaveFor(Order @object)
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
                stringBuilder.Append("VALUES ('{0}', '{1}', {2}, {3}, {4}, '{5}')");
                _saveFor = stringBuilder.ToString();
            }

            return string.Format(_saveFor, 
                                 @object.Id,
                                 @object.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                                 @object.ShippingAddress != null ? string.Format("{0}, ", @object.ShippingAddress.Id) : "NULL, ",
                                 @object.Manager != null ? string.Format("{0}, ", @object.Manager.Id) : "NULL, ",
                                 @object.PriceList != null ? string.Format("{0}, ", @object.PriceList.Id) : "NULL, ",
                                 @object.Warehouse != null ? string.Format("{0}, ", @object.Warehouse.Id) : "NULL, ",
                                 @object.Note.Replace("'", "''"));
        }

        private string _deleteFor;
        public override string DeleteFor(Order @object)
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
