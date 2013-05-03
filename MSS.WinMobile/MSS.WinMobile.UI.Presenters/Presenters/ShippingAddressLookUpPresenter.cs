using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class ShippingAddressLookUpPresenter : IListPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IShippingAddressLookUpView _view;
        private readonly CustomerRepository _customerRepository;
        private readonly ShippingAddressRepository _shippingAddressRepository;
        private readonly IDataPageRetriever<ShippingAddress> _shippingAddressRetriever;
        private readonly Cache<ShippingAddress> _cache;

        public ShippingAddressLookUpPresenter(IShippingAddressLookUpView view, CustomerRepository customerRepository, ShippingAddressRepository shippingAddressRepository, int customerId) {
            _customerRepository = customerRepository;
            _shippingAddressRepository = shippingAddressRepository;
            _shippingAddressRetriever = new ShippingAddressRetriever(_shippingAddressRepository,
                                                                     _customerRepository.GetById(customerId));
            _cache = new Cache<ShippingAddress>(_shippingAddressRetriever, 10);
            _view = view;
        }

        private ShippingAddress _selectedShippingAddress;

        public void SelectItem(int index)
        {
            _selectedShippingAddress = _cache.RetrieveElement(index);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            ShippingAddress item = _cache.RetrieveElement(index);
            return new Dictionary<string, string> { { "Address", item.Address } };
        }

        public int GetSelectedItemId()
        {
            if (_selectedShippingAddress != null)
                return _selectedShippingAddress.Id;

            throw new NoSelectedItemsException();
        }

        public int InitializeList() {
            return _shippingAddressRetriever.Count;
        }
    }
}
