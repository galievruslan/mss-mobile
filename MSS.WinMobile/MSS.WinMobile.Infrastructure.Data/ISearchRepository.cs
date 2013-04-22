namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ISearchRepository<TM, TQ, TC> where TM : IModel
    {
        IQueryObject<TM, TQ, TC> Find();
    }
}
