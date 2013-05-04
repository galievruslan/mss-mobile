using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class ShippingAddressQueryObject : QueryObject<ShippingAddress>
    {
        public ShippingAddressQueryObject(IStorage storage,
                                          ISpecificationTranslator<ShippingAddress> specificationTranslator,
                                          DataRecordTranslator<ShippingAddress> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name, Address, Customer_Id, Mine FROM ShippingAddresses";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
