using System.Net;
using MSS.WinMobile.Infrastructure.Remote.Data.Dtos;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class PriceListService
    {
        private const string PriceListsPath = "price_lists.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public PriceListService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public PriceListDto[] GetPriceLists()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, PriceListsPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<PriceListDto[]>(json);
        }
    }
}
