using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Services
{
    public class RouteTemplateService
    {
        private const string RouteTemplatesPath = "template_routes.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public RouteTemplateService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public RouteTemplateDto[] GetManagersTemplates(int managerId)
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateGetRequest(RouteTemplatesPath,
                                                                             new Dictionary<string, object>
                                                                                 {
                                                                                     {"manager_id", managerId}
                                                                                 });
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<RouteTemplateDto[]>(json);
        }
    }
}
