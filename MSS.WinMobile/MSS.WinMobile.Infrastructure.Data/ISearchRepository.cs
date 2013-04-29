namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ISearchRepository<TModel, TQuery, TConnection, TQueryResult> where TModel : IModel
    {
        IQueryObject<TModel, TQuery, TConnection, TQueryResult> Find();
    }
}
