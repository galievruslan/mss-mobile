using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;
using MSS.WinMobile.Infrastructure.WebRepositories.Utilites;
using log4net;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebQueryObject<T> : IQueryObject<T,IDictionary<string,object>,WebConnection> where T : IModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebQueryObject<T>));

        public IConnectionFactory<WebConnection> ConnectionFactory { get; private set; }
        public ITranslator<T> Translator { get; private set; }

        public WebQueryObject(IConnectionFactory<WebConnection> connectionFactory)
        {
            ConnectionFactory = connectionFactory;
            Translator = new WebTranslator<T>();
            _arguments = new Dictionary<string, object>();
        }

        private IQueryObject<T, IDictionary<string, object>, WebConnection> InnerQueryObject { get; set; }
        private readonly IDictionary<string, object> _arguments;

        public WebQueryObject(IQueryObject<T, IDictionary<string, object>, WebConnection> queryObject, IDictionary<string, object> arguments)
            : this(queryObject.ConnectionFactory)
        {
            InnerQueryObject = queryObject;
            _arguments = arguments;
        }

        public IDictionary<string, object> AsQuery() {
            IDictionary<string, object> arguments = _arguments;
            if (InnerQueryObject != null)
                foreach (var argument in InnerQueryObject.AsQuery()) {
                    if (!arguments.ContainsKey(argument.Key))
                        arguments.Add(argument.Key, argument.Value);
                }

            return arguments;
        }

        private T[] Execute() {
            string url;
            var attribute = (UrlAttribute) typeof (T).GetCustomAttributes(typeof (UrlAttribute), true)[0];
            if (attribute != null)
                url = attribute.Url;
            else
                throw new InvalidOperationException(string.Format("Can't retrieve from web object of type \"{0}\"",
                                                                  typeof (T)));

            HttpWebRequest webRequest = RequestFactory.CreateGetRequest(ConnectionFactory.GetConnection(), url, AsQuery());
            string json = ConnectionFactory.GetConnection().Get(webRequest);
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
