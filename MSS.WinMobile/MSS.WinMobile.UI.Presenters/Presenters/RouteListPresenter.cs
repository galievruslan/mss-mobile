using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class RouteListPresenter : IListPresenter {
        private IRouteListView _view;
        private readonly SqLiteUnitOfWork _unitOfWork;

        private readonly RoutesRetriever _routesRetriever;
        readonly Cache<Route> _cache;

        public RouteListPresenter(IRouteListView view, SqLiteUnitOfWork unitOfWork) {
            _view = view;
            _unitOfWork = unitOfWork;
            
            _routesRetriever = new RoutesRetriever(new RouteRepository(_unitOfWork));
            _cache = new Cache<Route>(_routesRetriever, 10);
        }

        public RouteViewModel GetRouteViewModel(int index)
        {
            Route item = _cache.RetrieveElement(index);
            return new RouteViewModel
                {
                    Date = item.Date
                };
        }

        public int InitializeList() {
            return _routesRetriever.Count;
        }
    }
}
