using System.Linq;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public class ProductsPriceMap : ObjectMap<ProductsPrice>
    {
        public ProductsPriceMap()
        {
            Table = new Table("ProductsPrices")
                .AddColumn(new KeyColumn("Id"))
                .AddColumn(new Column("Product_Id"))
                .AddColumn(new Column("PriceList_Id"))
                .AddColumn(new Column("Price"));
        }

        private string _saveFor;
        public override string SaveFor(ProductsPrice @object)
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
                stringBuilder.Append("VALUES ({0}, {1}, {2}, {3})");
                _saveFor = stringBuilder.ToString();
            }

            return string.Format(_saveFor, 
                                 @object.Id,
                                 @object.Product != null ? string.Format("{0}, ", @object.Product.Id) : "NULL, ",
                                 @object.PriceListId,
                                 @object.Price);
        }

        private string _deleteFor;
        public override string DeleteFor(ProductsPrice @object)
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
