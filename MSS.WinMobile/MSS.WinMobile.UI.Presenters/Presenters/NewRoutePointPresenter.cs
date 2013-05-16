using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class NewRoutePointPresenter : IPresenter<NewRoutePointViewModel> {

        private readonly INewRoutePointView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IModelsFactory _modelsFactory;
        private readonly INavigator _navigator;
        private readonly ILookUpService _lookUpService;
        private readonly RouteViewModel _routeViewModel;

        public NewRoutePointPresenter(INewRoutePointView view, 
                                      IUnitOfWorkFactory unitOfWorkFactory,
                                      IRepositoryFactory repositoryFactory, 
                                      IModelsFactory modelsFactory,
                                      INavigator navigator,
                                      ILookUpService lookUpService, 
                                      RouteViewModel routeViewModel) {
            _view = view;
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
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
                _viewModel.ShippingAddressId = 0;
                _viewModel.ShippingAddressName = string.Empty;
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
            else { _view.ShowError("You must select customer first."); }
        }

        public void ResetShippingAddress() {
            _viewModel.ShippingAddressId = 0;
            _viewModel.ShippingAddressName = string.Empty;
        }

        public void Save() {
            if (_viewModel.Validate()) {

                var routeRepository = _repositoryFactory.CreateRepository<Route>();
                var route =
                    routeRepository.Find()
                                   .Where(new RouteOnDateSpec(_routeViewModel.Date))
                                   .FirstOrDefault();

                var statusRepository = _repositoryFactory.CreateRepository<Status>();
                var defaultStatus = statusRepository.Find().FirstOrDefault();
                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();

                var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();

                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    unitOfWork.BeginTransaction();
                    if (route == null) {
                        route = _modelsFactory.CreateRoute(_routeViewModel.Date);
                        route = routeRepository.Save(route);
                    }
                    var routePoint = route.CreatePoint();
                    routePoint.SetShippingAddress(
                        shippingAddressRepository.GetById(_viewModel.ShippingAddressId));
                    routePoint.SetStatus(defaultStatus);

                    routePointRepository.Save(routePoint);
                    unitOfWork.Commit();
                }
            }
            else {
                _view.ShowError(_viewModel.Errors);
            }
            _navigator.GoToRoute(_routeViewModel);
        }

        public void Cancel() {
            _navigator.GoToRoute(_routeViewModel);
        }
    }
}
