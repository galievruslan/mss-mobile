﻿using System;
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

        public void InitializeView()
        {
            _view.SetItemCount(_routePointRetriever.Count);
        }

        private RoutePoint _selectedRoutePoint;

        public void SelectItem(int index)
        {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public string GetItemName(int index)
        {
            return _cache.RetrieveElement(index).ShippingAddress.Name;
        }

        public int GetSelectedItemId()
        {
            if (_selectedRoutePoint != null)
                return _selectedRoutePoint.Id;

            throw new NoSelectedItemsException();
        }
    }
}