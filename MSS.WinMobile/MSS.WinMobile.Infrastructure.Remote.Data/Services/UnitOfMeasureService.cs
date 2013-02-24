using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Remote.Data.Dtos;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class UnitOfMeasureService
    {
        private const string UnitsOfMeasuresPath = "unit_of_measures.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public UnitOfMeasureService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public UnitOfMeasureDto[] GetUnitsOfMeasures()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, UnitsOfMeasuresPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<UnitOfMeasureDto[]>(json);
        }
    }
}
