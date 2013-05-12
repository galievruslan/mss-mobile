﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using MSS.WinMobile.Synchronizer.Specifications;

namespace MSS.WinMobile.Synchronizer {
    public class RoutesSynchronization : Command<Route, string> {

        private readonly IWebServer _webServer;
        private readonly IStorageRepository<Route> _routesRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public RoutesSynchronization(IWebServer webServer,
            IStorageRepository<Route> routesRepository,
            IUnitOfWorkFactory unitOfWorkFactory) {
            _webServer = webServer;
            _routesRepository = routesRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override void Execute() {
            var routesToSync = _routesRepository.Find().Where(new RoutesToSyncSpec()).ToArray();

            foreach (var route in routesToSync) {
                IDictionary<string, object> routeDictionary = RouteToDictionary(route);
                IWebConnection webConnection = _webServer.Connect();
                var httpWebRequest = RequestFactory.CreatePostRequest(webConnection,
                                                                      "synchronization/routes.json",
                                                                      routeDictionary);
                string result = webConnection.Post(httpWebRequest);
            }
        }

        private IDictionary<string, object> RouteToDictionary(Route route) {
            var rootDictionary = new Dictionary<string, object>();
            var routeAttributesDictionary = new  Dictionary<string, object>();
            rootDictionary.Add("route", routeAttributesDictionary);
            routeAttributesDictionary.Add("date", route.Date.ToString("dd.MM.yyyy"));
            var routePointsAttributesDictionary = new Dictionary<string, object>();
            routeAttributesDictionary.Add("route_points_attributes", routePointsAttributesDictionary);
            var routePoints = route.Points.ToArray();
            for (int i = 0; i < routePoints.Length; i++) {
                var routePointAttributesDictionary = new Dictionary<string, object>();
                routePointsAttributesDictionary.Add(i.ToString(CultureInfo.InvariantCulture), routePointAttributesDictionary);
                routePointAttributesDictionary.Add("shipping_address_id", routePoints[i].ShippingAddressId);
                routePointAttributesDictionary.Add("status_id", routePoints[i].StatusId);
            }

            return rootDictionary;
        }
    }
}
