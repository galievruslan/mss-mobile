using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Remote.Data.Dtos;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class ManagerService
    {
        private const string ManagersPath = "managers.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public ManagerService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public ManagerDto[] GetManagers()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, ManagersPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<ManagerDto[]>(json);
        }
    }
}
