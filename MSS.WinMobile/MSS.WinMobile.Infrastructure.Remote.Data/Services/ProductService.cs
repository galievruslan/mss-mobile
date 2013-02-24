using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
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

        public IEnumerable<Product> GetProducts()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, ProductsPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<IEnumerable<Product>>(json);
        }
    }
}
