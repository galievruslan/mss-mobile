using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class CustomerRetriever : IDataPageRetriever<Customer> {

        private readonly CustomerStorageRepository _customerStorageRepository;

        public CustomerRetriever(CustomerStorageRepository customerStorageRepository) {
            _customerStorageRepository = customerStorageRepository;
        }

        public int Count {
            get {
                return _customerStorageRepository.Find().Count();
            }
        }

        public Customer[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _customerStorageRepository.Find()
                        .OrderBy("Name", OrderDirection.Asceding)
                        .Paged(lowerPageBoundary, rowsPerPage)
                        .ToArray();
        }
    }
}