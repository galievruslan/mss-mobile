using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ShippingAddressRetriever : IDataPageRetriever<ShippingAddress> {

        private readonly ShippingAddressRepository _shippingAddressRepository;
        private readonly Customer _customer;

        public ShippingAddressRetriever(ShippingAddressRepository shippingAddressRepository, Customer customer) {
            _shippingAddressRepository = shippingAddressRepository;
            _customer = customer;
        }

        public int Count
        {
            get { return _shippingAddressRepository.Find().Where("Customer_Id", new Equals(_customer.Id)).Count(); }
        }

        public ShippingAddress[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _shippingAddressRepository.Find()
                                                .Where("Customer_Id", new Equals(_customer.Id))
                                                .OrderBy("Address", OrderDirection.Asceding)
                                                .Page(lowerPageBoundary, rowsPerPage)
                                                .ToArray();
        }
    }
}