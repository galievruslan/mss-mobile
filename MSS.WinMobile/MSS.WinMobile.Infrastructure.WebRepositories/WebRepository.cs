using MSS.WinMobile.Infrastructure.Web.QueryObjects;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Web.Repositories
{
    public class WebRepository<T> : IWebRepository<T> where T : Dto {
        private readonly IWebServer _webServer;

        public WebRepository(IWebServer webServer) {
            _webServer = webServer;
        }

        public IQueryObject<T> Find()
        {
            return new WebQueryObject<T>(_webServer);
        }
    }
}
