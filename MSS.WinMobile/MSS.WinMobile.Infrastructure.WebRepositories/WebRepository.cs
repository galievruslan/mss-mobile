using System;
using System.Net;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebRepository<T> : ISearchRepository<T, HttpWebRequest, WebConnection> where T : Dto
    {
        private readonly string _relativeUrl;
        private readonly WebConnectionFactory _webConnectionFactory;

        public WebRepository(WebConnectionFactory webConnectionFactory) {
            var attribute = (UrlAttribute)typeof (T).GetCustomAttributes(typeof (UrlAttribute), true)[0];
            if (attribute != null)
                _relativeUrl = attribute.Url;
            else {
                throw new InvalidOperationException(string.Format("Can't retrieve from web object of type \"{0}\"", typeof(T)));
            }

            _webConnectionFactory = webConnectionFactory;
        }

        public IQueryObject<T, HttpWebRequest, WebConnection> Find()
        {
            return new WebQueryObject<T>(_relativeUrl, _webConnectionFactory);
        }
    }
}
