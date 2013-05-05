using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class CustomerRetriever : IDataPageRetriever<Customer> {

        private readonly IStorageRepository<Customer> _customerStorageRepository;

        public CustomerRetriever(IStorageRepository<Customer> customerStorageRepository) {
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