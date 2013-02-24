using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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

                string[] responseStrings = GetResponseStrings(httpWebResponse);
                httpWebResponse.Close();
                _scrfTokenContainer.SetCsrfToken(ExtractCsrfToken(responseStrings));

                var responseStringBuilder = new StringBuilder();
                foreach (var responseString in responseStrings)
                {
                    responseStringBuilder.Append(responseString);
                }

                return responseStringBuilder.ToString();
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

        private string[] GetResponseStrings(HttpWebResponse httpWebResponse)
        {
            var responseStrings = new List<string>();
            using (var stream = httpWebResponse.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            responseStrings.Add(reader.ReadLine());   
                        }
                    }
                }
            }
            return responseStrings.ToArray();
        }

        private string ExtractCsrfToken(IEnumerable<string> responseStrings)
        {
            string csrfToken = string.Empty;

            foreach (var responseString in responseStrings)
            {
                if (
                    responseString.IndexOf(CsrfTokenContainer.CSRF_TOKEN_TAG_NAME,
                                           StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(responseString);
                    var xmlElement = xmlDocument.DocumentElement;
                    if (xmlElement != null)
                    {
                        csrfToken = xmlElement.Attributes[CsrfTokenContainer.CSRF_TOKEN_VALUE_ATTRIBUTE].Value;
                        break;
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
