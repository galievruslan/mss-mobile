using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class RequestFactory
    {
        private const string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private const string ContentType = "application/json; charset=utf-8";
        private const string CsrfTokenParamName = "authenticity_token";

        private readonly Uri _uri;
        private readonly CookieContainer _cookieContainer;
        private readonly CsrfTokenContainer _csrfTokenContainer;

        public RequestFactory(Uri uri, CookieContainer cookieContainer, CsrfTokenContainer csrfTokenContainer)
        {
            _cookieContainer = cookieContainer;
            _csrfTokenContainer = csrfTokenContainer;
            _uri = uri;
        }

        public HttpWebRequest CreateGetRequest(string path, IDictionary<string, object> parameters)
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append('?');
            foreach (var parameter in parameters)
            {
                queryStringBuilder.Append(string.Format("{0}={1}&", parameter.Key, parameter.Value));
            }

            // Remove last &
            queryStringBuilder.Remove(queryStringBuilder.Length - 1, 1);
            string queryString = Uri.EscapeUriString(queryStringBuilder.ToString());

            return CreateGetRequest(string.Concat(path, queryString));
        }

        public HttpWebRequest CreateGetRequest(string path)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(string.Concat(_uri, path));
            webRequest.Headers.Add(CookieContainer.REQUESTHEADER_SESSIONCOOKIE, _cookieContainer.Cookie);
            webRequest.Method = WebMethod.GET;
            webRequest.UserAgent = UserAgent;
            webRequest.ContentType = ContentType;
            webRequest.AllowAutoRedirect = false;
            return webRequest;
        }

        public HttpWebRequest CreatePostRequest(string path, IDictionary<string, object> parameters)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(string.Concat(_uri, path));
            webRequest.Headers.Add(CookieContainer.REQUESTHEADER_SESSIONCOOKIE, _cookieContainer.Cookie);
            webRequest.Method = WebMethod.POST;
            webRequest.UserAgent = UserAgent;
            webRequest.ContentType = ContentType;
            webRequest.AllowAutoRedirect = false;

            parameters.Add(CsrfTokenParamName, _csrfTokenContainer.CsrfToken);
            string postData = ParseParametersToJson(parameters);

            webRequest.AllowWriteStreamBuffering = true;
            Stream requestStream = webRequest.GetRequestStream();
            var encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(postData);
            if (bytes.Length > 0)
                requestStream.Write(bytes, 0, bytes.Length);
            else
                webRequest.ContentLength = 0;

            requestStream.Close();

            return webRequest;
        }

        private string ParseParametersToJson(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var postDataBuilder = new StringBuilder();
            postDataBuilder.Append('{');
            foreach (var parameter in parameters)
            {
                if (postDataBuilder.Length > 1)
                    postDataBuilder.Append(',');

                if (parameter.Value is IDictionary<string, object>)
                    postDataBuilder.Append(string.Format("\"{0}\" : {1}", parameter.Key,
                                                         ParseParametersToJson(
                                                             parameter.Value as IDictionary<string, object>)));
                else
                    postDataBuilder.Append(string.Format("\"{0}\" : \"{1}\"", parameter.Key, parameter.Value));
            }
            postDataBuilder.Append('}');
            return postDataBuilder.ToString();
        }
    }

    static class WebMethod
    {
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";
    }
}
