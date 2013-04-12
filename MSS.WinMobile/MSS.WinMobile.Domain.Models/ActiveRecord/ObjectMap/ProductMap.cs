using System.Linq;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.ObjectMap
{
    public class ProductMap : ObjectMap<Product>
    {
        public ProductMap()
        {
            Table = new Table("Products")
                .AddColumn(new KeyColumn("Id"))
                .AddColumn(new Column("Name"))
                .AddColumn(new Column("Category_Id"));
        }

        private string _saveFor;
        public override string SaveFor(Product @object)
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

            return string.Format(_saveFor, @object.Id, @object.Name.Replace("'", "''"), @object.CategoryId);
        }

        private string _deleteFor;
        public override string DeleteFor(Product @object)
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
