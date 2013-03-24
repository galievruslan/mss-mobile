using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.DataRetrievers;
using log4net;

namespace MSS.WinMobile.UI.Presenters
{
    public class ShippingAddressLookUpPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IShippingAddressLookUpView _view;
        private readonly IDataPageRetriever<ShippingAddress> _shippingAddressRetriever;
        private readonly Cache<ShippingAddress> _cache;

        public ShippingAddressLookUpPresenter(IShippingAddressLookUpView view, Customer customer)
        {
            _shippingAddressRetriever = new ShippingAddressRetriever(customer);
            _cache = new Cache<ShippingAddress>(_shippingAddressRetriever, 10);
            _view = view;
        }

        public ShippingAddress GetShippingAddress(int index)
        {
            if (index >= _shippingAddressRetriever.Count)
                return null;

            return _cache.RetrieveElement(index);
        }

        public void InitializeView()
        {
            _view.SetShippingAddressCount(_shippingAddressRetriever.Count);
        }
    }
}
