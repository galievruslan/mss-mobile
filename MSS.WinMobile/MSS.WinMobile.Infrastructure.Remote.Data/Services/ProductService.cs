using System.Net;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Services
{
    public class ProductService
    {
        private const string ProductsPath = "products.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public ProductService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public ProductDto[] GetProducts(int page, int pageSize)
        {
            var parametersBuilder = new ParametersBuilder();
            parametersBuilder.PageNumber(page).ItemsPerPage(pageSize);
            HttpWebRequest httpWebRequest = _requestFactory.CreateGetRequest(ProductsPath, parametersBuilder.Build());
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<ProductDto[]>(json);
        }
    }
}
