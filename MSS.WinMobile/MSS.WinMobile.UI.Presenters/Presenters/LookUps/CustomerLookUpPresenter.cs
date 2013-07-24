using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;
using AppCache = MSS.WinMobile.Application.Cache.Cache;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps
{
    public class CustomerLookUpPresenter : IListPresenter<CustomerViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly ICustomerLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private IDataPageRetriever<Customer> _customerRetriever;
        private Cache<Customer> _cache;

        public CustomerLookUpPresenter(ICustomerLookUpView view, IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
            _customerRetriever = new CustomerRetriever(_repositoryFactory.CreateRepository<Customer>());
            _cache = new Cache<Customer>(_customerRetriever, 50);
            _view = view;
        }

        public int InitializeListSize() {
            return _customerRetriever.Count;
        }

        public CustomerViewModel GetItem(int index) {
            Customer item = _cache.RetrieveElement(index);
            return new CustomerViewModel
                {
                    Name = item.Name,
                    Address = item.Address
                };
        }

        private Customer _selectedCustomer;
        public void Select(int index) {
            _selectedCustomer = _cache.RetrieveElement(index);

            string customerCacheKey = string.Format("Customer Id={0}", _selectedCustomer.Id);
            if (!AppCache.Contains(customerCacheKey))
                AppCache.Add(customerCacheKey, _selectedCustomer);
        }

        public CustomerViewModel SelectedModel {
            get {
                return _selectedCustomer != null
                           ? new CustomerViewModel
                               {
                                   Id = _selectedCustomer.Id,
                                   Name = _selectedCustomer.Name,
                                   Address = _selectedCustomer.Address
                               }
                           : null;
            }
        }

        private string _searchCriteria;
        public void Search(string criteria) {
            _searchCriteria = criteria;
            _customerRetriever =
                new CustomerRetriever(_repositoryFactory.CreateRepository<Customer>(),
                                      _searchCriteria);
            _cache = new Cache<Customer>(_customerRetriever, 100);
            _selectedCustomer = null;
        }

        public void ClearSearch() {
            _searchCriteria = string.Empty;
            _customerRetriever =
                new CustomerRetriever(_repositoryFactory.CreateRepository<Customer>());
            _cache = new Cache<Customer>(_customerRetriever, 100);
            _selectedCustomer = null;
        }

        public void ShowDetails() {
            if (_selectedCustomer != null) {
                _view.ShowDetails(new Dictionary<string, string> {
                    {"Customer name", _selectedCustomer.Name}
                });
            }
        }
    }
}
