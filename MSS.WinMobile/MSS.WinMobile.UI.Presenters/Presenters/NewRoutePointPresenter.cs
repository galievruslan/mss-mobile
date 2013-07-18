using System;
using System.Linq;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class NewRoutePointPresenter : IPresenter<NewRoutePointViewModel> {

        private static readonly ILog Log = LogManager.GetLogger(typeof(NewRoutePointPresenter));

        private readonly INewRoutePointView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IModelsFactory _modelsFactory;
        private readonly IConfigurationManager _configurationManager;
        private readonly INavigator _navigator;
        private readonly ILookUpService _lookUpService;
        private readonly RouteViewModel _routeViewModel;

        public NewRoutePointPresenter(INewRoutePointView view, 
                                      IUnitOfWorkFactory unitOfWorkFactory,
                                      IRepositoryFactory repositoryFactory,
                                      IModelsFactory modelsFactory, 
                                      IConfigurationManager configurationManager,
                                      INavigator navigator,
                                      ILookUpService lookUpService, 
                                      RouteViewModel routeViewModel) {
            _view = view;
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _configurationManager = configurationManager;
            _navigator = navigator;
            _lookUpService = lookUpService;
            _unitOfWorkFactory = unitOfWorkFactory;
            _routeViewModel = routeViewModel;
        }

        private NewRoutePointViewModel _viewModel;
        public NewRoutePointViewModel Initialize() {
            _viewModel = new NewRoutePointViewModel {
                RouteId = _routeViewModel.Id
            };
            return _viewModel;
        }

        public void LookUpCustomer() {
            CustomerViewModel selectedCustomer = _lookUpService.LookUpCustomer();
            if (selectedCustomer != null) {
                _viewModel.CustomerId = selectedCustomer.Id;
                _viewModel.CustomerName = selectedCustomer.Name;

                IStorageRepository<Customer> customersRepo =
                    _repositoryFactory.CreateRepository<Customer>();
                Customer customer = customersRepo.GetById(selectedCustomer.Id);
                if (customer.ShippingAddresses.GetCount() == 1) {
                    ShippingAddress shippingAddress = customer.ShippingAddresses.FirstOrDefault();
                    _viewModel.ShippingAddressId = shippingAddress.Id;
                    _viewModel.ShippingAddressName = shippingAddress.Name;
                }
                else {
                    _viewModel.ShippingAddressId = 0;
                    _viewModel.ShippingAddressName = string.Empty;
                }
            }
        }

        public void ResetCustomer() {
            _viewModel.CustomerId = 0;
            _viewModel.CustomerName = string.Empty;
            _viewModel.ShippingAddressId = 0;
            _viewModel.ShippingAddressName = string.Empty;
        }

        public void LookUpShippingAddress() {
            if (_viewModel.CustomerId != 0) {
                ShippingAddressViewModel selectedShippingAddress =
                    _lookUpService.LookUpCustomerShippingAddress(new CustomerViewModel {
                        Id = _viewModel.CustomerId,
                        Name = _viewModel.CustomerName
                    });

                if (selectedShippingAddress != null) {
                    _viewModel.ShippingAddressId = selectedShippingAddress.Id;
                    _viewModel.ShippingAddressName = selectedShippingAddress.Address;
                }
            }
            else { _view.ShowError(new[] {"You must select customer first!"}); }
        }

        public void ResetShippingAddress() {
            _viewModel.ShippingAddressId = 0;
            _viewModel.ShippingAddressName = string.Empty;
        }

        public void Save() {
            int defaultStatusId;
            try {
                defaultStatusId = _configurationManager.GetConfig("Domain")
                                                       .GetSection("Statuses")
                                                       .GetSetting("DefaultRoutePointStatusId")
                                                       .As<int>();

                if (defaultStatusId == 0)
                    throw new ApplicationException("\"Default route point status\" setting not found.");
            }
            catch (Exception exception) {
                Log.Error(exception);
                _view.ShowError(new[]
                {"Default status setting not found. Please synchronize your device."});
                return;
            }

            if (_viewModel.Validate()) {

                var routeRepository = _repositoryFactory.CreateRepository<Route>();
                var route =
                    routeRepository.Find()
                                   .Where(new RouteOnDateSpec(_routeViewModel.Date))
                                   .FirstOrDefault();

                var statusRepository = _repositoryFactory.CreateRepository<Status>();
                var defaultStatus = statusRepository.GetById(defaultStatusId);
                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();

                var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();

                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    ShippingAddress shippingAddress =
                        shippingAddressRepository.GetById(_viewModel.ShippingAddressId);
                    if (route != null) {
                        var existingRoutePoint =
                            routePointRepository.Find()
                                                .Where(
                                                    new RoutePointInRouteWithShippingAddress(route,
                                                                                             shippingAddress))
                                                .FirstOrDefault();
                        if (existingRoutePoint != null) {
                            _view.ShowError(new[] {"Route point with same shipping address already exist"});
                            return;
                        }
                    }

                    unitOfWork.BeginTransaction();
                    if (route == null) {
                        route = _modelsFactory.CreateRoute(_routeViewModel.Date);
                        route = routeRepository.Save(route);
                    }
                    var routePoint = route.CreatePoint();
                    routePoint.SetShippingAddress(shippingAddress);
                    routePoint.SetStatus(defaultStatus);

                    routePointRepository.Save(routePoint);
                    unitOfWork.Commit();
                }

                _navigator.GoToRoute(_routeViewModel);
            }
            else {
                _view.ShowError(_viewModel.Errors);
            }
        }

        public void Cancel() {
            _navigator.GoToRoute(_routeViewModel);
        }
    }
}
