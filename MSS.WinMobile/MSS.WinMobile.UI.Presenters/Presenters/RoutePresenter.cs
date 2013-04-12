using System;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class RoutePresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IRouteView _view;
        private readonly IDataPageRetriever<RoutePoint> _routePointRetriever;
        private readonly Cache<RoutePoint> _cache; 

        public RoutePresenter(IRouteView view)
        {
            _routePointRetriever = RetrieversCache.GetCurrentRoutePointRetriever();
            _cache = new Cache<RoutePoint>(_routePointRetriever, 10);
            _view = view;
        }

        public void InitializeView()
        {
            _view.SetItemCount(_routePointRetriever.Count);
        }

        private RoutePoint _selectedRoutePoint;

        public void SelectItem(int index)
        {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            RoutePoint item = _cache.RetrieveElement(index);
            return new Dictionary<string, string> { { "Name", item.ShippingAddress.Name } };
        }

        public int GetSelectedItemId()
        {
            if (_selectedRoutePoint != null)
                return _selectedRoutePoint.Id;

            throw new NoSelectedItemsException();
        }
    }
}
