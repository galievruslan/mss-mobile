using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class NewRoutePointPresenter : IPresenter<NewRoutePointViewModel> {

        private readonly INewRoutePointView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private readonly RouteViewModel _routeViewModel;

        public NewRoutePointPresenter(INewRoutePointView view, IUnitOfWorkFactory unitOfWorkFactory,
                                      IRepositoryFactory repositoryFactory, RouteViewModel routeViewModel) {
            _view = view;
            _repositoryFactory = repositoryFactory;
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
            var view = NavigationContext.NavigateTo<ICustomerLookUpView>();
            if (view.ShowDialogView() == DialogViewResult.Ok) {
                _viewModel.CustomerId = view.SelectedCustomer.Id;
                _viewModel.CustomerName = view.SelectedCustomer.Name;
                _viewModel.ShippingAddressId = 0;
                _viewModel.ShippingAddressName = string.Empty;
            }
            view.CloseView();
        }

        public void ResetCustomer() {
            _viewModel.CustomerId = 0;
            _viewModel.CustomerName = string.Empty;
            _viewModel.ShippingAddressId = 0;
            _viewModel.ShippingAddressName = string.Empty;
        }

        public void LookUpShippingAddress() {
            var view =
                NavigationContext.NavigateTo<IShippingAddressLookUpView>(
                    new Dictionary<string, object>
                        {
                            {"customer", new CustomerViewModel {Id = _viewModel.CustomerId, Name = _viewModel.CustomerName}}
                        });
            if (view.ShowDialogView() == DialogViewResult.Ok) {
                _viewModel.ShippingAddressId = view.SelectedShippingAddress.Id;
                _viewModel.ShippingAddressName = view.SelectedShippingAddress.Address;
            }
            view.CloseView();
        }

        public void ResetShippingAddress() {
            _viewModel.ShippingAddressId = 0;
            _viewModel.ShippingAddressName = string.Empty;
        }

        public bool Save() {
            if (_viewModel.Validate()) {

                IStorageRepository<Route> routeRepository =
                    _repositoryFactory.CreateRepository<Route>();
                var route = routeRepository.GetById(_routeViewModel.Id);
                var statusRepository = _repositoryFactory.CreateRepository<Status>();
                var defaultStatus = statusRepository.Find().FirstOrDefault();
                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();

                var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();

                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {

                    var routePoint = route.CreatePoint();
                    routePoint.SetShippingAddress(
                        shippingAddressRepository.GetById(_viewModel.ShippingAddressId));
                    routePoint.SetStatus(defaultStatus);

                    unitOfWork.BeginTransaction();
                    routePointRepository.Save(routePoint);
                    unitOfWork.Commit();
                    return true;
                }
            }

            _view.DisplayErrors(_viewModel.Errors);
            return false;
        }

        public void Cancel() {
            _view.CloseView();
        }
    }
}
