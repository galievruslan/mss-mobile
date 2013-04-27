using System;
using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories
{
    public static class WebQueryObjectExtensions
    {
        public static WebQueryObject<T> Paged<T>(this WebQueryObject<T> queryObject, int page, int pageSize) where T : IModel {
            return new WebQueryObject<T>(queryObject,
                                         new Dictionary<string, object> {{"page", page}, {"page_size", pageSize}});
        }

        public static WebQueryObject<T> UpdatedAfter<T>(this WebQueryObject<T> queryObject, DateTime dateUpdatedAfter) where T : IModel {
            return new WebQueryObject<T>(queryObject,
                                         new Dictionary<string, object>
                                             {
                                                 {"updated_at", dateUpdatedAfter.ToUniversalTime()}
                                             });
        }
    }
}
