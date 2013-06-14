using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using MSS.WinMobile.Common;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using MSS.WinMobile.Synchronizer.Specifications;

namespace MSS.WinMobile.Synchronizer {
    public class RoutesSynchronization : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RoutesSynchronization));

        private readonly IWebServer _webServer;
        private readonly IStorageRepository<Route> _routesRepository;
        private readonly IStorageRepository<RoutePoint> _routePointsRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public RoutesSynchronization(IWebServer webServer,
            IStorageRepository<Route> routesRepository,
            IStorageRepository<RoutePoint> routePointsRepository,
            IUnitOfWorkFactory unitOfWorkFactory) {
            _webServer = webServer;
            _routesRepository = routesRepository;
            _routePointsRepository = routePointsRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override bool Execute() {
            var routesToSync = _routesRepository.Find().Where(new RoutesToSyncSpec()).ToArray();

            foreach (var route in routesToSync) {
                IDictionary<string, object> routeDictionary = RouteToDictionary(route);
                IWebConnection webConnection = _webServer.Connect();
                var httpWebRequest = RequestFactory.CreatePostRequest(webConnection,
                                                                      "synchronization/routes.json",
                                                                      routeDictionary);
                string result = webConnection.Post(httpWebRequest);
                var regex = new Regex("\"code\":100|\"code\":101", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

                if (regex.IsMatch(result)) {
                    using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                        unitOfWork.BeginTransaction();
                        foreach (var point in route.Points) {
                            point.Synchronized = true;
                            _routePointsRepository.Save(point);
                        }
                        unitOfWork.Commit();
                    }
                }
                else {
                    Log.ErrorFormat("Route with id {0} synchronizaton faled with response: {1}",
                                    route.Id, result);
                    throw new SystemException("Server rejected route");
                }
            }

            return true;
        }

        private IDictionary<string, object> RouteToDictionary(Route route) {
            var rootDictionary = new Dictionary<string, object>();
            var routeAttributesDictionary = new  Dictionary<string, object>();
            rootDictionary.Add("route", routeAttributesDictionary);
            routeAttributesDictionary.Add("date", route.Date.ToString("yyyy-MM-dd HH:mm:ss"));
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
