using System.Net;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebRepository<T> : ISearchRepository<T, HttpWebRequest, WebConnection> where T : Dto
    {
        private readonly string _relativeUrl;
        private readonly WebConnectionFactory _webConnectionFactory;

        public WebRepository(string relativeUrl, WebConnectionFactory webConnectionFactory)
        {
            _relativeUrl = relativeUrl;
            _webConnectionFactory = webConnectionFactory;
        }

        public IQueryObject<T, HttpWebRequest, WebConnection> Find()
        {
            return new WebQueryObject<T>(_relativeUrl, _webConnectionFactory);
        }
    }
}
