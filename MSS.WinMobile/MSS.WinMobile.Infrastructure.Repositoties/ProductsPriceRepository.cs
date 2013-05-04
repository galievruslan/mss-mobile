using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class ProductsPriceStorageRepository : SqLiteStorageRepository<ProductsPrice> {
        private readonly ISpecificationTranslator<ProductsPrice> _specificationTranslator;
        internal ProductsPriceStorageRepository(IStorage storage, ISpecificationTranslator<ProductsPrice> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<ProductsPrice> GetQueryObject()
        {
            return new ProductsPriceQueryObject(Storage, _specificationTranslator, new ProductsPriceDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO ProductsPrices (Id, Product_Id, PriceList_Id, Price) VALUES ({0}, {1}, {2}, {3})";
        protected override string GetSaveQueryFor(ProductsPrice model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.ProductId, model.PriceListId, model.Price);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ProductsPrices WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ProductsPrice model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
