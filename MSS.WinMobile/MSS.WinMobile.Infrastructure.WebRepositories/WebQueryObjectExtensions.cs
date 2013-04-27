using System;
using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public static class WebQueryObjectExtensions
    {
        public static IQueryObject<T, IDictionary<string, object>, WebConnection> Paged<T>(this IQueryObject<T, IDictionary<string, object>, WebConnection> queryObject, int page, int pageSize) where T : IModel
        {
            return new WebQueryObject<T>(queryObject,
                                         new Dictionary<string, object> {{"page", page}, {"page_size", pageSize}});
        }

        public static IQueryObject<T, IDictionary<string, object>, WebConnection> UpdatedAfter<T>(this IQueryObject<T, IDictionary<string, object>, WebConnection> queryObject, DateTime dateUpdatedAfter) where T : IModel
        {
            return new WebQueryObject<T>(queryObject,
                                         new Dictionary<string, object>
                                             {
                                                 {"updated_at", dateUpdatedAfter.ToString("s")}
                                             });
        }
    }
}
