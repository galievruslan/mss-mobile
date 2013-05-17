using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using log4net;

namespace MSS.WinMobile.Infrastructure.Web.Repositories.Utilites
{
    public static class RequestDispatcher
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RequestDispatcher));

        public static HttpWebResponse Dispatch(IWebConnection connection, HttpWebRequest httpWebRequest)
        {
            try {
                return (HttpWebResponse) httpWebRequest.GetResponse();
            }
            catch (WebException webException)
            {
                Log.Error(webException);
                if (webException.Response is HttpWebResponse)
                {
                    var response = webException.Response as HttpWebResponse;
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new NeedLogonException();
                    }
                }
                throw;
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                throw;
            }
        }

        public static string ProcessResponse(IWebConnection connection,
                                             HttpWebResponse httpWebResponse) {
            string responseText = string.Empty;
            string cookie = httpWebResponse.Headers.Get(CookieContainer.RESPONSEHEADER_SESSIONCOOKIE);
            if (!string.IsNullOrEmpty(cookie)) {
                connection.CookieContainer.SetCookie(cookie);
            }

            using (Stream stream = httpWebResponse.GetResponseStream()) {
                if (stream != null) {
                    using (var reader = new StreamReader(stream, true)) {
                        var responseTextBuilder = new StringBuilder((int)httpWebResponse.ContentLength);
                        while (!reader.EndOfStream) {
                            var buffer = new char[1024];
                            reader.Read(buffer, 0, buffer.Length);

                            var cleanBuffer = buffer.Where(c => c != '\0').ToArray();

                            if (cleanBuffer.Length > 0)
                                responseTextBuilder.Append(cleanBuffer);
                        }
                        responseText = responseTextBuilder.ToString();
                    }
                }
            }

            string csrfToken = ExtractCsrfToken(responseText);
            if (!string.IsNullOrEmpty(csrfToken))
                connection.CsrfTokenContainer.SetCsrfToken(csrfToken);

            return responseText;
        }

        private static string ExtractCsrfToken(string response)
        {
            string csrfToken = string.Empty;

            var regexCsrfTag = new Regex("<meta(.+?)>");

            MatchCollection matchCollection = regexCsrfTag.Matches(response);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                Match match = matchCollection[i];
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(match.Value);
                var xmlElement = xmlDocument.DocumentElement;
                if (xmlElement != null)
                {
                    XmlAttribute xmlAttribute = xmlElement.Attributes["name"];
                    if (xmlAttribute != null && xmlAttribute.Value == "csrf-token") {
                        csrfToken = xmlElement.Attributes["content"].Value;
                    }
                }
            }

            return csrfToken;
        }
    }

    public class NeedLogonException : Exception
    {
    }
}
