namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IRepository<TM,TQ,TC> where TM : IModel
    {
        TM GetById(int id);
        IQueryObject<TM,TQ,TC> Find();

        void Save(TM model);
        void Delete(TM model);
    }
}
