using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.DataRetrievers;
using log4net;

namespace MSS.WinMobile.UI.Presenters
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

        public Customer GetCustomer(int index)
        {
            if (index >= _customerRetriever.Count)
                return null;

            return _cache.RetrieveElement(index);
        }

        public void InitializeView()
        {
            _view.SetCustomerCount(_customerRetriever.Count);
        }
    }
}
