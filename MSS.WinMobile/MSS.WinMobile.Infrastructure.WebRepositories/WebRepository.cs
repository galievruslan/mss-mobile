using System;
using System.Collections.Generic;
using System.Net;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public class WebRepository<T> : ISearchRepository<T, IDictionary<string, object>, WebConnection> where T : Dto
    {
        private readonly WebConnectionFactory _webConnectionFactory;

        public WebRepository(WebConnectionFactory webConnectionFactory) {
            _webConnectionFactory = webConnectionFactory;
        }

        public IQueryObject<T, IDictionary<string, object>, WebConnection> Find()
        {
            return new WebQueryObject<T>(_webConnectionFactory);
        }
    }
}
