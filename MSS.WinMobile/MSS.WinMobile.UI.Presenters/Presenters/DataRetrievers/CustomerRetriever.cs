using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class CustomerRetriever : IDataPageRetriever<Customer>
    {
        private int _cachedCount;
        public int Count {
            get
            {
                if (_cachedCount == 0)
                    _cachedCount = Customer.GetAll().Count();
                return _cachedCount;
            }
        }

        public Customer[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                Customer.GetAll()
                        .OrderBy(Customer.Table.Fields.NAME, OrderDirection.Asceding)
                        .Skip(lowerPageBoundary)
                        .Take(rowsPerPage)
                        .ToArray();
        }
    }
}