using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class CustomerRetriever : IDataPageRetriever<Customer> {

        private readonly CustomerRepository _customerRepository;

        public CustomerRetriever(CustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public int Count {
            get {
                return _customerRepository.Find().GetCount();
            }
        }

        public Customer[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _customerRepository.Find()
                        .OrderBy("Name", OrderDirection.Asceding)
                        .Page(lowerPageBoundary, rowsPerPage)
                        .ToArray();
        }
    }
}