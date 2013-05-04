using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class CustomerLookUpPresenter : IListPresenter<CustomerViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly ICustomerLookUpView _view;
        private readonly CustomerStorageRepository _customerStorageRepository;
        private readonly IDataPageRetriever<Customer> _customerRetriever;
        private readonly Cache<Customer> _cache;

        public CustomerLookUpPresenter(ICustomerLookUpView view, CustomerStorageRepository customerStorageRepository) {
            _customerStorageRepository = customerStorageRepository;
            _customerRetriever = new CustomerRetriever(_customerStorageRepository);
            _cache = new Cache<Customer>(_customerRetriever, 10);
            _view = view;
        }

        private Customer _selectedCustomer;
        public void SelectItem(int index)
        {
            _selectedCustomer = _cache.RetrieveElement(index);
        }

        public int GetSelectedItemId()
        {
            if (_selectedCustomer != null)
                return _selectedCustomer.Id;

            throw new NoSelectedItemsException();
        }

        public int InitializeListSize() {
            return _customerRetriever.Count;
        }

        public CustomerViewModel GetItem(int index) {
            Customer item = _cache.RetrieveElement(index);
            return new CustomerViewModel {
                Name = item.Name
            };
        }
    }
}
