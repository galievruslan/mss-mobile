using System.Net;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Services
{
    public class UserService
    {
        private const string ProfilePath = "profile.json";

        private readonly RequestFactory _requestFactory;
        private readonly RequestDispatcher _requestDispatcher;

        public UserService(RequestFactory requestFactory, RequestDispatcher requestDispatcher)
        {
            _requestFactory = requestFactory;
            _requestDispatcher = requestDispatcher;
        }

        public Profile GetProfile()
        {
            HttpWebRequest httpWebRequest = _requestFactory.CreateRequest(WebMethod.GET, ProfilePath);
            string json = _requestDispatcher.Dispatch(httpWebRequest);
            return Json.JsonDeserializer.Deserialize<Profile>(json);
        }
    }

    public class Profile
    {
        public int ManagerId { get; set; }
    }
}
