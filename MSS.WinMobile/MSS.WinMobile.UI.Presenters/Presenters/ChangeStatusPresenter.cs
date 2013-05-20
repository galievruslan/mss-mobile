using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class ChangeStatusPresenter : IPresenter<RoutePointViewModel> {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ChangeStatusPresenter));

        private IChangeStatusView _changeStatusView;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly INavigator _navigator;
        private readonly RoutePointViewModel _routePointViewModel;

        public ChangeStatusPresenter(IChangeStatusView changeStatusView,
                                     IRepositoryFactory repositoryFactory,
                                     IUnitOfWorkFactory unitOfWorkFactory,
                                     INavigator navigator,
                                     RoutePointViewModel routePointViewModel) {
            _changeStatusView = changeStatusView;
            _repositoryFactory = repositoryFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            _navigator = navigator;
            _routePointViewModel = routePointViewModel;
        }

        public RoutePointViewModel Initialize() {
            return _routePointViewModel;
        }

        private StatusViewModel _selectedStatus;
        public void SelectStatus(StatusViewModel statusViewModel) {
            _selectedStatus = statusViewModel;
        }

        public IEnumerable<StatusViewModel> GetStatuses() {
            var statusRepository = _repositoryFactory.CreateRepository<Status>();
            return statusRepository.Find().Select(status => new StatusViewModel {
                Id = status.Id, Name = status.Name
            }).ToList();
        }

        public void Save() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route = routeRepository.GetById(_routePointViewModel.RouteId);

            var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointRepository.GetById(_routePointViewModel.Id);

            if (_selectedStatus != null && routePoint.StatusId != _selectedStatus.Id) {
                var statusRepository = _repositoryFactory.CreateRepository<Status>();
                var status = statusRepository.GetById(_selectedStatus.Id);
                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    try {
                        unitOfWork.BeginTransaction();
                        routePoint.SetStatus(status);
                        routePointRepository.Save(routePoint);
                        unitOfWork.Commit();
                    }
                    catch (Exception exception) {
                        Log.Error(exception);
                        unitOfWork.Rollback();
                    }
                }
            }
            _navigator.GoToRoute(new RouteViewModel {Id = route.Id, Date = route.Date});
        }

        public void Cancel() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route = routeRepository.GetById(_routePointViewModel.RouteId);
            _navigator.GoToRoute(new RouteViewModel {Id = route.Id, Date = route.Date});
        }
    }
}
