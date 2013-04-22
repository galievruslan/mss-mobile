namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IGetRepository<TM> where TM : IModel
    {
        TM GetById(int id);
    }
}
