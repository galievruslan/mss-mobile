using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Web.Repositories.Utilites
{
    public static class RequestFactory
    {
        public static HttpWebRequest CreateGetRequest(IWebConnection connection, string path, IDictionary<string, object> parameters)
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

            return CreateGetRequest(connection, string.Concat(path, queryString));
        }

        public static HttpWebRequest CreateGetRequest(IWebConnection connection, string path)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}//{1}", connection.Address, path));
            webRequest.Headers.Add(CookieContainer.REQUESTHEADER_SESSIONCOOKIE, connection.CookieContainer.Cookie);
            webRequest.Method = WebMethod.GET;
            webRequest.UserAgent = WebConnection.USER_AGENT;
            webRequest.ContentType = WebConnection.CONTENT_TYPE;
            webRequest.AllowAutoRedirect = false;
            return webRequest;
        }

        public static HttpWebRequest CreatePostRequest(IWebConnection connection, string path, IDictionary<string, object> parameters)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}//{1}", connection.Address, path));
            webRequest.Headers.Add(CookieContainer.REQUESTHEADER_SESSIONCOOKIE, connection.CookieContainer.Cookie);
            webRequest.Method = WebMethod.POST;
            webRequest.UserAgent = WebConnection.USER_AGENT;
            webRequest.ContentType = WebConnection.CONTENT_TYPE;
            webRequest.AllowAutoRedirect = false;

            parameters.Add(WebConnection.CSRF_TOKEN_PARAM_NAME, connection.CsrfTokenContainer.CsrfToken);
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

        private static string ParseParametersToJson(IEnumerable<KeyValuePair<string, object>> parameters)
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
