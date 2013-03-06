using System.Net;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Services
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

        public UnitOfMeasureDto[] GetUnitsOfMeasures(int page, int pageSize)
        {
            var parametersBuilder = new ParametersBuilder();
            parametersBuilder.PageNumber(page).ItemsPerPage(pageSize);
            HttpWebRequest httpWebRequest = _requestFactory.CreateGetRequest(UnitsOfMeasuresPath, parametersBuilder.Build());
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<UnitOfMeasureDto[]>(json);
        }
    }
}
