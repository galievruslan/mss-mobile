using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class CustomerRetriever : IDataPageRetriever<Customer> {

        private readonly IStorageRepository<Customer> _customerStorageRepository;
        public CustomerRetriever(IStorageRepository<Customer> customerStorageRepository) {
            _customerStorageRepository = customerStorageRepository;
        }

        private readonly string _searchCriteria;
        public CustomerRetriever(IStorageRepository<Customer> customerStorageRepository,
                                 string searchCriteria)
            : this(customerStorageRepository) {
            _searchCriteria = searchCriteria;
        }

        public int Count {
            get {
                return string.IsNullOrEmpty(_searchCriteria)
                           ? _customerStorageRepository.Find().Count()
                           : _customerStorageRepository.Find()
                                                       .Where(
                                                           new CustomerWithNameLikeSpec(
                                                               _searchCriteria))
                                                       .Count();
            }
        }

        public Customer[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            IQueryObject<Customer> queryObject = _customerStorageRepository.Find();
            if (!string.IsNullOrEmpty(_searchCriteria))
                queryObject = queryObject.Where(new CustomerWithNameLikeSpec(_searchCriteria));

            return
                queryObject.OrderBy("Name", OrderDirection.Asceding)
                           .Paged(lowerPageBoundary, rowsPerPage)
                           .ToArray();
        }
    }
}