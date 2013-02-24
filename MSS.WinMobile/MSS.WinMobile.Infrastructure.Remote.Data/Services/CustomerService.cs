using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class CustomerService
    {
        private const string CustomersPath = "customers.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public CustomerService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, CustomersPath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<IEnumerable<Customer>>(json);
        }
    }
}
