using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class RoutePresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly SqLiteUnitOfWork _unitOfWork;
        private RouteRepository _routeRepository;

        private readonly IRouteView _view;
        private IDataPageRetriever<RoutePoint> _routePointRetriever;
        private Cache<RoutePoint> _cache; 

        public RoutePresenter(IRouteView view, SqLiteUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _view = view;
        }

        private RouteViewModel _viewModel;
        public RouteViewModel InitializeView() {
            _viewModel = new RouteViewModel {Date = DateTime.Now};
            GetRouteOnDate(_viewModel.Date);
            return _viewModel;
        }

        private RoutePoint _selectedRoutePoint;

        public void SelectItem(int index)
        {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public RoutePointViewModel GetRoutePointViewModel(int index)
        {
            RoutePoint item = _cache.RetrieveElement(index);
            return new RoutePointViewModel
                {
                    ShippinAddressName = item.ShippingAddressName
                };
        }

        public void GetRouteOnDate(DateTime date) {
            if (_routeRepository.Find().Where("Date", new Equals(_viewModel.Date.Date)).Any()) {
                _routeRepository = new RouteRepository(_unitOfWork);
                var route = _routeRepository.Find().Where("Date", new Equals(_viewModel.Date.Date)).FirstOrDefault();
                if (route == null) {
                    
                }
                _routePointRetriever = new RoutePointRetriever(new RoutePointRepository(_unitOfWork), route);
                _cache = new Cache<RoutePoint>(_routePointRetriever, 10);
                _view.SetItemCount(_routePointRetriever.Count);
            }
        }
    }
}
