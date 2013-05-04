using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Storage.QueryObjects {
    public interface IPagedQueryObject<TModel> : IEnumerable<TModel> where TModel : IModel  {
    }
}
