using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class RequestDispatcher
    {
        private readonly CookieContainer _cookieContainer;
        private readonly CsrfTokenContainer _scrfTokenContainer;

        public RequestDispatcher(CookieContainer cookieContainer, CsrfTokenContainer scrfTokenContainer)
        {
            _cookieContainer = cookieContainer;
            _scrfTokenContainer = scrfTokenContainer;
        }

        public string Dispatch(HttpWebRequest httpWebRequest)
        {
            try
            {
                var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                string cookie = httpWebResponse.Headers.Get(CookieContainer.RESPONSEHEADER_SESSIONCOOKIE);
                if (!string.IsNullOrEmpty(cookie))
                {
                    _cookieContainer.SetCookie(cookie);
                }

                string responseText = string.Empty;
                using (Stream stream = httpWebResponse.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream, true))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }
                }

                httpWebResponse.Close();
                _scrfTokenContainer.SetCsrfToken(ExtractCsrfToken(responseText));

                return responseText;
            }
            catch (WebException webException)
            {
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
        }

        // TODO search attribute by name!!!
        private string ExtractCsrfToken(string response)
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
                    XmlAttribute xmlAttribute = xmlElement.Attributes[CsrfTokenContainer.CSRF_TOKEN_VALUE_ATTRIBUTE];
                    if (xmlAttribute != null)
                    {
                        csrfToken = xmlAttribute.Value;
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
