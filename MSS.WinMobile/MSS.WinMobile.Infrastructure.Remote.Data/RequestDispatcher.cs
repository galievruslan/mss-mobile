using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class RequestDispatcher
    {
        private readonly string _baseUri;

        public RequestDispatcher(string address, int port)
        {
            _baseUri = string.Format(@"http://{0}:{1}/", address, port);
            _requestPool = new List<HttpWebRequest>();
        }

        private const string ContentType = "application/json; charset=utf-8";

        public string Dispatch(string uri, string method)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(_baseUri + uri);
            webRequest.Method = method;
            webRequest.ContentType = ContentType;
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var stream = webResponse.GetResponseStream();
            if (stream != null)
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

            throw new WebException(string.Format(@"Uri: {0}, Method: {1}", uri, method));
        }

        private readonly IList<HttpWebRequest> _requestPool;

        public void Dispatch(string uri, string method, string json)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(_baseUri + uri);

            webRequest.Method = method;
            webRequest.ContentType = ContentType;
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            _requestPool.Add(webRequest);
        }

        public void ExecuteRequestPool()
        {
            for (int i = 0; i < _requestPool.Count; i++)
            {
                _requestPool[i].GetResponse();
            }
        }

        public void ClearRequestPool()
        {
            _requestPool.Clear();
        }
    }
}
