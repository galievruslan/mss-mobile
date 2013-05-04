using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Web.QueryObjects {
    public interface IPagedQueryObject<TModel> : IEnumerable<TModel> where TModel : IDto  {
    }
}
