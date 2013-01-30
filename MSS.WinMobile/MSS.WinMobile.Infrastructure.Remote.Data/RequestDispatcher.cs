using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class RequestDispatcher
    {
        private const string RequestheaderSessioncookie = "Cookie";
        private const string ResponseheaderSessioncookie = "Set-Cookie";

        private readonly Session _session;

        public RequestDispatcher(Session session)
        {
            _session = session;
            _requestPool = new List<HttpWebRequest>();
        }

        public string Dispatch(string uri, string method)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(_session.BaseUri + uri);
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            webRequest.Method = method;
            webRequest.ContentType = Session.CONTENT_TYPE;
            webRequest.AllowAutoRedirect = false;
            if (!string.IsNullOrEmpty(_session.Cookie))
            {
                webRequest.Headers.Add(RequestheaderSessioncookie, _session.Cookie);
            }
            HttpWebResponse webResponse = null;
            try
            {
                webResponse = (HttpWebResponse) webRequest.GetResponse();
                if (webResponse.Headers.Get(ResponseheaderSessioncookie) != null)
                {
                    _session.Cookie = webResponse.Headers.Get(ResponseheaderSessioncookie);
                }
            }
            catch (WebException webException)
            {
                if (webException.Response is HttpWebResponse)
                {
                    var response = webException.Response as HttpWebResponse;
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (Login())
                            return Dispatch(uri, method);
                    }
                }

            }
            if (webResponse != null)
            {
                var stream = webResponse.GetResponseStream();
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }

                webResponse.Close();
            }

            throw new WebException(string.Format(@"Uri: {0}, Method: {1}", uri, method));
        }

        private readonly IList<HttpWebRequest> _requestPool;

        public void Dispatch(string uri, string method, string json)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(_session.BaseUri + uri);

            webRequest.Method = method;
            webRequest.ContentType = Session.CONTENT_TYPE;
            webRequest.KeepAlive = true;
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
                if (!string.IsNullOrEmpty(_session.Cookie))
                {
                    _requestPool[i].Headers.Add(RequestheaderSessioncookie, _session.Cookie);
                }
                var webResponse = (HttpWebResponse)_requestPool[i].GetResponse();
                if (webResponse.Headers.Get(ResponseheaderSessioncookie) != null)
                {
                    _session.Cookie = webResponse.Headers.Get(ResponseheaderSessioncookie);
                }
            }
        }

        public void ClearRequestPool()
        {
            _requestPool.Clear();
        }

        public bool Login()
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(_session.BaseUri + "users/sign_in");
                if (!string.IsNullOrEmpty(_session.Cookie))
                {
                    webRequest.Headers.Add(RequestheaderSessioncookie, _session.Cookie);
                }
                webRequest.Method = "GET";
                webRequest.ContentType = Session.CONTENT_TYPE;
                webRequest.AllowAutoRedirect = false;
                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                if (webResponse.Headers.Get(ResponseheaderSessioncookie) != null)
                {
                    _session.Cookie = webResponse.Headers.Get(ResponseheaderSessioncookie);
                }
                
                _session.CsrfToken = GetCsrfToken(webResponse);
                webResponse.Close();
                string queryString = "?authenticity_token=" + Uri.EscapeDataString(_session.CsrfToken) +
                                     "&user[username]=" + _session.Username +
                                     "&user[password]=" + _session.Password;

                webRequest = (HttpWebRequest) WebRequest.Create(_session.BaseUri + "users/sign_in" + queryString);
                if (!string.IsNullOrEmpty(_session.Cookie))
                {
                    webRequest.Headers.Add(RequestheaderSessioncookie, _session.Cookie);
                }
                webRequest.AllowWriteStreamBuffering = true;
                //webRequest.ConnectionGroupName = "mygroup";
                webRequest.ContentLength = 0;
                webRequest.AllowAutoRedirect = false;
                webRequest.KeepAlive = true;
                webRequest.Method = "POST";
                //webRequest.ContentType = Session.CONTENT_TYPE;
                Stream requestStream = webRequest.GetRequestStream();
                requestStream.Close();

                webResponse = (HttpWebResponse) webRequest.GetResponse();
                if (webResponse.Headers.Get(ResponseheaderSessioncookie) != null)
                {
                    _session.Cookie = webResponse.Headers.Get(ResponseheaderSessioncookie);
                }
                webResponse.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GetCsrfToken(HttpWebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (!string.IsNullOrEmpty(line) &&
                                line.IndexOf("csrf-token", StringComparison.InvariantCultureIgnoreCase) >= 0)
                            {
                                var xmlDocument = new XmlDocument();
                                xmlDocument.LoadXml(line);
                                var xmlElement = xmlDocument.DocumentElement;
                                if (xmlElement != null)
                                {
                                    return xmlElement.Attributes["content"].Value;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
