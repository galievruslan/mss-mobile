using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps
{
    public class ShippingAddressLookUpPresenter : IListPresenter<ShippingAddressViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IShippingAddressLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IDataPageRetriever<ShippingAddress> _shippingAddressRetriever;
        private readonly Cache<ShippingAddress> _cache;

        public ShippingAddressLookUpPresenter(IShippingAddressLookUpView view, IRepositoryFactory repositoryFactory, CustomerViewModel customerViewModel)
        {
            _repositoryFactory = repositoryFactory;
            var customerRepository = _repositoryFactory.CreateRepository<Customer>();
            _shippingAddressRetriever = new ShippingAddressRetriever(customerRepository.GetById(customerViewModel.Id));
            _cache = new Cache<ShippingAddress>(_shippingAddressRetriever, 100);
            _view = view;
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

        private ShippingAddress _selectedShippingAddress;
        public void Select(int index) {
            _selectedShippingAddress = _cache.RetrieveElement(index);
        }

        public ShippingAddressViewModel SelectedModel {
            get {
                return _selectedShippingAddress != null
                           ? new ShippingAddressViewModel {
                               Id = _selectedShippingAddress.Id,
                               Name = _selectedShippingAddress.Name,
                               Address = _selectedShippingAddress.Address
                           }
                           : null;
            }
        }
    }
}
