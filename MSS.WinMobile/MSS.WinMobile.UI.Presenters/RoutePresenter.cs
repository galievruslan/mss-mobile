using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Presenters.DataRetrievers;
using log4net;

namespace MSS.WinMobile.UI.Presenters
{
    public class RoutePresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IRouteView _view;
        private readonly Route _route;
        private readonly IDataPageRetriever<RoutePoint> _routePointRetriever;
        private readonly Cache<RoutePoint> _cache; 

        public RoutePresenter(IRouteView view)
        {
            _route = Route.GetByDate(DateTime.Today);
            _routePointRetriever = new RoutePointRetriever(_route);
            _cache = new Cache<RoutePoint>(_routePointRetriever, 10);
            _view = view;
        }

        public Data GetRoutePointData(int index)
        {
            if (index >= _routePointRetriever.Count)
                return Data.Empty;

            RoutePoint routePoint = _cache.RetrieveElement(index);
            return new Data(routePoint.Id, routePoint.ShippingAddress.Name);
        }

        public void InitializeView()
        {
            _view.SetRoutePointCount(_routePointRetriever.Count);
        }
    }
}
