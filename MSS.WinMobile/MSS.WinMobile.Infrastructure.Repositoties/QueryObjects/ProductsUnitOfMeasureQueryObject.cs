using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ProductsUnitOfMeasureQueryObject : QueryObject<ProductsUnitOfMeasure>
    {
        public ProductsUnitOfMeasureQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<ProductsUnitOfMeasure, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Product_Id, UnitOfMeasure_Id, Base FROM ProductsUnitOfMeasures";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
