using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class ProductQueryObject : QueryObject<Product>
    {
        public ProductQueryObject(IStorage storage,
                                  ISpecificationTranslator<Product> specificationTranslator,
                                  DataRecordTranslator<Product> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name, Category_Id FROM Products";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
