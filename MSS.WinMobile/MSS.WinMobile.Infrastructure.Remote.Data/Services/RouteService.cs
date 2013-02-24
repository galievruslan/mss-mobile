using System.Net;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class RouteService
    {
        private const string RoutesPath = "routes.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public RouteService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public Route GetToday()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, RoutesPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<Route>(json);
        }
    }
}
