using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class ShippingAddressStorageRepository : SqLiteStorageRepository<ShippingAddress> {
        private readonly ISpecificationTranslator<ShippingAddress> _specificationTranslator;
        internal ShippingAddressStorageRepository(IStorage storage, ISpecificationTranslator<ShippingAddress> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<ShippingAddress> GetQueryObject()
        {
            return new ShippingAddressQueryObject(Storage, _specificationTranslator, new ShippingAddressDataRecordTranslator());
        }

        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO ShippingAddresses (Id, Name, Address, Customer_Id) VALUES ({0}, '{1}', '{2}', {3})";
        protected override string GetSaveQueryFor(ShippingAddress model) {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"),
                                 model.Address.Replace("'", "''"), model.CustomerId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ShippingAddresses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ShippingAddress model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
