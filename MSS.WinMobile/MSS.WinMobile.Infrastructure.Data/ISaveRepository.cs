namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ISaveRepository<TM> where TM : IModel
    {
        void Save(TM model);
    }
}
