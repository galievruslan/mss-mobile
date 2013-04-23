using System.Net;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebRepository<T> : ISearchRepository<T, HttpWebRequest, WebConnection> where T : IModel
    {
        private readonly string _relativeUrl;
        private readonly WebConnectionFactory _webConnectionFactory;
        private readonly ITranslator<T> _translator;

        public WebRepository(string relativeUrl, WebConnectionFactory webConnectionFactory, ITranslator<T> translator)
        {
            _relativeUrl = relativeUrl;
            _webConnectionFactory = webConnectionFactory;
            _translator = translator;
        }

        public IQueryObject<T, HttpWebRequest, WebConnection> Find()
        {
            return new WebQueryObject<T>(_relativeUrl, _webConnectionFactory, _translator);
        }
    }
}
