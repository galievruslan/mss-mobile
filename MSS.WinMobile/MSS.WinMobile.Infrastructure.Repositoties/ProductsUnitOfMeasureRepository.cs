using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ProductsUnitOfMeasureSQLiteRepository : SQLiteRepository<ProductsUnitOfMeasure>
    {
        public ProductsUnitOfMeasureSQLiteRepository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }


        protected override QueryObject<ProductsUnitOfMeasure> GetQueryObject()
        {
            return new ProductsUnitOfMeasureQueryObject(ConnectionFactory, new ProductsUnitOfMeasureDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO ProductsUnitOfMeasures (Id, Product_Id, UnitOfMeasure_Id, Base) VALUES ({0}, {1}, {2}, {3})";
        protected override string GetSaveQueryFor(ProductsUnitOfMeasure model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.ProductId, model.UnitOfMeasureId, model.Base ? 1 : 0);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ProductsUnitOfMeasures WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ProductsUnitOfMeasure model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
