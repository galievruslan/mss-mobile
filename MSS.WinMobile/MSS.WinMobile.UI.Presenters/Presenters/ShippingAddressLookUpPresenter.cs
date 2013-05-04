using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class ShippingAddressLookUpPresenter : IListPresenter<ShippingAddressViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IShippingAddressLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IDataPageRetriever<ShippingAddress> _shippingAddressRetriever;
        private readonly Cache<ShippingAddress> _cache;

        public ShippingAddressLookUpPresenter(IShippingAddressLookUpView view, IRepositoryFactory repositoryFactory, int customerId) {
            _repositoryFactory = repositoryFactory;
            var customerRepository = _repositoryFactory.CreateRepository<Customer>();
            _shippingAddressRetriever = new ShippingAddressRetriever(customerRepository.GetById(customerId));
            _cache = new Cache<ShippingAddress>(_shippingAddressRetriever, 10);
            _view = view;
        }

        private ShippingAddress _selectedShippingAddress;

        public void SelectItem(int index)
        {
            _selectedShippingAddress = _cache.RetrieveElement(index);
        }

        public int GetSelectedItemId()
        {
            if (_selectedShippingAddress != null)
                return _selectedShippingAddress.Id;

            throw new NoSelectedItemsException();
        }

        public int InitializeListSize() {
            return _shippingAddressRetriever.Count;
        }

        public ShippingAddressViewModel GetItem(int index) {
            ShippingAddress item = _cache.RetrieveElement(index);
            return new ShippingAddressViewModel {
                Name = item.Name,
                Address = item.Address
            };
        }
    }
}
