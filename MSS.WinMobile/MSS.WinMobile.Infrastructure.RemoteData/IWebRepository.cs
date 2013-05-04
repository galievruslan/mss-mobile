using MSS.WinMobile.Infrastructure.Web.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Web {

    public interface IWebRepository<TModel> where TModel : IDto {
        IQueryObject<TModel> Find();
    }
}
