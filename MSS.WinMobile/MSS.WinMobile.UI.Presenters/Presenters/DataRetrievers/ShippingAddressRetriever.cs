using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ShippingAddressRetriever : IDataPageRetriever<ShippingAddress> {

        private readonly Customer _customer;

        public ShippingAddressRetriever(Customer customer) {
            _customer = customer;
        }

        private readonly string _searchCriteria;
        public ShippingAddressRetriever(Customer customer, string searchCriteria)
            : this(customer) {
            _searchCriteria = searchCriteria;
        }


        public int Count
        {
            get {
                if (_customer == null)
                    return 0;

                return string.IsNullOrEmpty(_searchCriteria)
                           ? _customer.ShippingAddresses.Count()
                           : _customer.ShippingAddresses.Where(
                               new ShippingAddressWithNameOrAddressLikeSpec(_searchCriteria))
                                      .Count();
            }
        }

        public ShippingAddress[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            if (_customer == null)
                return new ShippingAddress[0];

            IQueryObject<ShippingAddress> queryObject = _customer.ShippingAddresses;
            if (!string.IsNullOrEmpty(_searchCriteria))
                queryObject =
                    queryObject.Where(new ShippingAddressWithNameOrAddressLikeSpec(_searchCriteria));

            return
                queryObject.OrderBy("Address", OrderDirection.Asceding)
                           .Paged(lowerPageBoundary, rowsPerPage)
                           .ToArray();
        }
    }
}