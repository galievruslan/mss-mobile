using System.Collections;
using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.WebRepositories.Utilites;
using log4net;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebQueryObject<T> : IQueryObject<T,HttpWebRequest,WebConnection> where T : IModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebQueryObject<T>));

        private readonly string _relativeUrl;
        public IConnectionFactory<WebConnection> ConnectionFactory { get; private set; }
        public ITranslator<T> Translator { get; private set; }

        public WebQueryObject(string relativeUrl, IConnectionFactory<WebConnection> connectionFactory)
        {
            _relativeUrl = relativeUrl;
            ConnectionFactory = connectionFactory;
            Translator = new WebTranslator<T>();
        }

        public IQueryObject<T,HttpWebRequest,WebConnection> InnerQueryObject { get; protected set; }

        protected WebQueryObject(IQueryObject<T, HttpWebRequest, WebConnection> queryObject)
            : this(string.Empty, queryObject.ConnectionFactory)
        {
            InnerQueryObject = queryObject;
        }

        public HttpWebRequest AsQuery()
        {
            return RequestFactory.CreateGetRequest(ConnectionFactory.GetConnection(), _relativeUrl);
        }

        protected virtual T[] Execute()
        {
            string json = ConnectionFactory.GetConnection().Get(AsQuery());
            return Translator.Translate<T[]>(json);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ObjectEnumerator<T>(Execute());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
