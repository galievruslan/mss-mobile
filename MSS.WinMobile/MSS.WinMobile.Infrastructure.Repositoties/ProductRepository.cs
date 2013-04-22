using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(SqliteConnectionFactory connectionFactory, SqliteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<Product> GetQueryObject()
        {
            return new ProductQueryObject(ConnectionFactory, new ProductTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Products (Id, Name, Category_Id) VALUES ({0}, '{1}', {2})";
        protected override string GetSaveQueryFor(Product model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"), model.CategoryId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM Products WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Product model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
