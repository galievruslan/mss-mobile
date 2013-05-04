using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Json;
using MSS.WinMobile.Infrastructure.Web.QueryObjects;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;

namespace MSS.WinMobile.Infrastructure.Web.Repositories
{
    public class WebQueryObject<T> : IQueryObject<T>, IPagedQueryObject<T> where T : IDto
    {
        private readonly IWebServer _webServer;
        public WebQueryObject(IWebServer webServer) {
            _webServer = webServer;

            _arguments = new Dictionary<string, object>();
        }
        
        private readonly IDictionary<string, object> _arguments;

        private T[] Execute() {
            string url;
            var attribute = (UrlAttribute) typeof (T).GetCustomAttributes(typeof (UrlAttribute), true)[0];
            if (attribute != null)
                url = attribute.Url;
            else
                throw new InvalidOperationException(string.Format("Can't retrieve from web object of type \"{0}\"",
                                                                  typeof (T)));

            HttpWebRequest webRequest = RequestFactory.CreateGetRequest(_webServer.Connect(), url, _arguments);
            string json = _webServer.Connect().Get(webRequest);
            return JsonDeserializer.Deserialize<T[]>(json);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ObjectEnumerator<T>(Execute());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IQueryObject<T> UpdatedAfter(DateTime date) {
            if (_arguments.ContainsKey("updated_at")) {
                _arguments["updated_at"] = date.ToString("s");
            }
            else {
                _arguments.Add("updated_at", date.ToString("s"));
            }
            return this;
        }

        public IPagedQueryObject<T> Paged(int page, int pageSize) {

            if (_arguments.ContainsKey("page")) {
                _arguments["page"] = page;
            }
            else {
                _arguments.Add("page", page);
            }

            if (_arguments.ContainsKey("page_size")) {
                _arguments["page_size"] = pageSize;
            }
            else {
                _arguments.Add("page_size", pageSize);
            }
            return this;
        }
    }
}
