using System;
using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Remote.Data.Services;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class Server : IDisposable
    {
        private const string LogonPath = "users/sign_in";
        private const string LogoutPath = "users/sign_out";
        private const string UserParamName = "user";
        private const string UsernameParamName = "username";
        private const string PasswordParamName = "password";

        private readonly Uri _uri;
        private readonly string _username;
        private readonly string _password;

        private readonly CsrfTokenContainer _csrfTokenContainer;
        private readonly CookieContainer _cookieContainer;

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        protected Server(Uri uri, string username, string password)
        {
            _uri = uri;
            _username = username;
            _password = password;

            _csrfTokenContainer = new CsrfTokenContainer();
            _cookieContainer = new CookieContainer();

            _requestFactory = new RequestFactory(_uri, _cookieContainer, _csrfTokenContainer);
            _requestDispatcher = new RequestDispatcher(_cookieContainer, _csrfTokenContainer);

            _requestDispatcher.Dispatch(_requestFactory.CreateGetRequest(LogonPath));

            var logonParams = new Dictionary<string, object>
                {
                    {
                        UserParamName, new Dictionary<string, object>
                            {
                                {UsernameParamName, _username},
                                {PasswordParamName, _password}
                            }
                    }
                };
            _requestDispatcher.Dispatch(_requestFactory.CreatePostRequest(LogonPath, logonParams));
        }

        public static Server Logon(Uri uri, string username, string password)
        {
            return new Server(uri, username, password);
        }

        public UserService UserService
        {
            get { return new UserService(_requestFactory, _requestDispatcher); }
        }

        public CustomerService CustomerService
        {
            get { return new CustomerService(_requestFactory, _requestDispatcher); }
        }

        public ManagerService ManagerService
        {
            get { return new ManagerService(_requestFactory, _requestDispatcher); }
        }

        public PriceListService PriceListService
        {
            get { return new PriceListService(_requestFactory, _requestDispatcher); }
        }

        public ProductService ProductService
        {
            get { return new ProductService(_requestFactory, _requestDispatcher); }
        }

        public RouteService RouteService
        {
            get { return new RouteService(_requestFactory, _requestDispatcher); }
        }

        public StatusService StatusService
        {
            get { return new StatusService(_requestFactory, _requestDispatcher); }
        }

        public WarehouseService WarehouseService
        {
            get { return new WarehouseService(_requestFactory, _requestDispatcher); }
        }

        public UnitOfMeasureService UnitOfMeasureService
        {
            get { return new UnitOfMeasureService(_requestFactory, _requestDispatcher); }
        }

        public void Dispose()
        {
            _requestDispatcher.Dispatch(_requestFactory.CreateGetRequest(LogoutPath));
        }
    }
}
