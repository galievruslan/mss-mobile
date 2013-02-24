using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class PriceListService
    {
        private const string PriceListsPath = "pricelists.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public PriceListService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public IEnumerable<PriceList> GetPriceLists()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, PriceListsPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<IEnumerable<PriceList>>(json);
        }
    }
}
