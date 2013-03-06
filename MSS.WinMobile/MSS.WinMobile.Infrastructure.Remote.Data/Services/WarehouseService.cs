using System.Net;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Services
{
    public class WarehouseService
    {
        private const string WarehousesPath = "warehouses.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public WarehouseService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public WarehouseDto[] GetWarehouses(int page, int pageSize)
        {
            var parametersBuilder = new ParametersBuilder();
            parametersBuilder.PageNumber(page).ItemsPerPage(pageSize);
            HttpWebRequest httpWebRequest = _requestFactory.CreateGetRequest(WarehousesPath, parametersBuilder.Build());
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<WarehouseDto[]>(json);
        }
    }
}
