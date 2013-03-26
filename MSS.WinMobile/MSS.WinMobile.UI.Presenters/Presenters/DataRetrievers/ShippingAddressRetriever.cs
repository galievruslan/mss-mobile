using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ShippingAddressRetriever : IDataPageRetriever<ShippingAddress>
    {
        private readonly Customer _customer;
        public ShippingAddressRetriever(Customer customer)
        {
            _customer = customer;
        }

        private int _cachedCount;
        public int Count
        {
            get
            {
                if (_cachedCount == 0)
                    _cachedCount = _customer.ShippingAddresses().Count();
                return _cachedCount;
            }
        }

        public ShippingAddress[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _customer.ShippingAddresses()
                         .OrderBy(ShippingAddress.Table.Fields.ADDRESS, OrderDirection.Asceding)
                         .Skip(lowerPageBoundary)
                         .Take(rowsPerPage)
                         .ToArray();
        }
    }
}