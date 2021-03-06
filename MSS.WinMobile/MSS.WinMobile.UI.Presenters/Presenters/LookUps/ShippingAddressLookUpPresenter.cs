﻿using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;
using AppCache = MSS.WinMobile.Application.Cache.Cache;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps
{
    public class ShippingAddressLookUpPresenter : IListPresenter<ShippingAddressViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IShippingAddressLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly CustomerViewModel _customerViewModel;
        private IDataPageRetriever<ShippingAddress> _shippingAddressRetriever;
        private Cache<ShippingAddress> _cache;

        public ShippingAddressLookUpPresenter(IShippingAddressLookUpView view, IRepositoryFactory repositoryFactory, CustomerViewModel customerViewModel)
        {
            _repositoryFactory = repositoryFactory;
            _customerViewModel = customerViewModel;
            var customerRepository = _repositoryFactory.CreateRepository<Customer>();
            var customer = customerRepository.GetById(_customerViewModel.Id);
            _shippingAddressRetriever = new ShippingAddressRetriever(customer);
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

            string shippingAddressCacheKey = string.Format("ShippingAddress Id={0}", _selectedShippingAddress.Id);
            if (!AppCache.Contains(shippingAddressCacheKey))
                AppCache.Add(shippingAddressCacheKey, _selectedShippingAddress);
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

        private string _searchCriteria;
        public void Search(string criteria) {
            _searchCriteria = criteria;
            var customerRepository = _repositoryFactory.CreateRepository<Customer>();
            var customer = customerRepository.GetById(_customerViewModel.Id);
            _shippingAddressRetriever =
                new ShippingAddressRetriever(customer, _searchCriteria);
            _cache = new Cache<ShippingAddress>(_shippingAddressRetriever, 100);
            _selectedShippingAddress = null;
        }

        public void ClearSearch() {
            _searchCriteria = string.Empty;
            var customerRepository = _repositoryFactory.CreateRepository<Customer>();
            var customer = customerRepository.GetById(_customerViewModel.Id);
            _shippingAddressRetriever =
                new ShippingAddressRetriever(customer);
            _cache = new Cache<ShippingAddress>(_shippingAddressRetriever, 100);
            _selectedShippingAddress = null;
        }

        public void ShowDetails() {
            if (SelectedModel != null) {
                _view.ShowDetails(new Dictionary<string, string> {
                    {"Shipping address name", SelectedModel.Name},
                    {"Shipping address", SelectedModel.Address}
                });
            }
        }
    }
}
