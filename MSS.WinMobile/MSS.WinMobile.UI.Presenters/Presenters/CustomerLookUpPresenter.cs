using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class CustomerLookUpPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly ICustomerLookUpView _view;
        private readonly IDataPageRetriever<Customer> _customerRetriever;
        private readonly Cache<Customer> _cache;

        public CustomerLookUpPresenter(ICustomerLookUpView view)
        {
            _customerRetriever = new CustomerRetriever();
            _cache = new Cache<Customer>(_customerRetriever, 10);
            _view = view;
        }

        public void InitializeView()
        {
            _view.SetItemCount(_customerRetriever.Count);
        }

        private Customer _selectedCustomer;

        public void SelectItem(int index)
        {
            _selectedCustomer = _cache.RetrieveElement(index);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            Customer item = _cache.RetrieveElement(index);
            return new Dictionary<string, string> { { "Name", item.Name } };
        }

        public int GetSelectedItemId()
        {
            if (_selectedCustomer != null)
                return _selectedCustomer.Id;

            throw new NoSelectedItemsException();
        }
    }
}
