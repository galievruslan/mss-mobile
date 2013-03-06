using System.Linq;
using MSS.WinMobile.Domain.Models;
using log4net;

namespace MSS.WinMobile.UI.Presenters
{
    public class RoutePresenter : Presenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private IRouteView _view;

        public RoutePresenter(ILayout layout, IRouteView view) : base(layout)
        {
            _view = view;

            // TODO Get route for current day (not last like now)
        }

        public int GetRoutePointsCount()
        {
            //using (ITransaction transaction = _session.BeginTransaction())
            //{
            //    IGenericRepository<Route> routeRepository = transaction.Resolve<Route>();
            //    Route route = routeRepository.Find().Last();
            //    if (route != null)
            //    {
            //        var routePointRepository =
            //            transaction.Resolve<RoutePoint>() as RoutePointRepository;

            //        if (routePointRepository != null)
            //        {
            //            return routePointRepository.FindByRoute(route).Length;
            //        }
            //    }
            //}

            return 0;
        }

        public int GetRoutePointId(int index)
        {
            return 0;
        }

        public string GetRoutePointLabel(int index)
        {
            return string.Empty;
        }
    }
}
