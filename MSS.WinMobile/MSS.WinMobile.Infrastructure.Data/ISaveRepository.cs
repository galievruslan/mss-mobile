namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ISaveRepository<TM> where TM : IModel
    {
        TM Save(TM model);
    }
}
